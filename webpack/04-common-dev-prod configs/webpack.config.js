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
  },
  optimization: {
    splitChunks: {
      chunks: 'all', // Ensures splitting applies to both dynamically imported and statically imported modules.
      cacheGroups: {
        mathjs: {
          test: /[\\/]node_modules[\\/]mathjs[\\/]/,
          name: 'mathjs', // Name of the vendor chunk ()
          chunks: 'all', // Include all types of chunks
        },
        vendors: {
          test: /[\\/]node_modules[\\/]/, // any other vendor library
          name: 'vendors', // Name of the vendor chunk
          chunks: 'all', // Include all types of chunks
        },
      },
    },
  },
}