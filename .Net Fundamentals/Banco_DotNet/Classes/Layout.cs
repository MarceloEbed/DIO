using dotnet_console_banco.Classes;
using dotnet_console_banco.Enum;

namespace dotnet_console_banco.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            //reseta menu
            opcao = 0;

            Console.Clear();

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Criar Conta                         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Entrar com CPF e Senha              ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            opEscolhida(opcao);

        }       

        private static void opEscolhida(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    //exibe a tela de criar conta:
                    TelaCriarConta();
                    break;
                case 2:
                    //Exibe a tela de Login
                    TelaEntrar();
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    Thread.Sleep(1000);
                    TelaPrincipal();
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine(" _Entre com seus dados para criar uma nova Conta:        ");
            Console.WriteLine("                 Digite seu Nome:                        ");
            string nome = Console.ReadLine();

            while(nome.Length  < 3){
                Console.Clear();
                Console.WriteLine("                 Nome deve ter pelo menos 3 caracteres:  ");
                Console.WriteLine("                 =================================       ");
                Thread.Sleep(1500);
                TelaCriarConta();
            }

            int tipo = 0;

            do {
                Console.Clear();
                Console.WriteLine("                 =================================       ");
                Console.WriteLine("                 Entre com o Tipo da sua Conta:          ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine("                 1 - Pessoa Física:                      ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine("                 2 - Pessoa Jurídica:                    ");
                Console.WriteLine("                 =================================       ");

                tipo = int.Parse(Console.ReadLine());
            
            } while(tipo  < 1 || tipo > 2 || tipo.GetType() != typeof(int));            

            Console.WriteLine("                 =================================       ");
            
            string documento = "";
            if(tipo == 1){
                

                do{
                    Console.Clear();
                    Console.WriteLine("                 Digite seu CPF:                         ");
                    documento = Console.ReadLine();

                }while(documento.Length < 5);

            } else if(tipo == 2){
                do{
                    Console.Clear();
                    Console.WriteLine("                 Digite seu CNPJ:                         ");
                    documento = Console.ReadLine();

                }while(documento.Length < 5);
                
            }            
            
            Console.WriteLine("                 =================================       ");
            
            string senha = "";
            
            do{
                Console.Clear();
                Console.WriteLine("                 Digite sua Senha:                       ");
                senha = Console.ReadLine();

            }while(senha.Length < 3 || senha == "");

            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            //chama o método que vai criar conta do usuário...
            Pessoa pessoa = criarConta(nome, documento, tipo,  senha);

            //adiciona na lista de pessoas cadastradas...
            pessoas.Add(pessoa);

            Console.Clear();
            Console.WriteLine("                 Conta cadastrada com sucesso!           ");
            Console.WriteLine("                 =================================       ");

            //aguarda 0.5 segundos
            Thread.Sleep(500);
            //redireciona para area do cliente ou tela inicial
            opcaoVoltar(pessoa);
        }

        private static Pessoa criarConta(string nome, string documento, int tipo, string senha)
        {
            TipoConta tipoConta;
            Pessoa pessoa = new Pessoa();
            ContaCorrente contaCorrente = new ContaCorrente(500);

            pessoa.setNome(nome);
            pessoa.setCpf(documento);
            pessoa.setSenha(senha);
            pessoa.Conta = contaCorrente;
            pessoa.Conta.selecionarTipoConta((TipoConta)tipo);

            return pessoa;
        }

        private static void TelaEntrar()
        {
            Console.Clear();

            Console.WriteLine(" _Entre com seus dados para acessar sua conta:           ");
            Console.WriteLine("                 Digite o número do CPF:                 ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Digite a Senha:                         ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            //chama o método que vai realizar o login...
            Pessoa pessoa = buscarConta(cpf, senha);

            if (pessoa != null){
                //redireciona para área do cliente
               areaDoCliente(pessoa);

            } else {
                Console.Clear();
                Console.WriteLine("                 Pessoa não cadastrada!                  ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine();
                Console.WriteLine();

                //aguarda 1.5 segundos
                Thread.Sleep(1500);
                //redireciona para o inicio
                TelaPrincipal();
            }
        }

        private static Pessoa buscarConta(string cpf, string senha)
        {
            Pessoa pessoa = pessoas.FirstOrDefault( x =>
                x.cpf == cpf &&
                x.senha == senha
            );

            return pessoa;
        }

        private static void telaBoasVindas(Pessoa pessoa)
        {
            string tipoConta ;
            if(pessoa.Conta.GetTipoConta() == TipoConta.PessoaFisica){
                tipoConta = "Pessoa Física";
            } else {
                tipoConta = "Pessoa Jurídica";
            }

            Console.WriteLine("                                                         ");
            Console.WriteLine($"                 Seja Bem Vindo, {pessoa.nome}          ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"      | Banco: {pessoa.Conta.GetCodigoDoBanco()} | Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()} | Tipo da sua Conta: {tipoConta}");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");
        }

        private static void areaDoCliente(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;

            Console.Clear();

            telaBoasVindas(pessoa);

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Realizar um Depósito                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Realizar um Saque                   ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 3 - Realizar Transferência              ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 4 - Consultar Saldo                     ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 5 - Extrato                             ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 6 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            opEscolhidaAreaCliente(opcao, pessoa);

        }       

        private static void opEscolhidaAreaCliente(int opcao, Pessoa pessoa)
        {
            switch (opcao)
            {
                case 1:
                    //realizar Depósito:
                    telaDeposito(pessoa);
                    break;
                case 2:
                    //realizar Saque:
                    telaSaque(pessoa);
                    break;
                case 3:
                    //realizar transferência
                    telaTransferir(pessoa);
                    break;
                case 4:
                    //Consultar Saldo:
                    telaCconsultaSaldo(pessoa);
                    break;
                case 5:
                    //Extrato:
                    telaExtrato(pessoa);
                    break;
                case 6:
                    //Sair
                    TelaPrincipal();
                    break;
                case 10:
                    listarContas(pessoas, pessoa);
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    Thread.Sleep(1500);
                    TelaPrincipal();
                    break;
            }
        }

        private static void telaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do Depósito:             ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                 =================================       ");

            //valida dado
            while(valor <= 0){
                Console.WriteLine("                 O valor do Depósito Inválido!           ");
                Console.WriteLine("                 =================================       ");
                
                Thread.Sleep(1000);
                opcaoVoltarAreaCliente(pessoa);
            }


            pessoa.Conta.Depositar(valor);
            
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Depósito Realizado com Sucesso!         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);
            opcaoVoltarAreaCliente(pessoa);

        }

        private static void telaSaque(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do Saque:                ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("                 =================================       ");

            bool result = pessoa.Conta.Sacar(valor);

             //mensagem de retorno
            if(!result){
                Console.Clear();
                Console.WriteLine("                 Saldo insuficiente                      ");
                Console.WriteLine("                 =================================       ");
                
            } else {
            
                Console.Clear();
                telaBoasVindas(pessoa);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                 Saque Realizado com Sucesso!            ");
                Console.WriteLine("                 =================================       ");

            }

            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);

            Console.Clear();
            opcaoVoltarAreaCliente(pessoa);

        }
        
        private static void telaTransferir(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);
            
            if(pessoa.Conta.GetType() == typeof(ContaCorrente)){

                Console.WriteLine("                 Digite o valor do a ser Transferido:    ");
                double valor = double.Parse(Console.ReadLine());
                Console.WriteLine("                 =================================       ");

                Console.WriteLine("                 Digite o numero da conta de Destino:    ");
                 string contaDestino = Console.ReadLine();
                Console.WriteLine("                 =================================       ");

                //verifica se a conta existe na lista
                //instancia a conta...
                Pessoa p = pessoas.FirstOrDefault( x =>x.Conta.GetNumeroConta() == contaDestino);
                
                string[] result = pessoa.Conta.Transferir(valor, p);
                
                Console.Clear();
                telaBoasVindas(pessoa);

                Console.WriteLine();
                Console.WriteLine();

                if(result[0] == "true"){
                    Console.WriteLine($"                 {result[1]}");
                    Console.WriteLine("                 =================================       ");

                } else if (result[0] == "Erro Conta Destino"){
                    Console.WriteLine($"                 {result[1]}");
                    Console.WriteLine("                 =================================       ");
                    Console.WriteLine();
                    Console.WriteLine();
                
                } else if(result[0] == "Erro Conta Origem"){
                    Console.WriteLine($"                 {result[1]}");
                    Console.WriteLine("                 =================================       "); 
                    Console.WriteLine();
                    Console.WriteLine();
            
                } 
            } else {
                Console.WriteLine("                 Esta conta não possui esta função       ");
                Console.WriteLine("                 =================================       ");
            }

            Thread.Sleep(1500);

            opcaoVoltarAreaCliente(pessoa);

        }
        
        private static void telaCconsultaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);

            Console.WriteLine("                 Seu Saldo é:                            ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                R$ {pessoa.Conta.ConsultarSaldo()}");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 Saldo + Crédito:                        ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine($"                R$ {pessoa.Conta.ConsultarSaldo()} + {pessoa.Conta.GetCredito()} = {pessoa.Conta.ConsultarSaldo() + pessoa.Conta.GetCredito()}");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine();
            Console.WriteLine();

            opcaoVoltarAreaCliente(pessoa);

        }    
        
        private static void telaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            telaBoasVindas(pessoa);
            
            //monta extrato a partir de um histórico de movimentações...
            if(pessoa.Conta.Extrato().Any()){
                Console.WriteLine("                  Extrato:                                                                  ");
                Console.WriteLine("                 ===================================================================        ");
                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine($"                 Data: {extrato.data.ToString("dd/MM/yyyy HH:mm:ss")}    Movimentação: {extrato.descricao}   Valor: {extrato.valor}      ");
                    Console.WriteLine("                 ---------------------------------------------------------------        ");
                }
                
                double saldoAtual = pessoa.Conta.Extrato().Sum(x => x.valor);
                double creditoAtual = pessoa.Conta.GetCredito();
                
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                    Saldo Atual:                                  ");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine($"                                      R$ {saldoAtual}                                     ");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine("                   Saldo + Crédito:                        ");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine($"                  R$ {saldoAtual} + {creditoAtual} = {saldoAtual + creditoAtual}");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine();
                Console.WriteLine();
            } else {
                Console.WriteLine("                 Não há Movimentações:                   ");
                Console.WriteLine("                 ===================================================================       ");
                Console.WriteLine();
                Console.WriteLine();
            }

            Thread.Sleep(1500);

            opcaoVoltarAreaCliente(pessoa);
        }      
        
        private static void opcaoVoltarAreaCliente(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Voltar para minha conta             ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            if(opcao == 1){
                areaDoCliente(pessoa);

            } else {
                TelaPrincipal();
            }

        }
        
        private static void opcaoVoltar(Pessoa pessoa)
        {
            //reseta menu
            opcao = 0;


            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Acessar Conta                       ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            if(opcao == 1){
                areaDoCliente(pessoa);

            } else {
                TelaPrincipal();
            }

        }
    
        private static void listarContas(List<Pessoa> pessoas, Pessoa pessoa)
        {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            foreach (Pessoa p in pessoas)
            {
                Console.WriteLine($"----------Pessoa: {p.nome}   Número da Conta:{p.Conta.GetNumeroConta()}   Saldo: R${p.Conta.ConsultarSaldo()}");
            }
            Thread.Sleep(1000);
            opcaoVoltarAreaCliente(pessoa);
        }
    }
 
}