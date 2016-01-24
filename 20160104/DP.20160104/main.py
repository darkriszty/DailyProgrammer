import Shapes
from Shapes import *

def main():
    # read from input file
    lines = getFileContents()
    for line in lines:
        print(line)

    # test abstract method
    Point().draw()
    Line().draw()
    Rect().draw()

def getFileContents():
    lines = []
    f = open("input.txt", "r")
    for line in f :
        lines.append(line.rstrip("\n"))
    f.close()

    return lines


main()