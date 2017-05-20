using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class АкцииService : IService<Акции_на_товар>
    {
        public UnitOfWork Uow { get; }

        public АкцииService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Акции_на_товар> ReadAll()
        {
            return Uow.АкцииНаТовары.GetAll();
        }

        public Акции_на_товар ReadOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}