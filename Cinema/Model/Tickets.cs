//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinema.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        public int IdTicket { get; set; }
        public int IdSession { get; set; }
        public Nullable<int> NumberRow { get; set; }
        public Nullable<int> NumberSeat { get; set; }
    
        public virtual Sessions Sessions { get; set; }
    }
}
