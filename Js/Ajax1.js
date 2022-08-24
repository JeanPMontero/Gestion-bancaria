$(function () {
    //validar si existe una cuenta
    $("#Contenido_txtNumeroCuentaConsignar").change(function () {
        var numeroCuenta = $("#Contenido_txtNumeroCuentaConsignar").val();
        $.ajax({
            url: '/SolicitudesAjax.aspx/existeCuentaPorNumero',
            data: '{numeroCuenta: ' + numeroCuenta + '}',
            type: 'post',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                if (resultado.d == 0) {
                    $("#mensaje").html('No existe cuenta con ese Número');
                } else {
                    $("#mensaje").html('');
                }
            }, error: function (resultado) {
                alert("ERROR " + resultado.status + ' ' + resultado.statusText);
            }
        });
    });
});