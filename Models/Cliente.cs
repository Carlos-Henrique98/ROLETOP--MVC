using System;
using ROLETOP.Enums;

namespace ROLETOP.Models
{
    public class Cliente 
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public uint TipoUsuarios { get; set; }
      
        public Cliente()
        {

        }

        public Cliente(string nome, string email, string senha, string cpf, string cnpj) 
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.CPF = cpf;
            this.CNPJ = cnpj;
        }
    }
}