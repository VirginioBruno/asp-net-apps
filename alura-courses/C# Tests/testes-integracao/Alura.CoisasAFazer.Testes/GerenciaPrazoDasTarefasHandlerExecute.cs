using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void TarefasAtrasadasDevemMudarStatus()
        {
            Categoria[] categorias = {
                new Categoria("Categoria 1"),
                new Categoria("Categoria 2"),
                new Categoria("Categoria 3")
            };

            var tarefas = new List<Tarefa>
            {
                //Atrasadas a partir de 1/1/2019
                { new Tarefa(1, "Tarefa 1", categorias[0], new DateTime(2018, 12, 31), null, StatusTarefa.Criada) },
                { new Tarefa(2, "Tarefa 2", categorias[1], new DateTime(2017, 12, 24), null, StatusTarefa.Criada) },
                { new Tarefa(3, "Tarefa 3", categorias[2], new DateTime(2018, 12, 15), null, StatusTarefa.Criada) },
                //No prazo em 1/1/2019
                { new Tarefa(4, "Tarefa 4", categorias[0], new DateTime(2019, 1, 22), null, StatusTarefa.Criada) },
                { new Tarefa(5, "Tarefa 5", categorias[1], new DateTime(2019, 4, 13), null, StatusTarefa.Criada) },
                { new Tarefa(6, "Tarefa 6", categorias[2], new DateTime(2019, 3, 5), null, StatusTarefa.Criada) }
            };

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;

            var contexto = new DbTarefasContext(options);

            var repositorio = new RepositorioTarefa(contexto);

            repositorio.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));

            var gerenciador = new GerenciaPrazoDasTarefasHandler(repositorio);

            gerenciador.Execute(comando);

            var tarefasEmAtraso = tarefas.Where(t => t.Status == StatusTarefa.EmAtraso).Count();
            Assert.Equal(3, tarefasEmAtraso);
        }

        [Fact]
        public void VerificaQuantidadeDeChamadasDadaAtualizacaoDeTarefas()
        {
            Categoria[] categorias = {
                new Categoria("Categoria 1"),
                new Categoria("Categoria 2"),
                new Categoria("Categoria 3")
            };

            var tarefas = new List<Tarefa>
            {
                { new Tarefa(1, "Tarefa 1", categorias[0], new DateTime(2018, 12, 31), null, StatusTarefa.Criada) },
                { new Tarefa(2, "Tarefa 2", categorias[1], new DateTime(2017, 12, 24), null, StatusTarefa.Criada) },
                { new Tarefa(6, "Tarefa 6", categorias[2], new DateTime(2019, 3, 5), null, StatusTarefa.Criada) }
            };

            var mock = new Mock<IRepositorioTarefas>();

            mock.Setup(r => r.ObtemTarefas(It.IsAny<Func<Tarefa, bool>>()))
                .Returns(tarefas);

            var repo = mock.Object;

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            handler.Execute(comando);

            mock.Verify(r => r.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once);
        }
    }
}
