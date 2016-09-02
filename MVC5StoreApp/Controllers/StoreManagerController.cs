using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5StoreApp.Models;

namespace MVC5StoreApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private readonly MVC5StoreAppDBContext _db = new MVC5StoreAppDBContext();

        // GET: /StoreManager/
        public ViewResult Index()
        {
            var items = _db.Items.Include(i => i.Genre).Include(i => i.Product);
            return View(items.ToList());
        }

        // GET: /StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound("Item not found");                
            }
            return View(item);
        }

        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }

        // POST: /StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ItemId,GenreId,ProductId,Title,Price,ItemUrl")] Item item)       
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ToDo: Dropdown of GenereID must filter teh ralated ProductIDs, instead of all as of now.           
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", item.GenreId);
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name", item.ProductId);
            return View(item);
        }

        // GET: /StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            //ToDo: Add another view to show errors (Errors view) as shown below by BadRequest and HttpNotFound()
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", item.GenreId);
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name", item.ProductId);
            return View(item);
        }

        // POST: /StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ItemId,GenreId,ProductId,Title,Price,ItemUrl")] Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name", item.GenreId);
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name", item.ProductId);
            return View(item);
        }

        // GET: /StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = _db.Items.Find(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
