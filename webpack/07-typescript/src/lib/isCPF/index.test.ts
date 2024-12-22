import { describe, test, expect } from 'vitest'
import { isCPF } from './index.js'

describe('isCPF', () => {
  test('should return true when CPF is 014.600.940-18', () => {
    expect(isCPF('014.600.940-18')).toBe(true)
  })

  test('should return false when CPF is 789.258.147-62', () => {
    expect(isCPF('12.175.094/0001-61')).toBe(false)
  })

  test.each(['789.258.147-62', '467.619.310-14', '000.000.000-00'])
    ('should return false when CPF is %s', (cpf) => {
      expect(isCPF(cpf)).toBe(false)
    })


  test.each`
    CPF | expectedResult
    ${'014.600.940-18'} | ${true}
    ${'702.007.130-94'} | ${true}
    ${'789.258.147-62"'} | ${false}
    ${'467.619.310-14'} | ${false}
    ${''} | ${false}
    `('should return $expectedResult for $CPF', ({ CPF, expectedResult }) => {
    expect(isCPF(CPF)).toBe(expectedResult)
  })
})