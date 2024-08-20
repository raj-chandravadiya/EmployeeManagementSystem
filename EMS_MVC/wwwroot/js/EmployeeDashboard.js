
var filterSearch = ""

EmployeeList(1);

$("#searchFilter").on("blur", function () {
    var searchValue = $(this).val().toLowerCase();
    filterSearch = searchValue;
    EmployeeList(1);
});

$("#searchFilter").on("keydown", function (e) {
    if (e.code === "Enter") {
        var searchValue = $(this).val().toLowerCase();
        filterSearch = searchValue;
        EmployeeList(1);
    }
});

function EmployeeList(page) {
    $.ajax({
        url: "/EmployeeDashboard/EmployeesList",
        type: 'POST',
        data: {
            filterSearch: filterSearch, page: page
        },
        success: function (result) {
            $('#employeeTable').html(result);
        },
        error: function (error) {
            location.href = "/EmployeeDashboard/Error";
        },
    });
}