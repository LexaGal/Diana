using System.Collections.Generic;
using Database;
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
        }

        public IEnumerable<Услуга> ReadSome(string name)
        {
            return Uow.Услуги.GetAll()
                .Where(c => c.название_услуги.Contains(name));
        }

        public bool Save(Услуга item)
        {
            Uow.Услуги.Save(item, item.код_услуги);
            return true;
        }

        public bool Delete(int id)
        {
            var prod = Uow.Услуги.Get(id);
            
            if (prod.ЧекУслуга.Any())
            {
                prod.ЧекУслуга.ToList().ForEach(a => Uow.Чеки.Delete(a.код_чека));
            }
            Uow.Услуги.Delete(id);
            return true;
        }
    }
}