//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Programm.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string imya { get; set; }
        public string familya { get; set; }
        public string otchestvo { get; set; }
        public int avatar { get; set; }
        public int lvl { get; set; }
        public int role { get; set; }
        public int language { get; set; }
        public string phoneNumber { get; set; }
        public Nullable<int> teacher { get; set; }
        public Nullable<int> score { get; set; }
    
        public virtual Avatar Avatar1 { get; set; }
        public virtual Language Language1 { get; set; }
        public virtual Lvl Lvl1 { get; set; }
        public virtual Role Role1 { get; set; }
        public virtual Score Score1 { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
