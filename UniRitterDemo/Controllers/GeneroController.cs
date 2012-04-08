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

        public IMapper<Genero, GeneroModel> Mapper { get; set; }

        // Construtor público do contoller de genero -- as duas dependências (mapper e BO)
        // são passadas nos argumentos
        public GeneroController(IBusinessObject<Genero> bo, IMapper<Genero, GeneroModel> mapper)
        {
            // guardando as dependências em propriedades, para usar depois
            BO = bo;
            Mapper = mapper;
        }
        //
        // GET: /Genero/

        public ActionResult Index()
        {
            // buscar todas as entidades
            // mapear as entidades para models
            // passar os models para a view
            return View();
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
            return View();
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
