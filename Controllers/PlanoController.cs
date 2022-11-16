using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
namespace Cemidex_BD.Controllers;

public class PlanoController : Controller
{

    private readonly DataContext _db;

    public PlanoController(DataContext db)
    {
        _db = db;
    }


    [HttpGet]
    public IActionResult Index()
    {

        ViewBag.PlanosFunebres = _db.PlanoFunebres.AsNoTracking().ToList();
        return View(new PlanoFunebre());
    }

    [HttpPost]
    public IActionResult Index(PlanoFunebre plano)
    {
        if (!ModelState.IsValid)
            return View(plano);

        _db.PlanoFunebres.Add(plano);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Deletar(PlanoFunebre plano)
    {

        var planoOriginal = _db.PlanoFunebres.Find(plano.IDPlano);
        if (plano is null)
        {
            return RedirectToAction("Index");
        }

        _db.PlanoFunebres.Remove(planoOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(PlanoFunebre plano)
    {
        var originalPlano = _db.PlanoFunebres.Find(plano.IDPlano);
        if (originalPlano is null)
        {
            return RedirectToAction("Index");
        }      
        originalPlano.Nome = plano.Nome;
        originalPlano.Descricao = plano.Descricao;
        if(originalPlano.Preco != plano.Preco){
            originalPlano.Preco = plano.Preco;
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}