﻿


cargarMenu();
function cargarMenu() {

    //fetch("ListaProducto").
    //    then(response => response.json()).
    //    then(response => {
    //        let resultado = '';

    //        console.log(response);
    //        for (let i in response) {

    //            resultado += `<div id="imgSeleccion" '>
    //                        <a id="mienlace"   href="seleccionaProductos/${response[i].Id}"><img  id="" class="" src="${response[i].NombreImagen.slice(1)}" alt=""></a>
    //                        <p> ${response[i].Nombre} <br> S/. ${response[i].Precio}</p>
                            
    //                    </div> `
    //        }

    //        document.getElementById("resultadoProducto").innerHTML = resultado;

    //    })



    fetch("ListarMenu").
        then(response => response.json()).
        then(response => {

            let resultado = '';

            console.log(response);
            for (let i in response) {
                
                resultado += `<a class="collapse-item" href="${response[i].Controlador}">${response[i].Nombre}</a>`
            }

            document.getElementById("menuadmin").innerHTML = resultado;

            

        });


}