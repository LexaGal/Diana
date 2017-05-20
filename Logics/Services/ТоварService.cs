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

        public bool Save(Товар item)
        {
            Uow.Товары.Save(item, item.код_товара);
            return true;
          //throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var prod = Uow.Товары.Get(id);
            if (prod.Акции_на_товар.Any())
            {
                prod.Акции_на_товар.ToList().ForEach(a => Uow.АкцииНаТовары.Delete(a.Код_акции_товар));
            }
            if (prod.Чек.Any())
            {
                prod.Чек.ToList().ForEach(a => Uow.Чеки.Delete(a.код_чека));
            }
            Uow.Товары.Delete(id);
            return true;
            //throw new NotImplementedException();
        }
    }
}