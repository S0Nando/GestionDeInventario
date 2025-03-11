using GestionDeInventario.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionDeInventario.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ProveedoresModels> Proveedores { get; set; }
    public DbSet<ProductosModels> Productos { get; set; }
    public DbSet<OrdenesCompraModels> OrdenesCompra { get; set; }
}

