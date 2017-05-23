using System;
using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;
using System.Linq;

namespace Logics.Services
{
    public class ПостоянныеКлиентыService : IService<Постоянные_клиенты>
    {
        public UnitOfWork Uow { get; }

        public ПостоянныеКлиентыService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Постоянные_клиенты> ReadAll()
        {
            return Uow.ПостоянныеКлиенты.GetAll();
        }

        public Постоянные_клиенты ReadOne(int id)
        {
            return Uow.ПостоянныеКлиенты.Get(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Постоянные_клиенты> ReadSome(string name)
        {
            return Uow.ПостоянныеКлиенты.GetAll()
                .Where(c => c.ФИО_клиента.Contains(name));
        }

        public bool Save(Постоянные_клиенты item)
        {
            Uow.ПостоянныеКлиенты.Save(item, item.Номер_карточки_клиента);
            return true;
        }

        public bool Delete(int id)
        {
            var prod = Uow.ПостоянныеКлиенты.Get(id);
            if (prod.Чек.Any())
            {
                prod.Чек.ToList().ForEach(a => Uow.Чеки.Delete(a.код_чека));
            }
            Uow.ПостоянныеКлиенты.Delete(id);
            return true;
        }
    }
}