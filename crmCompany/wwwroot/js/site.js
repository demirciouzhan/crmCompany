// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    //select2 eklentimizin tanımı
    $('#select2').select2();
    //hepsiniSec kodlarımız
    $("#hepsiniSec").on("click", function () {
        if ($(this).is(':checked')) {
            $("#select2 > option").prop("selected", "selected");
            $("#select2").trigger("change");
        }
        else {
            $("#select2 > option").removeAttr("selected");
            $("#select2").trigger("change");
        }
    });
});
