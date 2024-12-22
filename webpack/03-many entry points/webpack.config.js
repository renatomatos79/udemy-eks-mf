const path = require('path');

module.exports = {
  entry: {
    math: {
      import: './src/lib/math.js'
    },
    main: {
      import: './src/index.js',
      dependOn: 'math',
    },
  },
  mode: 'development',
  target: 'node',
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: '[name].bundle.js'
  }
}