namespace PracticaProgramada4Grupo7.DAL.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Carrera { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}