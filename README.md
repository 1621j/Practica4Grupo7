# Práctica Programada 4 - Grupo 7

Sistema para el registro y administración de estudiantes, desarrollado en ASP.NET Core 8 como parte del curso Programación Avanzada.

La aplicación utiliza una arquitectura por capas, una API REST, Entity Framework Core, SQL Server y una interfaz MVC que consume los servicios de la API.

## Integrantes

- Heiner David Calderón Montero
- Jessica Paola Porras Canales
- Alex Felipe Bolaños Alfaro
- Kendall Andrés Salas González

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- SQL Server Management Studio
- Swagger
- HTML
- CSS
- JavaScript
- Bootstrap
- HttpClient
- Visual Studio 2022

## Estructura de la solución

La solución está compuesta por cuatro proyectos:

### PracticaProgramada4Grupo7.DAL

Capa de acceso a datos.

Contiene:

- Entidad Estudiante.
- ApplicationDbContext.
- Interfaz del repositorio.
- Implementación del repositorio.
- Operaciones con Entity Framework Core.

### PracticaProgramada4Grupo7.BLL

Capa de lógica de negocio.

Contiene:

- DTO de estudiantes.
- DTO para actualizaciones.
- Mapeo entre entidades y DTO.
- Interfaz del servicio.
- Implementación del servicio.
- Validaciones de cédula y correo duplicados.

### PracticaProgramada4Grupo7.API

API REST encargada de recibir las solicitudes y comunicarse con la lógica de negocio.

Contiene:

- Controlador de estudiantes.
- Configuración de Swagger.
- Inyección de dependencias.
- Configuración de Entity Framework Core.
- Conexión con SQL Server.

### PracticaProgramada4Grupo7.UI

Interfaz MVC que consume la API mediante `HttpClient`.

Permite:

- Listar estudiantes.
- Registrar estudiantes.
- Consultar los datos de un estudiante.
- Editar estudiantes.
- Activar o inactivar estudiantes.
- Eliminar estudiantes.
- Mostrar mensajes de validación y confirmación.

## Relaciones entre proyectos

Las referencias están organizadas de la siguiente manera:

UI ───────────→ BLL
                  │
                  ▼
API ──────────→ BLL ──────────→ DAL
  └────────────────────────────→ DAL