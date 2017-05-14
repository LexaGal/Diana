//using Database.EFModel;

using Database;
using Database.Repository;

namespace Logics.Services
{
    public static class ServiceLocator
    {
        private static UnitOfWork _uow = new UnitOfWork();

        public static IService<T> GetService<T>() where T : class
        {
            if (typeof(T) == typeof(Автозаправка))
            {
                return new АвтозаправкаService(_uow) as IService<T>;
            }
            if (typeof(T) == typeof(Топливо))
            {
                return new ТопливоService(_uow) as IService<T>;
            }
            if (typeof(T) == typeof(Услуга))
            {
                return new УслугаService(_uow) as IService<T>;
            }
            if (typeof(T) == typeof(Постоянные_клиенты))
            {
                return new ПостоянныеКлиентыService(_uow) as IService<T>;
            }
            if (typeof(T) == typeof(Товар))
            {
                return new ТоварService(_uow) as IService<T>;
            }
            return null;
        }
    }
}