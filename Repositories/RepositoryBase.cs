namespace ROLETOP.Repositories
{
    public class RepositoryBase
    {
        protected string ExtrairValorDoCampo(string nomeCampo, string linha)
        {
            var chave = nomeCampo;
            var indicePalavra = linha.IndexOf(chave);

            var indiceTerminal = linha.IndexOf(";", indicePalavra);
            var valor = "";

            if(indiceTerminal != -1)
            {
                valor = linha.Substring(indicePalavra, indiceTerminal - indicePalavra);
            }
            else
            {
                valor = linha.Substring(indicePalavra);
            }

            System.Console.WriteLine($"Campo {nomeCampo} tem valor {valor}");
            return valor.Replace(nomeCampo + "=", "");
        }
    }
}