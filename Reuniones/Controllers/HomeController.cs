using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reuniones.Models;

namespace Reuniones.Controllers
{
    public class HomeController : Controller
    {
        private ReunionDBEntities _db = new ReunionDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Reuniones.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Reunion reunionToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Reuniones.Add(reunionToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var reunionToEdit = (from r in _db.Reuniones where r.Id == id select r).First();
            return View(reunionToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Reunion reunionToEdit)
        {
            var originalReunion = (from r in _db.Reuniones where r.Id == reunionToEdit.Id
                select r).First();

            if (!ModelState.IsValid)
                return View(originalReunion);

            _db.Entry(originalReunion).CurrentValues.SetValues(reunionToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
