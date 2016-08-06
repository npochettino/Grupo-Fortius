/*****************************************
    CONTROL: Tree
    ARCHIVO: tree.js
    UBICADO: Controles/Tree/JS
******************************************/
var nodos;
var treeApi;
var seleccionArbol;

function cargarNodos(nodos, claseItem) {

    //Test//////////////////////////////////////////////////////////////
    function test() {
        ////////////////////////////////////////////////////////////////
        //TEST
        //
        var nodos = [{
            "id": 2,
            "label": "Administracion",
            "inode": true,
            "icon": "folder",
            "checkbox": false,
            "branch": [{
                "id": 3,
                "label": "Legales",
                "inode": false,
                "icon": "folder",
            },
                {
                    "id": 4,
                    "label": "Recursos Humanos",
                    "inode": false,
                    "icon": "folder"
                },
                {
                    "id": 5,
                    "label": "Contabilidad",
                    "inode": false,
                    "icon": "folder"
                }]
        },
    {
        "id": 6,
        "label": "Soporte",
        "inode": true,
        "icon": "folder",
        "branch": [{
            "id": 7,
            "label": "Infraestructura",
            "inode": false,
            "icon": "folder",
        },
                {
                    "id": 8,
                    "label": "Servicio",
                    "inode": false,
                    "icon": "folder"
                },
                {
                    "id": 9,
                    "label": "Seguridad",
                    "inode": false,
                    "icon": "folder"
                }]
    },
    {
        "id": 10,
        "label": "Sistemas",
        "inode": false,
        "icon": "folder",
    }
        ];
        //nodos = rootData;
        ////////////////////////////////////////////////////////////////
    }
    ////////////////////////////////////////////////////////////////////

    // var nodos = [{
    //     "id": 2,
    //     "label": "Administracion",
    //     "inode": true,
    //     "icon": "folder",
    //     "checkbox": false,
    //     "branch": [{
    //         "id": 3,
    //         "label": "Legales",
    //         "inode": false,
    //         "icon": "folder",
    //     },
    //         {
    //             "id": 4,
    //             "label": "Recursos Humanos",
    //             "inode": false,
    //             "icon": "folder"
    //         },
    //         {
    //             "id": 5,
    //             "label": "Contabilidad",
    //             "inode": false,
    //             "icon": "folder"
    //         }]
    // }
    // ,
    //{
    //    "id": 6,
    //    "label": "Soporte",
    //    "inode": true,
    //    "icon": "folder",
    //    "branch": [{
    //        "id": 7,
    //        "label": "Infraestructura",
    //        "inode": false,
    //        "icon": "folder",
    //    },
    //            {
    //                "id": 8,
    //                "label": "Servicio",
    //                "inode": false,
    //                "icon": "folder"
    //            },
    //            {
    //                "id": 9,
    //                "label": "Seguridad",
    //                "inode": false,
    //                "icon": "folder"
    //            }]
    //},
    //{
    //    "id": 10,
    //    "label": "Sistemas",
    //    "inode": false,
    //    "icon": "folder",
    //}
    //];
    //init the treeview
    //will try to load the data from the `options.ajax.url` URL
    nodos = JSON.parse(nodos);
    $('#tree').aciTree({
        ajax: {
            url: '/ModulosEntidades/CrearItemMenu.aspx',
            dataType: 'json',
            data: {
                'method': 'CargarNodosTipoAplicacion'
            }
        },
        dataSource: null,
        rootData: nodos,
        queue: {
            async: 4,
            interval: 50,
            delay: 10
        },
        loaderDelay: 500,
        expand: false,
        collapse: false,
        unique: false,
        empty: false,
        selectable: false,           // selectable extension
        multiSelectable: false,     // selectable extension
        fullRow: false,             // selectable extension
        textSelection: false,       // selectable extension
        checkbox: true,            // checkbox extension
        checkboxChain: true,        // checkbox extension
        checkboxBreak: true,        // checkbox extension
        checkboxClick: false,       // checkbox extension
        radio: true,               // radio extension
        radioChain: true,           // radio extension
        radioBreak: true,           // radio extension
        radioClick: false,          // radio extension
        columnData: [],             // column extension
        editable: false,             // editable extension
        editDelay: 250,             // editable extension
        persist: null,              // persist extension
        selectHash: null,           // hash extension
        openHash: null,             // hash extension
        sortable: false,            // sortable extension
        sortDelay: 750,             // sortable extension
        //sortDrag: function(item, placeholder, isValid, helper),                         // sortable extension
        //sortValid: function(item, hover, before, isContainer, placeholder, helper),     // sortable extension
        show: {
            props: {
                'height': 'show'
            },
            duration: 'medium',
            easing: 'linear'
        },
        animateRoot: true,
        hide: {
            props: {
                'height': 'hide'
            },
            duration: 'medium',
            easing: 'linear'
        },
        view: {
            duration: 'medium',
            easing: 'linear'
        },
        autoInit: true,             // aciPlugin
        //ajaxHook: function(item, settings),
        // add the tooltip
        itemHook: function (parent, item, itemData, level) {
            var $this = item.find('.aciTreeText').first();
            $this.attr('data-original-title', itemData.label).tooltip({
                placement: 'bottom',
                container: 'body'
            });
            $this.attr('data-codigo', itemData.id);
        }
        //filterHook: function(item, search, regexp),                  // utils extension
        //serialize: function(item, what, value)
    }).on('acitree', function (event, api, item, eventName, options) {

        switch (eventName) {

            case 'init':

                // set focus so we can use the keyboard already
                $('#tree').focus();
                treeApi.open(treeApi.first());

                if (typeof seleccionArbol != 'undefined' && seleccionArbol != null) {
                    SeleccionarItem(seleccionArbol);
                    //seleccionArbol = null;
                }

                $('.aciTreeText').addClass(claseItem);
                agregarClickARadios();
                agregarIconoPuntoAcciones();
                break;

            case 'selected':

                // show a chart on item selection
                var image = $('.contenido');
                //image.html('Seleccionaste ' + api.itemData(item).label + ' !!!');
                seleccionArbol = api.itemData(item).id;
                try {
                    ItemArbolSeleccionado(this, api.itemData(item));
                }
                catch (err) {
                }

                //Si depende del tipo de nodo
                //if (api.isLeaf(item)) {
                //    image.html('Seleccionaste ' + api.itemData(item).label + ' !!!');
                //} else {
                //    image.html('please select index');
                //}
                break;

            case 'labelset':
                success: {
                    alert(api.itemData(item).id + " " + api.itemData(item).label)
                    nodos = treeApi.serialize(null, null);
                };
                break;

            case 'checked':
                //var api = $('#tree').aciTree('api');
                //leaves = $("#tree .aciTreeLi");
                //checked = api.radios(leaves, true);

                //checked.each(function (index, itemI) {
                //    var $itemI = $(itemI);
                //    api.uncheck($itemI);
                //});
                //api.check(item);
                //break;
        }
    });

    $('#tree').aciTree('init');
    treeApi = $('#tree').aciTree('api');

    //Configuracion de búsqueda
    $('.search').val('')
    var last = '';
    $('.search').keyup(function () {
        if ($(this).val() == last) {
            return;
        }
        last = $(this).val();
        treeApi.filter(null, {
            search: $(this).val(),
            success: function (item, options) {
                var itemSeleccionado = options.first;
                if (!itemSeleccionado) {
                    $('.search-error').addClass('has-error')
                }
                else {
                    $('.search-error').removeClass('has-error'),
                    treeApi.select(itemSeleccionado);
                    this.setVisible(itemSeleccionado);
                    $('.search').focus();
                }
            }
        });
    });

    $('#prev').click(function () {
        var actual = treeApi.selected();
        if (actual.length == 0) actual = $('.aciTreeLi');
        if (actual.length > 0) {
            treeApi.prevMatch(actual, $('.search').val(), function (item) {
                if (item) {
                    // open parents & bring into view
                    this.openPath(item, {
                        success: function (item) {
                            this.setVisible(item);
                        }
                    });
                    // select the item
                    this.select(item);
                } else {
                    alert('¡No se encontraron más resultados!');
                }
            });
        }
    });

    $('#next').click(function () {
        var actual = treeApi.selected();
        if (actual.length == 0) actual = $('.aciTreeLi');
        if (actual.length > 0) {
            treeApi.nextMatch(actual, $('.search').val(), function (item) {
                if (item) {
                    // open parents & bring into view
                    this.openPath(item, {
                        success: function (item) {
                            this.setVisible(item);
                        }
                    });
                    // select the item
                    this.select(item);
                } else {
                    alert('¡No se encontraron más resultados!');
                }
            });
        }
    });

    if (typeof TerminaCargarArbol != 'undefined') {
        TerminaCargarArbol();
    }
};

