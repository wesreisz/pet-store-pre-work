using PetStorePreWork.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStorePreWork.DAL.Repository;

namespace PetStorePreWork.Controllers
{
    public class PetsController : Controller
    {
        private PetStorePreWorkEntities db = new PetStorePreWorkEntities();

        // GET: Pets
        public ActionResult Index()
        {
            //var pets = db.Pets.Include(p => p.AnimalType);
            //return View(pets.ToList());
            IPetRepository repository = new PetRepository();
            
            return View(repository.All);
        }

        // GET: Pets/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPetRepository repository = new PetRepository();
            Pet pet = repository.Find(Decimal.ToInt32(id));
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            IAnimalTypeCDRepository repository = new AnimalTypeCdRepository();
            ViewBag.AnimalTypeCD = new SelectList(repository.All, "AnimalTypeCD", "AnimalName");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetId,PetName,PetDescription,AnimalTypeCD,PetPrice,ListDT")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                IPetRepository repository = new PetRepository();
                repository.InsertOrUpdates(pet);
                repository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalTypeCD = new SelectList(db.AnimalTypes, "AnimalTypeCD", "AnimalName", pet.AnimalTypeCD);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalTypeCD = new SelectList(db.AnimalTypes, "AnimalTypeCD", "AnimalName", pet.AnimalTypeCD);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetId,PetName,PetDescription,AnimalTypeCD,PetPrice,ListDT")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalTypeCD = new SelectList(db.AnimalTypes, "AnimalTypeCD", "AnimalName", pet.AnimalTypeCD);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
