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
        listItem.addClass("list-group-item ");
        divEjercicioRow.addClass("panel-body row");
        divColumnaMusculo.addClass("col-lg-2");
        labelMusculo.attr("for", "selectMusc");
        selectMusculos.addClass("form-control");
        selectMusculos.attr("id", "selectMusc");
        optionSeleccionarMusc.append("Seleccione un musculo");
        optionPecho.append("Pecho");
        optionEspalda.append("Espalda");
        optionBiceps.append("Biceps");
        optionTriceps.append("Triceps");
        optionPiernas.append("Piernas");
        

        var divColumnaEjercicio = document.createElement("div");
        var labelEjercicio =  document.createElement("label");
        var selectEjercicios = document.createElement("select");
        divColumnaEjercicio.addClass("col-lg-4");
        labelEjercicio.attr("for", "selectEjer");
        selectEjercicios.addClass("form-control");
        selectEjercicios.attr("id","selectEjer");


        var divColumnaRepes = document.createElement("div");
        var labelRepes = document.createElement("label");
        var inputRepes = document.createElement("input");


        var divColumnaEliminar = document.createElement("div");
        var divBoton = document.createElement("btn");

        $("#item-1").append();

    });