//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЧекТовар
    {
        public int Номер { get; set; }
        public int код_товара { get; set; }
        public int код_чека { get; set; }
        public int кол_во { get; set; }
    
        public virtual Товар Товар { get; set; }
        public virtual Чек Чек { get; set; }
    }
}
