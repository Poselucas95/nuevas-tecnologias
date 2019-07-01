﻿$(document).ready(function () {
    var contadorDia = 1;


    function deshabilitarBoton() {
        var botonEliminarDia = document.getElementById("boton-eliminar-dia");
        var botonAgregarDia = document.getElementById("boton-agregar-dia");
        if (contadorDia > 1) {
            botonEliminarDia.classList.remove("disabled");
        } else {
            botonEliminarDia.classList.add("disabled");
        }
        if (contadorDia === 7) {
            botonAgregarDia.classList.add("disabled");
        } else {
            botonAgregarDia.classList.remove("disabled");
        }
    }

    

    

    // funcion agregar ejercicio
    $(".boton-agregar-ejercicio-1").click(function () {
        var listItem = document.createElement("li");
        var divEjercicioRow = document.createElement("div");
        var divColumnaMusculo = document.createElement("div");
        var labelMusculo = document.createElement("label");
        var selectMusculos = document.createElement("select");
        var optionSeleccionarMusc = document.createElement("option");
        var optionEspalda = document.createElement("option");
        var optionPecho = document.createElement("option");
        var optionBiceps = document.createElement("option");
        var optionTriceps = document.createElement("option");
        var optionPiernas = document.createElement("option");
        listItem.classList.add("list-group-item");
        divEjercicioRow.classList.add("panel-body", "row");
        divColumnaMusculo.classList.add("col-lg-2");
        labelMusculo.setAttribute("for", "selectMusc");
        selectMusculos.classList.add("form-control");
        selectMusculos.setAttribute("id", "selectMusc");
        labelMusculo.append("Músculo:");
        optionSeleccionarMusc.append("Seleccionar músculo");
        optionPecho.append("Pecho");
        optionEspalda.append("Espalda");
        optionBiceps.append("Biceps");
        optionTriceps.append("Triceps");
        optionPiernas.append("Piernas");


        var divColumnaEjercicio = document.createElement("div");
        var labelEjercicio = document.createElement("label");
        var selectEjercicios = document.createElement("select");
        divColumnaEjercicio.classList.add("col-lg-4");
        labelEjercicio.setAttribute("for", "selectEjer");
        selectEjercicios.classList.add("form-control");
        selectEjercicios.setAttribute("id", "selectEjer");


        var divColumnaRepes = document.createElement("div");
        var labelRepes = document.createElement("label");
        var inputRepes = document.createElement("input");
        divColumnaRepes.classList.add("col-lg-4");
        labelRepes.setAttribute("for", "selectEjer");
        labelRepes.append("Repeticiones:");
        inputRepes.classList.add("form-control");
        inputRepes.setAttribute("id", "inputRepes");
        inputRepes.setAttribute("type", "text");

        var divColumnaEliminar = document.createElement("div");
        var botonEliminar = document.createElement("btn");
        divColumnaEliminar.classList.add("col-lg-2");
        divColumnaEliminar.setAttribute("align", "center");
        botonEliminar.classList.add("btn","btn-danger");
        botonEliminar.append("Eliminar");

        divColumnaMusculo.append(labelMusculo);
        divColumnaMusculo.append(selectMusculos);
        selectMusculos.append(optionSeleccionarMusc);
        selectMusculos.append(optionPecho);
        selectMusculos.append(optionEspalda);
        selectMusculos.append(optionBiceps);
        selectMusculos.append(optionTriceps);
        selectMusculos.append(optionPiernas);
        divEjercicioRow.append(divColumnaMusculo);

        divColumnaEjercicio.append(labelEjercicio);
        labelEjercicio.append("Ejercicio:");
        divColumnaEjercicio.append(selectEjercicios);
        divEjercicioRow.append(divColumnaEjercicio);

        divColumnaRepes.append(labelRepes);
        divColumnaRepes.append(inputRepes);
        divEjercicioRow.append(divColumnaRepes);

        divColumnaEliminar.append(botonEliminar);
        divEjercicioRow.append(divColumnaEliminar);

        listItem.append(divEjercicioRow);
        $("ol").append(listItem);

    });

    // funcion agregar dia
    $("#boton-agregar-dia").click(function () {
        if (contadorDia === 7) {
            alert("La semana solo llega a 7 días");
            return "";
        }
        contadorDia++;
        var divPanelDia = document.createElement("div");
        var divPanelHeading = document.createElement("div");
        var divPanelDefault = document.createElement("div");
        var divPanelTitleRow = document.createElement("div");
        var divColDia = document.createElement("div");
        var dia = document.createElement("a");
        var divColBoton = document.createElement("div");
        var botonAgregarEjercicio = document.createElement("btn");
        var divCollapse = document.createElement("div");
        var orderList = document.createElement("ol");
        var listItem = document.createElement("li");
        var divEjercicioRow = document.createElement("div");
        var divColumnaMusculo = document.createElement("div");
        var labelMusculo = document.createElement("label");
        var selectMusculos = document.createElement("select");
        var optionSeleccionarMusc = document.createElement("option");
        var optionEspalda = document.createElement("option");
        var optionPecho = document.createElement("option");
        var optionBiceps = document.createElement("option");
        var optionTriceps = document.createElement("option");
        var optionPiernas = document.createElement("option");

        divPanelDia.classList.add("panel-group");
        divPanelDia.setAttribute("id","accordion");
        divPanelHeading.classList.add("panel-heading");
        divPanelTitleRow.classList.add("panel-title", "row");
        divPanelDefault.classList.add("panel", "panel-default");
        divPanelDefault.setAttribute("id", "dia" + contadorDia);
        divColDia.classList.add("col-lg-1");
        dia.setAttribute("data-toggle", "collapse");
        dia.setAttribute("data-parent", "#accordion");
        dia.setAttribute("href", "#collapse" + contadorDia);
        dia.append("Dia "+contadorDia);
        divColBoton.classList.add("col-lg-1", "col-lg-offset-9");
        divColBoton.setAttribute("align", "right");
        botonAgregarEjercicio.classList.add("btn", "btn-success", "boton-agregar-ejercicio-" + contadorDia);
        botonAgregarEjercicio.append("Agregar ejercicio");
        divCollapse.setAttribute("id","collapse"+contadorDia);
        divCollapse.classList.add("panel-collapse","collapse","in");
        orderList.classList.add("list-group");
        listItem.classList.add("list-group-item");
        divEjercicioRow.classList.add("panel-body", "row");
        divColumnaMusculo.classList.add("col-lg-2");
        labelMusculo.setAttribute("for", "selectMusc");
        selectMusculos.classList.add("form-control");
        selectMusculos.setAttribute("id", "selectMusc");
        labelMusculo.append("Músculo:");
        optionSeleccionarMusc.append("Seleccionar músculo");
        optionPecho.append("Pecho");
        optionEspalda.append("Espalda");
        optionBiceps.append("Biceps");
        optionTriceps.append("Triceps");
        optionPiernas.append("Piernas");


        var divColumnaEjercicio = document.createElement("div");
        var labelEjercicio = document.createElement("label");
        var selectEjercicios = document.createElement("select");
        divColumnaEjercicio.classList.add("col-lg-4");
        labelEjercicio.setAttribute("for", "selectEjer");
        selectEjercicios.classList.add("form-control");
        selectEjercicios.setAttribute("id", "selectEjer");


        var divColumnaRepes = document.createElement("div");
        var labelRepes = document.createElement("label");
        var inputRepes = document.createElement("input");
        divColumnaRepes.classList.add("col-lg-4");
        labelRepes.setAttribute("for", "selectEjer");
        labelRepes.append("Repeticiones:");
        inputRepes.classList.add("form-control");
        inputRepes.setAttribute("id", "inputRepes");
        inputRepes.setAttribute("type", "text");

        var divColumnaEliminar = document.createElement("div");
        var botonEliminar = document.createElement("btn");
        divColumnaEliminar.classList.add("col-lg-2");
        divColumnaEliminar.setAttribute("align", "center");
        botonEliminar.classList.add("btn", "btn-danger");
        botonEliminar.append("Eliminar");

        divColumnaMusculo.append(labelMusculo);
        divColumnaMusculo.append(selectMusculos);
        selectMusculos.append(optionSeleccionarMusc);
        selectMusculos.append(optionPecho);
        selectMusculos.append(optionEspalda);
        selectMusculos.append(optionBiceps);
        selectMusculos.append(optionTriceps);
        selectMusculos.append(optionPiernas);
        divEjercicioRow.append(divColumnaMusculo);

        divColumnaEjercicio.append(labelEjercicio);
        labelEjercicio.append("Ejercicio:");
        divColumnaEjercicio.append(selectEjercicios);
        divEjercicioRow.append(divColumnaEjercicio);

        divColumnaRepes.append(labelRepes);
        divColumnaRepes.append(inputRepes);
        divEjercicioRow.append(divColumnaRepes);

        divColumnaEliminar.append(botonEliminar);
        divEjercicioRow.append(divColumnaEliminar);

        listItem.append(divEjercicioRow);
        $(orderList).append(listItem);
        divCollapse.append(orderList);

        divColBoton.append(botonAgregarEjercicio);
        divColDia.append(dia);
        divPanelTitleRow.append(divColDia);
        divPanelTitleRow.append(divColBoton);
        divPanelHeading.append(divPanelTitleRow);
        divPanelDefault.append(divPanelHeading);
        divPanelDefault.append(divCollapse);
        
        $("#accordion").append(divPanelDefault);
        deshabilitarBoton();
    });

    //funcion eliminar ultimo dia
    $("#boton-eliminar-dia").click(function () {
        if (contadorDia === 1) {
            alert("Solo puede tenerse como mínimo un día");
            return "";
        }
        $("#dia" + contadorDia).remove();
        contadorDia--;
        deshabilitarBoton();
    });

});