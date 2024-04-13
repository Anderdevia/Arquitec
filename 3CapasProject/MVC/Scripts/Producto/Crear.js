

//GetByFunctionParam('/Core/Ciudad', $("#IdCiudad"));

//function GetByFunctionParam(url, select) {
//    select.empty();
//    select.chosen("destroy");
//    select.append("<option></option>");
//    $('<div class="alert alert-info" role="alert"" align="center"><i class="fa fa-cog fa-4x fa-spin "></i><br /><h4> Cargando ...</h4></div>').insertAfter(select);
//    $.get(url + '/GetByFunctionAsync/')
//        .done(function (data) {
//            $.each(data.data, function (index, item) {
//                //Svar nombre = item.text.split('');
//                // select.append("<option value='" + nombre[1] + "'>" + nombre[1] + "</option>");
//                select.append("<option value='" + item.id + "'>" + item.text + "</option>");
//            });
//            select.chosen({
//                allow_single_deselect: true,
//                width: "100%"
//            });
//        })
//        .always(function () {
//            $(".alert").remove();
//        });
//}
$(document).ready(function () {
listarProductos();
cargarCategoria();
cargarProveedor();
});


function cargarCategoria() {


    fetch("GetComboCategoria").
        then(response => response.json())
        .then(miJson => {
            console.log(miJson);
            let resultado = "";
            for (let i = 0; i < miJson.length; i++) {
                resultado += "<option value='" + miJson[i].Codigo + "'> " + miJson[i].Nombre + "</option >"

            }
            document.getElementById("categoriaProducto").innerHTML = resultado;
            document.getElementById("categoriaProductoA").innerHTML = resultado;
        })
}


function cargarProveedor() {


    fetch("GetComboProveedor").
        then(response => response.json())
        .then(miJson => {
            console.log(miJson);
            let resultado = "";
            for (let i = 0; i < miJson.length; i++) {
                resultado += "<option value='" + miJson[i].Id + "'> " + miJson[i].Nombre + "</option >"

            }
            document.getElementById("proveedorProducto").innerHTML = resultado;
            document.getElementById("proveedorProductoA").innerHTML = resultado;
        })
}


