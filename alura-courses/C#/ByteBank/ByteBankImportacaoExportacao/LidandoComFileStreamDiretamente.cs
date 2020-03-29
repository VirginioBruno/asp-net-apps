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

        static void LidandoComFileStreamDiretamente()
        {
            var enderecoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1 kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }

            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var encoding = Encoding.Default;

            var contas = encoding.GetString(buffer, 0, bytesLidos);

            Console.Write(contas);

            //foreach (var meusByte in buffer)
            //{
            //    Console.Write(meusByte);
            //    Console.Write(" ");
            //}
        }
    }
}