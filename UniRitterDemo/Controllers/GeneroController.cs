using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniRitter.Demo.DomainModel;
using UniRitter.Demo.BusinessLogic;
using Moo;
using UniRitterDemo.Models;

namespace UniRitterDemo.Controllers
{
    public class GeneroController : Controller
    {
        public IBusinessObject<Genero> BO { get; set; }

        public IMappingRepository MappingRepo { get; set; }

        public GeneroController(IBusinessObject<Genero> bo, IMappingRepository mappingRepo)
        {
            this.BO = bo;
            this.MappingRepo = mappingRepo;
        }
    
        // GET: /Genero/

        public ActionResult Index()
        {
            var entidades = BO.BuscarTodos();
            var mapper = MappingRepo.ResolveMapper<Genero, GeneroIndexModel>();
            var models = mapper.MapMultiple(entidades);
            return View(models);
        }

        //
        // GET: /Genero/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Genero/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Genero/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Genero/Edit/5
 
        public ActionResult Edit(int id)
        {
            var entidade = BO.BuscarPorId(id);
            var mapper = MappingRepo.ResolveMapper<Genero, GeneroEditModel>();
            var model = mapper.Map(entidade);
            return View(model);
        }

        //
        // POST: /Genero/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Genero/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Genero/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
