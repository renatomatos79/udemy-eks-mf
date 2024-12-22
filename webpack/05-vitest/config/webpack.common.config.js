const path = require('path');

const config = {
  entry: {
    cpf: {
      import: './src/lib/cpf.js'
    },
    cnpj: {
      import: './src/lib/cnpj.js'
    },
  },
  target: 'node',
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js'
  }  
}

module.exports = config