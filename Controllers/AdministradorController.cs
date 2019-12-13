using ROLETOP.Repositories;
using ROLETOP.ViewModels;
using ROLETOP.Enums;
using Microsoft.AspNetCore.Mvc;
using ROLETOP.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace ROLETOP.Controllers {
    public class AdministradorController : AbstractController {
         
         AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
         EventoRepository eventoRepository = new EventoRepository();


        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Dashboard",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpGet]
         public IActionResult Dashboard()
         {
             var tipoUsuarioSessao = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            //  var tipoUsuarioSessao = uint.Parse(ObterUsuarioTipoSession());

             if(!tipoUsuarioSessao && (uint) TipoUsuarios.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
             {
                 var agendas = agendamentoRepository.ObterTodos();
             
                 DashboardViewModel dashboardViewModel = new DashboardViewModel();

                 foreach(var agenda in agendas)
                 {
                     switch(agenda.Status)
                     {
                         case (uint) StatusAgendamento.ACEITO:
                         dashboardViewModel.AgendamentoAceitos++;
                         break;
                         case (uint) StatusAgendamento.REPROVADO:
                         dashboardViewModel.AgendamentoReprovado++;
                         break;
                         default:
                         dashboardViewModel.AgendamentoPendente++;
                         dashboardViewModel.Agendamento.Add(agenda);
                         break;
                     }
                 }
                 dashboardViewModel.NomeView = "Dashboard";
                 dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

                 return View(dashboardViewModel);
             }

             return View("Erro", new MensagemViewModel()
             {
                NomeView = "Dashboard",
                MensagemRetorno = "Você não tem permissão"
             });
         }
    }
}

