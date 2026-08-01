using System.ComponentModel.DataAnnotations;

namespace PracticaProgramada4Grupo7.BLL.Dtos
{
    public class EstudianteActualizarDto
    {
        [MaxLength(20)]
        public string? Cedula { get; set; }

        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(100)]
        public string? PrimerApellido { get; set; }

        [MaxLength(100)]
        public string? SegundoApellido { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        public string? Correo { get; set; }

        [MaxLength(150)]
        public string? Carrera { get; set; }

        public bool? Activo { get; set; }
    }
}
