using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cemidex_BD.Controllers;

public class MemorialController : Controller
{
    private readonly DataContext _db;

    public MemorialController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var memoriais =  _db.Memorials.Include(m => m.Falecido).AsNoTracking().ToList();
        return View(memoriais);
    }

    public IActionResult Detalhes(int id)
    {

        ViewBag.Memoria =  _db.Memorials.AsNoTracking().ToList();
        ViewBag.ID = id;
        ViewBag.Falecido = _db.Falecidos.AsNoTracking().ToList();
        return View();
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        CarregarFalecidos();
        var m = new Memorial();
        return View(m);
    }

    
    private void CarregarFalecidos(int? idFalecidoSelecionado = null)
    {
        var falecidos = _db.Falecidos.AsNoTracking().OrderBy(f => f.Nome).ToList();
        var selectFalecidos = new SelectList(falecidos, "IDFalecido", "Nome", idFalecidoSelecionado);
        ViewBag.selectFalecidos = selectFalecidos;
    }

    [HttpPost]
    public IActionResult Cadastro(Memorial memorial)
    {
        _db.Memorials.Add(memorial);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Alterar(int id)
    {
        var m = _db.Memorials.Find(id);
        if (m is null)
            return RedirectToAction("Index");
        return View(m);
    }

    [HttpPost]
    public IActionResult Alterar(int id, Memorial memorial)
    {
        var memorialOriginal = _db.Memorials.Find(id);
        if (memorialOriginal is null)
        {
            return RedirectToAction("Index");
        }

        memorialOriginal.IDFalecido =  memorial.IDFalecido;
        memorialOriginal.Descricao = memorial.Descricao;

        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        var m = _db.Memorials.Find(id);
        if (m is null)
            return RedirectToAction("Index");

        return View(m);
    }

    [HttpPost]
    public IActionResult ProcessarExcluir(int id)
    {
        var m = _db.Memorials.Find(id);
        if (m is null)
            return RedirectToAction("Index");

        _db.Memorials.Remove(m);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}