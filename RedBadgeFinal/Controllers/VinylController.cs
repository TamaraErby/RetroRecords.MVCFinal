using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class VinylController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Vinyl
        public ActionResult Index()
        {
            List<Vinyl> vinylList = _db.Vinyls.ToList();
            List<Vinyl> orderedList = vinylList.OrderBy(vinyl => vinyl.Title).ToList();
            return View(orderedList);
        }

        //GET: Vinyl
        public ActionResult Create()
        {
            return View();
        }

        //GET: Vinyl
        [HttpPost]
        public ActionResult Create(Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                _db.Vinyls.Add(vinyl);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vinyl);
        }

        //GET: Delete
        //Vinyl/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = _db.Vinyls.Find(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        //POST: Delete
        //Vinyl/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Vinyl vinyl = _db.Vinyls.Find(id);
            _db.Vinyls.Remove(vinyl);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Vinyl/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = _db.Vinyls.Find(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        //POST: Edit
        //Vinyl/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(vinyl).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vinyl);
        }

        //GET: Details
        //Vinyl/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = _db.Vinyls.Find(id);

            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }
    }
}