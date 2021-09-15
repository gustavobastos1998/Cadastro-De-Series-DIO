using System.Collections.Generic;
using CadastroSeries.Classes;
namespace CadastroSeries.Interface
{
    public interface IRepositorio<G>
    {
        List<G> Lista();
        G RetornaPorId(int id);
        void InfoSeriesGeneroEspecifico(Genero genero);
        void InserirSerie(G newSerie);
        void ExcluirSeriePorId(int id);
        void AtualizarInfoSerie(int id, G updatedSerie);
        int NextId();
    }
}