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
    
    public partial class Чек
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Чек()
        {
            this.Автозаправка = new HashSet<Автозаправка>();
        }
    
        public int код_чека { get; set; }
        public Nullable<System.DateTime> дата { get; set; }
        public Nullable<int> код_топлива { get; set; }
        public Nullable<int> код_товара { get; set; }
        public Nullable<int> код_услуги { get; set; }
        public int номер_карточки_клиента { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Автозаправка> Автозаправка { get; set; }
        public virtual Постоянные_клиенты Постоянные_клиенты { get; set; }
        public virtual Товар Товар { get; set; }
        public virtual Топливо Топливо { get; set; }
        public virtual Услуга Услуга { get; set; }
    }
}
