//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class AutoService
    {
        public int Service_id { get; set; }
        public int Model_id { get; set; }
        public int Client_id { get; set; }
        public System.DateTime Datetime { get; set; }
        public string Title { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Model Model { get; set; }
    }
}
