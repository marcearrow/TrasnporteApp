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
            LlenarVehiculos();
            LlenarEmpleados();
        }
    }

    private void LlenarEmpleados()
    {
        ModeloBD bd = new ModeloBD();
        IQueryable<Empleado> empleados = from em in bd.Empleado where em.id_rol == 2 select em;
        ddConductores.DataSource = empleados.ToList();
        ddConductores.DataTextField = "nombre_empleado";
        ddConductores.DataValueField = "id_empleado";
        ddConductores.DataBind();
        ddConductores.Items.Insert(0, "Seleccione al Conductor");
    }


    private void LlenarVehiculos()
    {
        ModeloBD db = new ModeloBD();
        var listaVehiculos = from v in db.Vehiculo
                             join em in db.Empleado on v.id_empleado equals em.id_empleado
                             where em.id_rol == 2
                             select new
                             {
                                 Nombre = v.nombre_vehiculo,
                                 Modelo = v.modelo_vehiculo,
                                 Capacidad = v.capacidad_vehiculo,
                                 Patente = v.patente_vehiculo,
                                 Conductor = em.nombre_empleado + " " + em.apellidom_empleado,
                             };

        listadoVehiculos.DataSource = listaVehiculos.ToList();
        listadoVehiculos.DataBind();
    }

    protected void cmdAddVehiculo_Click(object sender, EventArgs e)
    {
        Vehiculo v = new Vehiculo();
        ModeloBD db = new ModeloBD();

        int resultado = db.Vehiculo.Count(x => x.patente_vehiculo.Equals(patenteInput.Text.Trim()));

        if (resultado == 0)
        {
            if (!capacidadInput.Text.Equals("") && ddConductores.SelectedIndex > 0)
            {
                v.nombre_vehiculo = nombreInput.Text.Trim();
                v.modelo_vehiculo = modeloInput.Text.Trim();
                v.capacidad_vehiculo = Convert.ToInt32(capacidadInput.Text.Trim());
                v.patente_vehiculo = patenteInput.Text.Trim();
                v.id_empleado = Convert.ToInt32(ddConductores.Text.Trim());
                v.estado_vehiculo = "true";

                nombreInput.Text = "";
                modeloInput.Text = "";
                capacidadInput.Text = "";
                patenteInput.Text = "";

                try
                {
                    db.Vehiculo.Add(v);
                    db.SaveChanges();
                    LtMensaje.Text = "<span class='alert alert-success'>Vehiculo agregado exitosamente</span>";
                    LlenarVehiculos();


                }
                catch (Exception ex)
                {
                    LtMensaje.Text = "<span class='alert alert-danger'>El Vehiculo o no se pudo agregar " + ex.ToString() + "</span>";

                }
            }

        }
        else
        {
            LtMensaje.Text = "La patente no puede repetirse";
        }

    }

    protected void GridViewVehiculos_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {



    }

    protected void ddConductores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        if (!BuscarInput.Text.Trim().Equals(""))
        {
            ModeloBD db = new ModeloBD();
            var vehiculo = from v in db.Vehiculo
                           join em in db.Empleado on v.id_empleado equals em.id_empleado
                           where em.id_rol == 2 && v.patente_vehiculo.Equals(BuscarInput.Text.Trim())
                           select new
                           {
                               Nombre = v.nombre_vehiculo,
                               Modelo = v.modelo_vehiculo,
                               Capacidad = v.capacidad_vehiculo,
                               Patente = v.patente_vehiculo,
                               Conductor = em.nombre_empleado + " " + em.apellidom_empleado,
                           };

            if (vehiculo.Any())
            {
                listadoVehiculos.DataSource = vehiculo.ToList();
                listadoVehiculos.DataBind();

            }
            else
            {
                listadoVehiculos.DataSource = null;
                listadoVehiculos.DataBind();
                ltModificar.Text = "<h4>No se encontro vehiculo </h4>";
            }


        }
        else
        {
            LlenarVehiculos();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ModeloBD bd = new ModeloBD();
        Vehiculo resultado = bd.Vehiculo.FirstOrDefault(x => x.patente_vehiculo.Equals(BuscarInput.Text));

        if (resultado != null)
        {
            bd.Vehiculo.Remove(resultado);
            bd.SaveChanges();
            LlenarVehiculos();
            ltModificar.Text = "eliminado";
            BuscarInput.Text = "";
        }
        else
        {
            ltModificar.Text = "ocurrio un error";
        }
    }

}
