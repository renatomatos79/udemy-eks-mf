# install dependencies
```sh
npm i
```

# update package.json and change type to be module
```sh
"type": "module",
```

# update webpack.common.config.js to use module format
```sh
import path from 'path';

const config = {
  entry: {
    isCPF: {
      import: './src/lib/isCPF/index.js',
    },
    isCNPJ: {
      import: './src/lib/isCNPJ/index.js',
    },
  },
  target: 'node',
  output: {
    path: path.resolve('./dist'),
    filename: '[name].bundle.js',
  },
};

export default config;
```

# update webpack.dev.config.js to use module format
```sh
import common from './webpack.common.config.js';
import { merge } from 'webpack-merge';

const config = merge(common, {
  mode: 'development'
})

export default config;
```


# update webpack.prod.config.js to use module format
```sh
import common from './webpack.common.config.js';
import { merge } from 'webpack-merge';

const config = merge(common, {
  mode: 'production'  
})

export default config;
```

# update lib/index.js content
```sh
import { isCPF } from './isCPF/index.js';
import { isCNPJ } from './isCNPJ/index.js';

export { isCPF, isCNPJ };
```

# rename vite.config.mjs to vite.config.js and update its content
```sh
import { defineConfig } from 'vitest/config'

export default defineConfig({
  test: {
    include: ['src/**/*.test.js'],
    coverage: {
        provider: 'v8',
        include: ['src/lib/**/*.js'],
        exclude: [
          'src/**/*.test.js',
          'src/lib/index.js'
        ],
        reporter: ['text', 'html'],
    }
  }
})
```


# let's confirm everything is ok
```sh
npm run build-dev
npm run build-prod
npm run test
npm run test:coverage
```