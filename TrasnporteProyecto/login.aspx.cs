using EntityModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void cmdSesion_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ModeloBD bd = new ModeloBD();

            var datos = bd.Empleado.FirstOrDefault(em => em.rut_empleado.Equals(rutInput.Text.Trim()) && em.clave_empleado.Equals(contraseniaInput.Text.Trim()));

            if (datos != null)
            {
                Session["nombre_empleado"] = datos.nombre_empleado.ToString();
                Session["rol_empleado"] = datos.id_rol.ToString();
                Session["id"] = datos.id_empleado.ToString();

                Redireccionar(Session);
            }
            else
            {
                LtMensaje.Text = "<span class='alert alert-warning'>No se pudo iniciar sesión</span>";
            }

        }
    }
    private void Redireccionar(System.Web.SessionState.HttpSessionState session)
    {
        if (session["rol_empleado"].Equals("1"))
        {
            Response.Redirect("admin_index.aspx");
        }

        else if (session["rol_empleado"].Equals("2"))
        {
            Response.Redirect("conductor_index.aspx");
        }
        else
        {
            rfvRut.Text = "El rut ingresado es incorrecto";
            rfvContrasenia.Text = "La contraseña ingresada no es valida";
        }
    }
}
