using PracticaProgramada4Grupo7.BLL.Dtos;

namespace PracticaProgramada4Grupo7.UI.Services
{
    public interface IEstudianteApiService
    {
        Task<List<EstudianteDto>> ObtenerTodosAsync();
        Task<EstudianteDto?> ObtenerPorIdAsync(int id);
        Task<EstudianteDto> RegistrarAsync(EstudianteDto estudiante);
        Task ActualizarAsync(int id, EstudianteActualizarDto estudiante);
        Task EliminarAsync(int id);
    }
}