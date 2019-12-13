using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ROLETOP.Models;
using ROLETOP.ViewModels;
using ROLETOP.Repositories;
using Microsoft.AspNetCore.Http;

namespace ROLETOP.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        public IActionResult CadastrarCliente(IFormCollection form)
       {
           ViewData["Action"] = "Cadastro";

           try
           {
               Cliente cliente = new Cliente()
               {
                   Nome =  form["nome"],
                   Email = form["email"],
                   Senha = form["senha"],
                   CPF = form["cpf"],
                   CNPJ = form["cnpj"]
               };
               

               clienteRepository.InserirCadastro(cliente);
               
                return View("Sucesso", new MensagemViewModel()
                {
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                    
                });

           }
           catch(Exception e)
           {
               System.Console.WriteLine(e.StackTrace);
               return View("Erro", new MensagemViewModel()
               {
                   NomeView = "Cadastro",
                   UsuarioEmail = ObterUsuarioSession(),
                   UsuarioNome = ObterUsuarioNomeSession()
               });
           }
       }
    }
}