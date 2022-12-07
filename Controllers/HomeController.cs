using Microsoft.AspNetCore.Mvc;
using Cemidex_BD.Models;
using Cemidex_BD.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using static BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace Cemidex_BD.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _db;

    private readonly IWebHostEnvironment _env;

    public HomeController(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }


    public IActionResult Index()
    {
        var memoriais =  _db.Memorials.Include(m => m.Falecido).AsNoTracking().ToList();
        return View(memoriais);
    }

    public IActionResult Contato()
    {
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        var login = new LoginViewModel();
        return View(login);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
    {
        // Verifico se o formulário de login foi preenchido corretamento
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        // Capturo o aluno com email informado em login
        var adm = _db.Administradores.FirstOrDefault(a => a.Email == login.Email);
        // Se não encontrou um aluno com o email informado...
        if (adm is null)
        {
            ModelState.AddModelError("Email", "Administrador não encontrado.");
            return View(login);
        }

        // verifica se a senha digitada no login corresponde á senha hash cadastrada no BD
        var verificado = Verify(login.Senha, adm.Senha);

        // cria um objeto com os dados que serão armazenados no cookie
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, adm.Email),
            new Claim(ClaimTypes.Name, adm.Nome),
            adm.Gerente ? new Claim(ClaimTypes.Role, "gerente") : null,
        };

        // cria um objeto identidade com o mecanismo de autenticação do ASP.NET a partir dos dados informados no código anterior
        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // configura opções dessa seção de login
        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,

            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20),

            IsPersistent = login.Lembrar,
        };

        // cria o cookie de login com todas as configurações a cima no padrão do ASP.NET
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                    authProperties);

        Console.WriteLine($"Administrador {adm.Email} logou às {DateTime.Now}.");

        // Redireciona a pagina que o usuario tentou acessar, por padrão ele é nulo
        if (returnUrl is null)
        {
            return RedirectToAction(nameof(Index)); // pagina principal da aplicação
        }

        return Redirect(returnUrl);
    }

    [Authorize] // proibe acesso anonimo à pagina
    public IActionResult AreaRestrita()
    {
        return View();
    }

    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        if (returnUrl is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return Redirect(returnUrl);
    }

    public IActionResult Menu()
    {
        return View();
    }
}
