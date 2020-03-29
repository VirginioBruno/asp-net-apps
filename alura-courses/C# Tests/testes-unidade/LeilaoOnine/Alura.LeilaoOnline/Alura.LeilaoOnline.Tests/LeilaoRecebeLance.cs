using System;
using Xunit;
using System.Linq;
using System.Text;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void RecebeLance_ShouldWork()
        {
            var leilao = new Leilao("Novo Leilao", new MaiorOferta());
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            Assert.True(leilao.Lances.Count() == 1);
        }

        [Fact]
        public void NaoAdicionaLanceDadoQueOPregaoFoiFinalizado()
        {
            var leilao = new Leilao("Novo Leilao", new MaiorOferta());
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            var exception = Assert.Throws<InvalidOperationException>(() => leilao.RecebeLance(fulano, 1000));

            Assert.Equal("O pregão não foi iniciado.", exception.Message);
        }

        [Fact]
        public void NaoAdicionaLanceDadoQueOPregaoNaoFoiIniciado()
        {
            var leilao = new Leilao("Novo Leilao", new MaiorOferta());
            var fulano = new Interessada("Fulano", leilao);

            var exception = Assert.Throws<InvalidOperationException>(() => leilao.RecebeLance(fulano, 1000));

            Assert.Equal("O pregão não foi iniciado.", exception.Message);
        }

        [Fact]
        public void NaoAceitaLancesConcecutivosDadoMesmoCliente()
        {
            var leilao = new Leilao("Novo Leilao", new MaiorOferta());
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(fulano, 2000);

            leilao.TerminaPregao();

            Assert.True(leilao.Lances.Count() == 1);
        }
    }
}
