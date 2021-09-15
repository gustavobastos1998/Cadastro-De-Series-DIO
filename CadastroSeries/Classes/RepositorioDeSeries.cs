using CadastroSeries.Interface;
using System.Collections.Generic;
using System;

namespace CadastroSeries.Classes
{
    public class RepositorioDeSeries : IRepositorio<Serie>
    {
        private List<Serie> listaDeSeries = new List<Serie>();
        public List<Serie> Lista()
        {
            return listaDeSeries;
        }
        public Serie RetornaPorId(int id)
        {
            return listaDeSeries[id];
        }
        public void InfoSeriesGeneroEspecifico(Genero genero)
        {
            for (int i = 0; i < listaDeSeries.Count; i = i + 1)
            {
                if (listaDeSeries[i].Genero == genero)
                {
                    Console.WriteLine(listaDeSeries[i]);
                }
            }
        }
        public void InserirSerie(Serie newSerie)
        {
            listaDeSeries.Add(newSerie);
        }
        public void ExcluirSeriePorId(int id)
        {
            listaDeSeries[id].ExcluirSerie();
        }
        public int NextId()
        {
            return listaDeSeries.Count;
        }

        public void AtualizarInfoSerie(int id, Serie updatedSerie)
        {
            listaDeSeries[id] = updatedSerie;
        }
    }
}