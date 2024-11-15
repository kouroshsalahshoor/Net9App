window.showToastr = function (type, message) {
    if (type == "success") {
        toastr.success(message);
    }
    else if (type == "error") {
        toastr.error(message);
    }
    else if (type == "warning") {
        toastr.warning(message);
    }
}