using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROLETOP.Enums;
using ROLETOP.Models;
using ROLETOP.Repositories;
using ROLETOP.ViewModels;

namespace ROLETOP.Controllers
{
    public class AgendamentoController : AbstractController
    {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        EventoRepository eventoRepository = new EventoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index()
        {
            AgendamentoViewModel agenda = new AgendamentoViewModel();
            agenda.Agendamento = agendamentoRepository.ObterTodos();

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if (!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                agenda.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterRegistroCliente(usuarioLogado);

            if (clienteLogado != null)
            {
                agenda.Cliente = clienteLogado;
            }

            agenda.NomeView = "Agenda";
            agenda.UsuarioEmail = usuarioLogado;
            agenda.UsuarioNome = nomeUsuarioLogado;

            return View(agenda);

        }

          public IActionResult Aceitar(ulong id)
        {
            Agendamento agendamento = agendamentoRepository.ObterPor(id);
            agendamento.Status = (uint) StatusAgendamento.ACEITO;

            if(agendamentoRepository.Atualizar(agendamento))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else {
                return View("Erro", new MensagemViewModel()
                {
                    MensagemRetorno = "ERRO NO AGENDAMENTO.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                    
                });
            }
        }

        public IActionResult Reprovar(ulong id)
        {
            Agendamento agenda = agendamentoRepository.ObterPor(id);
            agenda.Status = (uint) StatusAgendamento.REPROVADO;
     
            if(agendamentoRepository.Atualizar(agenda))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else {
                return View("Erro", new MensagemViewModel()
                {
                    MensagemRetorno = "ERRO NO AGENDAMENTO.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                    
                });
            }
        }
    }
}