//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Interage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioPadrao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuarioPadrao()
        {
            this.AreasInteresse = new HashSet<AreaInteresse>();
        }
    
        public int CodUsuario { get; set; }
        public string CPF { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual UsuarioExpectador UsuarioExpectador { get; set; }
        public virtual UsuarioExpositor UsuarioExpositor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AreaInteresse> AreasInteresse { get; set; }
        public virtual UsuarioPromotor UsuarioPromotor { get; set; }
    }
}
