window.DataTables2 = {
    dataTable: null,
    buildDataTable: function () {
        this.dataTable = $("#appFiles").DataTable({
            "columnDefs": [{
                "targets": 3,
                "render": function (data, type, row, meta) {
                    var dateValue = new Date(data);

                    if (type === 'display') {
                        return dateValue.toLocaleDateString();
                    }
                    else {
                        return dateValue.valueOf();
                    }
                }
            }],
            deferRender: true,
            scrollCollapse: true,
            scroller: true,
            scrollY: 300
        });
    },
    destroyDataTable: function () {
        if (this.dataTable) {
            this.dataTable.destroy();
        }
    }
}

// Call the buildDataTable method to initialize the DataTable
window.DataTables2.buildDataTable();
