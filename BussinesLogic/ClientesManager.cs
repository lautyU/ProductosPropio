using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.DataAccess;
using Taller.Domain;

namespace Taller.BussinesLogic
{
    public static class ClientesManager
    {
        public static int Guardar (Cliente pCliente)
        {
            //TODO : Validar Fecha
            if (true)
            {
                return ClientesDAL.Guardar(pCliente);
            }
            else return 0;
        }

        public static int Borrar(int id)
        {
            return ClientesDAL.Borrar(id);
        }

        public static List<Cliente> Get()
        {
            return ClientesDAL.Buscar();
        }
    }
}
