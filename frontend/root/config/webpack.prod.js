const { merge } = require('webpack-merge');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const commonConfig = require('./webpack.common');
const packageJson = require('../package.json');

// const domain = process.env.PRODUCTION_DOMAIN;

const prodConfig = {
  mode: 'production',
  output: {
    filename: '[name].[contenthash].js',
    publicPath: 'http://3.84.216.40:8084/',
  },
  plugins: [
    new ModuleFederationPlugin({
      name: 'root',
      remotes: {
        admin: `admin@/admin/latest/remoteEntry.js`,
        auth: `auth@/auth/latest/remoteEntry.js`,
        dashboard: `dashboard@/dashboard/latest/remoteEntry.js`,
      },
      shared: packageJson.dependencies,
    }),
  ],
};

module.exports = merge(commonConfig, prodConfig);
