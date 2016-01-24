﻿import Shapes
import ShapeFactory
from Shapes import *
from ShapeFactory import *

def main():
    factory = ShapeFactory()
    shapes = []

    # read from input file
    lines = getFileContents()
    for line in lines:
        newShape = factory.createShape(line)
        if newShape is not None:
            shapes.append(newShape)

    for shape in shapes:
        shape.draw()


def getFileContents():
    lines = []
    f = open("input.txt", "r")
    for line in f :
        lines.append(line.rstrip("\n"))
    f.close()

    return lines


main()