using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public partial class Постоянные_клиенты
    {
        public override string ToString()
        {
            return this.ФИО_клиента;
        }
    }

    public partial class Товар
    {
        public override string ToString()
        {
            return this.название_товара;
        }
    }

    public partial class Услуга
    {
        public override string ToString()
        {
            return this.название_услуги;
        }
    }
}
