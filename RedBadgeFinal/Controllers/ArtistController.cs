using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class ArtistController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Artist
        public ActionResult Index()
        {
            List<Artist> artistList = _db.Artists.ToList();
            List<Artist> orderedList = artistList.OrderBy(art => art.Name).ToList();
            return View(orderedList);
        }

        //GET: Artist
        public ActionResult Create()
        {
            return View();
        }

        //POST: Artist
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Artists.Add(artist);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //GET: Delete
        //Artist/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Artist artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //POST: Delete
        //Artist/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Artist artist = _db.Artists.Find(id);
            _db.Artists.Remove(artist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Artist/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Artist artist = _db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //POST: Edit
        //Artist/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(artist).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //GET: Details
        //Artist/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Artist artist = _db.Artists.Find(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
    }
}