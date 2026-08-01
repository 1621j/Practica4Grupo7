using PracticaProgramada4Grupo7.BLL.Dtos;
using PracticaProgramada4Grupo7.DAL.Repositorios;

namespace PracticaProgramada4Grupo7.BLL.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;

        public EstudianteService(
            IEstudianteRepositorio estudianteRepositorio)
        {
            _estudianteRepositorio = estudianteRepositorio;
        }

        public async Task<List<EstudianteDto>> ObtenerTodosAsync()
        {
            var estudiantes =
                await _estudianteRepositorio.ObtenerTodosAsync();

            return estudiantes
                .Select(MapeoClases.ConvertirAEstudianteDto)
                .ToList();
        }

        public async Task<EstudianteDto?> ObtenerPorIdAsync(int id)
        {
            var estudiante =
                await _estudianteRepositorio.ObtenerPorIdAsync(id);

            if (estudiante == null)
            {
                return null;
            }

            return MapeoClases.ConvertirAEstudianteDto(estudiante);
        }

        public async Task<EstudianteDto> RegistrarAsync(
            EstudianteDto estudianteDto)
        {
            var estudiantePorCedula =
                await _estudianteRepositorio.ObtenerPorCedulaAsync(
                    estudianteDto.Cedula.Trim());

            if (estudiantePorCedula != null)
            {
                throw new InvalidOperationException(
                    "Ya existe un estudiante con esa cédula.");
            }

            var estudiantePorCorreo =
                await _estudianteRepositorio.ObtenerPorCorreoAsync(
                    estudianteDto.Correo.Trim());

            if (estudiantePorCorreo != null)
            {
                throw new InvalidOperationException(
                    "Ya existe un estudiante con ese correo.");
            }

            estudianteDto.Id = 0;

            var estudiante =
                MapeoClases.ConvertirAEstudiante(estudianteDto);

            await _estudianteRepositorio.AgregarAsync(estudiante);

            return MapeoClases.ConvertirAEstudianteDto(estudiante);
        }

        public async Task<bool> ActualizarAsync(
            int id,
            EstudianteActualizarDto estudianteDto)
        {
            var estudianteExistente =
                await _estudianteRepositorio.ObtenerPorIdAsync(id);

            if (estudianteExistente == null)
            {
                return false;
            }

            var estudiantePorCedula =
                await _estudianteRepositorio.ObtenerPorCedulaAsync(
                    estudianteDto.Cedula.Trim());

            if (estudiantePorCedula != null &&
                estudiantePorCedula.Id != id)
            {
                throw new InvalidOperationException(
                    "Ya existe otro estudiante con esa cédula.");
            }

            var estudiantePorCorreo =
                await _estudianteRepositorio.ObtenerPorCorreoAsync(
                    estudianteDto.Correo.Trim());

            if (estudiantePorCorreo != null &&
                estudiantePorCorreo.Id != id)
            {
                throw new InvalidOperationException(
                    "Ya existe otro estudiante con ese correo.");
            }

            estudianteExistente.Cedula =
                estudianteDto.Cedula.Trim();

            estudianteExistente.Nombre =
                estudianteDto.Nombre.Trim();

            estudianteExistente.PrimerApellido =
                estudianteDto.PrimerApellido.Trim();

            estudianteExistente.SegundoApellido =
                estudianteDto.SegundoApellido?.Trim()
                ?? string.Empty;

            estudianteExistente.Correo =
                estudianteDto.Correo.Trim();

            estudianteExistente.Carrera =
                estudianteDto.Carrera.Trim();

            if (estudianteDto.Activo is bool activo)
            {
                estudianteExistente.Activo = activo;
            }

            await _estudianteRepositorio.ActualizarAsync(
                estudianteExistente);

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var estudiante =
                await _estudianteRepositorio.ObtenerPorIdAsync(id);

            if (estudiante == null)
            {
                return false;
            }

            await _estudianteRepositorio.EliminarAsync(estudiante);

            return true;
        }
    }
}