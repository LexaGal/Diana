using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class ТоварService : IService<Топливо>
    {
        public UnitOfWork Uow { get; }

        public ТоварService(UnitOfWork uow)
        {
            Uow = uow;
        }

        public IEnumerable<Топливо> ReadAll()
        {
            return Uow.Топливо.GetAll();
        }
    }
}