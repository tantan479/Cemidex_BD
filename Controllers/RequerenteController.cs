using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
namespace Cemidex_BD.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RequerenteController : Controller
{

    private readonly DataContext _db;

    public RequerenteController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        CarregarPlanos();
        ViewBag.Planos = _db.PlanoFunebres.AsNoTracking().ToList();
        ViewBag.Requerentes = _db.Requerentes.AsNoTracking().ToList();
        return View(new Requerente());
    }

    [HttpPost]
    public IActionResult Index(Requerente requerente)
    {
        if (!ModelState.IsValid)
            return View(requerente); 

        _db.Requerentes.Add(requerente);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Deletar(Requerente requerente)
    {

        var requerenteOriginal = _db.Requerentes.Find(requerente.IdRequerente);
        if (requerente is null)
        {
            return RedirectToAction("Index");
        }

        _db.Requerentes.Remove(requerenteOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(Requerente requerente)
    {
        var originalRequerente = _db.Requerentes.Find(requerente.IdRequerente);
        if (originalRequerente is null)
        {
            return RedirectToAction("Index");
        }      
        originalRequerente.Nome = requerente.Nome;

        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    private void CarregarPlanos(int? idPlanoSelecionado = null)
    {
        var planos = _db.PlanoFunebres.AsNoTracking().OrderBy(p => p.Nome).ToList();
        var selectPlanos = new SelectList(planos, "IDPlano", "Nome", idPlanoSelecionado);
        ViewBag.SelectPlanos = selectPlanos;
    }

}