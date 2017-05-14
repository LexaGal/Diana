using System.Collections.Generic;
using Database;
//using Database.EFModel;
using Database.Repository;

namespace Logics.Services
{
    public class АвтозаправкаService : IService<Автозаправка>
    {
        private UnitOfWork _uow;

        public АвтозаправкаService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Автозаправка> ReadAll()
        {
            return _uow.Автозаправки.GetAll();
        }        
    }
}