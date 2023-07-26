using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boleto.Domain.SwaggerModels
{
    public class BoletoSwagger
    {
        public int IdMatricula { get; set; }

        public decimal Valor { get; set; }

        public DateTime MesReferencia { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
