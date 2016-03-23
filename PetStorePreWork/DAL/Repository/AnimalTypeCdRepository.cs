using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStorePreWork.DAL.Repository
{
    public class AnimalTypeCdRepository : IAnimalTypeCDRepository
    {
        private PetStorePreWorkEntities db = new PetStorePreWorkEntities();

        public IQueryable<AnimalType> All
        {
            get
            {
                return db.AnimalTypes;
            }
        }

        public void Delete(string cd)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Pet Find(string cd)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdates(AnimalType animalType)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}