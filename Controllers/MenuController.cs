using System;
using Microsoft.AspNetCore.Mvc;
using ROLETOP.ViewModels;

namespace ROLETOP.Controllers
{
    public class MenuController : AbstractController
    {
        public IActionResult Menu()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Menu",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

       
    }
}