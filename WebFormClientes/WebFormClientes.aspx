<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormClientes.aspx.cs" Inherits="WebFormClientes.WebFormClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/main.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Formulario de Clientes</h1>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label class='label' ID="lblNombre" runat="server" Text="Nombre"  Width="200"></asp:Label>
            <asp:TextBox class='text' ID="txtNombre" runat="server" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblApellido" runat="server" Text="Apellido" Width="200" style=""></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" Width="234px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblFecha" runat="server" Text="Fecha de Nacimiento"  Width="200"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" Width="233px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion"  Width="200"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" Width="230px"></asp:TextBox>
        </p>
         
        <p>
            <asp:GridView ID="grdBuscar" runat="server" style="margin-left: 300px; margin-top:30px" OnSelectedIndexChanged="grdBuscar_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnGuardar" CssClass='boton' runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            <asp:Button ID="btnCancelar" CssClass='boton' runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </p>
    </form>
</body>
</html>
