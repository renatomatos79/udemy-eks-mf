const { merge } = require('webpack-merge');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const commonConfig = require('./webpack.common');
const packageJson = require('../package.json');

const devServerRemoteHostAdminContent = `'admin@${process.env.DS_RH_ADMIN}/remoteEntry.js'`;
const devServerRemoteHostAuthContent = `'auth@${process.env.DS_RH_AUTH}/remoteEntry.js'`;
const devServerRemoteHostDashboardContent = `'dashboard@${process.env.DS_RH_DASHBOARD}/remoteEntry.js'`;
const publicPathContent = `'${process.env.DS_PUBLIC_PATH}'`

console.log('devServerRemoteHostAdminContent: ', devServerRemoteHostAdminContent)
console.log('devServerRemoteHostAuthContent: ', devServerRemoteHostAuthContent)
console.log('devServerRemoteHostDashboardontent: ', devServerRemoteHostDashboardContent)
console.log('publicPathContent: ', publicPathContent)

const devConfig = {
  mode: 'development',
  output: {
    publicPath: publicPathContent,
  },
  devServer: {
    host: '0.0.0.0',
    port: 8084,
    historyApiFallback: {
      historyApiFallback: true,
    },
    headers: {
      'Access-Control-Allow-Origin': '*',
    },
  },
  plugins: [
    new ModuleFederationPlugin({
      name: 'container',
      remotes: {
        admin: devServerRemoteHostAdminContent,
        auth: devServerRemoteHostAuthContent,
        dashboard: devServerRemoteHostDashboardContent,
      },
      shared: packageJson.dependencies,
    }),
    new HtmlWebpackPlugin({
      template: './public/index.html',
    }),
  ],
};

const mergeResult = merge(commonConfig, devConfig);
console.log('mergeResult: ', mergeResult)
console.log('mergeResult: ', JSON.stringify(mergeResult))

module.exports = mergeResult;


