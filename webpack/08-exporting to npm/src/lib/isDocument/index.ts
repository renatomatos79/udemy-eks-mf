import { DocumentInterface } from '../../types/interfaces/document.interface';
import { DocumentType } from '../../types/enums/document-type.enum';
import { isCPF, isCNPJ } from '../';

export function isDocument(doc: string): DocumentInterface {
  const document = doc ?? '';
  if (isCPF(document)) {
    return {
      document,
      type: DocumentType.CPF,
    };
  }
  else if (isCNPJ(document)) {
    return {
      document,
      type: DocumentType.CNPJ,
    };
  } else {
    return {
      document,
      type: DocumentType.Unknown,
    };
  }
}