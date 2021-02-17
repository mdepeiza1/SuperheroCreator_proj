using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroCreator.Data;
using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperheroController
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes;
            return View(superheroes);
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Where(n => n.Id == id).FirstOrDefault();
            return View(superhero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            var sh = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();

            return View(sh);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero sh)
            //public ActionResult Edit(int id, IFormCollection collection) old version
        {
            try
            {
                var superhero = _context.Superheroes.Where(s => s.Id == sh.Id).FirstOrDefault();
                _context.Superheroes.Remove(superhero);
                _context.Superheroes.Add(sh);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
