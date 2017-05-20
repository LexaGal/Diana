using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;
using System.Linq;


namespace Logics.Services
{
    public class УслугаService : IService<Услуга>
    {
        public UnitOfWork Uow { get; }

        public УслугаService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Услуга> ReadAll()
        {
            return Uow.Услуги.GetAll();
        }


        public Услуга ReadOne(int id)
        {
            return Uow.Услуги.Get(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Услуга> ReadSome(string name)
        {
            return Uow.Услуги.GetAll()
                .Where(c => c.название_услуги.Contains(name));
        }
    }
}