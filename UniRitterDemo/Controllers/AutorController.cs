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

        public IMapper<AutorModel, Autor> MapperModel { get; private set; }

        public AutorController(
            IBusinessObject<Autor> bo,
            IMapper<Autor, AutorModel> mapper,
            IMapper<AutorModel, Autor> mapperModel)
        {
            BO = bo;
            Mapper = mapper;
            MapperModel = mapperModel;
        }

        // esse método serve para mostrar os dados do objeto que vai ser removido.
        public ActionResult Delete(int id)
        {
            return MostrarEntidade(id);
        }

        // esse método remove de fato
        [HttpPost]
        public ActionResult Delete(AutorModel model)
        {
            // mapeando do model para a entidade real
            var entidade = MapperModel.Map(model);
            // passando a entidade para o BO remover
            BO.Remover(entidade);
            // redirecionando para o "index" desse controller
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new AutorModel());
        } 

        //
        // GET: /Autor/

        public ActionResult Index()
        {
            var entidades = BO.BuscarTodos();
            var models = Mapper.MapMultiple(entidades);
            return View(models);
        }

        public ActionResult Details(int id)
        {
            return MostrarEntidade(id);
        }

        private ActionResult MostrarEntidade(int id)
        {
            var entidade = BO.BuscarPorId(id);
            var model = Mapper.Map(entidade);
            return View(model);
        }
    }
}
