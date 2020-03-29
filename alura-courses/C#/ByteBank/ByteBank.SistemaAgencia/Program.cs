using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.SistemaAgencia.Extensoes;
using ByteBank.SistemaAgencia.Comparadores;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var idades = new List<int>();
            var nomes = new List<string>();
            var contas = new List<ContaCorrente>();

            nomes.AdicionaVarios("Bruno", "Marcelo", "João", "Carlos");
            idades.AdicionaVarios(158, 58, 75, 15);
            contas.AdicionaVarios(
                new ContaCorrente(123, 5),
                null,
                new ContaCorrente(658, 1),
                null,
                new ContaCorrente(417, 96)
            );


            nomes.Sort();
            idades.Sort();

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta { conta.Agencia }/{ conta.Numero }");
            }

            Console.ReadLine();
        }
    }
}
