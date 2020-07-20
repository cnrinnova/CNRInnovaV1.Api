using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.Entidades;
using CNRInnovaV1.Api.Properties;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ResultActions;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace CNRInnovaV1.Api.Comun
{
    public class CombosComm : ICombosComm
    {
        private readonly IConfiguration _configuration;
        string MiConexion = "";

        public CombosComm(IConfiguration configuration)
        {
            MiConexion = configuration.GetConnectionString("MiConexion");
            _configuration = configuration;
        }


        public ReturnResult<List<dynamic>> ComboTipoIdentificacion()
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Consultar_TipoIdentificacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
            }

            var objDynamic = dtRetorno.ToDynamic();
         
             return ReturnResult<List<dynamic>>.CrearExistoso(objDynamic);
        }

        public ReturnResult<List<dynamic>> ComboEstadoUsuario()
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Consultar_EstadoUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
            }

            var objDynamic = dtRetorno.ToDynamic();

            return ReturnResult<List<dynamic>>.CrearExistoso(objDynamic);
        }

        public ReturnResult<List<dynamic>> ComboPerfiles()
        {            
                 DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Consultar_Perfiles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
            }

            var objDynamic = dtRetorno.ToDynamic();

            return ReturnResult<List<dynamic>>.CrearExistoso(objDynamic);
        }
   
    } 

}
