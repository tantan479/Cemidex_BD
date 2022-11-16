using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cemidex_BD.Controllers;

public class TransferenciaController : Controller
{
    private readonly DataContext _db;

    public TransferenciaController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Tranferencias = _db.Transferencias.AsNoTracking().ToList();
        
        var jazigos = _db.Jazigos.AsNoTracking().OrderBy(j => j.IDJazigo).ToList();
        var selectJazigos = new SelectList(jazigos, "IDJazigo", "IDJazigo");
        ViewBag.Jazigos = selectJazigos;
        
        var administradores = _db.Administradores.AsNoTracking().OrderBy(a => a.Nome).ToList();
        var selectadm = new SelectList(administradores, "IDAdministrador", "Nome");
        ViewBag.Administradores = selectadm;
        ViewBag.AdministradoresList = _db.Administradores.AsNoTracking().ToList();
        return View(new Transferencia());
    }

    [HttpPost]
    public IActionResult Index(Transferencia transferencia)
    {
        
        var sepultamento = _db.Sepultamentos.ToList().FindAll(s => s.IDJazigo == transferencia.IDJazigo1);
        var sepultamento2 = _db.Sepultamentos.ToList().Find(s => s.IDJazigo == transferencia.IDJazigo1);

        transferencia.IDSepultamento = sepultamento2.IDSepultamento;
        
        foreach (var item in sepultamento)
        {
            item.IDJazigo = transferencia.IDJazigo2;
        }

        
        List<int> id = new List<int>();

        foreach (var item in sepultamento)
        {
            id.Add(item.IDSepultamento);
        }
        

        transferencia.IDS = String.Join(" ", id);

        _db.Transferencias.Add(transferencia);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
