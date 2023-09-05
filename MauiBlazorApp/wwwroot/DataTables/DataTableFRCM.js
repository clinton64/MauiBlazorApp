window.DataTables1 = {
    dataTable: null,
    buildDataTable: function () {
        this.dataTable = $("#frcm_table").DataTable({
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
window.DataTables1.buildDataTable();
