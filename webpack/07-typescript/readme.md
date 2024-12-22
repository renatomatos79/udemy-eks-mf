# install dependencies
```sh
npm install --save-dev typescript@5.7.2 ts-loader@ts-loader
```

# add a file names tsconfig.json
```sh
{
    "compilerOptions": {
      "outDir": "./dist/",
      "noImplicitAny": true,
      "module": "es6",
      "target": "es5",
      "allowJs": true,
      "moduleResolution": "node",
      "sourceMap": true,
    }
}
```

# noImplicitAny: Ensures that all variables, parameters, and return values must have an explicit type or be inferred by the compile "module es6": typeScript will compile code to use the ES6 module format (import/export syntax).

# "target es5": The code will be transpiled to ECMAScript 5 (ES5), ensuring compatibility with older environments like older browsers.

# "moduleResolution node10": Supports extensions like .js, .ts, .json, etc. This is the most common setting for Node.js and frontend applications using modern module bundlers.

# "esModuleInterop true": With flag esModuleInterop we can import CommonJS modules in compliance with es6 modules spec. Now our import code looks like this:

```sh
// index.ts file in our app
import moment from 'moment'
moment(); // compliant with es6 module spec

// transpiled js with esModuleInterop (simplified):
const moment = __importDefault(require('moment'));
moment.default();
```

# Update webpack.common.config.js to deal with typescript files
```sh
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
  target: 'node10'
```

# Update webpack.dev.config.js to generate files using "cjs" extension, in order to be compatible with commonJS modules
```sh
entry: {
    app: './src/index.ts',
  },
  output: {
    filename: '[name].bundle.cjs'
  },
```

# Update vite.config.js
```sh
import { defineConfig } from 'vitest/config'

export default defineConfig({
  test: {
    include: ['src/**/*.test.ts'],
    coverage: {
        provider: 'v8',
        include: ['src/lib/**/*.ts'],
        exclude: [
          'src/**/*.test.ts',
          'src/lib/index.ts'
        ],
        reporter: ['text', 'html'],
    }
  }
})
```

# update package.json adding a script file to run app.bundle.cjs
```sh
"start": "npm run build-dev && node dist/app.bundle.cjs"
```

# testing
npm run test
npm run test:coverage
npm run build-dev
npm run build-prod
npm run start
