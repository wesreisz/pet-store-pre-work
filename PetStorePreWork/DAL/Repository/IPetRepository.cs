using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStorePreWork.DAL.Repository
{
    public interface IPetRepository : IDisposable
    {
        IQueryable<Pet> All { get; }
        Pet Find(int id);
        void InsertOrUpdates(Pet employee);
        void Delete(int id);
        void Save();
    }
}
