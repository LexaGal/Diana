using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class ПостоянныеКлиентыService : IService<Топливо>
    {
        private UnitOfWork _uow;

        public ПостоянныеКлиентыService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Топливо> ReadAll()
        {
            return _uow.Топливо.GetAll();
        }
    }
}