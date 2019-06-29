﻿$(document).ready(function () {


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
        optionSeleccionarMusc.append("Seleccione un musculo");
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
        labelRepes.append("Ejercicio:");
        inputRepes.classList.add("form-control");
        inputRepes.setAttribute("id", "inputRepes");
        inputRepes.setAttribute("type", "text");

        var divColumnaEliminar = document.createElement("div");
        var botonEliminar = document.createElement("btn");
        divColumnaEliminar.classList.add("col-lg-2");
        divColumnaEliminar.setAttribute("align", "center");
        botonEliminar.classList.add("btn","btn-danger");
        botonEliminar.append("Eliminar");


        $("#item-1").append(listItem);

    });


});