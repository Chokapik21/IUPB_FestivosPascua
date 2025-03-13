using FestivosPascua.Dominio.Entidades;
using FestivosPascua.Core.Repositorios;
using Microsoft.EntityFrameworkCore;
using FestivosPascua.Persistencia.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivosPascua.Aplicacion.Repositorio;

namespace FestivosPascua.Infraestructura.Repositorios
{
    public class FestivosRepositorio : IFestivosRepositorio
    {
        private readonly ClsFestivosPascuaContext contexto;

        public FestivosRepositorio(ClsFestivosPascuaContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<ClsFestivos> Agregar(ClsFestivos festivo)
        {
            contexto.Festivos.Add(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task<IEnumerable<ClsFestivos>> Buscar(int tipo, string dato)
        {
            return await contexto.Festivos
                .Where(f => f.IdTipo == tipo && f.Nombre.Contains(dato))
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            var festivo = await contexto.Festivos.FindAsync(id);
            if (festivo == null) return false;

            contexto.Festivos.Remove(festivo);
            await contexto.SaveChangesAsync();
            return true;
        }

        public async Task<ClsFestivos> Modificar(ClsFestivos festivo)
        {
            contexto.Festivos.Update(festivo);
            await contexto.SaveChangesAsync();
            return festivo;
        }

        public async Task<ClsFestivos> Obtener(int id)
        {
            return await contexto.Festivos.Include(f => f.TipoDias)
                                          .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<ClsFestivos>> ObtenerTodos()
        {
            return await contexto.Festivos.Include(f => f.TipoDias).ToListAsync();
        }
    }
}

