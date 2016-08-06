$(document).ready(function () {
    $('.input-icon').on('change keyup', function () {
        var valor = $(this).val();
        $(this).next().find('.previsualizarIcono').first().removeClass().addClass("previsualizarIcono " + valor);
        //$('.previsualizarIcono').removeClass().addClass(valor);
    });
    $('.input-icon').change();
});