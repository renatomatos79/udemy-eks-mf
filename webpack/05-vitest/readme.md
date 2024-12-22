# install dependencies
```sh
npm install --save-dev webpack-merge@6.0.1
```

# let's create a config folder 
# create webpack.common.config.js
```sh
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
```

# create webpack.dev.config.js
```sh
const common = require('./webpack.common.config');
const { merge } = require('webpack-merge');

module.exports = merge(common, {
  mode: 'development'
})
```

# create webpack.prod.config.js
```sh
const common = require('./webpack.common.config');
const { merge } = require('webpack-merge');

module.exports = merge(common, {
  mode: 'production',
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
})
```

# adjust package.json scripts
```sh
"scripts": {
    "build-dev": "webpack --config config/webpack.dev.config.js",
    "build-prod": "webpack --config config/webpack.prod.config.js",
    "start": "npm run build-dev && node dist/main.bundle.js"
  },
```  