//AGREGAR
const formulario = document.getElementById("formRegistra");
formulario.addEventListener('submit', function (e) {

    let formData = new FormData();
    let files = $('#imagenProducto')[0].files;

    for (var i = 0; i < files.length; i++) {
        formData.append('files', files[i]);

    }

    var id = document.getElementById("codigo").value;



    e.preventDefault();

    // Obtener los valores de los campos
    let nombre = document.getElementById("nombreProducto").value;
    let descripcion = document.getElementById("descripcionProducto").value;
    let referencia = document.getElementById("referenciaProducto").value;
    let stock = document.getElementById("stockProducto").value;
    let categoria = document.getElementById("categoriaProducto").value;
    let precio = document.getElementById("precioProducto").value;
    let imagen = document.getElementById("imagenProducto").value;
    let proveedor = document.getElementById("proveedorProducto").value;

    // Verificar si los campos están vacíos y cambiar el borde a rojo si es necesario
    if (nombre === "") {
        document.getElementById("nombreProducto").style.borderColor = "red";
    } else {
        document.getElementById("nombreProducto").style.borderColor = "";
    }

    if (descripcion === "") {
        document.getElementById("descripcionProducto").style.borderColor = "red";
    } else {
        document.getElementById("descripcionProducto").style.borderColor = "";
    }

    if (referencia === "") {
        document.getElementById("referenciaProducto").style.borderColor = "red";
    } else {
        document.getElementById("referenciaProducto").style.borderColor = "";
    }

    if (stock === "") {
        document.getElementById("stockProducto").style.borderColor = "red";
    } else {
        document.getElementById("stockProducto").style.borderColor = "";
    }

    if (categoria === "") {
        document.getElementById("categoriaProducto").style.borderColor = "red";
    } else {
        document.getElementById("categoriaProducto").style.borderColor = "";
    }

    if (precio === "") {
        document.getElementById("precioProducto").style.borderColor = "red";
    } else {
        document.getElementById("precioProducto").style.borderColor = "";
    }

    if (imagen === "") {
        document.getElementById("imagenProducto").style.borderColor = "red";
    } else {
        document.getElementById("imagenProducto").style.borderColor = "";
    }

    if (proveedor === "") {
        document.getElementById("proveedorProducto").style.borderColor = "red";
    } else {
        document.getElementById("proveedorProducto").style.borderColor = "";
    }


    // Verificar si alguna variable está vacía
    if (nombre === "" || descripcion === "" || referencia === "" || stock === "" || categoria === "" || precio === "" || imagen === "" || proveedor === "") {
        // Mostrar un mensaje de error o realizar alguna otra acción
        errorMessage.textContent = "Todos los campos son obligatorios. Por favor, completa los campos en Rojo.";
        errorMessage.style.display = "block"; // Mostrar el mensaje
        //alert("Todos los campos son obligatorios. Por favor, completa todos los campos.");
        return; // Detener la ejecución de la función
    } else {
        var cdert = files[0].name;
    }

    var datosProductos = {
        Nombre: nombre,
        Descripcion: descripcion,
        Referencia: referencia,
        Stock: stock,
        Categoria: categoria,
        Precio: precio,
        Id_tipo: categoria,
        Id_proveedor: proveedor,
        NombreImagen: "~/img/"+files[0].name

    };

    $.ajax({
        url: "nuevoProducto",
        type: 'POST',
        cache: false,
        data: {
            producto: datosProductos
        },
        dataType: 'json'
    }).done(function (res) {
        if (res.success) {
            var IdProveedorValida = 1;

            var datos = new FormData(formulario);
            fetch("imagenProducto", {
                method: 'POST',
                body: datos
            }).
                then(response => response.text()).
                then(respuesta => {
                    console.log("Agregado");

                    $('#ModalAgregar').modal('hide')


                    listarProductos();
                    $('#tablaProducto').DataTable().destroy();
                    resetear();
                    if (id == 0) {
                        Swal.fire({
                            position: 'top',
                            icon: 'success',
                            title: 'Registrado',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    } else {
                        Swal.fire({
                            position: 'top',
                            icon: 'success',
                            title: 'Actualizado',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    }



                });




        }
        else {


        }
    }).fail(function (res) {

    });


    


});






//Actualizar
const formularioA = document.getElementById("formActualiza");
formularioA.addEventListener('submit', function (e) {

    let formDataA = new FormData();
    let filesA = $('#imagenProductoA')[0].files;

    for (var i = 0; i < filesA.length; i++) {
        formDataA.append('files', filesA[i]);

    }

    var idA = document.getElementById("codigoA").value;



    e.preventDefault();

    // Obtener los valores de los campos
    let nombreA = document.getElementById("nombreProductoA").value;
    let descripcionA = document.getElementById("descripcionProductoA").value;
    let referenciaA = document.getElementById("referenciaProductoA").value;
    let stockA = document.getElementById("stockProductoA").value;
    let categoriaA = document.getElementById("categoriaProductoA").value;
    let precioA = document.getElementById("precioProductoA").value;
    let nombreRuta = document.getElementById("nombreRutaA").value;
    let imagenA = document.getElementById("imagenProductoA").value;
    let proveedorA = document.getElementById("proveedorProductoA").value;

    // Verificar si los campos están vacíos y cambiar el borde a rojo si es necesario
    if (nombreA === "") {
        document.getElementById("nombreProductoA").style.borderColor = "red";
    } else {
        document.getElementById("nombreProductoA").style.borderColor = "";
    }

    if (descripcionA === "") {
        document.getElementById("descripcionProductoA").style.borderColor = "red";
    } else {
        document.getElementById("descripcionProductoA").style.borderColor = "";
    }

    if (referenciaA === "") {
        document.getElementById("referenciaProductoA").style.borderColor = "red";
    } else {
        document.getElementById("referenciaProductoA").style.borderColor = "";
    }

    if (stockA === "") {
        document.getElementById("stockProductoA").style.borderColor = "red";
    } else {
        document.getElementById("stockProductoA").style.borderColor = "";
    }

    if (categoriaA === "") {
        document.getElementById("categoriaProductoA").style.borderColor = "red";
    } else {
        document.getElementById("categoriaProductoA").style.borderColor = "";
    }

    if (precioA === "") {
        document.getElementById("precioProductoA").style.borderColor = "red";
    } else {
        document.getElementById("precioProductoA").style.borderColor = "";
    }

    //if (imagenA === "") {
    //    document.getElementById("imagenProductoA").style.borderColor = "red";
    //} else {
    //    document.getElementById("imagenProductoA").style.borderColor = "";
    //}

    if (proveedorA === "") {
        document.getElementById("proveedorProductoA").style.borderColor = "red";
    } else {
        document.getElementById("proveedorProductoA").style.borderColor = "";
    }


    // Verificar si alguna variable está vacía
    if (nombreA === "" || descripcionA === "" || referenciaA === "" || stockA === "" || categoriaA === "" || precioA === "" || proveedorA === "") {
        // Mostrar un mensaje de error o realizar alguna otra acción
        errorMessageA.textContent = "Todos los campos son obligatorios. Por favor, completa los campos en Rojo.";
        errorMessageA.style.display = "block"; // Mostrar el mensaje
        //alert("Todos los campos son obligatorios. Por favor, completa todos los campos.");
        return; // Detener la ejecución de la función
    }
    //else {
    //    var cdert = filesA[0].name;
    //}

    var rutaNombreIma = "";
    var IfActualizarImagen = 0;

    if (filesA.length > 0) {
        rutaNombreIma = filesA[0].name;
       
        IfActualizarImagen = 1;
    }else if (nombreRuta.length > 0) {
        rutaNombreIma = nombreRuta;
    } 


    var datosProductosA = {
        Id: idA,
        Nombre: nombreA,
        Descripcion: descripcionA,
        Referencia: referenciaA,
        Stock: stockA,
        Categoria: categoriaA,
        Precio: precioA,
        Id_tipo: categoriaA,
        Id_proveedor: proveedorA,
        NombreImagen: "~/img/" +rutaNombreIma //  "~/img/" + filesA[0].name

    };

    //var datos = new FormData(formulario);
    //fetch("Productos/imagenProducto", {
    //    method: 'POST',
    //    body: datos
    //}).
    //    then(response => response.text()).
    //    then(respuesta => {
    //        console.log("Agregado");

    //        $('#ModalAgregar').modal('hide')


    //        listarProductos();
    //        $('#tablaProducto').DataTable().destroy();
    //        resetear();
    //        if (id == 0) {
    //            Swal.fire({
    //                position: 'top',
    //                icon: 'success',
    //                title: 'Registrado',
    //                showConfirmButton: false,
    //                timer: 1500
    //            })
    //        } else {
    //            Swal.fire({
    //                position: 'top',
    //                icon: 'success',
    //                title: 'Actualizado',
    //                showConfirmButton: false,
    //                timer: 1500
    //            })
    //        }

    //    });

    $.ajax({
        url: "actualizaProducto",
        type: 'POST',
        cache: false,
        data: {
            producto: datosProductosA,
            imagen: nombreRuta
        },
        dataType: 'json'
    }).done(function (res) {
        if (res.success) {

            if (filesA.length > 0) {



                var datos = new FormData(formularioA);
                fetch("imagenProducto", {
                    method: 'POST',
                    body: datos
                }).
                    then(response => response.text()).
                    then(respuesta => {
                        console.log("EditadoImagen");





                    });
            }

            $('#ModalActualizar').modal('hide')


            listarProductos();
            $('#tablaProducto').DataTable().destroy();
            resetear();
            if (idA == 0) {
                Swal.fire({
                    position: 'top',
                    icon: 'success',
                    title: 'Registrado',
                    showConfirmButton: false,
                    timer: 1500
                })
            } else {
                Swal.fire({
                    position: 'top',
                    icon: 'success',
                    title: 'Actualizado',
                    showConfirmButton: false,
                    timer: 1500
                })
            }




        }
        else {


        }
    }).fail(function (res) {

    });





});









function listarProductos() {
    var editar = "<button type='button' data-toggle='modal'  data-target='#ModalAgregar'" +
        "class='btn btn-small-table'  style='padding: 1px;' id='idEditar'><i class='fa fa-spinner'></button>";

    var foto = "<button type='button' data-toggle='modal'  data-target='#myModalFoto'" +
        "class='btn btn-warning' id='btnFoto'>Foto</button>";
    const table = document.querySelector("tbody");

    fetch("ListaProducto").
        then(response => response.json()).
        then(respuesta => {
            console.log(respuesta)
            let resultado = "";
            for (let i = 0; i < respuesta.length; i++) {
                

                resultado += '<tr class="small-font" taskId=' + respuesta[i].Id + '>' + '<td>' + respuesta[i].Id + '</td>' +
                    '<td class="small-font">' + respuesta[i].Nombre + '</td>' +  
                    '<td class="small-font">' + respuesta[i].Descripcion + '</td>' +  
                    '<td class="small-font">' + '$/.' + respuesta[i].Precio + '</td>' +  
                    '<td class="small-font">' + respuesta[i].Stock + '</td>' +  
                    '<td class="small-font">' + respuesta[i].Categoria + '</td>' +  
                    '<td class="small-font">' + respuesta[i].Id_proveedor + '</td>' +  
                    '<td>' + "<button onclick='editar(" + respuesta[i].Id + ")'  type='button' data-toggle='modal'  data-target='#ModalActualizar'" +
                    "class='btn btn-small-table'  style='padding: 1px;' id='idEditar'><i class='fa fa-spinner'></button>" + '</td>' +
                    '<td>' + "<button onclick='elimina(" + respuesta[i].Id + ")' type='button'" +
                    "class='btn btn-small-table' id='idEliminar' style='padding: 1px;'><i class='fa fa-trash'></button>" + "</td>" +
                    //'<td>' + foto + '</td>' +
                    '</tr>'

            }

            table.innerHTML = resultado;
            $('#tablaProducto').DataTable({
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },
            });

        });


}



//ACTUALIZAR
//const formularioA = document.getElementById("formActualiza");
//formularioA.addEventListener('submit', function (e) {
//    var codigoA = document.getElementById("codigoA").value;


//    e.preventDefault();
//    var datosA = new FormData(formularioA);



//    fetch("actualizaProducto", {
//        method: 'POST',
//        body: datosA
//    }).
//        then(response => response.text()).
//        then(respuesta => {
//            console.log("Actualizado");

//            Swal.fire({
//                position: 'top',
//                icon: 'success',
//                title: 'Actualizado',
//                showConfirmButton: false,
//                timer: 1500
//            })
//            $('#ModalActualizar').modal('hide')


//            listarProductos();
//            $('#tablaProducto').DataTable().destroy();
//            resetear();
//        });
//});



//const editar = document.getElementById("idEditar");
function editar(id) {


    fetch("Update?id=" + id).
        then(response => response.json()).
        then(respuesta => {
            let resultado = "";
            let resultado2 = "";
            let resultado3 = "";
            console.log(respuesta)
            if (respuesta.Id > 0) {
                
                document.getElementById("codigoA").value = respuesta.Id;
                document.getElementById("nombreProductoA").value = respuesta.Nombre;
                document.getElementById("descripcionProductoA").value = respuesta.Descripcion;
                document.getElementById("referenciaProductoA").value = respuesta.Referencia;
                document.getElementById("precioProductoA").value = respuesta.Precio;
                document.getElementById("stockProductoA").value = respuesta.Stock;
                document.getElementById("imagenProductoA").value = "";
                document.getElementById("nombreRutaA").value = respuesta.NombreImagen;
                document.getElementById("categoriaProductoA").value = respuesta.Categoria;
                document.getElementById("proveedorProductoA").value = respuesta.Id_proveedor;
                resultado3 += `<div id="imgSeleccion" style=' width: 100%;'> <img id=""  style=' width: 100%; 'src="${respuesta.NombreImagen.slice(1)}" alt=""> </div>`;

                document.getElementById("foto").innerHTML = resultado3;
                //Combos

           }

           

        });
}

function elimina(id) {

    fetch("Delete?id=" + id).
        then(response => response.json()).
        then(data => {
            listarProductos();
            //cargarProductos();
            $('#tablaProducto').DataTable().destroy();
        });
}


function resetear() {
    document.getElementById("codigo").value = 0;
    document.getElementById("nombreProducto").value = "";
    document.getElementById("descripcionProducto").value = "";
    document.getElementById("precioProducto").value = "";
    document.getElementById("stockProducto").value = "";
    document.getElementById("categoriaProducto").value = "";
    document.getElementById("proveedorProducto").value = "";
    document.getElementById("imagenProducto").value = "";
}