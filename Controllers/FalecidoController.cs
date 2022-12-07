using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Data;
using Cemidex_BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using Microsoft.AspNetCore.Authorization;

namespace Cemidex_BD.Controllers;

public class FalecidoController : Controller
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _env;

    public FalecidoController(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    [HttpGet][Authorize]
    public IActionResult Index()
    {

        var requerentes = _db.Requerentes.AsNoTracking().OrderBy(p => p.Nome).ToList();
        var selectRequerentes = new SelectList(requerentes, "IdRequerente", "Nome");
        ViewBag.Requerentes = selectRequerentes;


        var jazigos = _db.Jazigos.AsNoTracking().ToList();
        var selectJazigos = new SelectList(jazigos, "IDJazigo", "IDJazigo");
        ViewBag.Jazigos = selectJazigos;

        ViewBag.Sepultamento = new Sepultamento();

        ViewBag.Falecidos = _db.Falecidos.AsNoTracking().ToList();
        ViewBag.Sepultamentos = _db.Sepultamentos.AsNoTracking().ToList();
        ViewBag.dbrequerentes = _db.Requerentes.AsNoTracking().ToList();

        return View(new Falecido());
    }

    [HttpPost][Authorize]
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
        if(_db.SaveChanges() > 0)
        {
            var caminhoArquivoImagem = $"{_env.WebRootPath}//img//falecido//{falecido.IDFalecido.ToString("D6")}.jpg";
            SalvarUploadImagemAsync(caminhoArquivoImagem, falecido.ArquivoImagem).Wait();
        }
        sepultamento.IDFalecido = _db.Falecidos.Max(f => f.IDFalecido);
        _db.Sepultamentos.Add(sepultamento);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost][Authorize]
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

    [HttpPost][Authorize]
    public IActionResult Editar(Falecido falecido)
    {
        var originalFalecido = _db.Falecidos.Find(falecido.IDFalecido);
        var originalsepultalmentolist = _db.Sepultamentos.ToList().Find(sepultamento => sepultamento.IDFalecido == falecido.IDFalecido);

        var originalsepultalmento = _db.Sepultamentos.Find(originalsepultalmentolist.IDSepultamento);

        if (originalFalecido is null)
        {
            return RedirectToAction("Index");
        }

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
        if(falecido.ArquivoImagem != null)
        {
            var caminhoArquivoImagem = $"{_env.WebRootPath}//img//falecido//{falecido.IDFalecido.ToString("D6")}.jpg";
            SalvarUploadImagemAsync(caminhoArquivoImagem, falecido.ArquivoImagem).Wait();
        }
        return RedirectToAction("Index");
    }

    [HttpGet][Authorize]
    public IActionResult Detalhar(int id)
    {

        var dbfalecidos = _db.Falecidos.AsNoTracking().ToList();
        var falecido = dbfalecidos.Find(f => f.IDFalecido == id);

        return View(falecido);
    }

    public async Task<bool> SalvarUploadImagemAsync(
        string caminhoArquivoImagem, IFormFile imagem, bool salvarQuadrada = true)
    {
        if (imagem is null)
        {
            return false;
        }
        var ms = new MemoryStream();
        await imagem.CopyToAsync(ms);
        ms.Position = 0;
        var img = await Image.LoadAsync(ms);

        if (salvarQuadrada)
        {
            var tamanho = img.Size();
            var ladoMenor = (tamanho.Height < tamanho.Width) ? tamanho.Height : tamanho.Width;
            img.Mutate(x =>
                x.Resize(new ResizeOptions
                {
                    Size = new Size(ladoMenor, ladoMenor),
                    Mode = ResizeMode.Crop
                }).BackgroundColor(new Rgba32(255, 255, 255, 0)));
        }

        await img.SaveAsJpegAsync(caminhoArquivoImagem);
        return true;
    }
}