$("#AddCategoryBtn").click(function () {
    var name = $("#Name").val();
    var modalSuccess = $("#addCategoryModalSuccess");
    var modalForm = $("#addCategoryForm")
    console.log(name);

    $.ajax({
        url: 'Home/AddCategory',
        type: 'POST',
        data: {
            name: name
        },
        dataType: 'json',
        success: function (response) {
            modalSuccess.removeClass("d-none");
            modalForm.addClass("d-none");
        },
        failure: function (response) {
            alert('failure');
        },
        error: function (response) {
            alert('error');
        }
    });
});

$("#closeCategoryModalBtn").click(function () {
    $("#addCategoryModal").modal("hide");
});