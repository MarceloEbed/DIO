namespace dotnet_console_banco.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeBanco = "BancoEbed";
            this.CodigoBanco = "071";
        }

        public string NomeBanco {get; private set;}
        public string CodigoBanco { get; private set;}
    }
}