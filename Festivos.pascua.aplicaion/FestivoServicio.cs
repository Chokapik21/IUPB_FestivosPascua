using FestivosPascua.Dominio.Entidades;
using FestivosPascua.Persistencia.Contexto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FestivosPascua.Aplicacion.Servicios
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoServicio repositorio;

        public FestivoServicio(IFestivoServicio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<ClsFestivos> Agregar(ClsFestivos festivo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClsFestivos>> Buscar(int tipo, string dato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClsFestivos> Modificar(ClsFestivos festivo)
        {
            throw new NotImplementedException();
        }

        public async Task<ClsFestivos> Obtener(int id)
        {
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<ClsFestivos>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
