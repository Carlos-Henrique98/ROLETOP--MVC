using System.Collections.Generic;
using ROLETOP.Models;

namespace ROLETOP.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamento {get;set;}
        public uint AgendamentoAceitos { get; set; }
        public uint AgendamentoReprovado { get; set; }
        public uint AgendamentoPendente { get; set; }

        public DashboardViewModel()
        {
            this.Agendamento = new List<Agendamento>();
        }

        
    }
}