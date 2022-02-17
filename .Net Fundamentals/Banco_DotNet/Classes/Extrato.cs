namespace dotnet_console_banco.Classes
{
    public class Extrato
    {
        public Extrato(DateTime data, string descricao, double valor)
        {
            this.data = data;
            this.descricao = descricao;
            this.valor = valor;
        }

        public DateTime data { get; private set;}
        public string descricao { get; private set;}
        public double valor { get; private set;}
    }
}