using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere (T entidade);
        void exclui(int id);
        void atualiza(int id, T entidade );
        int ProximoId();
    }
}