using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void TarefaDeveSerIncluidaNoBD()
        {
            var novaTarefa = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), DateTime.Now.AddMonths(3));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var contexto = new DbTarefasContext(options);

            var repositorio = new RepositorioTarefa(contexto);
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var tarefaHandler = new CadastraTarefaHandler(repositorio, mockLogger.Object);

            tarefaHandler.Execute(novaTarefa);

            var tarefa = repositorio.ObtemTarefas(t => t.Titulo == "Estudar xUnit");
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void FalhaAoLancarExcecao()
        {
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), DateTime.Now.AddMonths(3));

            var mock = new Mock<IRepositorioTarefas>();
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Não foi possivel adicionar as tarefas."));

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            CommandResult resultado = handler.Execute(comando);

            Assert.False(resultado.IsSuccess);
        }

        [Fact]
        public void GravaLogAoLancarExcecao()
        {
            var exceptionLancada = new Exception("Não foi possível cadastrar a tarefa.");
            var comando = new CadastraTarefa("Estudar xUnit", new Categoria("Estudo"), new DateTime(2019, 12, 10));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();

            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(exceptionLancada);

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            CommandResult resultado = handler.Execute(comando);

            mockLogger.Verify(x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                exceptionLancada,
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));
        }

        delegate void CapturaMensagemLog(LogLevel level, EventId eventId, object state, Exception exception, object func);

        [Fact]
        public void GravarTarefaGeraLog()
        {
            var tituloTarefaEsperado = "Aprender API via testes com Moq";
            var comando = new CadastraTarefa(tituloTarefaEsperado, new Categoria("Estudo"), new DateTime(2019, 12, 10));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();

            LogLevel levelCapturado = LogLevel.Error;
            string mensagemCapturada = string.Empty;

            CapturaMensagemLog capturaTarefa = (level, eventId, state, exception, func) =>
            {
                levelCapturado = level;
                mensagemCapturada = state.ToString();
            };

            mockLogger.Setup(l => 
            l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                (Func<object, Exception, string>)It.IsAny<object>()
            )).Callback(capturaTarefa);

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            CommandResult resultado = handler.Execute(comando);

            Assert.Equal(LogLevel.Debug, levelCapturado);
            Assert.Contains(tituloTarefaEsperado, mensagemCapturada);
            
        }
    }
}
