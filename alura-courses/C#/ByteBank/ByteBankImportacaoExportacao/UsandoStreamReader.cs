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
        static void UsandoStreamReader()
        {
            var enderecoArquivo = "contas.txt";
            var listaDeContas = new List<ContaCorrente>();

            using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linhaConta = leitor.ReadLine();
                    var conta = ConverteStringParaContaCorrente(linhaConta);
                    listaDeContas.Add(conta);
                }
            }

            foreach (var conta in listaDeContas)
            {
                Console.WriteLine($"Conta { conta.Agencia }/{ conta.Numero }, Saldo: { conta.Saldo }, Titular: {conta.Titular.Nome} ");
            }
        }

        static ContaCorrente ConverteStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var nomeTitular = campos[3];
            var saldo = double.Parse(campos[2].Replace('.', ','));

            var conta = new ContaCorrente(agencia, numero);

            conta.Titular = new Cliente();
            conta.Titular.Nome = nomeTitular;
            conta.Depositar(saldo);

            return conta;
        }
    }

}