using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moo;
using UniRitter.Demo.BusinessLogic;
using UniRitter.Demo.DomainModel;
using UniRitterDemo.Models;

namespace UniRitterDemo.Controllers
{
    public class LivroController : Controller
    {
        public ILivroBO BO { get; set; }
        public IBusinessObject<Autor> AutorBO { get; set; }
        public IBusinessObject<Genero> GeneroBO { get; set; }
        public IMapper<Livro, LivroIndexModel> IndexMapper { get; set; }
        public IMapper<Livro, LivroEditModel> EditMapper { get; set; }
        public IMapper<LivroEditModel, Livro> ModelMapper { get; set; }
        public IMapper<IEntidade, LookupModel> LookupMapper { get; set; }

        public LivroController(
            ILivroBO bo,
            IBusinessObject<Autor> autorBO,
            IBusinessObject<Genero> livroBO,
            IMapper<Livro, LivroIndexModel> indexMapper,
            IMapper<Livro, LivroEditModel> editMapper,
            IMapper<LivroEditModel, Livro> modelMapper,
            IMapper<IEntidade, LookupModel> lookupMapper
            )
        {
            BO = bo;
            AutorBO = autorBO;
            GeneroBO = livroBO;
            IndexMapper = indexMapper;
            EditMapper = editMapper;
            ModelMapper = modelMapper;
            LookupMapper = lookupMapper;
        }

        //
        // GET: /Livro/

        public ActionResult Index()
        {
            var entidades = BO.BuscarTodos();
            var models = IndexMapper.MapMultiple(entidades);
            return View(models);
        }

        private ActionResult MostrarEntidade(int id)
        {
            var entidade = BO.BuscarPorId(id);
            var model = EditMapper.Map(entidade);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var autores = AutorBO.BuscarTodos();
            var autorLookup = LookupMapper.MapMultiple(autores);
            ViewData.Add("autores", autorLookup);
            var generos = GeneroBO.BuscarTodos();
            var generoLookup = LookupMapper.MapMultiple(generos);
            ViewData.Add("generos", generoLookup);
            return MostrarEntidade(id);
        }

        [HttpPost]
        public ActionResult Edit(LivroEditModel model)
        {
            var entidade = ModelMapper.Map(model);
            BO.Atualizar(entidade);
            return RedirectToAction("Index");
        }
    }
}
