//using Database.EFModel;

using Database;
using Database.Repository;

namespace Logics.Services
{
    public static class ServiceLocator
    {
        public static UnitOfWork Uow = new UnitOfWork();

        public static IService<T> GetService<T>() where T : class
        {
            if (typeof(T) == typeof(Автозаправка))
            {
                return new АвтозаправкаService(Uow) as IService<T>;
            }
            if (typeof(T) == typeof(Топливо))
            {
                return new ТопливоService(Uow) as IService<T>;
            }
            if (typeof(T) == typeof(Услуга))
            {
                return new УслугаService(Uow) as IService<T>;
            }
            if (typeof(T) == typeof(Постоянные_клиенты))
            {
                return new ПостоянныеКлиентыService(Uow) as IService<T>;
            }
            if (typeof(T) == typeof(Товар))
            {
                return new ТоварService(Uow) as IService<T>;
            }
            if (typeof(T) == typeof(Акции_на_товар) || typeof(T) == typeof(Акции_на_услугу))
            {
                return new АкцииService(Uow) as IService<T>;
            }
            //if ()
            //{
            //    return new АкцииService(Uow) as IService<T>;
            //}
            return null;
        }
    }
}