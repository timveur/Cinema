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
    
    public partial class FilmsPhotos
    {
        public int IdPhotos { get; set; }
        public int IdFilm { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual Films Films { get; set; }
    }
}
