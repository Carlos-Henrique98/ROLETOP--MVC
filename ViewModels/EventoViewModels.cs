using System;
using System.Collections.Generic;
using ROLETOP.Models;

namespace ROLETOP.ViewModels
{
    public class EventoViewModels : BaseViewModel
    {
        public List<Evento> Eventos { get; set; }
        public string DateEvento{ get; set; }
        public int QtdPessoas { get; set; }

        public EventoViewModels()
        {
            this.Eventos = new List<Evento>();
            
        }
    }
}