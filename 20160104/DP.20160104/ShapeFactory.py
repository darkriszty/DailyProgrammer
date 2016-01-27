import Shapes
from Shapes import *

class ShapeFactory(object):
    """responsible to create shapes"""

    _point = "point"
    _line = "line"
    _rect = "rect"

    def createBoard(self, boardLine):
        pieces = boardLine.split(" ")
        return Board(int(pieces[0]), int(pieces[1]))

    def createShape(self, definition):
        pieces = definition.split(" ")

        if pieces[0] == self._point:
            return self._createPoint(pieces)
        if pieces[0] == self._line:
            return self._createLine(pieces)
        if pieces[0] == self._rect:
            return self._createRect(pieces)
        return None

    def _createPoint(self, pointPieces):
        result = Point()
        result.setColor(self._getColor(pointPieces))
        result.pos = self._getPoint(pointPieces, 4)
        return result

    def _createLine(self, pointPieces):
        result = Line()
        result.setColor(self._getColor(pointPieces))
        result.p1 = self._getPoint(pointPieces, 4)
        result.p2 = self._getPoint(pointPieces, 6)
        return result

    def _createRect(self, pointPieces):
        result = Rect()
        result.setColor(self._getColor(pointPieces))
        result.setTopLeft(self._getPoint(pointPieces, 4))
        result.setWidthAndHeight(self._getPoint(pointPieces, 6))
        return result

    def _getColor(self, pointPieces):
        result = RgbColor()
        result.r = int(pointPieces[1])
        result.g = int(pointPieces[2])
        result.b = int(pointPieces[3])
        return result

    def _getPoint(self, pointPieces, index):
        result = Point2D()
        result.x = int(pointPieces[index])
        result.y = int(pointPieces[index + 1])
        return result
