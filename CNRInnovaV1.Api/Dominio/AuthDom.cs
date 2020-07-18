using CNRInnovaV1.Api.Comun.Servicios;
using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Entidades;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ResultActions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace CNRInnovaV1.Api.Dominio
{
    public class AuthDom : IAuthDom
    {
        private readonly IConfiguration _configuration;
        private readonly IToolDataComm _toolDataComm;

        string MiConexion = "";

        public AuthDom(IConfiguration configuration, IToolDataComm toolDataComm)
        {
            MiConexion = configuration.GetConnectionString("MiConexion");
            _configuration = configuration;
            _toolDataComm = toolDataComm;
        }

        public ReturnResult<Usuario> Login(string usu)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Consultar_Usuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuLogin", usu);
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
            }
            
            var resp = _toolDataComm.DataTableToList<Usuario>(dtRetorno).FirstOrDefault();
            return ReturnResult<Usuario>.CrearExistoso(resp);
        }
    }
}
