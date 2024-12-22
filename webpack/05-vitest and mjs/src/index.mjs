import { isCPF, isCNPJ } from './lib/index.mjs';

const CPFS = [
    // Valid CPFs
    "014.600.940-18",
    "702.007.130-94",
    "406.997.330-30",
    "350.886.090-60",
  
    // Invalid CPFs
    "789.258.147-62",
    "467.619.310-14",
    "000.000.000-00",
    "123.456.789-00" 
  ];

console.log('CPFs:');
CPFS.forEach(cpf => {
    console.log(`${cpf} is ${isCPF(cpf) ? 'valid' : 'invalid'}`);
})


const CNPJS = [
    // Valid CNPJs
    "11.222.333/0001-81",
    
    // Invalid CNPJs
    "12.175.094/0001-61",
    "22.333.444/0001-96",
    "33.444.555/0001-01"
]

console.log('\n');
console.log('CNPJs:');
CNPJS.forEach(cnpj => {
    console.log(`${cnpj} is ${isCNPJ(cnpj) ? 'valid' : 'invalid'}`);
})