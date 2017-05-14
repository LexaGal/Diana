using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class ПостоянныеКлиентыService : IService<Топливо>
    {
        public UnitOfWork Uow { get; }

        public ПостоянныеКлиентыService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Топливо> ReadAll()
        {
            return Uow.Топливо.GetAll();
        }
    }
}