# install dependencies
```sh
npm i
```

# create a webpack.config.js
```sh
const path = require('path');

module.exports = {
  entry: './src/index.js',
  mode: 'production',
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'bundle.js'
  }
}
```

# update our build script and run "npm run build"
```sh
"main": "src/index.js",
"scripts": {
  "build": "webpack"
}
```

# check output content on dist folder
```sh
=> npm run build
asset bundle.js 44 bytes [emitted] [minimized] (name: main)
./src/index.js 45 bytes [built] [code generated]
webpack 5.97.1 compiled successfully in 309 ms
```

# into scr folder, create folder named "lib" and then add a "math.js" file
```sh
function sum(a, b) {
  return a+b
}

module.exports = {
  sum
}; 
```

# update index.js file content
```sh
const math = require('./lib/math.js');
console.log('sum(1, 2) is ', math.sum(1, 2)); 
```

# run using "npm run src/index.js"
```sh
npm run src/index.js
sum(1, 2) is  3
```

# let's add one more script for package.json
# npm run start
```sh
"start": "npm run build && node dist/bundle.js"


output content fpr "npm run start":
> 01-blank-project@1.0.0 start
> npm run build && node dist/bundle.js


> 01-blank-project@1.0.0 build
> webpack

asset bundle.js 2.6 KiB [compared for emit] (name: main)
./src/index.js 90 bytes [built] [code generated]
./src/lib/math.js 71 bytes [built] [code generated]
webpack 5.97.1 compiled successfully in 100 ms
sum(1, 2) is  3
```

# can I set "module.exports = sum" ?
```sh
function sum(a, b) {
  return a+b
}

module.exports = sum;
```

