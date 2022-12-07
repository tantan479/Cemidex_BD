using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Models;
using Cemidex_BD.Data;
using Microsoft.EntityFrameworkCore;
namespace Cemidex_BD.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

public class JazigoController : Controller
{

    private readonly DataContext _db;

    public JazigoController(DataContext db)
    {
        _db = db;
    }

    [HttpGet][Authorize]
    public IActionResult Detalhes(int id)
    {
        
        var dbsepultamentos = _db.Sepultamentos.AsNoTracking().ToList();
        var sepultamentos = dbsepultamentos.FindAll(s => s.IDJazigo == id);

        List<Falecido> falecidos = new List<Falecido>();
        
        foreach (var sep in sepultamentos)
        {
            var dbfalecido = _db.Falecidos.AsNoTracking().ToList();
            var falecido = dbfalecido.Find(f => f.IDFalecido == sep.IDFalecido);
            falecidos.Add(falecido);
        }

        var dblocal = _db.Localizacaos.AsNoTracking().ToList();
        var local = dblocal.Find(l => l.IDLocal == (_db.Jazigos.AsNoTracking().ToList()).Find(j => j.IDJazigo == id).IDLocal);
        var nomelocal = local.Nome;

        ViewBag.Falecidos = falecidos;
        ViewBag.Local = nomelocal;

        
        return View(id);
    }
}