using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crud7MVC.Models;
using MagicVilla.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace crud7MVC.Controllers;

public class InicioController : Controller
{

    private readonly ApplicationDbContext _contexto;

    public InicioController(ApplicationDbContext contexto)
    {
        this._contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _contexto.Contactos.ToListAsync());
    }

    [HttpGet]
    public IActionResult Crear() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Contacto contacto )
    {
        if (ModelState.IsValid)
        {
            _contexto.Contactos.Add(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }
    

    [HttpGet]
    public IActionResult Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contacto= _contexto.Contactos.Find(id);
        if (contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Contacto contacto)
    {
        if (ModelState.IsValid)
        {
            _contexto.Update(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
