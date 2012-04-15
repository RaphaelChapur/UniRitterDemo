using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moo;
using UniRitter.Demo.DomainModel;
using UniRitter.Demo.BusinessLogic;
using UniRitterDemo.Models;

namespace UniRitterDemo.Controllers
{
    public class AutorController : Controller
    {
        public IBusinessObject<Autor> BO { get; private set; }

        public IMapper<Autor, AutorModel> Mapper { get; private set; }

        public IMapper<AutorModel, Autor> ModelMapper { get; private set; }

        public AutorController(
            IBusinessObject<Autor> bo,
            IMapper<Autor, AutorModel> mapper,
            IMapper<AutorModel, Autor> modelMapper)
        {
            BO = bo;
            Mapper = mapper;
            ModelMapper = modelMapper;
        }

        //
        // GET: /Autor/

        public ActionResult Index()
        {
            var entidades = BO.BuscarTodos();
            var models = Mapper.MapMultiple(entidades);
            return View(models);
        }

        private ActionResult MostrarDetalhes(int id)
        {
            var entidade = BO.BuscarPorId(id);
            var model = Mapper.Map(entidade);
            return View(model);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        public ActionResult Details(int id)
        {
            return MostrarDetalhes(id);
        }

        public ActionResult Edit(int id)
        {
            return MostrarDetalhes(id);
        }

        public ActionResult Delete(int id)
        {
            return MostrarDetalhes(id);
        }

        [HttpPost]
        public ActionResult Create(AutorModel model)
        {
            var entidade = ModelMapper.Map(model);
            BO.Inserir(entidade);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(AutorModel model)
        {
            var entidade = ModelMapper.Map(model);
            BO.Atualizar(entidade);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(AutorModel model)
        {
            var entidade = ModelMapper.Map(model);
            BO.Remover(entidade);
            return RedirectToAction("Index");
        }        
    }
}
