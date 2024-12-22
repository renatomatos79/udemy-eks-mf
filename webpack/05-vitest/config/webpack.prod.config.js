const common = require('./webpack.common.config');
const { merge } = require('webpack-merge');

module.exports = merge(common, {
  mode: 'production',
  optimization: {
    splitChunks: {
      chunks: 'all', // Ensures splitting applies to both dynamically imported and statically imported modules.
      cacheGroups: {
        vendors: {
          test: /[\\/]node_modules[\\/]/, // any other vendor library
          name: 'vendors', // Name of the vendor chunk
          chunks: 'all', // Include all types of chunks
        },
      },
    },
  },
})