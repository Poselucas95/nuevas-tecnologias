//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymSolutions.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rutina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rutina()
        {
            this.Dias_Rutina = new HashSet<Dias_Rutina>();
        }
    
        public int ID_RUTINA { get; set; }
        public string rutNombre { get; set; }
        public System.DateTime rutFechaCreacion { get; set; }
        public System.DateTime rutFechaModificacion { get; set; }
        public string ID_PERFIL { get; set; }
        public int usuCreador { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dias_Rutina> Dias_Rutina { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
