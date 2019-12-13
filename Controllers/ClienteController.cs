using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROLETOP.Repositories;
using ROLETOP.ViewModels;
using ROLETOP.Enums;
using ROLETOP.Models;

namespace ROLETOP.Controllers {
    public class ClienteController : AbstractController {

        private ClienteRepository clienteRepository = new ClienteRepository();
        private EventoRepository eventoRepository = new EventoRepository();
        private AgendamentoRepository agendamentoRepository = new AgendamentoRepository();

        [HttpGet]
        public IActionResult Login() {
            return View (new BaseViewModel () {
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form) 
        {
            ViewData["Action"] = "Login";

            try
            {
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);

                var usuarioCliente = form["email"];
                var senhaCliente = form["senha"];

                var cliente = clienteRepository.ObterRegistroCliente(usuarioCliente);

                if(cliente != null)
                {
                    if(cliente.Senha.Equals(senhaCliente))
                    {
                        switch(cliente.TipoUsuarios)
                        {
                            //cliente = 1
                            //administrador = 0
                            case (uint) TipoUsuarios.CLIENTE:

                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL,usuarioCliente);
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME,cliente.Nome);
                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuarios.ToString());
                            return RedirectToAction("Index","Evento");
                           
                            //QUANDO LOGA ELE VAI DIRETO PARA O DEFAULT
                            default:
                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL,usuarioCliente);
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuarios.ToString());
                            return RedirectToAction("Dashboard","Administrador");
                        }
                        
                    }
                    else
                    {
                        return View("Erro", new MensagemViewModel("Senha Incorreta"));
                    }
                }
                else
                {
                    return View("Erro", new MensagemViewModel($"Usuário {usuarioCliente} não encontrado"));
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro",new MensagemViewModel(e.Message));
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();

            var agendasCliente = agendamentoRepository.ObterTodosPorCliente(emailCliente);
            
            return View(new HistoricoViewModel()
            {
                Agendamentos = agendasCliente,
                NomeView = "Historico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }

}