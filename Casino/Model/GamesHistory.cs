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
    
    public partial class GamesHistory
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public Nullable<int> Bet { get; set; }
        public string Result { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}
