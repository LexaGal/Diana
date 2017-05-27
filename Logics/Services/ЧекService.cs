using System;
using System.Collections.Generic;
using Database;using Database.Repository;
using System.Linq;
using System.Data.Entity;

namespace Logics.Services
{
    public class ЧекService : IService<Чек>
    {
        public UnitOfWork Uow { get; }

        public ЧекService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Чек> ReadAll()
        {
            return Uow.Чеки.GetAll();
        }

        public Чек ReadOne(int id)
        {
            return Uow.Чеки.Get(id);
        }

        public bool Save(Чек item)
        {
            var cl = item.Постоянные_клиенты;
            cl.Количество_посещений++;
            cl.Скидка_на_количество_посещений++;

            //
            Uow.Db.Entry(cl).State = EntityState.Modified;
            item.ЧекТовар.Select(ct => ct.Товар).ToList().ForEach(t => Uow.Db.Entry(t).State = EntityState.Modified);
            item.ЧекУслуга.Select(cs => cs.Услуга).ToList().ForEach(s => Uow.Db.Entry(s).State = EntityState.Modified);
            //Uow.Db.Entry(item.Топливо).State = EntityState.Modified;
            //
            
            item.дата = DateTime.Now;

            Uow.Чеки.Save(item);
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}