function init() {
    bindearEventoClickSubmit();
    bindearEventoTerminosYCondiciones();
}

function bindearEventoClickSubmit() {
    $(".boton-submit").on('click', validarCampos);
}

function bindearEventoTerminosYCondiciones() {
    $(".texto-terminos").click(mostrarTerminos);
}

function validarCampos() {
    validarDniIngresado();
    validarTerminos();
}

function validarDniIngresado() {
    var DNI = document.getElementById("inputDni").value;
    if (DNI.length != 8) {
        alert("El DNI debe tener 8 caracteres");
    }
    event.cancelBubble = true;
}



function validarTerminos() {
    if (!document.getElementById("TYC").checked) {
        alert("Debe aceptar los términos y condiciones.");
    }
}

function mostrarTerminos() {
    $("#modalTerminos").css('display', 'inline-block');
}

document.getElementById("email").addEventListener("input", function () {
    var email = document.getElementById("email");
    var val = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (val.test(email.value)) {
        email.classList.remove("is-invalid");
        email.classList.add("is-valid");
    } else {
        email.classList.remove("is-valid");
        email.classList.add("is-invalid");
    }
});

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

function validarFormulario() {
    if (document.getElementById("email").classList.contains("is-invalid")) {
        alert("Email incorrecto");
        event.preventDefault();
    }

}




$(document).ready(init); 







< !DOCTYPE html >
    <html>
        <head>
            <meta charset="utf-8" />
            <title>Formulario</title>
            <link href="css/index.css" rel="stylesheet" />
            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
                <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
                <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
                <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
   
</head>
            <body>
                <div class="container">
                    <div class="row">

                        <div class="col-lg-6 offset-lg-3">
                            <h1>Bienvenido a vuestro sitio!</h1>
                            <form>
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>Nombre</label>
                                        <input type="text" class="form-control nombre" placeholder="Emilio" required>
                  </div>
                                        <div class="form-group col-md-6">
                                            <label>Apellido</label>
                                            <input type="text" class="form-control" placeholder="Ramirez" required>
                  </div>
                                        </div>
                                        <div class="form-group">
                                            <label for="inputDni">DNI <span>*</span></label>
                                            <input type="number" class="form-control" id="inputDni" required>
              </div>
                                            <div class="form-group">
                                                <label for="email">Email *</label>
                                                <input type="email" class="form-control" id="email" placeholder="ejemplo@gmail.com" required>
              </div>
                                                <div class="form-row">
                                                    <div class="form-group col-lg-12">
                                                        <label for="inputProv">Provincia *</label>
                                                        <select id="inputProv" class="form-control">
                                                            <option selected>Elegir...</option>
                                                            <option>Buenos Aires</option>
                                                            <option>Santa Fe</option>
                                                            <option>La Rioja</option>
                                                            <option>Cordoba</option>
                                                        </select>
                                                    </div>
                                                    <div class="form-group col-lg-12">
                                                        <label for="inputCiudad">Ciudad</label>
                                                        <select id="inputCiudad" class="form-control">
                                                            <option selected>Elegir...</option>
                                                            <option>Nuñez</option>
                                                            <option>Belgrano</option>
                                                            <option>Chacabuco</option>
                                                            <option>Victoria</option>
                                                        </select>
                                                    </div>
                                                    <div class="form-group col-lg-12">
                                                        <label for="inputNumeroTelefonico">Número telefónico</label>
                                                        <input type="number" class="form-control" id="inputNumeroTelefonico">
                  </div>

                                                    </div>
                                                    <div class="form-group">
                                                        <div class="form-check">
                                                            <input class="form-check-input" type="checkbox" id="TYC">
                                                                <label class="form-check-label texto-terminos" for="gridCheck">
                                                                    Aceptar los términos y condiciones
                      </label>
                  </div>
                                                        </div>
                                                        <button type="submit" onclick="validarFormulario();" class="btn btn-primary boton-submit">Enviar</button>



                                                        <div id="modalTerminos" tabindex="-1">
                                                            <div class="modal-dialog" role="document">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                            <span aria-hidden="true">&times;</span>
                                                                        </button>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        ...
                          </div>
                                                                    <div class="modal-footer">
                                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                                        <button type="button" class="btn btn-primary">Save changes</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

          </form>
                                                </div>
                                            </div>
                                        </div>
</body>
                                    <script src="js/form.js"></script>
</html>