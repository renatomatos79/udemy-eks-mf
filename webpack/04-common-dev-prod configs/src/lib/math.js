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