//$(document).ready(function () {

    //$('#ingresar').click(function (e) {
    //    const formularioAcc = document.getElementById("formAccede");
    //    formularioAcc.addEventListener('submit', function (e) {
    //        var correo = $('#usuario').val();
    //        var contraseña = $('#password').val();



    //        $.ajax({
    //            url: "/Login/AccesLogin",
    //            type: 'POST',
    //            cache: false,
    //            data: {
    //                correo: correo,
    //                contraseña: contraseña
    //            },
    //            dataType: 'json'
    //        }).done(function (data) {
    //            if (data.length > 0) {
    //                var IdProveedorValida = 1;


    //            }
    //            else {
    //                toastr.warning('mensaje', '¡Alerta!', toastr.options = { progressBar: true, closeButton: true });
    //            }
    //        }).fail(function (res) {

    //            toastr.warning('mesaje', '¡Alerta!', toastr.options = { progressBar: true, closeButton: true });
    //        });





            //$.ajax({
            //    url: "AccesLogin",
            //    type: 'POST',
            //    cache: false,
            //    data: {
            //        correo: correo,
            //        contraseña: contraseña
            //    },
            //    dataType: 'json'
            //}).done(function (res) {
            //    if (res.success) {
            //        var IdProveedorValida = 1;

            //        //var datos = new FormData(formulario);
            //        //fetch("Productos/imagenProducto", {
            //        //    method: 'POST',
            //        //    body: datos
            //        //}).
            //        //    then(response => response.text()).
            //        //    then(respuesta => {
            //        //        console.log("Agregado");

            //        //        $('#ModalAgregar').modal('hide')


            //        //        listarProductos();
            //        //        $('#tablaProducto').DataTable().destroy();
            //        //        resetear();
            //        //        if (id == 0) {
            //        //            Swal.fire({
            //        //                position: 'top',
            //        //                icon: 'success',
            //        //                title: 'Registrado',
            //        //                showConfirmButton: false,
            //        //                timer: 1500
            //        //            })
            //        //        } else {
            //        //            Swal.fire({
            //        //                position: 'top',
            //        //                icon: 'success',
            //        //                title: 'Actualizado',
            //        //                showConfirmButton: false,
            //        //                timer: 1500
            //        //            })
            //        //        }

            //        //    });
            //    }
            //    else {


            //    }
            //}).fail(function (res) {

            //});











            //if (usuario == "admin" && contraseña == "1234") {
            //    console.log("ir");
            //    window.location.href = "Producto/IndexProducto";

            //}


            //else {
            //    window.location.href = "Principal";

            //}

            //e.preventDefault();

    //    });


    //});
 
//});

//AGREGAR
//const formulario = document.getElementById("formRegistra");
//formulario.addEventListener('submit', function (e) {
//    // var codigo = document.getElementById("codigo").value;


//    e.preventDefault();
//    var datos = new FormData(formulario);


//    fetch("Producto/nuevoUsuario", {
//        method: 'POST',
//        body: datos
//    }).
//        then(response => response.text()).
//        then(respuesta => {
//            console.log(respuesta);
//            console.log("Agregado");


//            Swal.fire({
//                position: 'top',
//                icon: 'success',
//                title: 'Registrado',
//                showConfirmButton: false,
//                timer: 1500
//            })
//        });
//});


//CERRAR SESION
$('#cerrarsesion').click(function (e) {
//const formulario = document.getElementById("cerrarsesion");
//formulario.addEventListener('submit', function (e) {
    // var codigo = document.getElementById("codigo").value;


   // e.preventDefault();
   // var datos = new FormData(formulario);


    // Hacer la solicitud AJAX para cerrar la sesión
    fetch("CerrarSesion", {
        method: "POST", // Método POST ya que estás cerrando una sesión
        headers: {
            "Content-Type": "application/json" // Tipo de contenido JSON
        }
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                // La sesión se cerró con éxito
                alert(data.message);
                // Redirigir al usuario a la página de inicio o a otra página
                //window.location.href = "/Login/Index"; // Ajusta la ruta si es necesario
            } else {
                // Ocurrió un error al cerrar la sesión
                alert(data.message);
            }
        })
        .catch(error => {
            console.error("Error al cerrar la sesión:", error);
        });


    //fetch("Login/AccesLogin", {
    //    method: 'POST',
    //    body: datos
    //}).
    //    then(response => response.text()).
    //    then(respuesta => {
    //        console.log(respuesta);
    //        console.log("Agregado");


    //        Swal.fire({
    //            position: 'top',
    //            icon: 'success',
    //            title: 'Registrado',
    //            showConfirmButton: false,
    //            timer: 1500
    //        })
    //    });
});