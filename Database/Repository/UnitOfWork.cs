using System;
//using Database.EFModel;

namespace Database.Repository
{
    public class UnitOfWork : IDisposable
    {
        private АвтозаправкиEntities _db = new АвтозаправкиEntities();
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

        public IRepository<Автозаправка> Автозаправки => _автозаправки ?? (_автозаправки = new Repository<Автозаправка>(_db));

        public IRepository<Акции_на_товар> АкцииНаТовары => _акцииНаТовары ?? (_акцииНаТовары = new Repository<Акции_на_товар>(_db));

        public IRepository<Акции_на_услугу> АкцииНаУслуги => _акцииНаУслуги ?? (_акцииНаУслуги = new Repository<Акции_на_услугу>(_db));

        public IRepository<Запись> Записи => _записи ?? (_записи = new Repository<Запись>(_db));

        public IRepository<Общая> Общие => _общие ?? (_общие = new Repository<Общая>(_db));

        public IRepository<Постоянные_клиенты> ПостоянныеКлиенты => _постоянныеКлиенты ?? (_постоянныеКлиенты = new Repository<Постоянные_клиенты>(_db));

        public IRepository<Сервер> Серверы => _серверы ?? (_серверы = new Repository<Сервер>(_db));

        public IRepository<Товар> Товары => _товары ?? (_товары = new Repository<Товар>(_db));

        public IRepository<Топливо> Топливо => _топливо ?? (_топливо = new Repository<Топливо>(_db));

        public IRepository<Услуга> Услуги => _услуги ?? (_услуги = new Repository<Услуга>(_db));

        public IRepository<Чек> Чеки => _чеки ?? (_чеки = new Repository<Чек>(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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