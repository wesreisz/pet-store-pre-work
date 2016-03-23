using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStorePreWork.DAL.Repository
{
    interface IAnimalTypeCDRepository : IDisposable
    {
        IQueryable<AnimalType> All { get; }
        Pet Find(string cd);
        void InsertOrUpdates(AnimalType animalType);
        void Delete(string cd);
        void Save();
    }
}
