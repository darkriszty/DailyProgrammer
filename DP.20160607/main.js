var t = require("./transposer");

var transposer = new t.Transposer("input.txt"),
    input = transposer.getInput(),
    matrix = transposer.createMatrix(input),
    transposed = transposer.transpose(matrix);

transposer.writeMatrix(transposed);
