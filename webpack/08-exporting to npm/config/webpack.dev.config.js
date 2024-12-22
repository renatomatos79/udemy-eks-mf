import common from './webpack.common.config.js';
import { merge } from 'webpack-merge';

const config = merge(common, {
  mode: 'development',
  entry: {
    app: './src/index.ts',
  },
  output: {
    filename: '[name].bundle.cjs'
  },
})

export default config;