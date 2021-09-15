using System;
namespace CadastroSeries.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero gereno;
        private string titulo;
        private string descricao;
        private DateTime dataLancamento;
        private bool excluido;
        public Genero Genero
        {
            get => gereno;
            set => gereno = value;
        }
        public string Titulo
        {
            get => titulo;
            set => titulo = value;
        }
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }
        public DateTime DataDeLancamento
        {
            get => dataLancamento;
            set => dataLancamento = value;
        }
        public bool Excluido
        {
            get => excluido;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public void ExcluirSerie()
        {
            this.excluido = true;
        }

        public Serie(int id, Genero genero, string titulo, string descricao, DateTime dataLancamento)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.DataDeLancamento = dataLancamento;
            this.excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.DataDeLancamento.ToString("d") + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

    }
}