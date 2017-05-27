namespace Database
{
    public partial class Постоянные_клиенты
    {
        public override string ToString()
        {
            return this.ФИО_клиента;
        }
    }    public partial class Товар
    {
        public override string ToString()
        {
            return this.название_товара;
        }
    }    public partial class Услуга
    {
        public override string ToString()
        {
            return this.название_услуги;
        }
    }    public partial class ЧекТовар
    {
        public override string ToString()
        {
            return $"{this.Товар.название_товара}: {this.Товар.стоимость} руб., {this.кол_во} штук.";
        }
    }
    public partial class ЧекУслуга
    {
        public override string ToString()
        {
            return $"{this.Услуга.название_услуги}: {this.Услуга.стоимость} руб.";
        }
    }
}
