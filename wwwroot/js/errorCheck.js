console.log(@((ViewBag.Message != null && ViewBag.Message) ? "true" : "false"))
document.addEventListener("DOMContentLoaded", function () {
    var txtErrorElement = document.getElementById("txtError");

    if (txtErrorElement) {
        var showError = @((ViewBag.Message != null && ViewBag.Message) ? "true" : "false"); 
        if (showError) {
            txtErrorElement.classList.remove("d-none");
        }
    }
});
console.log(@((ViewBag.Message != null && ViewBag.Message) ? "true" : "false"))