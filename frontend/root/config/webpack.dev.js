const { merge } = require('webpack-merge');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const commonConfig = require('./webpack.common');
const packageJson = require('../package.json');

const devConfig = {
  mode: 'development',
  output: {
    publicPath: 'http://3.84.216.40:8084/',
  },
  devServer: {
    port: 8084,
    historyApiFallback: {
      historyApiFallback: true,
    },
  },
  plugins: [
    new ModuleFederationPlugin({
      name: 'container',
      remotes: {
        admin: 'admin@http://3.84.216.40:8081/remoteEntry.js',
        auth: 'auth@http://3.84.216.40:8082/remoteEntry.js',
        dashboard: 'dashboard@http://3.84.216.40:8083/remoteEntry.js',
      },
      shared: packageJson.dependencies,
    }),
  ],
};

const mergeResult = merge(commonConfig, devConfig);
console.log('mergeResult: ', mergeResult)
console.log('mergeResult: ', JSON.stringify(mergeResult))

module.exports = mergeResult;
