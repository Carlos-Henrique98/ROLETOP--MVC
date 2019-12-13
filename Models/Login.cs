using Microsoft.Extensions.Primitives;

namespace ROLETOP.Models
{
    public class Login
    {
        public string EmailLogin { get; set; }
        public string Senha { get; set; }

        public Login()
        {

        }

        public Login(string emaillogin,string senha)
        {
            this.EmailLogin = emaillogin;
            this.Senha = senha;
        }
    }
}