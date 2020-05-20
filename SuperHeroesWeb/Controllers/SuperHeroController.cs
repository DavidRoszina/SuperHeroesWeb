using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SuperHeroesWeb.Data;
using SuperHeroesWeb.Models;

namespace SuperHeroesWeb.Controllers
{

    public class SuperHeroController : Controller

    {
        private readonly ApplicationDbContext db;

        public SuperHeroController(ApplicationDbContext context)
        {
            db = context;
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            return View("Details");
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var superHeroInDB = db.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            SuperHero mySuperHeroInDB = null;
            foreach (SuperHero s in db.SuperHeroes)
            {
                if (s.Id == id)
                {
                    return View(mySuperHeroInDB);
                }
            }
            return View(mySuperHeroInDB);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero newSuperHero = new SuperHero();
            return View(newSuperHero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero newSuperHero)
        {
            try
            {
                db.SuperHeroes.Add(newSuperHero);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var superHeroInDB = db.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            SuperHero mySuperHeroInDB = null;
            foreach (SuperHero s in db.SuperHeroes)
            {
                if (s.Id == id)
                {
                    return View(mySuperHeroInDB);
                }
            }
            return View(mySuperHeroInDB);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}