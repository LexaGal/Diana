//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЧекУслуга
    {
        public int Номер { get; set; }
        public int код_услуги { get; set; }
        public int код_чека { get; set; }
    
        public virtual Услуга Услуга { get; set; }
        public virtual Чек Чек { get; set; }
    }
}
