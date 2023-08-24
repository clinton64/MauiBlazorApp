window.DataTables = {
    dataTable: null,
    buildDataTable: function () {
        this.dataTable = $("#weather").DataTable({
            "columnDefs": [{
                "targets": 0,
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
        });

        /*var self = this; // Save the reference to the object

        // Add click event handler to rows
        $('#weather tbody').on('click', 'tr', function () {
            var rowData = self.dataTable.row(this).data();
            if (rowData) {
                var dateValue = new Date(rowData[0]); // Assuming date is in the first column
                var formattedDate = dateValue.toISOString(); // Convert to ISO format or any format you prefer

                // Construct the URL with the formatted date
                var newPageUrl = 'new_page.html?date=' + encodeURIComponent(formattedDate);

                // Navigate to the new page
                window.location.href = newPageUrl;
            }
        });*/
    },
    destroyDataTable: function () {
        if (this.dataTable) {
            this.dataTable.destroy();
        }
    }
}

// Call the buildDataTable method to initialize the DataTable
window.DataTables.buildDataTable();
