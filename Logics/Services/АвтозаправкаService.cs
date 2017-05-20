using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class АвтозаправкаService : IService<Автозаправка>
    {
        public UnitOfWork Uow { get; }

        public АвтозаправкаService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Автозаправка> ReadAll()
        {
            return Uow.Автозаправки.GetAll();
        }

        public Автозаправка ReadOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}