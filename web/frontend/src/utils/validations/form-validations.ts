export const cpfRules: ((v: string) => string | boolean)[] = [
  (v) => !!v || 'CPF is required',
  (v) => (v && /^\d{11}$/.test(v)) || 'CPF must contain 11 digits',
  (v) => isValidCPF(v) || 'Invalid CPF',
];

function isValidCPF(cpf: string): boolean {
    cpf = cpf.replace(/[^\d]/g, '');
    if (cpf.length !== 11) return false;
  
    let sum = 0;
    let remainder;
  
    for (let i = 1; i <= 9; i++) {
      sum = sum + parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }
  
    remainder = (sum * 10) % 11;
  
    if (remainder === 10 || remainder === 11) remainder = 0;
  
    if (remainder !== parseInt(cpf.substring(9, 10))) return false;
  
    sum = 0;
    for (let i = 1; i <= 10; i++) {
      sum = sum + parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }
  
    remainder = (sum * 10) % 11;
  
    if (remainder === 10 || remainder === 11) remainder = 0;
  
    if (remainder !== parseInt(cpf.substring(10, 11))) return false;
  
    return true;
}