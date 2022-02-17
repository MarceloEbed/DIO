using System.Collections.Generic;
using dotnet_console_crud_series.Classes;
using dotnet_console_crud_series.Enums;

namespace dotnet_console_crud_series.classes
{
public class App
    {
        public static void Run()
        {
            SerieRepositorio serieRepositorio = new SerieRepositorio();
            Layout.serieRepositorio = serieRepositorio;
            
            Layout.TelaPrincipal();
        }


        public static void TesteRun()
        {

            //testa criação de uma série e mudança de status...
            TestarSerie();
            Console.WriteLine();

            //testa criação de repositório de series com cadastro e manipulação de séries cadastradas (utilizado o Excluir para testar)
            TestarRepositorioDeSeries();            
            Console.WriteLine(); 

        }

        private static void TestarSerie()
        {
            Serie s = new Serie(
                id: 100, 
                titulo: "Heroes",
                descricao: "Série de Heróis",
                ano: "2006",
               genero:  1
            );
            Console.WriteLine("\t\t----Criação de uma série-----");
            Console.WriteLine(s.ToString());
            Console.WriteLine("\t\tExcluído: " + s.getStatus());
            s.Excluir();
            Console.WriteLine("\t\tExcluído: " + s.getStatus());
        }

        private static void TestarRepositorioDeSeries()
        {
            SerieRepositorio serieRepositorio = new SerieRepositorio();

            Serie s1 = new Serie(
                id: serieRepositorio.ProximoId(), 
                titulo: "Heroes",
                descricao: "Série de Heróis",
                ano: "2006",
               genero:  9
            );

            serieRepositorio.Cadastrar(s1);

            Serie s2 = new Serie(
                id: serieRepositorio.ProximoId(), 
                titulo: "Peaky Blinders",
                descricao: "Série de Gângsters",
                ano: "2011",
               genero:  10
            );

            serieRepositorio.Cadastrar(s2);

            Console.WriteLine("\t\t----Listagem de séries-----");
            List<Serie> serieList = serieRepositorio.Listar(); 
            foreach (var serie in serieList)
            {
                Console.Write("\t\t" + serie.getId());
                Console.WriteLine("\t" + serie.getTitulo());
                
            }
            Console.WriteLine();

            Console.WriteLine("\t\t---- série s1 -------------");
            Serie serie1  = serieRepositorio.Visualizar(0);
            Console.WriteLine(serie1.ToString());
            Console.WriteLine();

            Console.WriteLine("\t\t---- série s2 -------------");
            Serie serie2  = serieRepositorio.Visualizar(1);
            Console.WriteLine(serie2.ToString());
            Console.WriteLine();

            Console.WriteLine("\t\t---- Exclui série s1--------");
            serieRepositorio.Excluir(0);                            //colocará o status == true (excluído)
            Console.WriteLine("\t\texclusão executada");
            Console.WriteLine();
            
            Console.WriteLine("\t\t----Listagem de séries atual");
            List<Serie> serieListAtual = serieRepositorio.Listar(); 
            foreach (var serie in serieListAtual)
            {
                if(!serie.getStatus()){
                    Console.Write("\t\t" + serie.getId());
                    Console.WriteLine("\t" + serie.getTitulo());
                }
                
            }


        }
    }
}