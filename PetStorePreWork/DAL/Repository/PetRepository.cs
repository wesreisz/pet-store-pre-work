using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace PetStorePreWork.DAL.Repository
{
    public class PetRepository : IPetRepository
    {
        private PetStorePreWorkEntities db = new PetStorePreWorkEntities();
        public IQueryable<Pet> All
        {
            get
            {
                return db.Pets.Include(p => p.AnimalType);
            }
        }

        public void Delete(int id)
        {
            var pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Pet Find(int id)
        {
            return db.Pets.Find(id);
        }

        public void InsertOrUpdates(Pet pet)
        {
            if (pet.PetId == default(int))
            {
                db.Pets.Add(pet);
            }
            else {
                db.Entry(pet).State = EntityState.Modified;    
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}