function SeleccionarItem(sel) {
    treeApi.search(null, {
        search: sel,
        success: function (item) {
            if (item) {
                this.openPath(item, {
                    success: function (item) {
                        this.setVisible(item);
                    }
                });
                this.select(item);
            }
        }
    });
}

//Tooltip
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
});


//Funciones para Guardar
function GuardarTree() {
    PageMethods.GuardarTree(nodos, GuardarTreeCallback, siFalla);
}

function GuardarTreeCallback() {
}

function siFalla() {
}
function agregarClickARadios() {
    $(".aciTreeItem").click(function () {
        descheckearRadios();
    });
}

//Deselecciona los radiobuttons
function descheckearRadios() {
    var api = $('#tree').aciTree('api');
    var leaves = $("#tree *");
    var radios = api.radios(leaves);

    radios.each(function (index, item) {
        var $item = $(item);
        api.uncheck($item);
    });
}

function agregarIconoPuntoAcciones() {
    $('.aciTree i').addClass('fa fa-circle treeActionIcon');
}
//Deselecciona los checkboxs
function descheckearChecks() {
    var api = $('#tree').aciTree('api');
    leaves = $("#tree .aciTreeLi");
    checked = api.checkboxes(leaves);

    checked.each(function (index, item) {
        var $item = $(item);
        api.uncheck($item);
    });
}

//Quita las selecciones de checkbox y radiobuttons
function CleanTreeSelection() {
    descheckearRadios();
    descheckearChecks();
}

function RecuperarCheckedRadios() {
    var itemsCheckeados = [];
    var api = $('#tree').aciTree('api');
    leaves = $("#tree .aciTreeLi");
    radios = api.radios(leaves, true);

    radios.each(function (index, item) {
        var $item = $(item);
        itemsCheckeados.push(api.getId($item));
    });
    if (itemsCheckeados.length > 0) {
        return itemsCheckeados[0];
    }
    else {
        return 0;
    }
}
function RecuperarCheckedChecks() {
    var itemsCheckeados = [];

    var api = $('#tree').aciTree('api');
    leaves = $("#tree .aciTreeLi");
    checked = api.checkboxes(leaves, true);

    checked.each(function (index, item) {
        var $item = $(item);
        itemsCheckeados.push(api.getId($item));
    });
    return itemsCheckeados;
}