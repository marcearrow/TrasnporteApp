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
            LlenarRoles();
            LlenarEmpleados();
        }

    }

    private void LlenarRoles()
    {
        ModeloBD bd = new ModeloBD();
        IQueryable<Rol> roles = from r in bd.Rol where r.id_rol != 1 select r;
        ddRol.DataSource = roles.ToList();
        ddRol.DataTextField = "nombre_rol";
        ddRol.DataValueField = "id_rol";
        ddRol.DataBind();
        ddRol.Items.Insert(0, "Seleccione el rol");
    }

    protected void ddRol_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cmdAddEmpleado_Click(object sender, EventArgs e)
    {
        Empleado em = new Empleado();
        ModeloBD db = new ModeloBD();

        if (!rutInput.Equals("") && ddRol.SelectedIndex != 0)
        {
            var resultado = db.Empleado.Count(x => x.rut_empleado.Equals(rutInput.Text.Trim()));

            if (resultado ==0)
            {
                em.rut_empleado = rutInput.Text.Trim();
                em.nombre_empleado = nombreInput.Text.Trim();
                em.apellidop_empleado = apellidopInput.Text.Trim();
                em.apellidom_empleado = apellidomInput.Text.Trim();
                em.direccion_empleado = direccionInput.Text.Trim();
                em.email_empleado = emailInput.Text.Trim();
                em.telefono_empleado = telefonoInput.Text.Trim();
                em.id_rol = Convert.ToInt32(ddRol.SelectedValue.ToString());
                em.clave_empleado = "123456";

                rutInput.Text = "";
                nombreInput.Text = "";
                apellidopInput.Text = "";
                apellidomInput.Text = "";
                direccionInput.Text = "";
                emailInput.Text = "";
                telefonoInput.Text = "";


                try
                {
                    db.Empleado.Add(em);
                    db.SaveChanges();
                    LtMensaje.Text = "<span class='alert alert-success'>Empleado agregado exitosamente</span>";
                    LlenarEmpleados();


                }
                catch (Exception ex)
                {
                    LtMensaje.Text = "<span class='alert alert-danger'>El empleado no se pudo agregar " + ex.ToString() + "</span>";

                }
            }
            else
            {
                LtMensaje.Text = "El rut no puede ser igual a otro";
               
            }
        }


    }

    private void LlenarEmpleados()
    {
        ModeloBD db = new ModeloBD();
        var listaEmpleados = from e in db.Empleado
                             join r in db.Rol on e.id_rol equals r.id_rol
                             where e.id_rol != 1
                             select new
                             {
                                 Rut = e.rut_empleado,
                                 Empleado = e.nombre_empleado + " " + e.apellidom_empleado,
                                 Telefono = e.telefono_empleado,
                                 Email = e.email_empleado,
                                 Direccion = e.direccion_empleado,
                                 Puesto = r.nombre_rol,
                             };

        listadoEmpleados.DataSource = listaEmpleados.ToList();
        listadoEmpleados.DataBind();
    }

    protected void GridViewEmpleados_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Modificar")
        {


        }
        if (e.CommandName == "Eliminar")
        {

        }

    }

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        if (!BuscarInput.Text.Trim().Equals(""))
        {
            ModeloBD db = new ModeloBD();
            var empleado = from em in db.Empleado
                           join r in db.Rol on em.id_rol equals r.id_rol
                           where em.rut_empleado.Equals(BuscarInput.Text.Trim())
                           select new
                           {
                               Rut = em.rut_empleado,
                               Empleado = em.nombre_empleado + " " + em.apellidom_empleado,
                               Telefono = em.telefono_empleado,
                               Email = em.email_empleado,
                               Direccion = em.direccion_empleado,
                               Puesto = r.nombre_rol,
                           };
            if (empleado.Any())
            {
                listadoEmpleados.DataSource = empleado.ToList();
                listadoEmpleados.DataBind();


            }
            else
            {
                listadoEmpleados.DataSource = null;
                listadoEmpleados.DataBind();
                ltModificar.Text = "<h4>No se encontro a ningun empleado</h4>";
            }


        }
        else
        {
            LlenarEmpleados();
        }
    }




    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ModeloBD bd = new ModeloBD();
        Empleado resultado = bd.Empleado.FirstOrDefault(x => x.rut_empleado.Equals(BuscarInput.Text.Trim()));

        if (resultado != null)
        {
            bd.Empleado.Remove(resultado);
            bd.SaveChanges();
            LlenarEmpleados();
            ltModificar.Text = "eliminado";
            BuscarInput.Text = "";
        }
        else
        {
            ltModificar.Text = "ocurrio un error";
        }
    }


}
