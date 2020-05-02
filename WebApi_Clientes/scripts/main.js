$(function () {
    actualizarGrilla();
    $('#btnGuardar').click(function () { guardarCliente(); });
    $('#btnEliminar').click(function () { borrarCliente(); });
    $('#btnCancelar').click(function () { limpiarControles(); });

    $('#btnGuardar').val("Nuevo");

});

function actualizarGrilla()
{
    var data = ajaxGET();
    construyeGrilla(data);
};

function ajaxGET() {
    var result;

    $.ajax({
        url: 'http://localhost:6030/api/clientes',
        type: 'GET',
        async: false
    }).done(function (data) {
        //$('#txtDireccion').val(data[0].Direccion);
        result = data;
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function ajaxPOST() {
    var result;
    var obj = obtenerCliente();

    $.ajax({
        url: 'http://localhost:6030/api/clientes',
        type: 'POST',
        async: false,
        data: { "Id": obj.Id, "Nombre": obj.Nombre, "Apellido": obj.Apellido, "Fecha_Nac": obj.Fecha_Nac, "Direccion": obj.Direccion }
    }).done(function (data) {
        result = data;
        alert('Elemento insertado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function ajaxPUT() {
    var result;
    var obj = obtenerCliente();

    $.ajax({
        url: 'http://localhost:6030/api/clientes',
        type: 'PUT',
        async: false,
        data: obj
    }).done(function (data) {
        result = data;
        alert('Elemento actualizado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function ajaxDELETE(id) {
    var result;

    $.ajax({
        url: 'http://localhost:6030/api/clientes/'+id,
        type: 'DELETE',
        async: false
    }).done(function (data) {
        result = data;
        alert('Elemento borrado')
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function construyeGrilla(data) {
    var grd = $('#grdClientes');
    grd.html("");
    var tbl = $('<table border=1></table>');


    var header = $('<tr></tr>');
    header.append('<td>Id</td>');
    header.append('<td>Nombre</td>');
    header.append('<td>Apellido</td>');
    header.append('<td>Fecha de Nacimiento</td>');
    header.append('<td>Direccion</td>');

    tbl.append(header);
 

    for(d in data)
    {
        var row = $('<tr class="jqClickeable"></tr>');
        row.append('<td>' + data[d].Id + '</td>');
        row.append('<td>' + data[d].Nombre + '</td>');
        row.append('<td>' + data[d].Apellido + '</td>');
        row.append('<td>' + data[d].Fecha_Nac + '</td>');
        row.append('<td>' + data[d].Direccion + '</td>');

        tbl.append(row);
    }

    grd.append(tbl);
    $('.jqClickeable').click(function () { mostrarElemento($(this)); });

}

function borrarCliente()
{
    var id = $('#txtID').val();
    ajaxDELETE(id);
    actualizarGrilla();
    limpiarControles();
}

function guardarCliente() {
    var id = $('#txtID').val();
    if (id == 0)
    {
        ajaxPOST();
    }
    else
    {
        ajaxPUT();
    }
    actualizarGrilla();
    limpiarControles();
}

function mostrarElemento(elem)
{
    $('#txtID').val(elem.children().eq(0).text());
    $('#txtNombre').val(elem.children().eq(1).text());
    $('#txtApellido').val(elem.children().eq(2).text());
    $('#txtFecha').val(elem.children().eq(3).text());
    $('#txtDireccion').val(elem.children().eq(4).text());

    $('#btnGuardar').val("Modificar");
}

function obtenerCliente()
{
    var cliente = {};
    cliente.Id = $('#txtID').val();
    cliente.Nombre = $('#txtNombre').val();
    cliente.Apellido = $('#txtApellido').val();
    cliente.Fecha_Nac = $('#txtFecha').val();
    cliente.Direccion = $('#txtDireccion').val();

    return cliente;
}
function limpiarControles()
{
    $('#txtID').val(0);
    $('#txtNombre').val("");
    $('#txtApellido').val("");
    $('#txtFecha').val("");
    $('#txtDireccion').val("");

    $('#btnGuardar').val("Nuevo");

}