import { describe, test, expect } from 'vitest'
import { isCNPJ } from './index.js'

describe('isCNPJ', () => {
  test('should return true when CNPJ is 11.222.333/0001-81', () => {
    expect(isCNPJ('11.222.333/0001-81')).toBe(true)
  })

  test('should return false when CNPJ is 12.175.094/0001-61', () => {
    expect(isCNPJ('12.175.094/0001-61')).toBe(false)
  })

  test.each(['12.175.094/0001-61', '22.333.444/0001-96', '33.444.555/0001-01'])
    ('should return false when CNPJ is %s', (cnpj) => {
      expect(isCNPJ(cnpj)).toBe(false)
    })


  test.each`
    CNPJ | expectedResult
    ${'11.222.333/0001-81'} | ${true}
    ${'12.175.094/0001-61'} | ${false}
    ${'22.333.444/0001-96"'} | ${false}
    ${'33.444.555/0001-01'} | ${false}
    ${''} | ${false}
    `('should return $expectedResult for $CNPJ', ({ CNPJ, expectedResult }) => {
    expect(isCNPJ(CNPJ)).toBe(expectedResult)
  })
})