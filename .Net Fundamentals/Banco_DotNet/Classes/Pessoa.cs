using dotnet_console_banco.Enum;
using dotnet_console_banco.Interfaces;
namespace dotnet_console_banco.Classes
{
    public class Pessoa
    {
        public string nome { get; private set;}
        public string cpf { get; private set;}
        public string senha {get; private set;}
        public IConta Conta {get; set;}
    
        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public void setSenha(string senha)
        {
            this.senha = senha;
        }
    }
}