import common from './webpack.common.config.js';
import { merge } from 'webpack-merge';

const config = merge(common, {
  mode: 'production' ,
  output: {
    library: {
      type: 'commonjs2', // Use CommonJS2 for Node.js compatibility
    },
  }   
})

export default config;