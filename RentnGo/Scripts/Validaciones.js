$(document).ready(function ($) {

    //1. MASCARAS
    $('#formSearchUpDate').mask('00/00/0000');
    $('#formSearchOffDate').mask('00/00/0000');

    //2. EJECUCION DE VALIDACIONES
    $('#formSearchUpDate').on('blur', validarFecha);
    $('#formSearchOffDate').on('blur', validarFecha);

    //$("#formSearchUpDate").text("");
    //$("#formSearchOffDate").text("");
    // Desarrollo de validaciones de datos ingresados

    function validarMail() {
        if (document.getElementById('txtEmail').value.indexOf("@") < 0
            || document.getElementById('txtEmail').value.indexOf(".") < 0
            || document.getElementById('txtEmail').value.length < 4) {
            $('#txtEmail').removeClass('is-valid').addClass('is-invalid');
        }
        else {
            $('#txtEmail').removeClass('is-invalid').addClass('is-valid');
        }
    }
    
    function validarFecha() {
        var esValido;
        var esValido2;

        if (document.getElementById('formSearchUpDate').value.length < 8 || !isValidDate(document.getElementById('formSearchUpDate').value)) {
            $('#formSearchUpDate').removeClass('is-valid').addClass('is-invalid');
            esValido = false;
        }
        else {
            $('#formSearchUpDate').removeClass('is-invalid').addClass('is-valid');
            esValido = true;
        }

        if (document.getElementById('formSearchOffDate').value.length < 8 || !isValidDate(document.getElementById('formSearchOffDate').value)) {
            $('#formSearchOffDate').removeClass('is-valid').addClass('is-invalid');
            esValido2 = false;
        }
        else {
            $('#formSearchOffDate').removeClass('is-invalid').addClass('is-valid');
            esValido2 = true;
        }

        if (!esValido || !esValido2) {
            //ocultar("btnActualizar");
        }
        else {
        //    mostrar("btnActualizar");
            var currentValue = document.getElementById("hdnPrecioPorDia").innerHTML;
            document.getElementById("vPrecioActual").innerHTML = "$" + (currentValue * diferenciaEntreFechas($("#formSearchUpDate").val(), $("#formSearchOffDate").val()));
            ocultar("porDia");
            console.log(diferenciaEntreFechas($("#formSearchUpDate").val(), $("#formSearchOffDate").val()));
        }


    }

    function isValidDate(dateString) {
        // First check for the pattern
        if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
            return false;

        // Parse the date parts to integers
        var parts = dateString.split("/");
        var day = parseInt(parts[0], 10);
        var month = parseInt(parts[1], 10);
        var year = parseInt(parts[2], 10);

        // Check the ranges of month and year
        if (year < 1000 || year > 3000 || month == 0 || month > 12)
            return false;

        var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        // Adjust for leap years
        if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
            monthLength[1] = 29;

        // Check the range of the day
        return day > 0 && day <= monthLength[month - 1];
    };

    function ocultar(control) {
        $("#" + control).hide();
    }

    function mostrar(control) {
        $("#" + control).show();
    }

    function diferenciaEntreFechas(fecha1, fecha2) {
        var fechaa1 = new Date(fecha1);
        var fechaa2 = new Date(fecha2);

        var dateParts1 = fecha1.split("/");

        // month is 0-based, that's why we need dataParts[1] - 1
        var dateObject1 = new Date(+dateParts1[2], dateParts1[1] - 1, +dateParts1[0]); 

        var dateParts2 = fecha2.split("/");

        // month is 0-based, that's why we need dataParts[1] - 1
        var dateObject2 = new Date(+dateParts2[2], dateParts2[1] - 1, +dateParts2[0]); 

        const diffTime = Math.abs(dateObject2.getTime() - dateObject1.getTime());
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
        return Math.trunc(diffDays);

        //var day = moment(fecha1, "DD/MM/YYYY");
        //var day2 = moment(fecha2, "DD/MM/YYYY");

        //var diffTime = Math.abs(momentsDifference(fecha1, fecha2));
        //var diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
        //return diffDays;
    }
});
