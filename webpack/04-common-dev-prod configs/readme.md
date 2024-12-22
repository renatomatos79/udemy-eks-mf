# install dependencies
```sh
npm i
```

# update webpack.config.js, also setting target to be node 
# => Does not include browser-specific globals like window or self
# https://webpack.js.org/configuration/target/
```sh
const path = require('path');

module.exports = {
  entry: {
    math: {
      import: './src/math.js'
    },
    main: {
      import: './src/index.js',
      dependOn: 'math'
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

# update package.json start script
```sh
"start": "npm run build && node dist/main.bundle.js"
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

# installing mathjs lib and splitting vendor dependencies
# https://mathjs.org/examples/expressions.js.html
```sh
npm i mathjs
```

# update matj.js file:
```sh
const mathjs = require('mathjs');

function sum(a, b) {
  return a+b
}

function evalExpresion(expresion) {
  return mathjs.evaluate(expresion)
}

module.exports = {
  sum, evalExpresion
}; 
```

# update index.js file:
```sh
const math = require('./lib/math.js');

console.log('sum(1 2): ', math.sum(1, 2)); 
console.log('evalExpresion("sqrt(3^2 + 4^2")): ', math.evalExpresion('sqrt(3^2 + 4^2)')); 
```

# npm run start
```sh
asset math.bundle.js 3.64 MiB [compared for emit] (name: math)
asset main.bundle.js 1.4 KiB [emitted] (name: main)
runtime modules 2.69 KiB 10 modules
modules by path ./node_modules/mathjs/lib/cjs/ 2.4 MiB 1007 modules
modules by path ./node_modules/seedrandom/ 26.5 KiB
  modules by path ./node_modules/seedrandom/lib/*.js 16 KiB 6 modules
  modules by path ./node_modules/seedrandom/*.js 10.5 KiB 2 modules
modules by path ./node_modules/@babel/runtime/helpers/*.js 2.37 KiB
  ./node_modules/@babel/runtime/helpers/interopRequireDefault.js 214 bytes [built] [code generated]
  ./node_modules/@babel/runtime/helpers/extends.js 504 bytes [built] [code generated]
  ./node_modules/@babel/runtime/helpers/defineProperty.js 362 bytes [built] [code generated]
  + 3 modules
modules by path ./src/ 381 bytes
  ./src/index.js 179 bytes [built] [code generated]
  ./src/lib/math.js 202 bytes [built] [code generated]
+ 8 modules
webpack 5.97.1 compiled successfully in 2162 ms
sum(1 2):  3
evalExpresion("sqrt(3^2 + 4^2")):  5
```

# Spliting vendor libs:
# 1) Since vendor libraries change less frequently than your application code, caching them separately allows browsers to reuse them across deployments.
# 2) Splitting vendors minimizes the size of the initial bundle loaded by users.
# let's split vendor libs from our mathjs module
```sh
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
```  

# new output
```sh  
asset mathjs.bundle.js 3.32 MiB [emitted] (name: mathjs) (id hint: mathjs)
asset vendors.bundle.js 308 KiB [emitted] (name: vendors) (id hint: vendors)
asset math.bundle.js 9.5 KiB [emitted] (name: math)
asset main.bundle.js 1.45 KiB [emitted] (name: main)
Entrypoint math 3.63 MiB = mathjs.bundle.js 3.32 MiB vendors.bundle.js 308 KiB math.bundle.js 9.5 KiB
Entrypoint main 1.45 KiB = main.bundle.js
runtime modules 3.79 KiB 12 modules
modules by path ./node_modules/mathjs/lib/cjs/ 2.4 MiB 1007 modules
modules by path ./node_modules/seedrandom/ 26.5 KiB
  modules by path ./node_modules/seedrandom/lib/*.js 16 KiB 6 modules
  modules by path ./node_modules/seedrandom/*.js 10.5 KiB 2 modules
modules by path ./node_modules/@babel/runtime/helpers/*.js 2.37 KiB
  ./node_modules/@babel/runtime/helpers/interopRequireDefault.js 214 bytes [built] [code generated]
  ./node_modules/@babel/runtime/helpers/extends.js 504 bytes [built] [code generated]
  ./node_modules/@babel/runtime/helpers/defineProperty.js 362 bytes [built] [code generated]
  + 3 modules
modules by path ./src/ 381 bytes
  ./src/index.js 179 bytes [built] [code generated]
  ./src/lib/math.js 202 bytes [built] [code generated]
+ 8 modules
webpack 5.97.1 compiled successfully in 5710 ms
sum(1 2):  3
evalExpresion("sqrt(3^2 + 4^2")):  5
```  