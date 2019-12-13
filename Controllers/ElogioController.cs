using Microsoft.AspNetCore.Mvc;
using ROLETOP.ViewModels;

namespace ROLETOP.Controllers
{
    public class ElogiosController : AbstractController
    {
          public IActionResult Index() {
            return View (new BaseViewModel () {
                NomeView = "Elogio",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
        }
    }
}