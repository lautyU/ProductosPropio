using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller.BussinesLogic;
using Taller.DataAccess;
using Taller.Domain;

namespace WebFormClientes
{
    public partial class WebFormClientes : System.Web.UI.Page
    {
        private int _IDCliente;
        private void ActualizarControles()
        {
            btnGuardar.Text = "Modificar";
            _IDCliente = Convert.ToInt32(grdBuscar.SelectedRow.Cells[1].Text);
            txtNombre.Text = Convert.ToString(grdBuscar.SelectedRow.Cells[2].Text);
            txtApellido.Text = Convert.ToString(grdBuscar.SelectedRow.Cells[3].Text);
            txtFecha.Text = Convert.ToString(grdBuscar.SelectedRow.Cells[4].Text);
            txtDireccion.Text = Convert.ToString(grdBuscar.SelectedRow.Cells[5].Text);
            Page.Session["_IDCliente"] = _IDCliente;
        }

        private void ActualizarGrilla()
        {
            List<Cliente> lista = ClientesDAL.Buscar();
            grdBuscar.DataSource = lista;
            grdBuscar.DataBind();
        }

        private void Limpiar()
        {
            btnGuardar.Text = "Nuevo";
            _IDCliente = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFecha.Text = DateTime.Now.ToString();
            txtDireccion.Text = "";
            Page.Session["_IDCliente"] = _IDCliente;
        }

        private Cliente ObtenerCliente()
        {
            Cliente pCliente = new Cliente();
            _IDCliente = Convert.ToInt32(Page.Session["_IDCliente"]);

            pCliente.Id = _IDCliente;
            pCliente.Nombre = txtNombre.Text;
            pCliente.Apellido = txtApellido.Text;
            pCliente.Fecha_Nac = txtFecha.Text ;
            pCliente.Direccion = txtDireccion.Text;

            return pCliente;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente pCliente = ObtenerCliente();
            ClientesManager.Guardar(pCliente);
            ActualizarGrilla();
            Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void grdBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarControles();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarGrilla();
            }
        }
    }
}