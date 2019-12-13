using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//ADMINISTRADORCONTROLLER = ORGANIZADORCONTROLER
namespace ROLETOP.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_TIPO_USUARIO = "tipo_usuario";

        //ObterUsuarioSession() = substituido por ObterContainerUsuario
        protected string ObterUsuarioSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            if(!string.IsNullOrEmpty(email))
            {
                return email;
            }
            else
            {
                return "";
            }
        }

        //ObterContainerNome() = ObterUsuarioNomeSession()
        protected string ObterUsuarioNomeSession()
        {
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if(!string.IsNullOrEmpty(nome))
            {
                return nome;
            }
            else
            {
                return "";
            }
        }

        //ObterUsuarioTipoSession() = ObterContainerTipo()
        protected string ObterUsuarioTipoSession()
        {
            var usuario = HttpContext.Session.GetString(SESSION_TIPO_USUARIO);
            if(!string.IsNullOrEmpty(usuario))
            {
                return usuario;
            }
            else
            {
                return "";
            }
        }

    
    }
}