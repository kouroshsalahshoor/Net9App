//https://sweetalert2.github.io/
window.showSwal = function (type, message) {
    if (type == "success") {
        Swal.fire({
            title: "Good job!",
            text: message,
            icon: "success"
        });
    }
    else if (type == "error") {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: message,
            //footer: '<a href="#">Why do I have this issue?</a>'
        });
    }
    else if (type == "warning") {
        Swal.fire({
            title: "Warning!",
            text: message,
            icon: "warning"
        });
    }
}