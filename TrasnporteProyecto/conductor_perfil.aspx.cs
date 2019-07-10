using EntityModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarDatos();
            contraseniaInput.Attributes["type"] = "password";
        }
       
    }

    private void LlenarDatos()
    {
        int id = Convert.ToInt32(Session["id"]);
        ModeloBD db = new ModeloBD();

        Empleado em = db.Empleado.Find(id);
        if (em!=null)
        {
            rutInput.Text = em.rut_empleado.ToString();
            nombreInput.Text = em.nombre_empleado.ToString();
            apellidopInput.Text = em.apellidop_empleado.ToString();
            apellidomInput.Text = em.apellidom_empleado.ToString();
            direccionInput.Text = em.direccion_empleado.ToString();
            emailInput.Text = em.email_empleado.ToString();
            telefonoInput.Text = em.telefono_empleado.ToString();
            contraseniaInput.Text = em.clave_empleado.ToString();
        }
              

    }

    protected void cmdModEmpleado_Click(object sender, EventArgs e)
    {
        ModeloBD bd = new ModeloBD();

        int id = Convert.ToInt32(Session["id"]);

        var resultado = bd.Empleado.Find(id);
        if (resultado != null)
        {
            if (!emailInput.Text.Equals("") && !telefonoInput.Text.Equals("") && !direccionInput.Text.Equals(""))
            {
                resultado.email_empleado = emailInput.Text;
                resultado.telefono_empleado = telefonoInput.Text;
                resultado.direccion_empleado = direccionInput.Text;
                bd.Entry(resultado).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
                LtMensaje.Text = "<span class='alert alert-success'>Perfil modificado exitosamente</span>";
                LlenarDatos();
            }
            else
            {
                LtMensaje.Text = "<span class='alert alert-warning'>Los campos no deben estar vacios</span>";
                LlenarDatos();
            }
           
        }
    }
}