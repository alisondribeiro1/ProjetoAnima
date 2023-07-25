namespace ApiFinanceiro
{
    public class BoletoModel
    {       
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime MesReferencia { get; set; }
        public DateTime DataGeracao { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
