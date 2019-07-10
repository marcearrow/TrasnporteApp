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
            LlenarRutas();
            LlenarPasajes();
        }

    }

    private void LlenarPasajes()
    {
        ModeloBD db = new ModeloBD();

        var listaPasajes = from p in db.Pasaje
                           join r in db.Ruta on p.id_ruta equals r.id_ruta
                           join v in db.Vehiculo on r.id_vehiculo equals v.id_vehiculo
                           select new
                           {
                               Nombre = p.nombre_pasaje,
                               Fecha = p.fecha_pasaje,
                               Precio = p.precio_pasaje,
                               Ruta = r.nombre_ruta,
                               Vehiculo = v.nombre_vehiculo,
                           };

    
        listadoPasajes.DataSource = listaPasajes.ToList();
        listadoPasajes.DataBind();
    }

    private void LlenarRutas()
    {
        ModeloBD db = new ModeloBD();

        IQueryable<Ruta> rutas = from r in db.Ruta select r;

        ddRuta.DataSource = rutas.ToList();
        ddRuta.DataTextField = "nombre_ruta";
        ddRuta.DataValueField = "id_ruta";
        ddRuta.DataBind();
        ddRuta.Items.Insert(0, "Seleccione una ruta");
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        fechaInput.Text = Calendar1.SelectedDate.ToShortDateString();
    }

    protected void ddRuta_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddVehiculo.DataSource = null;
        ddVehiculo.DataBind();

        ModeloBD db = new ModeloBD();

        int id = Convert.ToInt32(ddRuta.Text.Trim());

        IQueryable<Vehiculo> vehiculos = from v in db.Vehiculo
                                         join r in db.Ruta on v.id_vehiculo equals r.id_vehiculo
                                         where r.id_ruta.Equals(id)
                                         select v;
        ;
        ddVehiculo.DataSource = vehiculos.ToList();
        ddVehiculo.DataTextField = "nombre_vehiculo";
        ddVehiculo.DataValueField = "id_vehiculo";
        ddVehiculo.DataBind();
        ddVehiculo.SelectedIndex = 0;
    }

    protected void cmdAddPasaje_Click(object sender, EventArgs e)
    {
        Pasaje pasaje = new Pasaje();
        ModeloBD bd = new ModeloBD();

        if (!nombreInput.Equals("") && !precioInput.Equals(""))
        {
          

            if  (!nombreInput.Text.Equals("") && ddRuta.SelectedIndex>0)
            {


                int resultado = bd.Pasaje.Count(x => x.nombre_pasaje.Equals(nombreInput.Text.Trim()));

                if (resultado == 0)
                {
                    pasaje.nombre_pasaje = nombreInput.Text.ToString().Trim();
                    pasaje.fecha_pasaje = Calendar1.SelectedDate;
                    pasaje.precio_pasaje = Convert.ToInt32(precioInput.Text.ToString().Trim());
                    pasaje.id_ruta = Convert.ToInt32(ddRuta.Text.Trim());
                    pasaje.id_vehiculo = Convert.ToInt32(ddVehiculo.Text.Trim());



                    nombreInput.Text = "";
                    fechaInput.Text = "";
                    precioInput.Text = "";
                    ddRuta.SelectedIndex=0;
                    ddVehiculo.DataSource=null;
                    ddVehiculo.DataBind();

                    try
                    {
                        bd.Pasaje.Add(pasaje);
                        bd.SaveChanges();
                        LtMensaje.Text = "<span class='alert alert-success'>Pasaje agregado exitosamente</span>";
                        LlenarPasajes();


                    }
                    catch (Exception ex)
                    {
                        LtMensaje.Text = "<span class='alert alert-danger'>El pasaje no se pudo agregar " + ex.ToString() + "</span>";

                    }
                }
                else
                {
                    LtMensaje.Text = "El nombre debe ser unico";
                }
            }
            
        }
        else
        {
            LtMensaje.Text = "complete todos los campos";
        }
    }




    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        if (!BuscarInput.Text.Trim().Equals(""))
        {
            ModeloBD db = new ModeloBD(); 
            var listaPasaje = from p in db.Pasaje
                               join r in db.Ruta on p.id_ruta equals r.id_ruta
                               join v in db.Vehiculo on r.id_vehiculo equals v.id_vehiculo
                               where p.nombre_pasaje.Equals(BuscarInput.Text.Trim())
                               select new
                               {
                                   Nombre = p.nombre_pasaje,
                                   Fecha = p.fecha_pasaje,
                                   Precio = p.precio_pasaje,
                                   Ruta = r.nombre_ruta,
                                   Vehiculo = v.nombre_vehiculo,
                               };


            if (listaPasaje.Any())
            {
               listadoPasajes.DataSource = listaPasaje.ToList();
               listadoPasajes.DataBind();


            }
            else
            {
                listadoPasajes.DataSource = null;
                listadoPasajes.DataBind();
                ltModificar.Text = "<h4>No se encontro ningun pasaje</h4>";
            }


        }
        else
        {
            LlenarPasajes();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

        ModeloBD bd = new ModeloBD();
        var resultado = bd.Pasaje.FirstOrDefault(x => x.nombre_pasaje.Equals(BuscarInput.Text));

        if (resultado != null)
        {
            bd.Pasaje.Remove(resultado);
            bd.SaveChanges();
            LlenarPasajes();
            ltModificar.Text = "eliminado";
            BuscarInput.Text = "";
        }
        else
        {
            ltModificar.Text = "ocurrio un error";
        }
    }
}