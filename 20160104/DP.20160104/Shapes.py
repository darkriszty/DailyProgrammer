﻿from abc import ABCMeta, abstractmethod

class RgbColor(object):
    """encapsulates the properties of an rgb color"""
    r = 0
    g = 0
    b = 0

    def toString(self):
        return "RGB({0}, {1}, {2})".format(self.r, self.g, self.b)

class Shape(metaclass=ABCMeta):
    """represents a base class for other shapes that have a color"""

    color = RgbColor()

    @abstractmethod
    def draw(self):
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

    def draw(self):
        print("drawing point of color {0} at {1}".format(self.color.toString(), self.pos.toString()))

class Line(Shape):
    """represents a line"""

    p1 = Point2D()
    p2 = Point2D()

    def draw(self):
        print("drawing line of color {0} at {1} -> {2}".format(self.color.toString(), self.p1.toString(), self.p2.toString()))

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

    def draw(self):
        print("drawing rectangle of color {0} to {1} -> {2} -> {3} -> {4}".format(self.color.toString(), self._p1.toString(), self._p2.toString(), self._p3.toString(), self._p4.toString()))