using System;
using System.Collections.Generic;
using Database;using Database.Repository;
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
            return Uow.Автозаправки.Get(id);
        }
        public bool Save(Автозаправка item)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}