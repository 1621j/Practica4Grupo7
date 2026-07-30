using PracticaProgramada4Grupo7.BLL.Dtos;

namespace PracticaProgramada4Grupo7.BLL.Services
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDto>> ObtenerTodosAsync();

        Task<EstudianteDto?> ObtenerPorIdAsync(int id);

        Task<EstudianteDto> RegistrarAsync(
            EstudianteDto estudianteDto);

        Task<bool> ActualizarAsync(
            int id,
            EstudianteDto estudianteDto);

        Task<bool> EliminarAsync(int id);
    }
}