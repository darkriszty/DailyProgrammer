fs = require("fs");

function Transposer( fileName ) {
	this._fileName = fileName;
};

Transposer.prototype.transpose = function ( matrix ) {
	var me = this,
	    i, j,
	    rowLen = matrix.length,
	    colLen = matrix[0].length,
	    result = new Array(colLen);
	
	for (i = 0; i < colLen; i++) {
		result[i] = new Array(rowLen);
		for (j = 0; j < rowLen; j++) {
			result[i][j] = matrix[j][i];
		}
	}

	return result;
}

Transposer.prototype.getInput = function ( ) {
	var me = this,
	    fileContent = fs.readFileSync(me._fileName, "utf8");

	return fileContent;
}

Transposer.prototype.createMatrix = function ( multiLineText ) {
	var lines = multiLineText.replace(/\n+$/, "").split("\n"),
	    i, j, 
	    lineLength, 
	    maxLineLength = 0,
	    currentLine,
	    totalLines = lines.length,
	    matrix;
	
	// find the longest line length
	for (i = 0; i < totalLines; i++) {
		currentLine = lines[i];
		if (currentLine.length > maxLineLength)
			maxLineLength = currentLine.length;
	}

	// create the matrix where each line has the same length
	matrix = new Array(totalLines);
	for (i = 0; i < totalLines; i++) {
		currentLine = lines[i];
		matrix[i] = new Array(maxLineLength);
		for (j = 0; j < maxLineLength; j++) {
			// if we still have characters on this line then use them, otherwise use spaces to fill up matrix
			matrix[i][j] = j < currentLine.length
				? currentLine[j]
				: ' ';
		}
	}

	return matrix;
}

Transposer.prototype.writeMatrix = function ( matrix ) {
	var me = this,
	    i, j,
	    rowLen = matrix.length,
	    colLen = matrix[0].length;

	for (i = 0; i < rowLen; i++) {
		for (j = 0; j < colLen; j++) {
			process.stdout.write(matrix[i][j]);
		}
		console.log();
	}
}

exports.Transposer = Transposer;
