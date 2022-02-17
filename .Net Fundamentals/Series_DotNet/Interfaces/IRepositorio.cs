
using System.Collections.Generic;

namespace dotnet_console_crud_series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Listar();
         void Cadastrar(T entity);
         T Visualizar(int id);
         void Atualizar(int id, T entity);
         void Excluir(int id);
         int ProximoId();

    }
}