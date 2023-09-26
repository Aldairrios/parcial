using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using parcial.Models;
using System.Linq;
using System.Threading.Tasks;


public class ParcialController : Controller
{
    private readonly ApplicationDbContext _context;

    public ParcialController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Acción para mostrar la lista de usuarios
    public async Task<IActionResult> Index()
    {
        var usuarios = await _context.Parcial.ToListAsync();
        return View(usuarios);
    }

    // Acción para mostrar los detalles de un usuario por su DNI
    public async Task<IActionResult> Details(int? DNI)
    {
        if (DNI == null)
        {
            return NotFound();
        }

        var usuario = await _context.Parcial.FirstOrDefaultAsync(u => u.DNI == DNI);

        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // Acción para mostrar el formulario de creación
    public IActionResult Create()
    {
        return View();
    }

    // Acción para guardar un nuevo usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DNI,Nombre,Apellidos")] Parcial parcial)
    {
        if (ModelState.IsValid)
        {
            _context.Add(parcial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(parcial);
    }

    // Acción para mostrar el formulario de edición por DNI
    public async Task<IActionResult> Edit(int? DNI)
    {
        if (DNI == null)
        {
            return NotFound();
        }

        var usuario = await _context.Parcial.FindAsync(DNI);

        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // Acción para actualizar los datos de un usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int DNI, [Bind("DNI,Nombre,Apellidos")] Parcial parcial)
    {
        if (DNI != parcial.DNI)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(parcial);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(parcial.DNI))
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
        return View(parcial);
    }

    // Acción para mostrar el formulario de eliminación por DNI
    public async Task<IActionResult> Delete(int? DNI)
    {
        if (DNI == null)
        {
            return NotFound();
        }

        var usuario = await _context.Parcial.FirstOrDefaultAsync(u => u.DNI == DNI);

        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // Acción para eliminar un usuario
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int DNI)
    {
        var usuario = await _context.Parcial.FindAsync(DNI);
        _context.Parcial.Remove(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UsuarioExists(int DNI)
    {
        return _context.Parcial.Any(e => e.DNI == DNI);
    }
}
