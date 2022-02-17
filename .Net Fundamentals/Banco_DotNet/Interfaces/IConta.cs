
using dotnet_console_banco.Classes;
using dotnet_console_banco.Enum;

namespace dotnet_console_banco.Interfaces;

public interface IConta
{
    bool Depositar(double valor);
    bool Sacar(double valor);
    double ConsultarSaldo();
    string GetCodigoDoBanco();
    string GetNumeroAgencia();
    string GetNumeroConta();
    List<Extrato> Extrato();
    double GetCredito();
    void DefinirLimiteDeCredito(double credito);
    void selecionarTipoConta(TipoConta tipoConta);
    TipoConta GetTipoConta();

    string[] Transferir(double valor, Pessoa p);

}