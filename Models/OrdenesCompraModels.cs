using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeInventario.Models
{
    [Table("OrdenesCompra")]
    public class OrdenesCompraModels
    {
        [Key]
        [Column("orden_id")]
        public int OrdenId { get; set; }

        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("cantidad")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int Cantidad { get; set; }

        [Column("precio_unitario", TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal PrecioUnitario { get; set; }

        [Column("fecha_orden", TypeName = "datetime")]
        public DateTime? FechaOrden { get; set; }

        [Column("estado")]
        [StringLength(50)]
        public string? Estado { get; set; }

        [ForeignKey("ProductoId")]
        [InverseProperty("OrdenesCompra")]
        public virtual ProductosModels Productos { get; set; } = null!;

        [ForeignKey("ProveedorId")]
        [InverseProperty("OrdenesCompra")]
        public virtual ProveedoresModels Proveedores { get; set; } = null!;
    }

}
