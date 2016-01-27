from abc import ABCMeta, abstractmethod

class RgbColor(object):
    """encapsulates the properties of an rgb color"""
    r = 0
    g = 0
    b = 0

    def toString(self):
        return "{0} {1} {2}".format(self.r, self.g, self.b)

class Shape(metaclass=ABCMeta):
    """represents a base class for other shapes that have a color"""

    _color = RgbColor()

    def setColor(self, color):
        self._color = color
        self._colorUpdated()

    def getColor(self):
        return self._color

    @abstractmethod
    def draw(self, board):
        pass

    @abstractmethod
    def _colorUpdated(self):
        pass

class Point2D(object):
    """represents a point in 2D"""
    x = 0
    y = 0

    def __init__(self, x = 0, y = 0):
        self.x = x
        self.y = y

    def toString(self):
        return "({0}, {1})".format(self.x, self.y)

class Point(Shape):
    """represents a point"""

    pos = Point2D()

    def draw(self, board):
        board.drawPixel(self.getColor(), self.pos)

    def _colorUpdated(self):
        pass

class Line(Shape):
    """represents a line"""

    p1 = Point2D()
    p2 = Point2D()

    def draw(self, board):
        # Bresenham algorithm
        dx = self.p2.x-self.p1.x
        dy = self.p2.y-self.p1.y
        D = 2*dy - dx
        board.drawPixel(self.getColor(), self.p1)
        y = self.p1.y
        if D > 0:
            y = y+1
            D = D - (2*dx)
        x = self.p1.x + 1
        while x < self.p2.x:
            board.drawPixel(self.getColor(), Point2D(x, y))
            D = D + (2*dy)
            if D > 0:
                y = y+1
                D = D - (2*dx)
            x += 1

    def _colorUpdated(self):
        pass

class Rect(Shape):
    """represents a rectangle"""

    _topLeft = Point2D()
    _widthAndHeight = Point2D()
    # from top clockwise to left
    _lines = [ Line(), Line(), Line(), Line() ]

    def setTopLeft(self, topLeft):
        self._topLeft = topLeft
        self._updateLines()

    def setWidthAndHeight(self, widthAndHeight):
        self._widthAndHeight = widthAndHeight
        self._updateLines()

    def _colorUpdated(self):
        for line in self._lines:
            line.setColor(self.getColor())

    def _updateLines(self):
        # top line
        self._lines[0].p1 = Point2D(self._topLeft.x, self._topLeft.y)
        self._lines[0].p2 = Point2D(self._lines[0].p1.x + self._widthAndHeight.x, self._lines[0].p1.y)

        # right side line
        self._lines[1].p1 = Point2D(self._lines[0].p2.x, self._lines[0].p2.y)
        self._lines[1].p2 = Point2D(self._lines[1].p1.x, self._lines[1].p1.y + self._widthAndHeight.y)

        # bottom line
        self._lines[2].p1 = Point2D(self._lines[1].p2.x, self._lines[1].p2.y)
        self._lines[2].p2 = Point2D(self._lines[0].p1.x, self._lines[2].p1.y)

        # left side line
        self._lines[3].p1 = Point2D(self._lines[2].p2.x, self._lines[2].p2.y)
        self._lines[3].p2 = Point2D(self._lines[0].p1.x, self._lines[0].p1.y)

    def draw(self, board):
        for line in self._lines:
            line.draw(board)

class Board(object):
    """represents a board that can be used for drawing"""

    _width = 0
    _height = 0
    _pixels = []

    def __init__(self, width, height):
        self._width = width
        self._height = height
        for i in range(0, width):
            new = []
            for j in range(0, height):
                new.append(RgbColor())
            self._pixels.append(new)

    def drawPixel(self, color, pos):
        print("drawing into ({0},{1})".format(pos.y, pos.x))
        self._pixels[pos.y][pos.x] = color

    def showBoard(self):
        for i in range(0, self._width):
            for j in range(0, self._height):
                print(self._pixels[i][j].toString());
            print("");
