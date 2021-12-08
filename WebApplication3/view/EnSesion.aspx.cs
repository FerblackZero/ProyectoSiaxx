using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.view
{
    public partial class EnSesion1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cx = new SqlConnection("server=FERBLACK\\SQLEXPRESS; database=System_UPBC; User ID=Administrador; Password=12345; MultipleActiveResultSets=true");

            String query = "SELECT * FROM Alumno INNER JOIN Matricula, INNER JOIN Nombre, INNER JOIN Carrera," +
                "INNER JOIN Periodo, INNER JOIN FK_Cuatrimestre, INNER JOIN Estatus, INNER JOIN Condicion, INNER JOIN Direccion, " +
                "INNER JOIN Telefono, INNER JOIN Email, INNER JOIN FK_Tutor, WHERE Matricula= @Matricula";

            //Response.Redirect("EnSesion.aspx");
            SqlCommand com = new SqlCommand(query, cx);
            //com.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
            //com.Parameters.AddWithValue("@Contra", txtContra.Text);
            cx.Open();
            SqlDataReader rs = com.ExecuteReader();
            
            if (rs.Read()) 
            {
                Response.Write(query);
                LBMatricula.Text = rs["Matricula"].ToString();
            }
            
            //Session["Matricula"] = txtMatricula.Text;
            //Label Matricula = LBMatricula;
            //Label Nombre = LBNombreAlumno;
            //Label Carrera = LBNombreCarrera;
        }
    }
}