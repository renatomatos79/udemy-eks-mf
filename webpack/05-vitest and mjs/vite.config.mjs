import { defineConfig } from 'vitest/config'

export default defineConfig({
  test: {
    include: ['src/**/*.test.mjs'],
    coverage: {
        provider: 'v8',
        include: ['src/lib/**/*.mjs'],
        exclude: [
          'src/**/*.test.mjs',
          'src/lib/index.mjs'
        ],
        reporter: ['text', 'html'],
    }
  }
})