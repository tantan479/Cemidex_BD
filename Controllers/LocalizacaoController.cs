using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Cemidex_BD.Controllers;

public class LocalizacaoController : Controller
{

    private readonly DataContext _db;

    public LocalizacaoController(DataContext db)
    {
        _db = db;
    }


    [HttpGet][Authorize]
    public IActionResult Index()
    {

        ViewBag.Localizacoes = _db.Localizacaos.AsNoTracking().ToList();
        return View(new Localizacao());
    }

    [HttpPost][Authorize]
    public IActionResult Index(Localizacao localizacao)
    {
        if (!ModelState.IsValid)
            return View(localizacao);

        _db.Localizacaos.Add(localizacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost][Authorize]
    public IActionResult Deletar(Localizacao localizacao)
    {

        var localizacaoOriginal = _db.Localizacaos.Find(localizacao.IDLocal);
        if (localizacao is null)
        {
            return RedirectToAction("Index");
        }

        _db.Localizacaos.Remove(localizacaoOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost][Authorize]
    public IActionResult Editar(Localizacao localizacao)
    {
        var originalLocalizacao = _db.Localizacaos.Find(localizacao.IDLocal);
        if (originalLocalizacao is null)
        {
            return RedirectToAction("Index");
        }       
        originalLocalizacao.Nome = localizacao.Nome;
        originalLocalizacao.Descricao = localizacao.Descricao;

        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}