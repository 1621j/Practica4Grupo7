using Microsoft.AspNetCore.Mvc;
using PracticaProgramada4Grupo7.BLL.Dtos;
using PracticaProgramada4Grupo7.UI.Models;
using PracticaProgramada4Grupo7.UI.Services;

namespace PracticaProgramada4Grupo7.UI.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudianteApiService
            _estudianteApiService;

        public EstudiantesController(
            IEstudianteApiService estudianteApiService)
        {
            _estudianteApiService =
                estudianteApiService;
        }

        public async Task<IActionResult> Index()
        {
            var modelo = new EstudiantesViewModel();

            try
            {
                modelo.Estudiantes =
                    await _estudianteApiService
                        .ObtenerTodosAsync();
            }
            catch (HttpRequestException)
            {
                ViewBag.Error =
                    "No fue posible conectarse con la API. " +
                    "Verifique que la API esté ejecutándose.";
            }

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(
            EstudiantesViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                modelo.Estudiantes =
                    await ObtenerEstudiantesSeguroAsync();

                ViewBag.AbrirFormulario = true;
                ViewBag.ModoEditar = false;

                return View("Index", modelo);
            }

            try
            {
                await _estudianteApiService
                    .RegistrarAsync(modelo.Formulario);

                TempData["Exito"] =
                    "El estudiante fue registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    ex.Message);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No fue posible conectarse con la API.");
            }

            modelo.Estudiantes =
                await ObtenerEstudiantesSeguroAsync();

            ViewBag.AbrirFormulario = true;
            ViewBag.ModoEditar = false;

            return View("Index", modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(
            int id,
            EstudiantesViewModel modelo)
        {
            modelo.Formulario.Id = id;

            if (!ModelState.IsValid)
            {
                modelo.Estudiantes =
                    await ObtenerEstudiantesSeguroAsync();

                ViewBag.AbrirFormulario = true;
                ViewBag.ModoEditar = true;

                return View("Index", modelo);
            }

            try
            {
                var cambios =
                    new EstudianteActualizarDto
                    {
                        Cedula =
                            modelo.Formulario.Cedula,

                        Nombre =
                            modelo.Formulario.Nombre,

                        PrimerApellido =
                            modelo.Formulario.PrimerApellido,

                        SegundoApellido =
                            modelo.Formulario.SegundoApellido
                            ?? string.Empty,

                        Correo =
                            modelo.Formulario.Correo,

                        Carrera =
                            modelo.Formulario.Carrera,

                        Activo =
                            modelo.Formulario.Activo
                    };

                await _estudianteApiService
                    .ActualizarAsync(id, cambios);

                TempData["Exito"] =
                    "El estudiante fue actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(
                    string.Empty,
                    ex.Message);
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No fue posible conectarse con la API.");
            }

            modelo.Estudiantes =
                await ObtenerEstudiantesSeguroAsync();

            ViewBag.AbrirFormulario = true;
            ViewBag.ModoEditar = true;

            return View("Index", modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _estudianteApiService
                    .EliminarAsync(id);

                TempData["Exito"] =
                    "El estudiante fue eliminado correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (HttpRequestException)
            {
                TempData["Error"] =
                    "No fue posible conectarse con la API.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<EstudianteDto>>
            ObtenerEstudiantesSeguroAsync()
        {
            try
            {
                return await _estudianteApiService
                    .ObtenerTodosAsync();
            }
            catch (HttpRequestException)
            {
                return new List<EstudianteDto>();
            }
        }
    }
}