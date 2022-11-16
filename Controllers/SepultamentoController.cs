using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cemidex_BD.Controllers;

public class SepultamentoController : Controller
{
    private readonly DataContext _db;

    public SepultamentoController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
