var currentTable
var action; //accion guardada en js
var modalID;//id del modal guardado en js
var tableID;//id de la tabla guardado en js
var nameProp; // nombre
var textBuscar; // input text de buscar
var hiddenText;// text para entityid
var descriptionText; //text para el campo de nombre/descripcion
//muestra el modal y setea las variables que se declaran en el helper
function mostrarModalBusqueda(modalIDParam, tableIDParam, actionNameParam, namePropParam, textBuscarParam, currentIDParam, hiddenTextParam, descriptionTextParam) {
    //Seteo variables globales con el valor del control de busqueda actual
    modalID = modalIDParam;
    tableID = tableIDParam;
    action = actionNameParam;
    nameProp = namePropParam;
    textBuscar = textBuscarParam;
    currentID = currentIDParam;
    hiddenText = hiddenTextParam;
    descriptionText = descriptionTextParam;
    InicializaTablaBusqueda();
    setTimeout(FocusTextBusqueda, 1000)
    $('#' + modalID).modal('show'); 
}

var timerid;
function FocusTextBusqueda()
{
    //seteo foco en el text de buscar 
    $('#' + textBuscar).focus();
}
function InicializaTablaBusqueda()
{
    ActualizarGrillaBusqueda();
}

//funcion que se ejecuta cuando se ingresa texto en el input
$(".textBuscar").on("input", function (e) {
    var value = $(this).val();
    if ($(this).data("lastval") != value) {
        $(this).data("lastval", value);

        //currentColumn = GetColumnsByID(currentID);
        //currentReload = GetReloadByID(currentID);
        //var currentParametros = GetParametrosByID(currentID);

        clearTimeout(timerid);
        timerid = setTimeout(function () {

            ActualizarGrillaBusqueda();
        }, 500);

    };
});

//Retorna el valor de una propiedad por nombre
function GetPropertyByName(obj, prop) {
    var valor;
    $.each(obj, function (key, element) {
        if (key == prop) {
            valor = element;
        }
    });
    return valor;
}

//Selecciona la fila elegida, setea valores en los inputs correspondientes
function SeleccionarFila(EntityID, name) {
    $('#' + hiddenText).val(EntityID).change();
    $('#' + descriptionText).val(name).change();
    $('#' + modalID).modal('hide');
}

//Obtiene las columnas de la tabla por id
function GetColumnsByID(id)
{
    var currentColumns
    for(var i=0; i<columns.length;i++)
    {
        if(columns[i][0]== id)
        {
            currentColumns = columns[i][1];
        }
    }
    return currentColumns;
}

//Obtiene  el reload por id
function GetReloadByID(id) {
    var currentReload
    for (var i = 0; i < reloades.length; i++) {
        if (reloades[i][0] == id) {
            currentReload = reloades[i][1];
        }
    }
    return currentReload;
}

//actualiza el reload a true
function SetReloadTrueByID(id)
{
    for (var i = 0; i < reloades.length; i++) {
        if (reloades[i][0] == id) {
            reloades[i][1] = true;;
        }
    }
}
//Retorna un array con los valores de los parametros para mandar por ajax
function GetParametrosValues(parametrosArray)
{
    var parametrosValues = [];
    for (var i = 0; i < parametrosArray.length; i++) {
        parametrosValues.push(GetInputValueById(parametrosArray[i][1]));
    }
    return parametrosValues;
}
//devuelve el valor de un elemento
function GetInputValueById(inputID)
{
    var value
    var element = $('#' + inputID);
    //Verifica que exista .value , sino obtiene el valor con .val()
    if (undefined != element.value)
    {
        value = element.value
    }
    else
    {
        value = element.val();
    }
    return value;
}

//Obtiene  parametros por id para el buscador actual
function GetParametrosByID(id) {
    var currentParams;
    if (parametrosFiltro !== undefined) {
        for (var i = 0; i < parametrosFiltro.length; i++) {
            if (parametrosFiltro[i][0] == id) {
                currentParams = parametrosFiltro[i][1];
            }
        }
    }
    return currentParams;
}

function ActualizarGrillaBusqueda()
{
    //obtengo las columnas y el estado de reload del control actual 
    currentColumn = GetColumnsByID(currentID);
    currentReload = GetReloadByID(currentID);
    //obtengo los parametros del control actual
    var currentParametros = GetParametrosByID(currentID);

    if (!currentReload) {//la primera vez creo la tabla
        var currentTable = $('#' + tableID).dataTable({
            ajax:
                {
                    url: action,
                    dataType: "json",
                    type: "GET",
                    traditional: true,
                    //contentType: 'application/x-www-form-urlencoded; charset=utf-8',    //replace /json to the urlenoded
                    data: function (d) {
                        d.text = $("#" + textBuscar).val();
                        if (currentParametros != undefined) {
                            d.parametros = GetParametrosValues(currentParametros);
                        }
                    },
                    //data: {text: value},
                    dataSrc: function (json) {
                        //var obj = JSON.parse(json);
                        //console.log(obj);
                        return json;
                    }
                },
            "language": langOptions,
            'columns': currentColumn,
            "aoColumnDefs": [ //agrega la columna de boton
               {
                   "aTargets": [currentColumn.length],
                   "mData": null,
                   "mRender": function (data, type, full) {
                       return '<a href="#" class="btn btn-success btn-xs" onclick="SeleccionarFila(\'' + GetPropertyByName(full, 'EntityID') + '\',\'' + GetPropertyByName(full, nameProp) + '\');"><i class="fa fa-check-circle"></i></a>';
                   }
               }
            ]
        });
        SetReloadTrueByID(currentID);
        //reload = true
    }
    else {//si esta creada, recargo el contenido
        $('#' + tableID).DataTable().ajax.reload();
    }
}