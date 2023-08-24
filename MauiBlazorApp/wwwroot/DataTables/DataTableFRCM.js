window.DataTables3 = {
    dataTable: null,
    buildDataTable: function () {
        this.dataTable = $("#frcm_table").DataTable();
    },
    destroyDataTable: function () {
        if (this.dataTable) {
            this.dataTable.destroy();
        }
    }
}

// Call the buildDataTable method to initialize the DataTable
window.DataTables3.buildDataTable();
