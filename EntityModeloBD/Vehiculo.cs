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
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Ruta = new HashSet<Ruta>();
            this.Pasaje = new HashSet<Pasaje>();
        }
    
        public int id_vehiculo { get; set; }
        public string nombre_vehiculo { get; set; }
        public string modelo_vehiculo { get; set; }
        public int capacidad_vehiculo { get; set; }
        public string patente_vehiculo { get; set; }
        public string estado_vehiculo { get; set; }
        public int id_empleado { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ruta> Ruta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasaje> Pasaje { get; set; }
    }
}
