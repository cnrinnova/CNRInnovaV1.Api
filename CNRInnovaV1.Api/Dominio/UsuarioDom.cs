using CNRInnovaV1.Api.Dominio.Servicios;
using CNRInnovaV1.Api.DTO;
using CNRInnovaV1.Api.Entidades;
using CNRInnovaV1.Api.Properties;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ResultActions;
using System.Data;
using System.Linq;

namespace CNRInnovaV1.Api.Dominio
{
    public class UsuarioDom : IUsuarioDom
    {
        private readonly IConfiguration _configuration;
        string MiConexion = "";

        public UsuarioDom(IConfiguration configuration)
        {
            MiConexion = configuration.GetConnectionString("MiConexion");
            _configuration = configuration;
        }

        public ReturnResult<dynamic> ConsultarUsuarioByIdentificacion(int idTipoIdentificacion, string NumDoc)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Consultar_UsuarioByIdentificacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdIdentificacion", idTipoIdentificacion);
                    cmd.Parameters.AddWithValue("@NumDoc", NumDoc);
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
            }

            var resp = dtRetorno.ToDynamic().FirstOrDefault();

            return ReturnResult<dynamic>.CrearExistoso(resp);
        }

        

        public ReturnResult<bool> CrearUsuario(UsuarioDTO usu)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using MySqlCommand cmd = new MySqlCommand("Crear_Usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@UsuEmail", usu.UsuEmail);
                cmd.Parameters.AddWithValue("@TipoIdentificacionId", usu.TipoIdentificacionId);
                cmd.Parameters.AddWithValue("@NumDocumento", usu.NumDocumento);
                cmd.Parameters.AddWithValue("@PriNombre", usu.PriNombre);
                cmd.Parameters.AddWithValue("@SegNombre", usu.SegNombre);
                cmd.Parameters.AddWithValue("@PriApellido", usu.PriApellido);
                cmd.Parameters.AddWithValue("@SegApellido", usu.SegApellido);
                cmd.Parameters.AddWithValue("@FchNacimiento", usu.FchNacimiento);
                cmd.Parameters.AddWithValue("@Celular", usu.Celular);
                cmd.Parameters.AddWithValue("@PerfilId", usu.PerfilId);
                cmd.Parameters.AddWithValue("@Estado", usu.Estado);

                using MySqlDataAdapter dbr = new MySqlDataAdapter(cmd);

                dbr.Fill(dtRetorno);
            }

            var resp = dtRetorno.ToDynamic().FirstOrDefault();

            return ReturnResult<bool>.CrearExistoso(true);
        }

        public ReturnResult<bool> ModificarUsuario(UsuarioDTO usu)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using MySqlCommand cmd = new MySqlCommand("Modificar_Usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsu", usu.Id);
                cmd.Parameters.AddWithValue("@UsuEmail", usu.UsuEmail);
                cmd.Parameters.AddWithValue("@TipoIdentificacionId", usu.TipoIdentificacionId);
                cmd.Parameters.AddWithValue("@NumDocumento", usu.NumDocumento);
                cmd.Parameters.AddWithValue("@PriNombre", usu.PriNombre);
                cmd.Parameters.AddWithValue("@SegNombre", usu.SegNombre);
                cmd.Parameters.AddWithValue("@PriApellido", usu.PriApellido);
                cmd.Parameters.AddWithValue("@SegApellido", usu.SegApellido);
                cmd.Parameters.AddWithValue("@FchNacimiento", usu.FchNacimiento);
                cmd.Parameters.AddWithValue("@Celular", usu.Celular);
                cmd.Parameters.AddWithValue("@PerfilId", usu.PerfilId);
                cmd.Parameters.AddWithValue("@Estado", usu.Estado);

                using MySqlDataAdapter dbr = new MySqlDataAdapter(cmd);

                dbr.Fill(dtRetorno);
            }

            var resp = dtRetorno.ToDynamic().FirstOrDefault();

            return ReturnResult<bool>.CrearExistoso(true);
        }

        public ReturnResult<bool> CrearPassword(PasswordDTO pass)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Crear_Password", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", pass.UsuarioId);
                    cmd.Parameters.AddWithValue("@Pass", pass.Pass);
                    cmd.Parameters.AddWithValue("@Estado", pass.Estado);
                    
                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }
                return ReturnResult<bool>.CrearExistoso(true);
            }
        }

        public ReturnResult<bool> ModificarPassword(PasswordDTO pass)
        {
            DataTable dtRetorno = new DataTable();

            using (MySqlConnection con = new MySqlConnection(MiConexion))
            {
                using (MySqlCommand cmd = new MySqlCommand("Crear_Password", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", pass.UsuarioId);
                    cmd.Parameters.AddWithValue("@Pass", pass.Pass);
                    cmd.Parameters.AddWithValue("@Estado", pass.Estado);

                    using (MySqlDataAdapter dbr = new MySqlDataAdapter(cmd))
                    {
                        dbr.Fill(dtRetorno);
                    }
                }                
            }
            return ReturnResult<bool>.CrearExistoso(true);
        }

    }
}
