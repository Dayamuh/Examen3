using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EncuestasUTC.Clases
{
    public class Form
    {
        public static string Nombre { get; set; }
        public static int Edad { get; set; }
        public static string CorreoElec { get; set; }

        public static int PartidoP { get; set; }


        public Form(string nombre, int edad, string correo, int partidoP)
        {
            Nombre = nombre;
            Edad = edad;
            CorreoElec = correo;
            PartidoP = partidoP;
        }
        public Form() { }

        public static int AgregarForm(string nombre, int edad, string correo, int partidoP)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_FORM", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@EDAD", edad));
                    cmd.Parameters.Add(new SqlParameter("@CORREOELEC", correo));
                    cmd.Parameters.Add(new SqlParameter("@PARTIDOP", partidoP));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
    }
}