using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.view
{
    public partial class SiaxxLogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void BtnLogin_Click(object sender, EventArgs e) 
        {
            SqlConnection cx = new SqlConnection("server=FERBLACK\\SQLEXPRESS; database=System_UPBC; User ID=Administrador; Password=12345; MultipleActiveResultSets=true");

            String query = "SELECT * FROM Usuario WHERE Matricula= @Matricula AND Contraseña=@Contra";
            //Response.Redirect("EnSesion.aspx");
            SqlCommand com = new SqlCommand(query, cx);
            com.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
            com.Parameters.AddWithValue("@Contra", txtContra.Text);
            cx.Open();
            SqlDataReader rs = com.ExecuteReader();
            if (rs.Read())
            {
                Response.Write(query);
                Session["Matricula"] = txtMatricula.Text;
                Response.Redirect("EnSesion.aspx");
            }
            else
            {
                string script = " <script type='text/javascript'> alert('Credenciales Incorrectas!!');   </script> ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "callfn", script, false);
                txtMatricula.Text = "";
                txtContra.Text = "";
            }
        }
    }
}