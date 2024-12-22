# install dependencies
# https://vitest.dev/guide/#adding-vitest-to-your-project
```sh
npm install -D vitest
```

# update webpack.common.config.js
```sh
const path = require('path');

const config = {
  entry: {
    isCPF: {
      import: './src/lib/isCPF/index.mjs'
    },
    isCNPJ: {
      import: './src/lib/isCNPJ/index.mjs'
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