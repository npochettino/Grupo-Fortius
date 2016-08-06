// -- Inicializo los input del tipo date
$('.sandbox-container-datepicker .input-group.date').datepicker({
    //todayBtn: true,
    //clearBtn: true,
    language: "es",
    format: "dd/mm/yyyy"
});

// -- Inicializo los input del tipo datetime
$('.datetimepicker-control').datetimepicker({
    //todayBtn: true,
    //clearBtn: true,
    locale: "es",
    format: "DD/MM/YYYY HH:mm"
});