using System.Collections.Generic;
using Database;
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
        }

        public bool Delete(int id)
        {
            var prod = Uow.Товары.Get(id);
            
            if (prod.ЧекТовар.Any())
            {
                prod.ЧекТовар.ToList().ForEach(a => Uow.Чеки.Delete(a.код_чека));
            }
            Uow.Товары.Delete(id);
            return true;
        }
    }
}