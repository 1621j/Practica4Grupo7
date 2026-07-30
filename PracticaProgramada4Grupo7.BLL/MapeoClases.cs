using PracticaProgramada4Grupo7.BLL.Dtos;
using PracticaProgramada4Grupo7.DAL.Entidades;

namespace PracticaProgramada4Grupo7.BLL
{
    public static class MapeoClases
    {
        public static EstudianteDto ConvertirAEstudianteDto(
            Estudiante estudiante)
        {
            return new EstudianteDto
            {
                Id = estudiante.Id,
                Cedula = estudiante.Cedula,
                Nombre = estudiante.Nombre,
                PrimerApellido = estudiante.PrimerApellido,
                SegundoApellido = estudiante.SegundoApellido,
                Correo = estudiante.Correo,
                Carrera = estudiante.Carrera,
                Activo = estudiante.Activo
            };
        }

        public static Estudiante ConvertirAEstudiante(
            EstudianteDto estudianteDto)
        {
            return new Estudiante
            {
                Id = estudianteDto.Id,
                Cedula = estudianteDto.Cedula.Trim(),
                Nombre = estudianteDto.Nombre.Trim(),
                PrimerApellido = estudianteDto.PrimerApellido.Trim(),
                SegundoApellido = estudianteDto.SegundoApellido?.Trim()
                    ?? string.Empty,
                Correo = estudianteDto.Correo.Trim(),
                Carrera = estudianteDto.Carrera.Trim(),
                Activo = estudianteDto.Activo
            };
        }
    }
}