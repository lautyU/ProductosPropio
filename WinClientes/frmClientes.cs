using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taller.BussinesLogic;
using Taller.DataAccess;
using Taller.Domain;


namespace Taller.WinClientes
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private int IDCliente;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente pCliente = ObtenerCliente();
            ClientesManager.Guardar(pCliente);
            ActualizarGrilla();
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvBuscar_Click(object sender, EventArgs e)
        {
            ActualizarControles();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
        private void ActualizarControles()
        {
            btnGuardar.Text = "Modificar";
            IDCliente = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[1].Value);
            txtApellido.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[2].Value);
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvBuscar.CurrentRow.Cells[3].Value);
            txtDireccion.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[4].Value);
        }

        private void ActualizarGrilla()
        {
            List<Cliente> lista = ClientesDAL.Buscar();
            dgvBuscar.DataSource = lista;
        }

        private void Limpiar()
        {
            btnGuardar.Text = "Nuevo";
            IDCliente = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtDireccion.Text = "";
        }

        private Cliente ObtenerCliente()
        {
            Cliente pCliente = new Cliente();

            pCliente.Id = IDCliente;
            pCliente.Nombre = txtNombre.Text;
            pCliente.Apellido = txtApellido.Text;
            pCliente.Fecha_Nac = dtpFechaNacimiento.Value.Year.ToString() + '/' + dtpFechaNacimiento.Value.Month.ToString() + '/' + dtpFechaNacimiento.Value.Day.ToString(); ;
            pCliente.Direccion = txtDireccion.Text;

            return pCliente;
        }
    }
}
