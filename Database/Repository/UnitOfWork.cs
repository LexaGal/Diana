using System;

namespace Database.Repository
{
    public class UnitOfWork : IDisposable
    {
        public АвтозаправкиEntities Db;
        
        public UnitOfWork()
        {
            Db = new АвтозаправкиEntities();
        }

        public IRepository<Автозаправка> Автозаправки =>
           new Repository<Автозаправка>(Db);

       public IRepository<Запись> Записи =>
            new Repository<Запись>(Db);

        public IRepository<Общая> Общие =>
            new Repository<Общая>(Db);

        public IRepository<Постоянные_клиенты> ПостоянныеКлиенты =>
            new Repository<Постоянные_клиенты>(Db);

        public IRepository<Сервер> Серверы =>
            new Repository<Сервер>(Db);

        public IRepository<Товар> Товары =>
            new Repository<Товар>(Db);

        public IRepository<Топливо> Топливо =>
            new Repository<Топливо>(Db);

        public IRepository<Услуга> Услуги =>
            new Repository<Услуга>(Db);

        public IRepository<Чек> Чеки =>
            new Repository<Чек>(Db);

        public void Save()
        {
            Db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}