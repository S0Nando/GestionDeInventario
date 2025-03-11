using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionDeInventario.Data;
using GestionDeInventario.Models;

namespace GestionDeInventario.Controllers
{
    public class OrdenesCompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenesCompra
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdenesCompra.Include(o => o.Productos).Include(o => o.Proveedores);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenesCompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesCompraModels = await _context.OrdenesCompra
                .Include(o => o.Productos)
                .Include(o => o.Proveedores)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenesCompraModels == null)
            {
                return NotFound();
            }

            return View(ordenesCompraModels);
        }

        // GET: OrdenesCompra/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Nombre");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre");
            return View();
        }

        // POST: OrdenesCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenId,ProveedorId,ProductoId,Cantidad,PrecioUnitario,FechaOrden,Estado")] OrdenesCompraModels ordenesCompraModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenesCompraModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Nombre", ordenesCompraModels.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre", ordenesCompraModels.ProveedorId);
            return View(ordenesCompraModels);
        }

        // GET: OrdenesCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesCompraModels = await _context.OrdenesCompra.FindAsync(id);
            if (ordenesCompraModels == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Nombre", ordenesCompraModels.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre", ordenesCompraModels.ProveedorId);
            return View(ordenesCompraModels);
        }

        // POST: OrdenesCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenId,ProveedorId,ProductoId,Cantidad,PrecioUnitario,FechaOrden,Estado")] OrdenesCompraModels ordenesCompraModels)
        {
            if (id != ordenesCompraModels.OrdenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenesCompraModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenesCompraModelsExists(ordenesCompraModels.OrdenId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "Nombre", ordenesCompraModels.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre", ordenesCompraModels.ProveedorId);
            return View(ordenesCompraModels);
        }

        // GET: OrdenesCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesCompraModels = await _context.OrdenesCompra
                .Include(o => o.Productos)
                .Include(o => o.Proveedores)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenesCompraModels == null)
            {
                return NotFound();
            }

            return View(ordenesCompraModels);
        }

        // POST: OrdenesCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenesCompraModels = await _context.OrdenesCompra.FindAsync(id);
            if (ordenesCompraModels != null)
            {
                _context.OrdenesCompra.Remove(ordenesCompraModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenesCompraModelsExists(int id)
        {
            return _context.OrdenesCompra.Any(e => e.OrdenId == id);
        }
    }
}
