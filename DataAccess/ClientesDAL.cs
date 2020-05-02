using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Taller.Domain;

namespace Taller.DataAccess
{
    public class ClientesDAL
    {
        public static int Guardar(Cliente pCliente)
        {
            if (pCliente.Id == 0) return Agregar(pCliente);
            else return Actualizar(pCliente);
        }

        public static List<Cliente> Buscar()
        {
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand("GetClientes", BdComun.ObtenerConexion());
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);


                _lista.Add(pCliente);
            }

            return _lista;
        }

        public static int Actualizar(Cliente pCliente)
        {
            int retorno = 0;
            SqlConnection conexion = BdComun.ObtenerConexion();

            SqlCommand comando = new SqlCommand(string.Format("Update clientes set Nombre='{0}', Apellido='{1}', Fecha_Nacimiento='{2}', Direccion='{3}' where IdCliente={4}",
                pCliente.Nombre, pCliente.Apellido, pCliente.Fecha_Nac, pCliente.Direccion, pCliente.Id), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }

        public static int Agregar(Cliente pCliente)
        {

            int retorno = 0;

            SqlCommand comando = new SqlCommand(string.Format("Insert into clientes (Nombre, Apellido, Fecha_Nacimiento, Direccion) values ('{0}','{1}','{2}', '{3}')",
                pCliente.Nombre, pCliente.Apellido, pCliente.Fecha_Nac, pCliente.Direccion), BdComun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

        public static int Borrar(int id)
        {

            int retorno = 0;

            SqlCommand comando = new SqlCommand(string.Format("DELETE FROM clientes WHERE IdCliente={0}",
                id), BdComun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();

            return retorno;
        }












        public static List<Cliente> Buscar(string pNombre, string pApellido)
        {
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand(String.Format(
           "SELECT IdCliente, Nombre, Apellido, Fecha_Nacimiento, Direccion FROM clientes  where Nombre ='{0}' or Apellido='{1}'", pNombre, pApellido), BdComun.ObtenerConexion());
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);


                _lista.Add(pCliente);
            }

            return _lista;
        }

 
        public static Cliente ObtenerCliente(int pId)
        {
            Cliente pCliente = new Cliente();
            SqlConnection conexion = BdComun.ObtenerConexion();

            SqlCommand _comando = new SqlCommand(String.Format("SELECT IdCliente, Nombre, Apellido, Fecha_Nacimiento, Direccion FROM clientes where IdCliente={0}", pId), conexion);
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);

            }

            conexion.Close();
            return pCliente;

        }






        public static int Eliminar(int pId)
        {
            int retorno = 0;
            SqlConnection conexion = BdComun.ObtenerConexion();

            SqlCommand comando = new SqlCommand(string.Format("Delete From clientes where IdCliente={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }


    }
}
