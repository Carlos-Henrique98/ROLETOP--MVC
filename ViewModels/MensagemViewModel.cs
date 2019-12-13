namespace ROLETOP.ViewModels
{
    public class MensagemViewModel : BaseViewModel
    {   
        public string MensagemRetorno {get;set;}

        public MensagemViewModel()
        {

        }

        public MensagemViewModel(string mensagemretorno)
        {
            this.MensagemRetorno = mensagemretorno;
        }
    }
}