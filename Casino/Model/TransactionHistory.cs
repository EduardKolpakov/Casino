//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Casino.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionHistory
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Type { get; set; }
        public Nullable<int> summ { get; set; }
    
        public virtual User User { get; set; }
    }
}
