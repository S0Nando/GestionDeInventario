using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDeInventario.Models
{
    public class ProductosModels
    {

        [Key]
        [Column("producto_id")]
        public int ProductoId { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string Nombre { get; set; } = null!;

        [Column("descripcion")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255)]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string? Descripcion { get; set; }

        [Column("precio", TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "El campo es requerido")]
        public decimal Precio { get; set; }

        [Column("stock")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int Stock { get; set; }

        [InverseProperty("Productos")]
        public virtual ICollection<OrdenesCompraModels> OrdenesCompra { get; set; } = new List<OrdenesCompraModels>();
    }
}