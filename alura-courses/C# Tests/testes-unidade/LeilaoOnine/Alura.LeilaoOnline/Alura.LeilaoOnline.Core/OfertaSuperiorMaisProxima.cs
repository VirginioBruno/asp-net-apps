using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double valorDestino;

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            this.valorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances.Where(l => l.Valor > valorDestino).OrderBy(l => l.Valor).First();
        }
    }
}
