$(function () {
    $('.js-basic-example').DataTable({
        responsive: true,
        "language": {
            "decimal": "",
            "emptyTable": "رکوردی وجود ندارد",
            //"info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "info": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
            "infoEmpty": "نمایش 0 تا 0 از 0 ",
            //"infoFiltered": "(filtered from _MAX_ total entries)",
            "infoFiltered": "(جستجو از _MAX_ مجموع رکورد ها)",
            //"infoPostFix": "",
            //"thousands": ",",
            //"lengthMenu": "Show _MENU_ entries",
            "lengthMenu": "نمایش _MENU_ رکورد",
            "loadingRecords": "لطفا صبر کنید...",
            "processing": "در حال انجام ...",
            "search": "جستجو:",
            "zeroRecords": "رکوردی یافت نشد",
            "paginate": {
                "first": "اول",
                "last": "اخر",
                "next": "بعدی",
                "previous": "قبلی"
            },
        }
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