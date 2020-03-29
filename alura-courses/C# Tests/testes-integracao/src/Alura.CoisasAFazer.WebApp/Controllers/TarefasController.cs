using Microsoft.AspNetCore.Mvc;
using Alura.CoisasAFazer.WebApp.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IRepositorioTarefas repositorioTarefas;
        private readonly ILogger<CadastraTarefaHandler> logger;

        public TarefasController(IRepositorioTarefas repositorioTarefas, ILogger<CadastraTarefaHandler> logger)
        {
            this.repositorioTarefas = repositorioTarefas;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(repositorioTarefas).Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);
            var handler = new CadastraTarefaHandler(repositorioTarefas, logger);
            var retorno = handler.Execute(comando);
            if (retorno.IsSuccess) return Ok();
            return StatusCode(500);
        }
    }
}