using PracticaProgramada4Grupo7.DAL.Entidades;

namespace PracticaProgramada4Grupo7.DAL.Repositorios
{
    public interface IEstudianteRepositorio
    {
        Task<List<Estudiante>> ObtenerTodosAsync();

        Task<Estudiante?> ObtenerPorIdAsync(int id);

        Task<Estudiante?> ObtenerPorCedulaAsync(string cedula);

        Task<Estudiante?> ObtenerPorCorreoAsync(string correo);

        Task AgregarAsync(Estudiante estudiante);

        Task ActualizarAsync(Estudiante estudiante);

        Task EliminarAsync(Estudiante estudiante);
    }
}