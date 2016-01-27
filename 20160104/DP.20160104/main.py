import Shapes
import ShapeFactory
from Shapes import *
from ShapeFactory import *

def main():
    factory = ShapeFactory()
    shapes = []

    # read from input file
    lines = getFileContents()

    board = factory.createBoard(lines[0])

    for line in lines:
        newShape = factory.createShape(line)
        if newShape is not None:
            shapes.append(newShape)

    for shape in shapes:
        shape.draw(board)

    board.showBoard()


def getFileContents():
    lines = []
    f = open("input.txt", "r")
    for line in f :
        l = line.strip()
        if l.startswith("#"):
            continue
        lines.append(line.rstrip("\n"))
    f.close()

    return lines


main()