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
    
    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            this.Auto = new HashSet<Auto>();
            this.AutoService = new HashSet<AutoService>();
        }
    
        public int Model_id { get; set; }
        public string Mark { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public int EngineType_id { get; set; }
        public string Complectation { get; set; }
        public string HorsePower { get; set; }
        public string EngineVolume { get; set; }
        public string Places { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auto> Auto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoService> AutoService { get; set; }
        public virtual EngineType EngineType { get; set; }
    }
}
