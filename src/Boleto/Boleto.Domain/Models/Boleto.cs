using System.ComponentModel.DataAnnotations;

namespace Boleto.Domain.Models
{
    public class BoletoModel
    {
        public int IdBoleto { get; set; }

        public int IdMatricula { get; set; }

        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        public DateTime MesReferencia { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataGeracao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        public bool Pago { get; set; }

        public string UrlBoleto { get; set; } = string.Empty;
    }
}
