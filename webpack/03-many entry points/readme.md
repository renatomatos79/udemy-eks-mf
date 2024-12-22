# install dependencies
```sh
npm i
```

# update webpack.config.js, also setting target to be node 
# => Does not include browser-specific globals like window or self
```sh
const path = require('path');

module.exports = {
  entry: {
    math: {
      import: './src/math.js'
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
```

# run "npm run start"
```sh
asset math.bundle.js 5.44 KiB [compared for emit] (name: math)
asset main.bundle.js 1.31 KiB [compared for emit] (name: main)
runtime modules 1.88 KiB 5 modules
cacheable modules 161 bytes
  ./src/index.js 90 bytes [built] [code generated]
  ./src/lib/math.js 71 bytes [built] [code generated]
webpack 5.97.1 compiled successfully in 96 ms
sum(1, 2) is  3
```