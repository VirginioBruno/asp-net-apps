using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Controllers
{
    public class LivrosController : Controller
    {
        private readonly LivroRepositorioCSV _repo = new LivroRepositorioCSV();

        public string Detalhes(int id)
        {
            var livro = _repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public IActionResult ParaLer()
        {
            return View("Lista", _repo.ParaLer.Livros);
        }

        public IActionResult Lendo()
        {
            return View("Lista", _repo.Lendo.Livros);
        }

        public IActionResult Lidos()
        {
            return View("Lista", _repo.Lidos.Livros);
        }

        public string Incluir(Livro livro)
        {
            _repo.Incluir(livro);
            return "O Livro foi adicionado com sucesso.";
        }

        public IActionResult Novo()
        {
            return View();
        }
    }
}
