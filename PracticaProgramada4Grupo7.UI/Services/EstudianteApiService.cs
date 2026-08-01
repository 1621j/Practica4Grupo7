using PracticaProgramada4Grupo7.BLL.Dtos;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace PracticaProgramada4Grupo7.UI.Services
{
    public class EstudianteApiService : IEstudianteApiService
    {
        private readonly HttpClient _cliente;

        public EstudianteApiService(HttpClient cliente)
        {
            _cliente = cliente;
        }

        public async Task<List<EstudianteDto>> ObtenerTodosAsync()
        {
            return await _cliente.GetFromJsonAsync<List<EstudianteDto>>("api/estudiantes")
                ?? new List<EstudianteDto>();
        }

        public async Task<EstudianteDto?> ObtenerPorIdAsync(int id)
        {
            var respuesta = await _cliente.GetAsync($"api/estudiantes/{id}");
            if (respuesta.StatusCode == HttpStatusCode.NotFound)
                return null;

            await ValidarRespuestaAsync(respuesta);
            return await respuesta.Content.ReadFromJsonAsync<EstudianteDto>();
        }

        public async Task<EstudianteDto> RegistrarAsync(EstudianteDto estudiante)
        {
            var respuesta = await _cliente.PostAsJsonAsync("api/estudiantes", estudiante);
            await ValidarRespuestaAsync(respuesta);
            return (await respuesta.Content.ReadFromJsonAsync<EstudianteDto>())!;
        }

        public async Task ActualizarAsync(int id, EstudianteActualizarDto estudiante)
        {
            var respuesta = await _cliente.PutAsJsonAsync($"api/estudiantes/{id}", estudiante);
            await ValidarRespuestaAsync(respuesta);
        }

        public async Task EliminarAsync(int id)
        {
            var respuesta = await _cliente.DeleteAsync($"api/estudiantes/{id}");
            await ValidarRespuestaAsync(respuesta);
        }

        private static async Task ValidarRespuestaAsync(HttpResponseMessage respuesta)
        {
            if (respuesta.IsSuccessStatusCode)
                return;

            var contenido = await respuesta.Content.ReadAsStringAsync();
            try
            {
                using var json = JsonDocument.Parse(contenido);
                if (json.RootElement.TryGetProperty("mensaje", out var mensaje))
                    throw new InvalidOperationException(mensaje.GetString());
                if (json.RootElement.TryGetProperty("title", out var titulo))
                    throw new InvalidOperationException(titulo.GetString());
            }
            catch (JsonException)
            {
                // Si la API no devolvió JSON, se muestra un mensaje general.
            }

            throw new InvalidOperationException(
                $"No fue posible completar la operación ({(int)respuesta.StatusCode}).");
        }
    }
}