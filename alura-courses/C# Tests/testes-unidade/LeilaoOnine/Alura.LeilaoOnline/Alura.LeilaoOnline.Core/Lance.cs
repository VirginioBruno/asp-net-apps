using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; private set; }
        public double Valor { get; private set; }

        public Lance(Interessada cliente, double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("O valor do lance deve ser maior ou igual a 0.");
            }

            Cliente = cliente;
            Valor = valor;
        }
    }
}
