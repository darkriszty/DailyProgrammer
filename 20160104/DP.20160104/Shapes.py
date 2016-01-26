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

    color = RgbColor()

    @abstractmethod
    def draw(self, board):
        pass

class Point2D(object):
    """represents a point in 2D"""
    x = 0
    y = 0

    def toString(self):
        return "({0}, {1})".format(self.x, self.y)

class Point(Shape):
    """represents a point"""

    pos = Point2D()

    def draw(self, board):
        board.drawPixel(self.color, self.pos)

class Line(Shape):
    """represents a line"""

    p1 = Point2D()
    p2 = Point2D()

    def draw(self, board):
        #TODO: draw actual line
        board.drawPixel(self.color, self.p1)
        board.drawPixel(self.color, self.p2)

class Rect(Shape):
    """represents a rectangle"""

    # from top left clockwise to bottom left
    _p1 = Point2D()
    _p2 = Point2D()
    _p3 = Point2D()
    _p4 = Point2D()

    def setTopLeft(self, pos):
        self._p1 = pos
        self._updatePoints()

    def setBottomRight(self, pos):
        self._p3 = pos
        self._updatePoints()

    def _updatePoints(self):
       self._p2.x = self._p1.x;
       self._p2.y = self._p3.y;
       self._p4.x = self._p3.x;
       self._p4.y = self._p1.y;

    def draw(self, board):
        #TODO: draw actual rectangle
        board.drawPixel(self.color, self._p1)
        board.drawPixel(self.color, self._p2)
        board.drawPixel(self.color, self._p3)
        board.drawPixel(self.color, self._p4)

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
        self._pixels[pos.x][pos.y] = color

    def showBoard(self):
        for i in range(0, self._width):
            for j in range(0, self._height):
                print(self._pixels[i][j].toString());
            print("");
