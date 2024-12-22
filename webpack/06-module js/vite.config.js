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