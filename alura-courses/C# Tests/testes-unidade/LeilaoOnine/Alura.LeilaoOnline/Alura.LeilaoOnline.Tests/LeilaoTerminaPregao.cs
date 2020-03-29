using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1500, new double[] { 400, 1200, 1500, 750 })]
        [InlineData(0, new double[0])]
        public void TerminaPregao_ShouldWork(double esperado, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Novo Leilão", new MaiorOferta());
            var fulano = new Interessada("Fulano", leilao);
            var fulano1 = new Interessada("Fulano1", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                if(i%2 == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(fulano1, ofertas[i]);
                }
            }
            
            //Act - Metodo sob teste
            leilao.TerminaPregao();
            var valorObtido = leilao.Ganhador.Valor;

            //Assert - Confirma se é o esperado
            Assert.Equal(esperado, valorObtido);
        }

        [Theory]
        [InlineData(1500, 1450, new double[] { 400, 1200, 1500, 750 })]
        [InlineData(800, 700, new double[] { 400, 2000, 200, 350, 800 })]
        public void DefineGanhadorDadoValorSuperiorMaisProximo(double esperado, double valorDestino, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Novo Leilão", new OfertaSuperiorMaisProxima(valorDestino));
            var fulano = new Interessada("Fulano", leilao);
            var fulano1 = new Interessada("Fulano1", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, ofertas[i]);
                }
                else
                {
                    leilao.RecebeLance(fulano1, ofertas[i]);
                }
            }

            //Act - Metodo sob teste
            leilao.TerminaPregao();
            var valorObtido = leilao.Ganhador.Valor;

            //Assert - Confirma se é o esperado
            Assert.Equal(esperado, valorObtido);
        }

        [Fact]
        public void LancaExcessaoDadoPregaoNaoIniciado()
        {
            var leilao = new Leilao("Novo Leilao", new MaiorOferta());
            var interessado = new Interessada("Fulano", leilao);

            var exception = Assert.Throws<InvalidOperationException>(() => leilao.TerminaPregao());

            Assert.Equal("O pregão não foi iniciado.", exception.Message);
        }
    }
}
