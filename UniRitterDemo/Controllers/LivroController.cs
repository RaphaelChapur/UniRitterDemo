using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniRitter.Demo.BusinessLogic;
using UniRitter.Demo.DomainModel;
using Moo;
using UniRitterDemo.Models;

namespace UniRitterDemo.Controllers
{
    public class LivroController : Controller
    {
        public IBusinessObject<Livro> BO { get; set; }

        public IMappingRepository MappingRepo { get; set; }

        public LivroController(
            IBusinessObject<Livro> bo,
            IMappingRepository mappingRepo)
        {
            this.BO = bo;
            this.MappingRepo = mappingRepo;
        }

        public LivroController(
            IBusinessObject<Livro> bo)
            : this(bo, MappingRepository.Default)
        {
        }

        //
        // GET: /Livro/

        public ActionResult Index()
        {
            // buscando todos os livros do sistema
            var entidades = BO.BuscarTodos();
            // criando um mapper para copiar dados da entidade para o ViewModel
            var mapper = MappingRepo.ResolveMapper<Livro, LivroIndexModel>();
            // mapeando das entidades para os ViewModels
            var models = mapper.MapMultiple(entidades);
            // mostrando na tela
            return View(models);
        }

        public ActionResult Edit(int id)
        {
            var entidade = BO.BuscarPorId(id);
            var mapper = MappingRepo.ResolveMapper<Livro, LivroEditModel>();
            var model = mapper.Map(entidade);
            return View(model);
        }
    }
}
