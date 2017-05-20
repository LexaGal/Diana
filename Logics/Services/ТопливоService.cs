using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class ТопливоService : IService<Топливо>
    {
        public UnitOfWork Uow { get; }

        public ТопливоService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Топливо> ReadAll()
        {
            return Uow.Топливо.GetAll();
        }

        public Топливо ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Топливо item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}