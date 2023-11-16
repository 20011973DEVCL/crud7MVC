using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crud7MVC.Models;
using MagicVilla.Datos;
using Microsoft.EntityFrameworkCore;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
