using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;
using System.Linq;


namespace Logics.Services
{
    public class ТоварService : IService<Товар>
    {
        public UnitOfWork Uow { get; }

        public ТоварService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Товар> ReadAll()
        {
            return Uow.Товары.GetAll();
        }


        public Товар ReadOne(int id)
        {
            return Uow.Товары.Get(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Товар> ReadSome(string name)
        {
            return Uow.Товары.GetAll()
                .Where(c => c.название_товара.Contains(name));
        }
    }
}