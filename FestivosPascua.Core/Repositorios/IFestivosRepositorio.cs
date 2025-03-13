using FestivosPascua.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FestivosPascua.Aplicacion.Repositorio
{
    public interface IFestivoRepositorio
    {
        Task<ClsFestivos> Agregar(ClsFestivos festivo);
        Task<IEnumerable<ClsFestivos>> Buscar(int tipo, string dato);
        Task<bool> Eliminar(int id);
        Task<ClsFestivos> Modificar(ClsFestivos festivo);
        Task<ClsFestivos> Obtener(int id);
        Task<IEnumerable<ClsFestivos>> ObtenerTodos();
    }
}
