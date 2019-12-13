using System;
using ROLETOP.Enums;

namespace ROLETOP.Models {
    public class Agendamento 
    {
        public ulong Id { get; set; }
        public Cliente Cliente {get; set;}
        public Evento Evento { get; set; }
        public uint Status { get; set; }

        public Agendamento () {
            this.Cliente = new Cliente();
            this.Evento = new Evento ();
            this.Id = 0;
            this.Status = (uint) StatusAgendamento.PENDENTE;
      
          
        }
    }
}