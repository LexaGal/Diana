using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;
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
            //throw new NotImplementedException();
        }

        //public IEnumerable<Чек> ReadSome(string name)
        //{
        //    return Uow.Чеки.GetAll()
        //        .Where(c => c.название_товара.Contains(name));
        //}

        public bool Save(Чек item)
        {
            var cl = item.Постоянные_клиенты;
            cl.Количество_посещений++;

            cl.Скидка_на_количество_посещений++;
            //Uow.ПостоянныеКлиенты.Save(cl, cl.Номер_карточки_клиента);

            //Uow.Db.Entry(cl).State = EntityState.Added;
            //Uow.Db.Entry(cl).State = EntityState.Unchanged;
                //Постоянные_клиенты.           

            var lastId = Uow.Чеки.GetAll().OrderBy(c => c.код_чека).LastOrDefault()?.код_чека ?? 1;

            Uow.Чеки.Save(item, lastId);
            return true;
            //throw new NotImplementedException(); д_чека
        }

        public bool Delete(int id)
        {
            //проверка на связи с другими таблицами
            //var prod = Uow.Товары.Get(id);
            //if (prod.Акции_на_товар.Any())
            //{
            //    prod.Акции_на_товар.ToList().ForEach(a => Uow.АкцииНаТовары.Delete(a.Код_акции_товар));
            //}
            //if (prod.ЧекТовар.Any())
            //{
            //    prod.ЧекТовар.ToList().ForEach(a => Uow.Чеки.Delete(a.код_чека));
            //}
            //Uow.Товары.Delete(id);
            return true;
            //throw new NotImplementedException();
        }
    }
}