using System.Data.SqlClient;

namespace Taller.DataAccess
{
    public class BdComun
    {

       public static SqlConnection ObtenerConexion()
       {
           SqlConnection conectar = new SqlConnection("Data Source=LENOVO-PC;Initial Catalog=Taller;Integrated Security=true;");

           conectar.Open();
           return conectar;
       }

    }
}
C:\Users\Terriand\Desktop\taller - zip\WebApi_Clientes\Web.config