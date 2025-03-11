using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDeInventario.Models
{
    [Index("Email", Name = "UQ__Proveedo__AB6E6164E9A56EF8", IsUnique = true)]
    public class ProveedoresModels
    {
        [Key]
        [Column("proveedor_id")]
        public int ProveedorId { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100)]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string Nombre { get; set; } = null!;

        [Column("direccion")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(255)]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string? Direccion { get; set; }

        [Column("telefono")]
        [StringLength(20)]
        [Required(ErrorMessage = "El campo es requerido")]
        [MinLength(3, ErrorMessage = "El campo requiere mínimo 3 letras")]
        public string? Telefono { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "No es un formato de correo electronico")]
        public string? Email { get; set; }

        [InverseProperty("Proveedores")]
        public virtual ICollection<OrdenesCompraModels> OrdenesCompra { get; set; } = new List<OrdenesCompraModels>();
    }
}