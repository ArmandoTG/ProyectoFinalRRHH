function Inicio() {
    $(document).ready(function () {

        function cargar_frmdocumento() {

            $("#frame").load("/Documento/Documento", function (response, status, xhr) {
                if (status == "error") {
                    var msg = "Error!, algo ha sucedido: ";
                    $("#frameDocumento").html(msg + xhr.status + " " + xhr.statusText);
                }
            });
        }
        cargar_frmdocumento();

        function cargar_frmListaDocumentos() {

            $("#frame").load("/ListaDocumentos/ListaDocumentos", function (response, status, xhr) {
                if (status == "error") {
                    var msg = "Error!, algo ha sucedido: ";
                    $("#frameDocumento").html(msg + xhr.status + " " + xhr.statusText);
                }
            });
        }
        $("#hrefDocumento").click(function () {
            cargar_frmdocumento();
        });
        $("#hrefListaDocumentos").click(function () {
            cargar_frmListaDocumentos();
        });

    });
}

function Documento() {
    $(document).ready(function () {
        $("#panel-title").text("Registro");
        $('.date-picker').datepicker({
            orientation: "top auto",
            autoclose: true,
            language: 'es',
            todayHighlight: true
        });



        function cargarDate() {
            var DTO = {};

            $.ajax({
                type: "POST",
                url: "../Documento/GetDate",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('#txtFecha').val(response[0].vc_Fecha);
                    $('#txtHora').val(response[0].vc_Hora);
                },
                error: function (response) {
                    if (response.length != 0)
                        $('#txtFecha').val("Error");
                    $('#txtHora').val("Error");
                },
                complete: function (response) {
                }
            });
        }
        cargarDate();

        function cargarTipoSolicitud(idddl) {

            var IDDropDownList = "#" + idddl;
            var DTO = {};
            //DTO.in_PadreID = in_PadreID;
            //DTO.in_Nivel = in_Nivel;

            $.ajax({
                type: "POST",
                url: "../Documento/GetTipoSolicitud",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("--- Seleccione ---");
                    for (var i = 0; i < response.length; i++) {
                        var val = response[i].in_IDTipoSolicitud;
                        var text = response[i].vc_Descripcion;
                        $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option(text, val);
                    }
                    //funcionSuccess();

                },
                error: function (response) {
                    if (response.length != 0)
                        $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("Sin Datos");
                    //funcionError();
                },
                complete: function (response) {
                    //uncionComplete();
                }
            });
        }
        cargarTipoSolicitud("ddlTipoSolicitud");

        function cargarSede(idddl, IDSede) {

            var IDDropDownList = "#" + idddl;
            var DTO = {};

            $.ajax({
                type: "POST",
                url: "../Documento/GetSede",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("--- Seleccione ---");
                    for (var i = 0; i < response.length; i++) {
                        var val = response[i].in_IDSede;
                        var text = response[i].vc_Descripcion;
                        if (val == IDSede) {
                            $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option(text, val, true, true);
                        }
                        else {
                            $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option(text, val, false);

                        }
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("Sin Datos");
                },
                complete: function (response) {
                    if (IDSede != null) {
                        var valSede = $("#ddlSede").val();
                        cargarRecepcionista(valSede);
                    }
                    else {
                        $('#spnRecepcion').text("Seleccione una sede");
                    }
                }
            });
        }
        cargarSede("ddlSede");

        function cargarArea(idddl) {

            var IDDropDownList = "#" + idddl;
            var DTO = {};

            $.ajax({
                type: "POST",
                url: "../Documento/GetArea",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("--- Seleccione ---");
                    for (var i = 0; i < response.length; i++) {
                        var val = response[i].in_IDArea;
                        var text = response[i].vc_Descripcion;
                        var idSede = response[i].in_IDSede;
                        ($(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option(text, val)).setAttribute("data-idsede", idSede);
                    }
                },
                error: function (response) {
                    if (response.length != 0)
                        $(IDDropDownList).get(0).options.length = 0;
                    $(IDDropDownList).get(0).options[$(IDDropDownList).get(0).options.length] = new Option("Sin Datos");
                },
                complete: function (response) {
                }
            });
        }
        cargarArea("ddlArea");

        function cargarRecepcionista(in_IDSede) {
            var in_IDPerfil = 1;
            var in_IDSede = in_IDSede;
            var DTO = {};
            DTO.in_IDPerfil = in_IDPerfil;
            DTO.in_IDSede = in_IDSede;

            $.ajax({
                type: "POST",
                url: '../Documento/GetUsuario',
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('#spnRecepcion').text(response[0].vc_Nombre + ' ' + response[0].vc_ApellidoPat);
                },
                error: function (response) {
                    if (response.length != 0)
                        $('#spnRecepcion').text("Seleccione una sede");
                }
            });
        }

        $("#ddlArea").change(function () {
            var selected = $(this).find('option:selected');
            var extra = selected.data('idsede');
            cargarSede("ddlSede", extra);
        });

        function registrarDocumento() {
            var vc_Descripcion = $('#txtDescripcion').val();
            var vc_Fecha = $('#txtFecha').val();
            var vc_Hora = $('#txtHora').val();
            var vc_CodOriginal = $('#txtCodOriginal').val();
            var in_IDTipoSolicitud = $('#ddlTipoSolicitud').val();
            var in_NumeroHojas = $('#txtNhojas').val();
            var vc_Remitente = $('#txtRemitente').val();
            var vc_Ruta = $('#txtArchivo').val();
            var in_IDArea = $('#ddlArea').val();
            var in_IDSede = $('#ddlSede').val();
            var vc_Recepcionista = $('#spnRecepcion').text();
            var vc_Observacion = $('#txtObservacion').val();
            var in_IDExpediente = null;
            var vc_Estado = 'Pendiente Archivo';

            var Documento = {};
            Documento.vc_Descripcion = vc_Descripcion;
            Documento.vc_Fecha = vc_Fecha;
            Documento.vc_Hora = vc_Hora;
            Documento.vc_CodOriginal = vc_CodOriginal;
            Documento.in_IDTipoSolicitud = in_IDTipoSolicitud;
            Documento.in_NumeroHojas = in_NumeroHojas;
            Documento.vc_Remitente = vc_Remitente;
            Documento.vc_Ruta = vc_Ruta;
            Documento.in_IDArea = in_IDArea;
            Documento.in_IDSede = in_IDSede;
            Documento.vc_Recepcionista = vc_Recepcionista;
            Documento.vc_Observacion = vc_Observacion;
            Documento.in_IDExpediente = in_IDExpediente;
            Documento.vc_Estado = vc_Estado;

            var DTO = {};
            DTO.Documento = Documento;

            $.ajax({
                type: "POST",
                url: "../Documento/SetDocumento",
                data: JSON.stringify(DTO),
                contentType: "application/json;charset=utf-8",
                dataType: "json",

                success: function (response) {
                    var obj = JSON.stringify(response);
                    if (obj > 0) {
                        alert("Datos Registrados Correctamente" + obj);



                        var in_IDDocumento = obj;
                        var DTO = {};
                        DTO.in_IDDocumento = in_IDDocumento;

                        $.ajax({
                            type: "POST",
                            url: '../Documento/GetDocumento',
                            data: JSON.stringify(DTO),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                $('.spnCodigo').text(response[0].vc_CodOriginal);
                                $('.spnDescripcion').text(response[0].vc_Descripcion);
                                $('.spnFecha').text(response[0].vc_Fecha);
                                $('.spnHora').text(response[0].vc_Hora);
                                $('.spnHojas').text(response[0].in_NumeroHojas);
                                $('.spnDestino').text(response[0].vc_Destino);

                                $('.modal').modal({
                                    keyboard: false,
                                    backdrop: 'static',
                                })
                            },
                            error: function (response) {

                            }
                        });
                    }
                },
                error: function (response) {
                    if (response.length != 0) {
                        alert("Ocurrio un error");
                    }
                }
            });
        }



        $('#btnimprimir').click(function () {

            $("#div-print").print();
        });

        $('#fileupload').validate({
            rules: {
                txtDescripcion: {
                    required: true
                },
                txtCodOriginal: {
                    required: true
                },
                txtRemitente: {
                    required: true
                },
                ddlTipoSolicitud: {
                    min: 1
                },
                ddlTipoSolicitud: {
                    min: 1
                },
                txtNhojas: {
                    required: true
                },
                ddlArea: {
                    min: 1
                },
                ddlSede: {
                    min: 1
                },

            },
            messages: {
                //firstname: "Enter your firstname",
                txtDescripcion: "Campo requerido",
                txtCodOriginal: "Campo requerido",
                txtRemitente: "Campo requerido",
                txtNhojas: "Campo requerido",

                ddlTipoSolicitud: {
                    min: "Seleccione un elemento",
                },
                ddlArea: {
                    min: "Seleccione un elemento",
                },
                ddlSede: {
                    min: "Seleccione un elemento",
                },
                //username: {
                //    required: "Enter a username",
                //    minlength: jQuery.format("Enter at least {0} characters"),
                //    remote: jQuery.format("{0} is already in use")
                //}
            },
            submitHandler: function (form) { // for demo	
                //alert("data saved");
                registrarDocumento();
            }
        });

        $('#btnGuardar').click(function () {

            //registrarDocumento();
            $("#fileupload").submit();
        });

        function enviarCorreo() {
            var EmailAddress = "bquiroz@cosapidata.com.pe";
            var txtSubject = "PRUEBA TRAMITE DOC"
            var txtMessage = "PRUEBA TRAMITE DOC"


            var Correo = {};
            Correo.EmailAddress = EmailAddress;
            Correo.txtSubject = txtSubject;
            Correo.txtMessage = txtMessage;


            var DTO = {};
            DTO.Correo = Correo;

            $.ajax({
                type: "POST",
                url: "../Documento/SendEmail",
                data: JSON.stringify(DTO),
                contentType: "application/json;charset=utf-8",
                dataType: "json",

                success: function (response) {
                    var obj = JSON.stringify(response);
                    if (obj > 0) {
                        alert("Datos Registrados Correctamente" + obj);
                    }
                },
                error: function (response) {
                    if (response.length != 0) {
                        alert("Ocurrio un error");
                    }
                }
            });
        }

        $('#btnGuardarEnviar').click(function () {
            enviarCorreo();
        });

        $('#fileupload').fileupload({
            url: '../Documento/UploadFiles',
            maxChunkSize: 10000000,
            acceptFileTypes: /(jpg)|(jpeg)|(png)|(gif)|(pdf)$/i,
            add: function (e, data) {
                $("#btnGuardar").off('click').on('click', function () {
                    //data.submit();
                });
            },
        });





        $("#ddlSede").change(function () {
            var selected = $(this).val();
            cargarRecepcionista(selected);
        });
    });
}

function ListaDocumentos() {
    $(document).ready(function () {
        $("#panel-title").text("Lista");
        $('#table_id').dataTable({
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });
        $('.date-picker').datepicker({
            orientation: "top auto",
            autoclose: true,
            language: 'es'
        });
    });
}