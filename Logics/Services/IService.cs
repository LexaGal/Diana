using Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services
{
    public interface IService<T> where T : class
    {
        UnitOfWork Uow { get; }
        IEnumerable<T> ReadAll();
        T ReadOne(int id);
        bool Save(T item);
        bool Delete(int id);
    }
}
