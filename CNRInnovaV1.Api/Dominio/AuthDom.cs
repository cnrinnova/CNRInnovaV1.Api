using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.Entidades;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ResultActions;
using System.Data;
using System.Linq;


namespace CNRInnovaV1.Api.Dominio
{
    public class AuthDom : IAuthDom
    {
        private readonly IConfiguration _configuration;
        //private readonly IToolDataComm _toolDataComm;

        string MiConexion = "";

        public AuthDom(IConfiguration configuration)
        {
            MiConexion = configuration.GetConnectionString("MiConexion");
            _configuration = configuration;
        }

        public ReturnResult<Usuario> Login(string usu)
        {
            DataTable dtRetorno = new DataTable();

            MySqlConnection conexion = new MySqlConnection(MiConexion);
           
            MySqlCommand command = new MySqlCommand("Consultar_Usuario", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@usuLogin", usu);

            MySqlDataAdapter dr = new MySqlDataAdapter(command);
            conexion.Open();
            dr.Fill(dtRetorno);
            conexion.Close();

            var resp = ToolDataTable.DataTableToList<Usuario>(dtRetorno).FirstOrDefault();

            return ReturnResult<Usuario>.CrearExistoso(resp);
        }
    }
}
