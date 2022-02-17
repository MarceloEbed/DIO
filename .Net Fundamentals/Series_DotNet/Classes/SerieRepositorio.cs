using dotnet_console_crud_series.Interfaces;

namespace dotnet_console_crud_series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        //esta lista irá conter todas as sérias cadastradas, desta forma teremos uma 
        //base de dados em memória, um repositório de Series
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie entity)
        {
            listaSerie[id] = entity;
        }

        public void Cadastrar(Serie entity)
        {
            listaSerie.Add(entity);
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public List<Serie> Listar()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count; 
        }

        public Serie Visualizar(int id)
        {
            bool result = listaSerie.Contains(listaSerie[id]);

            if(result){
                return listaSerie[id];
            } else {
                return null;
            }
        }
    }
}