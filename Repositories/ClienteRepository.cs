using System;
using System.Collections.Generic;
using System.IO;
using ROLETOP.Models;

namespace ROLETOP.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        //Dois Metodos que inserem dados do cliente
        //InserirCadastro = Inserir
        //ObterRegistroCLiente = ObterPor
        //INSERIR DADOS NO CADASTRO DO CLIENTE
        public bool InserirCadastro(Cliente cliente)
        {
            var inserirLinha = new string[] {PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH, inserirLinha);

            return true;
        }

        //METODO ObterPor
        public Cliente ObterRegistroCliente(string email)
        {
            var lerLinhas = File.ReadAllLines(PATH);
            foreach(var lerdado in lerLinhas)
            {
                if(ExtrairValorDoCampo("email", lerdado).Equals(email))
                {
                    Cliente registrar = new Cliente();
                    registrar.Nome = ExtrairValorDoCampo("nome", lerdado);
                    registrar.Email = ExtrairValorDoCampo("email",lerdado);
                    registrar.Senha = ExtrairValorDoCampo("senha", lerdado);
                    registrar.CPF = ExtrairValorDoCampo("cpf", lerdado);
                    registrar.CNPJ = ExtrairValorDoCampo("cnpj", lerdado);

                    registrar.TipoUsuarios = uint.Parse(ExtrairValorDoCampo("tipo_usuario", lerdado));
                    return registrar;
                }
            }
                return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo_usuario={cliente.TipoUsuarios};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};cpf={cliente.CPF};cnpj={cliente.CNPJ};";
        }
            
    }
}