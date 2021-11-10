using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Genre
        public ActionResult Index()
        {
            List<Genre> genreList = _db.Genres.ToList();
            List<Genre> orderedList = genreList.OrderBy(genre => genre.Category).ToList();
            return View(orderedList);
        }

        //GET: Genre
        public ActionResult Create()
        {
            return View();
        }

        //POST: Genre
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //GET: Delete
        //Genre/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //POST: Delete
        //Genre/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Genre genre = _db.Genres.Find(id);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Genre/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //POST: Edit
        //Genre/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(genre).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //GET: Details
        //Genre/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Genre genre = _db.Genres.Find(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
    }
}