document.addEventListener("DOMContentLoaded", function () {
    const modalFormulario =
        document.getElementById("modalFormulario");

    const modalDetalles =
        document.getElementById("modalDetalles");

    const modalEliminar =
        document.getElementById("modalEliminar");

    const formulario =
        document.getElementById("formularioEstudiante");

    if (!formulario) {
        return;
    }

    const urlRegistrar =
        formulario.dataset.urlRegistrar;

    const urlEditar =
        formulario.dataset.urlEditar;

    const estudianteId =
        document.getElementById("estudianteId");

    const cedula =
        document.getElementById("cedula");

    const nombre =
        document.getElementById("nombre");

    const primerApellido =
        document.getElementById("primerApellido");

    const segundoApellido =
        document.getElementById("segundoApellido");

    const correo =
        document.getElementById("correo");

    const carrera =
        document.getElementById("carrera");

    const activo =
        document.getElementById("activo");

    const subtituloFormulario =
        document.getElementById("subtituloFormulario");

    const tituloFormulario =
        document.getElementById("tituloFormulario");

    const botonGuardar =
        document.getElementById("botonGuardar");

    const botonNuevoEstudiante =
        document.getElementById("botonNuevoEstudiante");

    const cerrarFormulario =
        document.getElementById("cerrarFormulario");

    const cancelarFormulario =
        document.getElementById("cancelarFormulario");

    const cerrarDetalles =
        document.getElementById("cerrarDetalles");

    const botonCerrarDetalles =
        document.getElementById("botonCerrarDetalles");

    const cerrarEliminar =
        document.getElementById("cerrarEliminar");

    const cancelarEliminar =
        document.getElementById("cancelarEliminar");

    function limpiarValidaciones() {
        const resumen =
            formulario.querySelector(".resumen-validacion");

        if (resumen) {
            resumen.innerHTML = "";
        }

        formulario
            .querySelectorAll(
                ".field-validation-error, .field-validation-valid"
            )
            .forEach(function (elemento) {
                elemento.textContent = "";
            });

        formulario
            .querySelectorAll(".input-validation-error")
            .forEach(function (elemento) {
                elemento.classList.remove(
                    "input-validation-error"
                );
            });
    }

    function configurarModoRegistro() {
        formulario.reset();
        limpiarValidaciones();

        formulario.action = urlRegistrar;

        estudianteId.value = "0";
        activo.checked = true;

        subtituloFormulario.textContent =
            "NUEVO REGISTRO";

        tituloFormulario.textContent =
            "Registrar estudiante";

        botonGuardar.textContent =
            "Guardar estudiante";
    }

    function configurarModoEdicion(boton) {
        limpiarValidaciones();

        formulario.action = urlEditar;

        estudianteId.value =
            boton.dataset.id;

        cedula.value =
            boton.dataset.cedula;

        nombre.value =
            boton.dataset.nombre;

        primerApellido.value =
            boton.dataset.primerApellido;

        segundoApellido.value =
            boton.dataset.segundoApellido || "";

        correo.value =
            boton.dataset.correo;

        carrera.value =
            boton.dataset.carrera;

        activo.checked =
            boton.dataset.activo === "true";

        subtituloFormulario.textContent =
            "EDITAR REGISTRO";

        tituloFormulario.textContent =
            "Editar estudiante";

        botonGuardar.textContent =
            "Guardar cambios";
    }

    function abrirFormularioRegistro() {
        configurarModoRegistro();
        modalFormulario.showModal();
    }

    function abrirFormularioEdicion(boton) {
        configurarModoEdicion(boton);
        modalFormulario.showModal();
    }

    function abrirDetalles(boton) {
        const nombreCompleto = [
            boton.dataset.nombre,
            boton.dataset.primerApellido,
            boton.dataset.segundoApellido
        ]
            .filter(Boolean)
            .join(" ");

        document.getElementById(
            "detalleNombreCompleto"
        ).textContent = nombreCompleto;

        document.getElementById(
            "detalleCedula"
        ).textContent = boton.dataset.cedula;

        document.getElementById(
            "detalleCorreo"
        ).textContent = boton.dataset.correo;

        document.getElementById(
            "detalleCarrera"
        ).textContent = boton.dataset.carrera;

        document.getElementById(
            "detalleEstado"
        ).textContent =
            boton.dataset.activo === "true"
                ? "Activo"
                : "Inactivo";

        modalDetalles.showModal();
    }

    function abrirConfirmacionEliminar(boton) {
        document.getElementById(
            "eliminarId"
        ).value = boton.dataset.id;

        document.getElementById(
            "nombreEliminar"
        ).textContent =
            `${boton.dataset.nombre} ${boton.dataset.primerApellido}`;

        modalEliminar.showModal();
    }

    botonNuevoEstudiante.addEventListener(
        "click",
        abrirFormularioRegistro
    );

    cerrarFormulario.addEventListener(
        "click",
        function () {
            modalFormulario.close();
        }
    );

    cancelarFormulario.addEventListener(
        "click",
        function () {
            modalFormulario.close();
        }
    );

    cerrarDetalles.addEventListener(
        "click",
        function () {
            modalDetalles.close();
        }
    );

    botonCerrarDetalles.addEventListener(
        "click",
        function () {
            modalDetalles.close();
        }
    );

    cerrarEliminar.addEventListener(
        "click",
        function () {
            modalEliminar.close();
        }
    );

    cancelarEliminar.addEventListener(
        "click",
        function () {
            modalEliminar.close();
        }
    );

    document
        .querySelectorAll(".boton-ver")
        .forEach(function (boton) {
            boton.addEventListener(
                "click",
                function () {
                    abrirDetalles(boton);
                }
            );
        });

    document
        .querySelectorAll(".boton-editar")
        .forEach(function (boton) {
            boton.addEventListener(
                "click",
                function () {
                    abrirFormularioEdicion(boton);
                }
            );
        });

    document
        .querySelectorAll(".boton-eliminar")
        .forEach(function (boton) {
            boton.addEventListener(
                "click",
                function () {
                    abrirConfirmacionEliminar(boton);
                }
            );
        });

    const abrirFormulario =
        formulario.dataset.abrirFormulario === "true";

    const modoEditar =
        formulario.dataset.modoEditar === "true";

    if (abrirFormulario) {
        formulario.action =
            modoEditar
                ? urlEditar
                : urlRegistrar;

        subtituloFormulario.textContent =
            modoEditar
                ? "EDITAR REGISTRO"
                : "NUEVO REGISTRO";

        tituloFormulario.textContent =
            modoEditar
                ? "Editar estudiante"
                : "Registrar estudiante";

        botonGuardar.textContent =
            modoEditar
                ? "Guardar cambios"
                : "Guardar estudiante";

        modalFormulario.showModal();
    }
});