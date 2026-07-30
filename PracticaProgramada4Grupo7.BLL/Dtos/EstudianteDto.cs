using System.ComponentModel.DataAnnotations;

namespace PracticaProgramada4Grupo7.BLL.Dtos
{
    public class EstudianteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [MaxLength(20)]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [MaxLength(100)]
        public string PrimerApellido { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [MaxLength(150)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        [MaxLength(150)]
        public string Carrera { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}