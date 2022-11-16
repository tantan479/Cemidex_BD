using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cemidex_BD.Controllers;

public class FalecidoController : Controller
{
    private readonly DataContext _db;

    public FalecidoController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {

        var requerentes = _db.Requerentes.AsNoTracking().OrderBy(p => p.Nome).ToList();
        var selectRequerentes = new SelectList(requerentes, "IdRequerente", "Nome");
        ViewBag.Requerentes = selectRequerentes;


        var jazigos = _db.Jazigos.AsNoTracking().ToList();
        var selectJazigos = new SelectList(jazigos, "IDJazigo", "IDLocal");
        ViewBag.Jazigos = selectJazigos;

        ViewBag.Sepultamento = new Sepultamento();

        ViewBag.Falecidos = _db.Falecidos.AsNoTracking().ToList();
        ViewBag.Sepultamentos = _db.Sepultamentos.AsNoTracking().ToList();
        ViewBag.dbrequerentes = _db.Requerentes.AsNoTracking().ToList();
        
        return View(new Falecido());
    }

    [HttpPost]
    public IActionResult Index(Falecido falecido, int sepultamento1, int sepultamento2)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var sepultamento = new Sepultamento();

        sepultamento.IDJazigo = sepultamento1;
        sepultamento.IDRequerente = sepultamento2;




        _db.Falecidos.Add(falecido);
        _db.SaveChanges();
        sepultamento.IDFalecido = _db.Falecidos.Max(f => f.IDFalecido);
        _db.Sepultamentos.Add(sepultamento);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Deletar(Falecido falecido)
    {

        var falecidoOriginal = _db.Falecidos.Find(falecido.IDFalecido);
        if (falecido is null)
        {
            return RedirectToAction("Index");
        }


        var sepultamento = _db.Sepultamentos.ToList().Find(s => s.IDFalecido == falecido.IDFalecido);

        var sepultamentoOriginal = _db.Sepultamentos.Find(sepultamento.IDSepultamento);

        _db.Falecidos.Remove(falecidoOriginal);
        _db.Sepultamentos.Remove(sepultamentoOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(Falecido falecido, int sepultamento1, int sepultamento2)
    {
        var originalFalecido = _db.Falecidos.Find(falecido.IDFalecido);
        var originalsepultalmentolist = _db.Sepultamentos.ToList().Find(sepultamento => sepultamento.IDFalecido == falecido.IDFalecido);

        var originalsepultalmento = _db.Sepultamentos.Find(originalsepultalmentolist.IDSepultamento);

        if (originalFalecido is null)
        {
            return RedirectToAction("Index");
        }

        originalsepultalmento.IDJazigo = sepultamento1;
        originalsepultalmento.IDRequerente = sepultamento2;
        originalFalecido.Nome = falecido.Nome;
        originalFalecido.NomeMae = falecido.NomeMae;
        originalFalecido.NomePai = falecido.NomePai;
        originalFalecido.DataNascimento = falecido.DataNascimento;
        originalFalecido.TempoEnterro = falecido.TempoEnterro;
        originalFalecido.Sexo = falecido.Sexo;
        originalFalecido.EstadoCivil = falecido.EstadoCivil;
        originalFalecido.RegistroObito = falecido.RegistroObito;
        originalFalecido.CertidaoObito = falecido.CertidaoObito;
        originalFalecido.DataObito = falecido.DataObito;

        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}