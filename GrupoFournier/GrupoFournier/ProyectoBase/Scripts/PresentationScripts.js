$(document).ready(function () {
    //Seleccionar el item menu actual
    SelectCurrentMenuItem();
    //Inicializa los combos como select2
    $('.select2').select2();
    // -- Saco la validacion de datetime
    jQuery.validator.methods["date"] = function (value, element) { return true; }
});

//Selecciona el item de menu en el que se encuentra la pagina
function SelectCurrentMenuItem() {
    //obtiene el path
    var path = window.location.pathname;
    // armo el selector
    var selectorString = '.sidebar-menu a[href="' + path + '"]';
    //obtengo los elementos 
    var selector = $(selectorString);
    //si encontró algo
    if (selector.length > 0) {
        //agrega la clase
        selector.parents('li').addClass('active');
    }
    else {
        //si no lo encontro por path es porque es acción
        var split = path.split('/');
        //si tiene un parámetro lo quito
        if (split.length >= 2) {
            path = "/" + split[1] + "/" + split[2];
        }
        // -- Saco el /Index
        path = path.replace("/Index", "");
        // armo el selector
        selectorString = '.sidebar-menu a[data-children-actions~="' + path + '"]';
        //obtengo los elementos 
        selector = $(selectorString);
        //agrega la clase
        selector.parents('li').addClass('active');
    }
}

//Bloqueo y desbloqueo de pantalla mientras un ajax se esta ejecutando
//Bloquea solamente el content-wrapper dejando los menues activos
function BloquearContenido() {
    $('.content-wrapper').overlay();
}

function DesbloquearContenido() {
    $('.content-wrapper').overlayout();
}

/* Funciones para deshabilitar (baja logica) en grilla  */
function DeshabilitarEnModal(disableAction, indexAction) {
    //bloquea contenido
    BloquearContenido();
    $.ajax({
        cache: false,
        type: "POST",
        url: disableAction,
        data: { "id": entityID },
        success: function (data) {
            $('#modalDeshabilitar').modal('hide');
            new PNotify({
                title: 'Deshabilitado correcto',
                text: 'Se deshabilitó ' + nombre + ' correctamente',
                type: 'success',
                hide: true,
                delay: 8000
            });
            DesbloquearContenido();
            window.location.href = indexAction;
        },
        error: function (xhr, ajaxOptions, thrownError) {
            DesbloquearContenido();
            $('#modalDeshabilitar').modal('hide');
            new PNotify({
                title: 'Atencion !',
                text: 'Error al deshabilitar',
                type: 'notice',
                hide: true,
                delay: 8000
            });
        }
    });
}
//Abre el modal para deshabilitar(baja logica)
function AbreModal(entityIDParam, nombreParam) {
    //setea variables desde parametros
    entityID = entityIDParam;
    nombre = nombreParam;
    //Setea el parrafo
    $('#modal-body-deshabilitar').html('<p>Desea deshabilitar ' + nombreParam + '</p>');
    //Abre modal
    $('#modalDeshabilitar').modal('show');
}

/*Completa con 0s a la izquierda*/
function leftPad(number, targetLength) {
    var output = number + '';
    while (output.length < targetLength) {
        output = '0' + output;
    }
    return output;
}

/*Obtiene el valor de un parametro de la query string*/
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}