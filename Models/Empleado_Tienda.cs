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
    
    public partial class Empleado_Tienda
    {
        public int Id { get; set; }
        public Nullable<int> tienda { get; set; }
        public Nullable<int> empleado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual Empleado Empleado1 { get; set; }
        public virtual Tienda Tienda1 { get; set; }
    }
}
