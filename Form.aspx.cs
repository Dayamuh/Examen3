using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncuestasUTC
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropdown();
            }
        }
        protected void LlenarDropdown()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CONSULTAR_PARTIDOS"))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropList.DataSource = dt;

                            DropList.DataTextField = dt.Columns["NombrePartido"].ToString();
                            DropList.DataValueField = dt.Columns["PartidoID"].ToString();
                            DropList.DataBind();
                        }
                    }
                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

             int resultado = Clases.Form.AgregarForm(tNom.Text, int.Parse(tEdad.Text), tCore.Text, int.Parse(DropList.Text));


                    if (resultado > 0)
                    {
                        alertas("La encuesta ha sido agregada con exito");
                        tNom.Text = string.Empty;
                        tEdad.Text = string.Empty;
                        tCore.Text = string.Empty;
                    }
                    else
                    {
                        alertas("Error al ingresar encuesta");

                    }        

        }
        
    }
}