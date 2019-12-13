using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using ROLETOP.Models;
using ROLETOP.ViewModels;
using ROLETOP.Repositories;
using Microsoft.AspNetCore.Http;

namespace ROLETOP.Controllers
{
    public class EventoController : AbstractController
    {
        EventoRepository eventoRepository = new EventoRepository();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();

        [HttpGet]
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Evento",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        
        [HttpPost]
        public IActionResult AgendarEvento(IFormCollection form)
        {
            ViewData["Action"] = "Evento";

            Agendamento agendamento = new Agendamento();
            ClienteRepository clienteRepository =  new ClienteRepository();
        
            var cliente = clienteRepository.ObterRegistroCliente(ObterUsuarioSession());


            Evento evento = new Evento()
            {
                NomeEvento = form["tipo_evento"],
                DataEvento = form["data_evento"],
                QtdPessoas = int.Parse(form["qtdpessoas"])
            };

            agendamento.Evento = evento;
            agendamento.Cliente = cliente;


            if (agendamentoRepository.InserirEvento(agendamento))
            {
                return RedirectToAction("Historico","Cliente");
                // return View("Sucesso", new MensagemViewModel()
                // {
                //     NomeView = "Evento",
                //     UsuarioEmail = ObterUsuarioSession(),
                //     UsuarioNome = ObterUsuarioNomeSession()

                // });
            }
            else
            {
                return View("Erro", new MensagemViewModel()
                {
                    NomeView = "Evento",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}