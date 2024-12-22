import { describe, test, expect } from 'vitest'
import { isDocument } from './index.js'
import { DocumentType } from '../../types/enums/document-type.enum'

describe('isDocument', () => {
  test('should return unknown when document is not supplied', () => {
    expect(isDocument('')).toMatchObject({ document: '', type: 2 })
  })

  test('should return CPF when document is a valid CPF', () => {
    expect(isDocument('014.600.940-18')).toMatchObject({ document: '014.600.940-18', type: DocumentType.CPF })
  })

  test('should return unknown when CPF is not valid', () => {
    expect(isDocument('123.456.789-00')).toMatchObject({ document: '123.456.789-00', type: DocumentType.Unknown })
  })

  test('should return CNPJ when document is a valid CNPJ', () => {
    expect(isDocument('11.222.333/0001-81')).toMatchObject({ document: '11.222.333/0001-81', type: DocumentType.CNPJ })
  })

  test('should return unknown when CNPJ is not valid', () => {
    expect(isDocument('11.222.333/0000-00')).toMatchObject({ document: '11.222.333/0000-00', type: DocumentType.Unknown })
  })
})