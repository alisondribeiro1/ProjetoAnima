export interface BoletoModel {
  dataGeracao: string;
  dataVencimento: string;
  idBoleto: number;
  idMatricula: number;
  mesReferencia: string;
  pago: boolean;
  urlBoleto: string;
  valor: number;
}
