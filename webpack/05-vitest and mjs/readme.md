# install dependencies
# https://vitest.dev/guide/#adding-vitest-to-your-project
# https://vitest.dev/guide/coverage
```sh
npm install -D vitest@2.1.8
npm install -D vitest/coverage-v8@2.1.8
```

# update webpack.common.config.js
```sh
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
  }
}

module.exports = config
```

# update scripts
```sh
"scripts": {
    "test": "vitest"
    "test:coverage": "vitest run --coverage"
  },
```  

# run test (npm run test)
```sh
✓ src/lib/isCNPJ/index.test.mjs (10)
✓ src/lib/isCPF/index.test.mjs (10)

 Test Files  2 passed (2)
      Tests  20 passed (20)
   Start at  16:25:30
   Duration  1.59s (transform 99ms, setup 0ms, collect 169ms, tests 22ms, environment 1ms, prepare 819ms)
```

# run test coverage (npm run test:coverage)
```sh
 RUN  v2.1.8 C:/projetos/udemy-eks-mf/webpack/05-vitest and mjs
      Coverage enabled with v8

 ✓ src/lib/isCNPJ/index.test.mjs (10)
 ✓ src/lib/isCPF/index.test.mjs (10)

 Test Files  2 passed (2)
      Tests  20 passed (20)
   Start at  16:28:10
   Duration  3.18s (transform 91ms, setup 0ms, collect 483ms, tests 29ms, environment 1ms, prepare 1.11s)

 % Coverage report from v8
---------------------------|---------|----------|---------|---------|-------------------
File                       | % Stmts | % Branch | % Funcs | % Lines | Uncovered Line #s
---------------------------|---------|----------|---------|---------|-------------------
All files                  |   45.67 |    66.66 |   44.44 |   45.67 |
 config                    |       0 |        0 |       0 |       0 |
  webpack.common.config.js |       0 |        0 |       0 |       0 | 1-19
  webpack.dev.config.js    |       0 |        0 |       0 |       0 | 1-6
  webpack.prod.config.js   |       0 |        0 |       0 |       0 | 1-18
 src                       |       0 |        0 |       0 |       0 |
  index.mjs                |       0 |        0 |       0 |       0 | 1-37
 src/lib                   |       0 |        0 |       0 |       0 |
  index.mjs                |       0 |        0 |       0 |       0 | 1-4
 src/lib/isCNPJ            |   95.12 |    81.81 |     100 |   95.12 |
  index.mjs                |   95.12 |    81.81 |     100 |   95.12 | 36-37
 src/lib/isCPF             |   94.59 |    81.81 |     100 |   94.59 |
  index.mjs                |   94.59 |    81.81 |     100 |   94.59 | 32-33
---------------------------|---------|----------|---------|---------|-------------------
```

# adding config file for vitest named "vite.config.mjs"
```sh
import { defineConfig } from 'vitest/config'

export default defineConfig({
  test: {
    include: ['src/**/*.test.mjs'],
    coverage: {
        provider: 'v8',
        include: ['src/lib/**/*.mjs'],
        exclude: [
          'src/**/*.test.mjs',
          'src/lib/index.mjs'
        ],
        reporter: ['text', 'html'],
    }
  }
})
```

# run test:coverage using "npm run test:coverage"
```sh
 RUN  v2.1.8 C:/projetos/udemy-eks-mf/webpack/05-vitest and mjs
      Coverage enabled with v8

 ✓ src/lib/isCNPJ/index.test.mjs (10)
 ✓ src/lib/isCPF/index.test.mjs (10)

 Test Files  2 passed (2)
      Tests  20 passed (20)
   Start at  16:40:03
   Duration  2.22s (transform 87ms, setup 0ms, collect 169ms, tests 18ms, environment 1ms, prepare 769ms)

 % Coverage report from v8
------------|---------|----------|---------|---------|-------------------
File        | % Stmts | % Branch | % Funcs | % Lines | Uncovered Line #s
------------|---------|----------|---------|---------|-------------------
All files   |   94.87 |    81.81 |     100 |   94.87 |
 isCNPJ     |   95.12 |    81.81 |     100 |   95.12 |
  index.mjs |   95.12 |    81.81 |     100 |   95.12 | 36-37
 isCPF      |   94.59 |    81.81 |     100 |   94.59 |
  index.mjs |   94.59 |    81.81 |     100 |   94.59 | 32-33
------------|---------|----------|---------|---------|-------------------
```

# let's understand these columns

Statements:
```sh
function add(a, b) {
  return a + b; // This is an executable statement
}
```

Branches
```sh
function isEven(num) {
  if (num % 2 === 0) { // Branch 1
    return true;
  } else {             // Branch 2
    return false;
  }
}
```

Functions
```sh
function sum(a, b) { // Function 1
  return a + b;
}

function multiply(a, b) { // Function 2
  return a * b;
}
```

Lines
```sh
function greet(name) {
  console.log("Hello, " + name); // Line 1
  return name ? "Hi, " + name : "Hello!"; // Line 2 (with a conditional operator)
}
```
