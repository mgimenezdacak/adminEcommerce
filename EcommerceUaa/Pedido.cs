//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceUaa
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Entrega = new HashSet<Entrega>();
        }
    
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public System.DateTime ped_fecha { get; set; }
        public double ped_descuento { get; set; }
        public string ped_confirmado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual PedidoDetalle PedidoDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entrega { get; set; }
    }
}
