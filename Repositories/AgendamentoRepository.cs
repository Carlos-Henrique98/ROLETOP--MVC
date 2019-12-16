using System;
using System.Collections.Generic;
using System.IO;
using ROLETOP.Models;


namespace ROLETOP.Repositories
{
    public class AgendamentoRepository : RepositoryBase
    {
        private const string PATH = "Database/Agendamento.csv";

        public AgendamentoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        //Inserir() = InserirEvento()
        public bool InserirEvento(Agendamento agenda)
        {
            var quantidadeEventos = File.ReadAllLines(PATH).Length;
            agenda.Id = (ulong) ++quantidadeEventos;
            var linha = new string[] {PrepararEventoCSV(agenda)};
            File.AppendAllLines(PATH,linha);

            return true;
        }

        public List<Agendamento> ObterTodosPorCliente(String email)
        {
            var agendamentos = ObterTodos();
            List<Agendamento> agendamentosCliente = new List<Agendamento>();

            foreach(var agendamento in agendamentos)
            {
                if(agendamento.Cliente.Email.Equals(email))
                {
                    agendamentosCliente.Add(agendamento);
                }
            }
            return agendamentosCliente;
        }

        // ObterPor() = VerificarID()
        // AgendamentoRepository = PedidoRepository()
        // ObterTodos() = ObterEventos()
       
        public Agendamento ObterPor(ulong id)
        {
            var eventosTotais = ObterTodos();
            foreach(var evento in eventosTotais)
            {
                if(evento.Id == id)
                {
                    return evento;
                }
            }
            return null;
        }

        public List<Agendamento> ObterTodos()
        {
            var lerLinhas = File.ReadAllLines(PATH);
            List<Agendamento> agenda = new List<Agendamento>();

            foreach(var lerLinha in lerLinhas)
            {
                Agendamento agendas = new Agendamento();

                agendas.Id = ulong.Parse(ExtrairValorDoCampo("id", lerLinha));        
                agendas.Status = uint.Parse(ExtrairValorDoCampo("status_evento", lerLinha));
                agendas.Evento.NomeEvento = ExtrairValorDoCampo("tipo_evento", lerLinha);
                agendas.Evento.DataEvento = ExtrairValorDoCampo("data_evento", lerLinha);
                agendas.Evento.QtdPessoas = int.Parse(ExtrairValorDoCampo("qtdpessoas", lerLinha));
                agendas.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", lerLinha);
                agendas.Cliente.Email = ExtrairValorDoCampo("cliente_email", lerLinha);
                agendas.Cliente.Senha = ExtrairValorDoCampo("cliente_senha", lerLinha);
                agendas.Cliente.CPF = ExtrairValorDoCampo("cliente_cpf", lerLinha);
                agendas.Cliente.CNPJ = ExtrairValorDoCampo("cliente_cnpj", lerLinha);
                agendas.Cliente.TipoUsuarios = uint.Parse(ExtrairValorDoCampo("cliente_tipoUsuarios", lerLinha));
                
                agenda.Add(agendas);
            }

            return agenda;
        }


            public bool Atualizar(Agendamento agendamento)
            {
            
            var pedidosTotais = File.ReadAllLines(PATH);
           
            var pedidoCSV = PrepararEventoCSV(agendamento);
           
            var linhaPedido = -1;
            var resultado = false;

            for (int i = 0; i < pedidosTotais.Length; i++)
            {
   
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id",pedidosTotais[i]));
                if (agendamento.Id.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado){
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
            }

            return resultado;
        }
        private string PrepararEventoCSV(Agendamento agendas)
        {
            Cliente c = agendas.Cliente;
            Evento e = agendas.Evento;
            return $"id={agendas.Id};status_evento={agendas.Status};tipo_evento={e.NomeEvento};data_evento={e.DataEvento};qtdpessoas={e.QtdPessoas};cliente_nome={c.Nome};cliente_email={c.Email};cliente_senha={c.Senha};cliente_cpf={c.CPF};cliente_cnpj={c.CNPJ};cliente_tipoUsuarios={c.TipoUsuarios};";
        }
    }
}