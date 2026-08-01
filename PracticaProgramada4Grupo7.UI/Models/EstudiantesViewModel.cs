using PracticaProgramada4Grupo7.BLL.Dtos;

namespace PracticaProgramada4Grupo7.UI.Models
{
    public class EstudiantesViewModel
    {
        public List<EstudianteDto> Estudiantes { get; set; }
            = new List<EstudianteDto>();

        public EstudianteDto Formulario { get; set; }
            = new EstudianteDto();
    }
}