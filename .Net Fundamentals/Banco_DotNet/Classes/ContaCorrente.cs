namespace dotnet_console_banco.Classes
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumeroConta = "00" + Conta.numeroDaContaSequencial;
            this.DefinirLimiteDeCredito(0);
        }

        public ContaCorrente(double credito)
        {
            this.NumeroConta = "00" + Conta.numeroDaContaSequencial;
            this.DefinirLimiteDeCredito(credito);
        }

        
        
    }
}