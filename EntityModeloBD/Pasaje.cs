//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityModeloBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pasaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pasaje()
        {
            this.Detallescompra = new HashSet<Detallescompra>();
        }
    
        public int id_pasaje { get; set; }
        public string nombre_pasaje { get; set; }
        public Nullable<System.DateTime> fecha_pasaje { get; set; }
        public Nullable<double> precio_pasaje { get; set; }
        public Nullable<int> id_vehiculo { get; set; }
        public Nullable<int> id_ruta { get; set; }
    
        public virtual Ruta Ruta { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detallescompra> Detallescompra { get; set; }
    }
}
