﻿




function loadJSON(jsonName, callback) {

    var xobj = new XMLHttpRequest();
    xobj.overrideMimeType("application/json");
    xobj.open('GET', 'http://myjson.com/za2z0', true);
    xobj.onreadystatechange = function () {
        if (xobj.readyState == 4 && xobj.status == "200") {
            // Required use of an anonymous callback as .open will NOT return a value but simply returns undefined in asynchronous mode
            callback(xobj.responseText);
        }
    };
    xobj.send(null);
}

function obtenerYAgregarListaProvincias() {
    //Obtengo la lista de provincias
    loadJSON("jsonProvincias.json", function (response) {
        console.log(response)
        var provinciasFormGroup = document.getElementById("listaProvincias");
        // Parse JSON string into object
        let jsonObj = JSON.parse(response)
        jsonProvinciasYLocalidades = jsonObj
        jsonProvinciasYLocalidades.forEach(prov => {
            console.log(prov);
            provinciasFormGroup.append(new Option(
                prov.nombre));
        });
    });
}

function obtenerLocalidades() {
    var inputProvinciaHtml = document.getElementById("inputProv")
    inputProvinciaHtml.addEventListener("select", function () {
        // Getteo lista de localidades con el
        var provinciaSeleccionada = inputProvinciaHtml.value
        jsonProvinciasYLocalidades.provinciaSeleccionada


    })
}


//Validación del nombre en linea
document.getElementById("inputNombre").addEventListener("input", function () {
    var nombre = document.getElementById("inputNombre");
    //Expresión regular que debe poseer el texto ingresado
    var val = /^([a-zA-Z]+[\s]*)+$/;
    validarExpresion(nombre, val);
});

//Validación del apellido en linea
document.getElementById("inputApellido").addEventListener("input", function () {
    var apellido = document.getElementById("inputApellido");
    //Expresión regular que debe poseer el texto ingresado
    var val = /^([a-zA-Z]+[\s]*)+$/;
    validarExpresion(apellido, val)
});


//Validación del correo en linea
document.getElementById("inputEmail").addEventListener("input", function () {
    var email = document.getElementById("inputEmail");
    //Expresión regular que debe poseer el texto ingresado
    var val = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    validarExpresion(email, val);
});

//Validación del DNI en linea
document.getElementById("inputDni").addEventListener("input", function () {
    var dni = document.getElementById("inputDni");
    if (dni.value.length > 8 || dni.value.length < 7) {
        dni.classList.remove("is-valid");
        dni.classList.add("is-invalid");
    } else {
        dni.classList.remove("is-invalid");
        dni.classList.add("is-valid");
    }

})


//Validación del formulario al momento de ser enviado (enter o click)
function validarFormulario() {
    //Variables de las ID de los campos a validar
    var inputEmail = document.getElementById("inputEmail");
    var inputDni = document.getElementById("inputDni");
    var inputNombre = document.getElementById("inputNombre");
    var inputApellido = document.getElementById("inputApellido");
    var checkBox = document.getElementById("TYC");

    //Validación del Email en caso de ser vacio o poseer la clase "is-invalid"(bootstrap)
    if (inputEmail.classList.contains("is-invalid") || inputEmail.value.length < 1) {
        event.preventDefault();
        var campoEmail = document.querySelector(".email");
        var textoEmail = "Debe ingresar un correo electronico valido";

        if (document.querySelector(".errorEmail")) {
            document.querySelector(".errorEmail").innerText = textoEmail;
        } else {
            crearAlertaError("errorEmail", campoEmail, textoEmail);
        }
    } else {
        //Eliminar alerta en caso de ser corregido
        document.querySelector(".errorEmail").parentNode.removeChild(document.querySelector(".errorEmail"));
    }

    //Validación del DNI en caso de ser vacio o poseer la clase "is-invalid"(bootstrap)
    if (inputDni.classList.contains("is-invalid") || inputDni.value.length < 1) {
        event.preventDefault();
        var campoDni = document.querySelector(".dni");
        var textoDni = "Debe tener entre 7 y 8 caracteres";

        if (document.querySelector(".errorDni")) {
            document.querySelector(".errorDni").innerText = textoDni;
        } else {
            crearAlertaError("errorDni", campoDni, textoDni);
        }
    } else {
        //Eliminar alerta en caso de ser corregido
        document.querySelector(".errorDni").parentNode.removeChild(document.querySelector(".errorDni"));
    }

    //Validación del nombre y apelldio en caso de ser vacio o poseer la clase "is-invalid"(bootstrap)
    if (inputNombre.classList.contains("is-invalid") || inputNombre.value.length < 1 || inputApellido.classList.contains("is-invalid") || inputApellido.value.length < 1) {
        event.preventDefault();
        var campoNombreApellido = document.querySelector(".nombreApellido");
        var textoNombreApellido = "Ingrese su nombre y apellido";

        if (document.querySelector(".errorNombreApellido")) {
            document.querySelector(".errorNombreApellido").innerText = textoNombreApellido;
        } else {
            crearAlertaError("errorNombreApellido", campoNombreApellido, textoNombreApellido);
        }
    } else {
        //Eliminar alerta en caso de ser corregido
        document.querySelector(".errorNombreApellido").parentNode.removeChild(document.querySelector(".errorNombreApellido"));
    }

    //función para validar el checkbox de los términos y condiciones    
    if (!checkBox.checked) {
        event.preventDefault();
        var campoCheckBox = document.querySelector(".campoCheckBox");
        var textoCheck = "Debe aceptar los terminos y condiciones";
        if (document.querySelector(".errorCheckbox")) {
            document.querySelector(".errorCheckbox").innerText = textoCheck;
        } else {
            crearAlertaError("errorCheckbox", campoCheckBox, textoCheck);
        }

    } else {
        document.querySelector(".errorCheckbox").parentNode.removeChild(document.querySelector(".errorCheckbox"));
    }

    

}

//Función para la creación de alertas.
function crearAlertaError(clase, contenedor, texto) {
    var fragmento = document.createDocumentFragment();
    var div = document.createElement("div");
    //Se añaden las clases correspondientes y el texto a mostrar.
    div.classList.add("alert-danger", "alert", clase);
    div.setAttribute("role", "alert");
    div.innerText = texto;
    //Se incluyen los elementos creados.
    fragmento.appendChild(div);
    contenedor.appendChild(fragmento);
}


//Función para validar la expresion regular.
function validarExpresion(valor, expre) {
    if (expre.test(valor.value)) {
        valor.classList.remove("is-invalid");
        valor.classList.add("is-valid");
    } else {
        valor.classList.remove("is-valid");
        valor.classList.add("is-invalid");
    }
}

var modal = document.getElementById('modalTyc');
var tyc = document.getElementById("tyc");
var span = document.getElementsByClassName("close")[0];
tyc.onclick = function () {
    modal.style.display = "block";
}

span.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}