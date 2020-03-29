using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaExcessaoDadoValorInvalido()
        {
            var leilao = new Leilao("Novo Leilão", new MaiorOferta());
            var interessado = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            var exception = Assert.Throws<ArgumentException>(() => leilao.RecebeLance(interessado, -100));

            Assert.Equal("O valor do lance deve ser maior ou igual a 0.", exception.Message);
        }
    }
}
