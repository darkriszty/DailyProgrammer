import Shapes
import ShapeFactory
from Shapes import *
from ShapeFactory import *

def main():
    factory = ShapeFactory()
    shapes = []

    # read from input file
    lines = getFileContents()

    # create the board that is used for drawing
    board = factory.createBoard(lines[0])

    # create the shapes from the file
    for line in lines:
        newShape = factory.createShape(line)
        if newShape is not None:
            shapes.append(newShape)

    # draw each shape on the board
    for shape in shapes:
        shape.draw(board)

    # get the painted result from the board and write the it into an output file
    result = board.showBoard()
    f = open("output.txt", "w")
    f.write(result)
    f.close()


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