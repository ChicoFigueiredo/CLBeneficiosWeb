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
    
    public partial class Beneficio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beneficio()
        {
            this.Beneficios_Convenios = new HashSet<Beneficios_Convenios>();
        }
    
        public int idBeneficio { get; set; }
        public string Nome_Beneficio { get; set; }
        public decimal Preço_Mensal_Base { get; set; }
        public decimal Preço_Assinatura_Base { get; set; }
        public bool Obrigatorio_Base { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beneficios_Convenios> Beneficios_Convenios { get; set; }
    }
}
