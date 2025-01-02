using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CFA.Models;
using CFA.Repository;

namespace CFA.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        IMoviesRepository<Movie> mov = new IMoviesRepository<Movie>();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie p)
        {
            if (ModelState.IsValid)
            {
                mov.Insert(p);
                mov.Save();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //3. edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = mov.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Movie p)
        {
            if (ModelState.IsValid)
            {
                mov.Update(p);
                mov.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }
    }
}