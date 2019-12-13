using System.Collections.Generic;
using ROLETOP.Models;

namespace ROLETOP.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamento {get; set;}
        public string NomeUsuario { get; set; }
        public Cliente Cliente { get; set; }

        public AgendamentoViewModel()
        {
            this.Agendamento = new List<Agendamento>();
            this.Cliente = new Cliente();
        }
    }
}