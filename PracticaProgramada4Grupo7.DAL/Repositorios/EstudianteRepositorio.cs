using Microsoft.EntityFrameworkCore;
using PracticaProgramada4Grupo7.DAL.Data;
using PracticaProgramada4Grupo7.DAL.Entidades;

namespace PracticaProgramada4Grupo7.DAL.Repositorios
{
    public class EstudianteRepositorio : IEstudianteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public EstudianteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> ObtenerTodosAsync()
        {
            return await _context.Estudiantes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Estudiante?> ObtenerPorIdAsync(int id)
        {
            return await _context.Estudiantes
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Estudiante?> ObtenerPorCedulaAsync(string cedula)
        {
            return await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Cedula == cedula);
        }

        public async Task<Estudiante?> ObtenerPorCorreoAsync(string correo)
        {
            return await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Correo == correo);
        }

        public async Task AgregarAsync(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
        }
    }
}