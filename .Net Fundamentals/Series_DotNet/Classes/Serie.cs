using dotnet_console_crud_series.Enums;

namespace dotnet_console_crud_series.Classes
{
    public class Serie : Midia
    {
        private string titulo { get; set; }
        private string descricao { get; set; }
        private string ano { get; set; }
        private Genero genero { get; set; }
        private bool status { get; set; }

        public Serie(int id, string titulo, string descricao, string ano, int genero)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.genero = (Genero)genero;
            this.status = false;
        }

        public string ToString()
        {
            string informacoes = "";
            informacoes += "\t\t----------------------------------------" + Environment.NewLine;
            informacoes += "\t\tTítulo: \t" + this.titulo + Environment.NewLine; 
            informacoes += "\t\tDescrição: \t" + this.descricao + Environment.NewLine; 
            informacoes += "\t\tAno: \t\t" + this.ano + Environment.NewLine; 
            informacoes += "\t\tGênero: \t" + this.genero + Environment.NewLine; 
            informacoes += "\t\t----------------------------------------" + Environment.NewLine;

            return informacoes;
        }

        public string getTitulo()
        {
            return this.titulo;
        }

        public int getId()
        {
            return this.id;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public bool getStatus()
        {
            return this.status;
        }
        
        public void Excluir()
        {
            this.status = true;
        }

    }
}