//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlobalSegurosPrueba.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Empleado_Tienda = new HashSet<Empleado_Tienda>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
        public string Documento { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string genero { get; set; }
        public Nullable<int> cargo { get; set; }
    
        public virtual Cargo Cargo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado_Tienda> Empleado_Tienda { get; set; }
    }
}
