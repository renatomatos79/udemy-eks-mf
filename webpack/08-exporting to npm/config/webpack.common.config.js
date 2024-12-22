import { clear } from 'console';
import path from 'path';

const config = {
  entry: {
    isCPF: './src/lib/isCPF/index.ts',
    isCNPJ: './src/lib/isCNPJ/index.ts',
    index:  {
      dependOn: ['isCPF', 'isCNPJ'],
      import: './src/lib/index.ts',
    },
  },
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js',
    clean: true    
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/,
      },
    ],
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js'],
  },
};

export default config;