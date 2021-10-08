using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class serieRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSerie = new List<Series>();
        public void atualiza(int id, Series objeto)
        {
            ListaSerie[id] = objeto;
        }

        public void exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}