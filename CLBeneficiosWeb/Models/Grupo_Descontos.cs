//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CLBeneficiosWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grupo_Descontos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupo_Descontos()
        {
            this.Convenios = new HashSet<Convenio>();
        }
    
        public short idGrupo_Desconto { get; set; }
        public string Nome_Grupo_Desconto { get; set; }
        public string Apelido_Grupo_Desconto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Convenio> Convenios { get; set; }
    }
}
