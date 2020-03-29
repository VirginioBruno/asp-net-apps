using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;

namespace Alura.CoisasAFazer.Testes
{
    public class ObtemCategoriaPorIdHandlerExecute
    {
        [Fact]
        public void QuandoIdExistenteDeveChamarSomenteUmaVez() 
        {
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);

            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            var handler = new ObtemCategoriaPorIdHandler(repo);

            handler.Execute(comando);

            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once);
        }
    }
}
