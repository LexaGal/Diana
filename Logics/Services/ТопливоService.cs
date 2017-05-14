using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class ТопливоService : IService<Топливо>
    {
        public UnitOfWork Uow { get; }

        public ТопливоService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Топливо> ReadAll()
        {
            return Uow.Топливо.GetAll();
        }
    }
}