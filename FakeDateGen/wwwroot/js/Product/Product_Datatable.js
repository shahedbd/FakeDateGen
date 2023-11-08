$(document).ready(function () {
    LoadIndex();
});

var LoadIndex = function () {
    $('#tblProduct').DataTable({
        paging: true,
        select: true,
        "order": [[0, "desc"]],
        dom: 'Bfrtip',


        buttons: [
            'pageLength',
        ],


        "processing": true,
        "serverSide": true,
        "filter": true, //Search Box
        "orderMulti": false,
        "stateSave": true,

        ajax: {
            url: '/Product/Data',
            type: "POST"
        },
        rowId: 'Id',
        columns: [
            { data: "Id", title: "Id" },
            { data: "Code", title: "Code" },
            { data: "Description", title: "Description" },
            { data: "Category", title: "Category" },
            { data: "Price", title: "Price" }
        ]
    });
}