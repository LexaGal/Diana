using System;
//using Database.EFModel;

namespace Database.Repository
{
    public class UnitOfWork : IDisposable
    {
        public АвтозаправкиEntities Db;
        private IRepository<Автозаправка> _автозаправки;
        private IRepository<Акции_на_товар> _акцииНаТовары;
        private IRepository<Акции_на_услугу> _акцииНаУслуги;
        private IRepository<Запись> _записи;
        private IRepository<Общая> _общие;
        private IRepository<Постоянные_клиенты> _постоянныеКлиенты;
        private IRepository<Сервер> _серверы;
        private IRepository<Товар> _товары;
        private IRepository<Топливо> _топливо;
        private IRepository<Услуга> _услуги;
        private IRepository<Чек> _чеки;

        public UnitOfWork()
        {
            Db = new АвтозаправкиEntities();
        }

        public IRepository<Автозаправка> Автозаправки => //_автозаправки ?? (
            _автозаправки = new Repository<Автозаправка>(Db);

        public IRepository<Акции_на_товар> АкцииНаТовары => //_акцииНаТовары ?? (
            _акцииНаТовары = new Repository<Акции_на_товар>(Db);

        public IRepository<Акции_на_услугу> АкцииНаУслуги => //_акцииНаУслуги ?? (
            _акцииНаУслуги = new Repository<Акции_на_услугу>(Db);

        public IRepository<Запись> Записи => //_записи ?? (
            _записи = new Repository<Запись>(Db);

        public IRepository<Общая> Общие => //_общие ?? (
            _общие = new Repository<Общая>(Db);

        public IRepository<Постоянные_клиенты> ПостоянныеКлиенты => //_постоянныеКлиенты ?? (
            _постоянныеКлиенты = new Repository<Постоянные_клиенты>(Db);

        public IRepository<Сервер> Серверы =>// _серверы ?? (
            _серверы = new Repository<Сервер>(Db);

        public IRepository<Товар> Товары => //_товары ?? (
            _товары = new Repository<Товар>(Db);

        public IRepository<Топливо> Топливо => //_топливо ?? (
            _топливо = new Repository<Топливо>(Db);

        public IRepository<Услуга> Услуги => // _услуги ?? (
            _услуги = new Repository<Услуга>(Db);

        public IRepository<Чек> Чеки => //_чеки //?? (
            _чеки = new Repository<Чек>(Db);

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