// Muestra una alerta del tipo success
function AlertSuccess(mensaje, titulo)
{
    new PNotify({
        title: titulo,
        text: mensaje,
        type: 'success',
        hide: true,
        delay: 8000
    });
}

// Muestra una alerta del tipo notice
function AlertNotice(mensaje, titulo) {
    new PNotify({
        title: titulo,
        text: mensaje,
        type: 'notice',
        hide: true,
        delay: 8000
    });
}

// Muestra una alerta del tipo error
function AlertError(mensaje, titulo) {
    new PNotify({
        title: titulo,
        text: mensaje,
        type: 'error',
        hide: true,
        delay: 8000
    });
}

// Muestra una alerta del tipo info
function AlertInfo(mensaje, titulo) {
    new PNotify({
        title: titulo,
        text: mensaje,
        type: 'info',
        hide: true,
        delay: 8000
    });
}