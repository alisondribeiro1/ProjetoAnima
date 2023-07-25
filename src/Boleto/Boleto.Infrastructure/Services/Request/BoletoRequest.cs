using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boleto.Infrastructure.Services.Request
{
    public class BoletoRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime MesReferencia { get; set; }
        public DateTime DataGeracao { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
