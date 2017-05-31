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

            item.дата = DateTime.Now.AddDays(1);
            item.скидка = cl.Скидка_на_количество_посещений;

            cl.Количество_посещений++;
            cl.Скидка_на_количество_посещений = cl.Количество_посещений.Value % 15;
            
            // not to insert related objects - as they were obtained outside of context
            Uow.Db.Entry(cl).State = EntityState.Modified;
            item.ЧекТовар.Select(ct => ct.Товар)
                .Distinct()
                .ToList()
                .ForEach(t => Uow.Db.Entry(t).State = EntityState.Modified);
            item.ЧекУслуга.Select(cs => cs.Услуга).ToList().ForEach(s => Uow.Db.Entry(s).State = EntityState.Modified);
            Uow.Db.Entry(item.Топливо).State = EntityState.Modified;
            //

            Uow.Чеки.Save(item);
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public decimal GetChecksSum(int month, int day = 0)
        {
            var sum = GetChecks(month, day).Sum(c => c.стоимость);
            return sum;
        }

        public decimal GetFuelChecksSum(int month, int day = 0)
        {
            var sum = GetChecks(month, day).Sum(c =>
            {
                return c.кол_во_топлива * c.Топливо.стоимость * (1 - (c.скидка != null ? (decimal) c.скидка.Value / 100 : 0));
            });
            return sum;
        }

        public decimal GetProdServChecksSum(int month, int day = 0)
        {
            var checks = GetChecks(month, day).ToList();

            var prods = checks.SelectMany(c => c.ЧекТовар);
            var sumProd =
                prods.Sum(
                    p =>
                        p.кол_во*p.Товар.стоимость.Value*(1 - (p.Чек.скидка != null ? (decimal) p.Чек.скидка.Value/100 : 0)));

            var servs = checks.SelectMany(c => c.ЧекУслуга);
            var sumServ = servs.Sum(s => s.Услуга.стоимость.Value*
                        (1 - (s.Чек.скидка != null ? (decimal) s.Чек.скидка.Value/100 : 0)));

            return sumProd + sumServ;
        }

        private IEnumerable<Чек> GetChecks(int month, int day = 0)
        {
            return day == 0
                ? Uow.Чеки.GetAll().Where(c => c.дата.Value.Month == month)
                : Uow.Чеки.GetAll().Where(c => c.дата.Value.Month == month && c.дата.Value.Day == day);
        }
    }
}