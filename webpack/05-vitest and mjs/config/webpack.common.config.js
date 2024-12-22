const path = require('path');

const config = {
  entry: {
    isCPF: './src/lib/isCPF/index.mjs',
    isCNPJ: './src/lib/isCNPJ/index.mjs',
    index: {
      dependOn: ['isCPF', 'isCNPJ'],
      import: './src/lib/index.mjs',
    },
  },
  target: 'node',
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js',
    clean: true
  }
}

module.exports = config