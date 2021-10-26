$(function () {
    $('.js-basic-example').DataTable({
        responsive: true,
        ajax: {
            url: '/Account/GetAccountList'
        },
        columns: [
            { data: "Name" },
            { data: "Family" },
            { data: "NationalCode" },
            { data: "Gender" },
            { data: "Email" },
            { data: "UserName" }
        ]
    });

    //Exportable table
    $('.js-exportable').DataTable({
        dom: 'Bfrtip',
        responsive: true,
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
});