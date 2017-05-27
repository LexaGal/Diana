using Database.Repository;
using System.Collections.Generic;
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
