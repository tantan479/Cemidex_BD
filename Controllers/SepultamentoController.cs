using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Cemidex_BD.Controllers;

public class SepultamentoController : Controller
{
    private readonly DataContext _db;

    public SepultamentoController(DataContext db)
    {
        _db = db;
    }

    [HttpGet][Authorize]
    public IActionResult Index()
    {

        var jazigo = _db.Jazigos.AsNoTracking().OrderBy(j => j.IDJazigo).ToList();
        var falecidos = _db.Falecidos.AsNoTracking().OrderBy(f => f.IDFalecido).ToList();
        var sepultamento = _db.Sepultamentos.AsNoTracking().OrderBy(s => s.IDSepultamento).ToList();

        ViewBag.Jazigo = jazigo;
        ViewBag.Falecido = falecidos;
        ViewBag.Sepultamento = sepultamento;

        return View();
    }
}
