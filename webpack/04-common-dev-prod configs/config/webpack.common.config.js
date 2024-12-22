const path = require('path');

const config = {
  entry: {
    math: {
      import: './src/lib/math.js'
    },
    main: {
      import: './src/index.js',
      dependOn: 'math',
    },
  },
  target: 'node',
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js'
  }  
}

module.exports = config