var oTable;
$(function () {
    oTable = $('.grid-table').DataTable({
        "language": langOptions,
        "iDisplayLength": 50,
        "bSort": false
    });
});