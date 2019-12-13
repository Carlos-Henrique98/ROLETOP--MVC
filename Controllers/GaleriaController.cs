using System;
using Microsoft.AspNetCore.Mvc;
using ROLETOP.ViewModels;

namespace ROLETOP.Controllers
{
    public class GaleriaController : AbstractController
    {
         public IActionResult Index() {
            return View (new BaseViewModel () {
                NomeView = "Galeria",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
        }
    }
}