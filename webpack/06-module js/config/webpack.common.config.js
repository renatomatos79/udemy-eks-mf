import { clear } from 'console';
import path from 'path';

const config = {
  entry: {
    isCPF: './src/lib/isCPF/index.js',
    isCNPJ: './src/lib/isCNPJ/index.js',
    index:  {
      dependOn: ['isCPF', 'isCNPJ'],
      import: './src/lib/index.js',
    },
  },
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js',
    clean: true,
  },
};

export default config;