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
        # naive line drawing algorithm
        dx = dy = x1 = x2 = y1 = y2 = 0
        if (self.p2.x > self.p1.x):
            x1 = self.p1.x
            y1 = self.p1.y
            x2 = self.p2.x
            y2 = self.p2.y
        else:
            x1 = self.p2.x
            y1 = self.p2.y
            x2 = self.p1.x
            y2 = self.p1.y

        dx = x2 - x1
        dy = y2 - y1

        x = x1
        while x < x2:
            y = y1 + dy * (x - x1) / dx
            board.drawPixel(self.getColor(), Point2D(int(x), int(y)))
            x += 1

    def _colorUpdated(self):
        pass

class Rect(Shape):
    """represents a rectangle"""

    _topLeft = Point2D()
    _widthAndHeight = Point2D()
    # contains the lines: top, right, bottom, left
    _lines = []

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
        self._lines = []
        
        # top line
        line0 = Line()
        line0.p1 = Point2D(self._topLeft.x, self._topLeft.y)
        line0.p2 = Point2D(line0.p1.x + self._widthAndHeight.x - 1, line0.p1.y)
        self._lines.append(line0)

        # right side line
        line1 = Line()
        line1.p1 = Point2D(line0.p2.x, line0.p2.y)
        line1.p2 = Point2D(line1.p1.x, line1.p1.y + self._widthAndHeight.y - 1)
        self._lines.append(line1)

        # bottom line
        line2 = Line()
        line2.p1 = Point2D(line1.p2.x, line1.p2.y)
        line2.p2 = Point2D(line2.p1.x, line2.p1.y)
        self._lines.append(line2)

        # left side line
        line3 = Line()
        line3.p1 = Point2D(line2.p2.x, line2.p2.y)
        line3.p2 = Point2D(line0.p1.x, line0.p1.y)
        self._lines.append(line3)

    def draw(self, board):
        for line in self._lines:
            line.draw(board)

        # fill the rectangle
        x = self._lines[0].p1.x
        while x <= self._lines[1].p1.x:
            y = self._lines[0].p1.y
            while y <= self._lines[1].p2.y:
                board.drawPixel(self.getColor(), Point2D(x, y))
                y += 1
            x += 1

class Board(object):
    """represents a board that can be used for drawing"""

    _width = 0
    _height = 0
    _pixels = []
    _maxColor = 0

    def __init__(self, width, height):
        self._width = width
        self._height = height
        for i in range(0, width):
            new = []
            for j in range(0, height):
                new.append(RgbColor())
            self._pixels.append(new)

    def drawPixel(self, color, pos):
        if color.r > self._maxColor: self._maxColor = color.r
        if color.g > self._maxColor: self._maxColor = color.g
        if color.b > self._maxColor: self._maxColor = color.b
        self._pixels[pos.y][pos.x] = color

    def showBoard(self):
        result = "P3\n{0} {1}\n{2}\n".format(self._width, self._height, self._maxColor)
        for i in range(0, self._height):
            for j in range(0, self._width):
                result += self._pixels[j][i].toString() + "\t"
            result += "\n"
        return result
