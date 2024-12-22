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