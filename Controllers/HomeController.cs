using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Models;

namespace Cemidex_BD.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    } 

    public IActionResult Contato()
    {
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Menu()
    {
        return View();
    }
}
