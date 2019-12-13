using System.Collections.Generic;
using System.IO;
using ROLETOP.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace ROLETOP.Repositories
{
    public class EventoRepository : RepositoryBase
    {
        private const string PATH = "Database/Evento.csv";

       public List<Evento> ObterTodos()
       {
           List<Evento> evento = new List<Evento>();

            string[] lerLinhas = File.ReadAllLines(PATH);
            foreach(var lerLinha in lerLinhas)
            {
                Evento e = new Evento();
                string[] inform = lerLinha.Split(";");
                e.NomeEvento = inform[0];
            }
           return evento;
       }

       

    }
}