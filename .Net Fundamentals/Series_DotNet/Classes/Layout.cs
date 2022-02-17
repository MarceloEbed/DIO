using dotnet_console_crud_series.Enums;

namespace dotnet_console_crud_series.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        public static SerieRepositorio serieRepositorio;

        public static void TelaPrincipal()
        {
            //reseta menu
            opcao = 0;

            Console.Clear();

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Listar Séries                       ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Cadastrar Série                     ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 3 - Visualizar Série                    ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 4 - Atualizar Série                     ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 5 - Excluir Série                       ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 6 - Sair                                ");
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
                    //Listagem de Sérias cadastradas:
                    TelaListarSeries();
                    break;
                case 2:
                    //Tela de cadastro de séries (1 cadastrar / 2 atualizar)
                    TelaCadastrarSerie();
                    break;
                case 3:
                    //Visualizar série a partir de um ID
                    TelaVisualizarSerie();
                    break;
                case 4:
                    //Tela que permite atualizar uma série a partir de um ID
                    TelaAtualizarSerie();
                    break;
                case 5:
                    //Tela que permite excluir uma série a partir de um ID
                    TelaExcluirSerie();
                    break;
                case 6:
                    //Encerra programa
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opt invalida");
                    Thread.Sleep(1000);
                    Console.Clear();
                    TelaPrincipal();
                    break;
            }
        }
        private static void TelaListarSeries()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Lista de séries cadastradas             ");
            Console.WriteLine("                 =================================       ");

            int seriesCadastradas = serieRepositorio.ProximoId();

            if(seriesCadastradas == 0){
                Console.WriteLine();
                Console.WriteLine("                 Nenhuma Série cadastrada                ");
                Console.WriteLine("                 =================================       ");
                
            } else {
                Console.WriteLine("                 [ID] \t [Título]");
                Console.WriteLine("                 ---------------------------------");
                
                foreach (var serie in serieRepositorio.Listar())
                {
                    //imprime apenas as que não foram exclídas
                    if(serie.getStatus() == false){
                        Console.WriteLine($"                 {serie.getId()} \t {serie.getTitulo()}");
                        Console.WriteLine("                 ---------------------------------");
                    }
                }
            }

            Thread.Sleep(1500);
            Voltar();
        }
        private static void TelaCadastrarSerie()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Entre com o Título da série:  ");
            Console.WriteLine("                 =================================       ");
            string titulo = Console.ReadLine();

            Console.WriteLine("                 Entre com a Descrição da série:  ");
            Console.WriteLine("                 =================================       ");
            string descricao = Console.ReadLine();

            Console.WriteLine("                 Entre com o Ano de lançamento da série:  ");
            Console.WriteLine("                 =================================       ");
            string ano = Console.ReadLine();

            Console.WriteLine("                 Entre com o Gênero da série:  ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine();
            Console.WriteLine("                -------Lista de Gêneros------------");
            
            foreach(int i in Enum.GetValues(typeof(Genero))){
            Console.WriteLine($" \t\t {i} \t" + Enum.GetName(typeof(Genero), i)); 
            }

            Console.WriteLine("                ----------------------------------");
            int genero = int.Parse(Console.ReadLine());
            Console.WriteLine("                 =================================       ");

            Serie serie = new Serie(serieRepositorio.ProximoId(), titulo, descricao, ano, genero);
            serieRepositorio.Cadastrar(serie);
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"                 Série {titulo} cadastrada com sucesso! ");
            Console.WriteLine("                 =================================       ");

            //aguarda 1.5 segundos
            Thread.Sleep(1500);
            TelaPrincipal();
        }
        private static void TelaVisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Entre com o ID da série:                ");
            Console.WriteLine("                 =================================       ");
            int id = int.Parse(Console.ReadLine());

            Serie serie = serieRepositorio.Visualizar(id);
            Console.WriteLine(serie.ToString());
            
            Thread.Sleep(1500);
            Voltar();
        }
        private static void TelaAtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Entre com o ID da série:                ");
            Console.WriteLine("                 =================================       ");
            int id = int.Parse(Console.ReadLine());

            if(serieRepositorio.Visualizar(id) != null){

                Console.WriteLine();
                Console.WriteLine("                 Entre com o Título da série:  ");
                Console.WriteLine("                 =================================       ");
                string titulo = Console.ReadLine();

                Console.WriteLine("                 Entre com a Descrição da série:  ");
                Console.WriteLine("                 =================================       ");
                string descricao = Console.ReadLine();

                Console.WriteLine("                 Entre com o Ano de lançamento da série:  ");
                Console.WriteLine("                 =================================       ");
                string ano = Console.ReadLine();

                Console.WriteLine("                 Entre com o Gênero da série:  ");
                Console.WriteLine("                 =================================       ");
                Console.WriteLine();
                Console.WriteLine("                -------Lista de Gêneros------------");
                
                foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($" \t\t {i} \t" + Enum.GetName(typeof(Genero), i)); 
                }

                Console.WriteLine("                ----------------------------------");
                int genero = int.Parse(Console.ReadLine());
                Console.WriteLine("                 =================================       ");

                Serie serie = new Serie(id, titulo, descricao, ano, genero);
                serieRepositorio.Atualizar(id, serie);            
            
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine($"                 Série {serie.getTitulo()} atualizada com sucesso! ");
                Console.WriteLine("                 =================================       ");
            } else {
                Console.WriteLine();
                Console.WriteLine("                 Série Não encontrada! ");
                Console.WriteLine("                 =================================       ");
            }

            //aguarda 0.5 segundos
            Thread.Sleep(1500);
            TelaPrincipal();
        }      
        private static void TelaExcluirSerie()
        {
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 Entre com o ID da série:                ");
            Console.WriteLine("                 =================================       ");
            int id = int.Parse(Console.ReadLine());

            if(serieRepositorio.Visualizar(id) != null){
                serieRepositorio.Excluir(id);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"                 Série excluída com sucesso!            ");
            Console.WriteLine("                 =================================       ");
            } else {
                Console.WriteLine();
                Console.WriteLine("                 Série Não encontrada! ");
                Console.WriteLine("                 =================================       ");
            }

            //aguarda 1.5 segundos
            Thread.Sleep(1500);
            TelaPrincipal();
        }
        private static void Voltar()
        {
            opcao = 0;

            Console.WriteLine("                                                         ");
            Console.WriteLine("                 Digite a opção desejada:                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 1 - Voltar                              ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                 2 - Sair                                ");
            Console.WriteLine("                 =================================       ");
            Console.WriteLine("                                                         ");

            while(opcao == 0)
            {
                opcao = int.Parse(Console.ReadLine());

            }    

            opEscolhidaRetorno(opcao);
        }
        private static void opEscolhidaRetorno(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    //exibe a tela de criar conta:
                    TelaPrincipal();
                    break;
                case 2:
                    //Encerra programa
                    Environment.Exit(0);
                    break;
            }
        }

    }
}