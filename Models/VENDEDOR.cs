//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectAvanzada.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENDEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDEDOR()
        {
            this.VENTA = new HashSet<VENTA>();
        }
    
        public int IDVENDEDOR { get; set; }
        public int IDCATEGORIA { get; set; }
        public string DIRECCION { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
    
        public virtual CATEGORIA_VENDEDOR CATEGORIA_VENDEDOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTA> VENTA { get; set; }
    }
}
