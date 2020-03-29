using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivoUsandoBytes()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaTexto = "21544,45465,4585.25,Bruno Silva";

                var bytes = Encoding.UTF8.GetBytes(contaTexto);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                var conta = new ContaCorrente(123, 4256);
                conta.Titular = new Cliente();
                conta.Titular.Nome = "Bruno";

                escritor.WriteLine($"{conta.Agencia},{conta.Numero},{conta.Saldo},{conta.Titular.Nome}");
            }
        }
    }


}