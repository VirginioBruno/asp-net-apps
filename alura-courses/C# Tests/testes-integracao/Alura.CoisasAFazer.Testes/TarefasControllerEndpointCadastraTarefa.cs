using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var context = new DbTarefasContext(options);

            context.Categorias.Add(new Categoria(20, "Estudo"));
            context.SaveChanges();

            var repo = new RepositorioTarefa(context);

            var controller = new TarefasController(repo, mockLogger.Object);
            var model = new CadastraTarefaVM();
            model.IdCategoria = 20;
            model.Titulo = "Estudar xUnit";
            model.Prazo = new DateTime(2020, 3, 30);

            //Act
            var retorno = controller.EndpointCadastraTarefa(model);

            //Assert
            Assert.IsType<OkResult>(retorno);
        }

        [Fact]
        public void DadaTarefa()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.ObtemCategoriaPorId(20)).Returns(new Categoria(20, "Estudo"));
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro"));
            
            var controller = new TarefasController(mock.Object, mockLogger.Object);
            var model = new CadastraTarefaVM();
            model.IdCategoria = 20;
            model.Titulo = "Estudar xUnit";
            model.Prazo = new DateTime(2020, 3, 30);

            //Act
            var retorno = controller.EndpointCadastraTarefa(model);

            //Assert
            Assert.IsType<StatusCodeResult>(retorno);
            var statusCodeResult = (retorno as StatusCodeResult).StatusCode;

            Assert.Equal(500, statusCodeResult);
            
        }
    }
}
