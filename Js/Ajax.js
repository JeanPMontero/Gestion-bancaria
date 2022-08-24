$(function () {
    $("#Contenido_txtIdentificacion").change(function () {
        //valores de parametros a enviar
        var identificacion = $('#Contenido_txtIdentificacion').val();
        //llamado mediante ajax
        $.ajax({
            url: '/SolicitudesAjax.aspx/obtenerClientePorIdentificacion',
            data: '{identificacion: ' + identificacion + '}',
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                if (resultado.d != null) {
                    $("#Contenido_txtNombre").val(resultado.d.nombres + " " + resultado.d.apellidos);
                    $("#Contenido_txtIdCliente").val(resultado.d.idCliente);
                    $('#mensaje').html('');
                } else {
                    $("#Contenido_txtNombre").val('');
                    $('#mensaje').html('No existe Cliente con el número de documento de identidad');
                }
            },
            error: function (resultado) {
                alert("ERROR " + resultado.status + ' ' + resultado.statusText);
            }
        });
    });

    //validar si exsite número de cuenta
    $("#Contenido_txtNumeroCuenta").change(function () {
        //valores de parametros a enviar
        var numeroCuenta = $('#Contenido_txtNumeroCuenta').val();
        //llamado mediante ajax
        $.ajax({
            url: '/SolicitudesAjax.aspx/existeCuentaPorNumero',
            data: '{numeroCuenta: ' + numeroCuenta + '}',
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                if (resultado.d == 0) {
                    $('#mensaje').html('No existe cuenta con ese Número, Intente nuevamente');

                } else {
                    $('#mensaje').html('');

                }
            },
            error: function (resultado) {
                alert("ERROR " + resultado.status + ' ' + resultado.statusText);
            }
        });
    });

    //Retirar de la cuenta
    $("#Contenido_txtValorRetirar").change(function () {
        //valores de parametros a enviar
        var numeroCuenta = $('#Contenido_txtNumeroCuenta').val();
        var valorRetirar = $('#Contenido_txtValorRetirar').val();
        //llamado mediante ajax
        $.ajax({
            url: '/SolicitudesAjax.aspx/tieneSaldoDisponible',
            data: '{numeroCuenta: ' + numeroCuenta + '}',
            dataType: 'json',
            type: 'post',
            contentType: "application/json; charset=utf-8",
            success: function (resultado) {
                if (resultado.d != null) {
                    if (resultado.d.tipoCuenta == 1) {
                        if (valorRetirar > resultado.d.saldo) {
                            $('#mensajeValor').html('El Valor a Retirar excede el saldo actual de $' + resultado.d.saldo);
                        } else {
                            $('#mensajeValor').html('');
                        }
                    } else {
                        if (resultado.d.saldo - valorRetirar < -1000000) {
                            $('#mensajeValor').html('Cuenta Corriente excede saldo en Rojo de (-1000000). Saldo Actual: ' + resultado.d.saldo);
                        } else {
                            $('#mensajeValor').html('');
                        }
                    }

                }
            },
            error: function (resultado) {
                alert("ERROR " + resultado.status + ' ' + resultado.statusText);
            }
        });
    });

    //validar si exsite número de cuenta
    $("#Contenido_cbCuentasOrigen").change(function () {        
        if ($("#Contenido_cbCuentasOrigen option:selected").text() == $("#Contenido_txtNumeroCuentaDestino").val()) {
            $('#mensajeOrigen').html('Cuenta Origen y Destino no pueden ser iguales');
        } else {
            $('#mensajeDestino').html('');
            $('#mensajeOrigen').html('');
            //valores de parametros a enviar
            var numeroCuenta = $('#Contenido_cbCuentasOrigen option:selected').text();
            //llamado mediante ajax
            $.ajax({
                url: '/SolicitudesAjax.aspx/existeCuentaPorNumero',
                data: '{numeroCuenta: ' + numeroCuenta + '}',
                dataType: 'json',
                type: 'post',
                contentType: "application/json; charset=utf-8",
                success: function (resultado) {
                    if (resultado.d == 0) {
                        $('#mensajeOrigen').html('No existe cuenta con ese Número, Intente nuevamente');

                    } else {
                        $('#mensajeOrigen').html('');

                    }
                },
                error: function (resultado) {
                    alert("ERROR " + resultado.status + ' ' + resultado.statusText);
                }
            });
        }
    });

    //validar si exsite número de cuenta
    $("#Contenido_txtNumeroCuentaDestino").change(function () {
        if ($("#Contenido_cbCuentasOrigen option:selected").text() == $("#Contenido_txtNumeroCuentaDestino").val()) {
            $('#mensajeDestino').html('Cuenta Origen y Destino no pueden ser iguales');
        } else {
            $('#mensajeDestino').html('');
            $('#mensajeOrigen').html('');
            //valores de parametros a enviar
            var numeroCuenta = $('#Contenido_txtNumeroCuentaDestino').val();
            //llamado mediante ajax
            $.ajax({
                url: '/SolicitudesAjax.aspx/existeCuentaPorNumero',
                data: '{numeroCuenta: ' + numeroCuenta + '}',
                dataType: 'json',
                type: 'post',
                contentType: "application/json; charset=utf-8",
                success: function (resultado) {
                    if (resultado.d == 0) {
                        $('#mensajeDestino').html('No existe cuenta con ese Número, Intente nuevamente');

                    } else {
                        $('#mensajeDestino').html('');

                    }
                },
                error: function (resultado) {
                    alert("ERROR " + resultado.status + ' ' + resultado.statusText);
                }
            });
        }
    });
});