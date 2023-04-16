using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento
            {
                Id=1,
                Nome = "Departamento de RH",
                Endereco = "Volta Redonda"
            },
            new Departamento
            {
                Id=2,
                Nome = "Departamento Pessoal",
                Endereco = "Volta Redonda"
            }
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            departamento.Id = departamentos.Select(d => d.Id).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            return View(departamentos.Where(d => d.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(d => d.Id == departamento.Id).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(d => d.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(d => d.Id == departamento.Id).First());
            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            return View(departamentos.Where(d => d.Id == id).First());
        }
    }
}
