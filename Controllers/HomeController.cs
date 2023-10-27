#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rivera_Mauricio_ASPCore_EDojVa.Models;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Rivera_Mauricio_ASPCore_EDojVa.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public static Dictionary<string, string> datosNinja = new Dictionary<string, string>();

    public List<string> ubicacion = new List<string>()
            {
                "Valparaíso",
                "Viña del Mar",
                "Santiago"
            };

    public List<string> languages = new List<string>()
            {
                "CSharp",
                "Java",
                "SQL"
            };

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.Localizacion = ubicacion;
        ViewBag.Lenguajes = languages;

        return View();
    }

    [HttpPost("")]
    public IActionResult Index(Usuario ninja)
    {
        ViewBag.Localizacion = ubicacion;
        ViewBag.Lenguajes = languages;

        if (ModelState.IsValid)
        {
            datosNinja.Add("Nombre", ninja.Nombre);
            datosNinja.Add("Ubicacion", ninja.Ubicacion);
            datosNinja.Add("Lenguaje", ninja.Lenguaje);
            datosNinja.Add("Comentario", ninja.Comentario);

            foreach (var dato in datosNinja)
            {
                if (dato.Value == "Nombre")
                {
                    ninja.Nombre = dato.Value;
                }
                else if (dato.Value == "Ubicacion")
                {
                    ninja.Ubicacion = dato.Value;
                }
                else if (dato.Value == "Lenguaje")
                {
                    ninja.Lenguaje = dato.Value;
                }
                else if (dato.Value == "Comentario")
                {
                    ninja.Comentario = dato.Value;
                }
            }

            return RedirectToAction("Resultado", ninja);
        }
        else
        {
            return View("Index", ninja);
        }
    }

    [HttpGet("resultado")]
    public IActionResult Resultado(Usuario ninja)
    {
        ViewBag.Datos = datosNinja;

        return View("resultado", ninja);
    }

    [HttpPost("resultado")]
    public IActionResult Resultado(Usuario ninja, string valor = "")
    {
        datosNinja.Clear();

        ninja.Nombre = valor;

        return RedirectToAction("Index");
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
