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
        public static void EscritaComMetodoFlush()
        {
            var arquivoDinamico = "arquivoDinamico.txt";

            using (var fs = new FileStream(arquivoDinamico, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                for (int i = 0; i < 10000; i++)
                {
                    sw.WriteLine($"Escrevendo linha ({i}) no arquivo. Pressione enter para continuar gravando!");
                    sw.Flush();
                    Console.ReadLine();
                }
            }
        }

        public static void EscritaBinaria()
        {
            var arquivo = "escritaBinaria.txt";

            using (var fs = new FileStream(arquivo, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(46515);
                bw.Write(485.5);
                bw.Write(true);
                bw.Write(false);
                bw.Write("Teste String");
            }
        }

        public static void LeituraDeArquivoBinario()
        {
            using (var fs = new FileStream("escritaBinaria.txt", FileMode.Open))
            using (var sr = new BinaryReader(fs))
            {
                var agencia = sr.ReadInt32();
                var saldo = sr.ReadDouble();
                var isValid = sr.ReadBoolean();
                var isConta = sr.ReadBoolean();
                var textoConta = sr.ReadString();

                Console.WriteLine($"Agencia: {agencia}, Saldo: {saldo}, É valido: {isValid}, É conta: {isConta}, texto: {textoConta}");
            }
        }
    }
}