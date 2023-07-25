using System.Diagnostics;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ApiFinanceiro
{
    public class PersistenciaPDF
    {
        public static void GerarPdf(BoletoModel dadosBoleto, Guid guid)
        {
            string nomeArquivo = (Directory.GetCurrentDirectory() + $"\\bin\\Debug\\net6.0\\boleto.{guid}.pdf");

            PdfWriter writer = new PdfWriter(nomeArquivo);

            PdfDocument pdf = new PdfDocument(writer);

            Document doc = new Document(pdf);

            doc.Add(new Paragraph($"Cliente: {dadosBoleto.Nome}"));
            doc.Add(new Paragraph($"CPF: {dadosBoleto.CPF}"));
            doc.Add(new Paragraph($"Mês referente: {dadosBoleto.MesReferencia}"));
            doc.Add(new Paragraph($"Valor: R$ {dadosBoleto.Valor}"));
            doc.Add(new Paragraph($"Data de geração: {dadosBoleto.DataGeracao}"));
            doc.Add(new Paragraph($"Data de vencimento: {dadosBoleto.DataVencimento}"));

            doc.Close();            
        }
    }
}
