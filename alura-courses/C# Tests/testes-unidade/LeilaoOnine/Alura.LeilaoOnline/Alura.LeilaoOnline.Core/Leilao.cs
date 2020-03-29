using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public enum Estado
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private Interessada _ultimoCliente;
        private List<Lance> _lances = new List<Lance>();
        private IModalidadeAvaliacao _avaliador;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public Estado EstadoLeilao { get; private set; }

        public Leilao(string peca, IModalidadeAvaliacao modalidade)
        {
            Peca = Peca;
            _avaliador = modalidade;
            EstadoLeilao = Estado.LeilaoAntesDoPregao;
        }

        private bool ValidaLance(Interessada cliente, double valor)
        {
            return (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(EstadoLeilao != Estado.LeilaoEmAndamento)
            {
                throw new InvalidOperationException("O pregão não foi iniciado."); 
            }

            if(ValidaLance(cliente, valor))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            EstadoLeilao = Estado.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if(EstadoLeilao == Estado.LeilaoEmAndamento)
            {
                Ganhador = _avaliador.Avalia(this);
                EstadoLeilao = Estado.LeilaoFinalizado;
            }
            else
            {
                throw new InvalidOperationException("O pregão não foi iniciado.");
            }
        }
    }
}
