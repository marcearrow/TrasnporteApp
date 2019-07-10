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
            LlenarSucursales();
            LlenarVehiculos();

        }
    }

    private void LlenarSucursales()
    {


        ModeloBD bd = new ModeloBD();
        IQueryable<Sucursal> sucursales = from s in bd.Sucursal select s;
        ddInicio.DataSource = sucursales.ToList();
        ddInicio.DataTextField = "nombre_sucursal";
        ddInicio.DataValueField = "id_sucursal";
        ddInicio.DataBind();
        ddInicio.Items.Insert(0, "Seleccione la sucursal de inicio");

        ddLlegada.DataSource = sucursales.ToList();
        ddLlegada.DataTextField = "nombre_sucursal";
        ddLlegada.DataValueField = "id_sucursal";
        ddLlegada.DataBind();
        ddLlegada.Items.Insert(0, "Seleccione la sucursal de llegada");
    }

    private void LlenarVehiculos()
    {
        ModeloBD db = new ModeloBD();

        IQueryable<Vehiculo> vehiculos = from v in db.Vehiculo select v;
        ddVehiculo.DataSource = vehiculos.ToList();
        ddVehiculo.DataTextField = "nombre_vehiculo";
        ddVehiculo.DataValueField = "id_vehiculo";
        ddVehiculo.DataBind();
        ddVehiculo.Items.Insert(0, "Seleccione el vehiculo ");
    }

    private void LlenarRutas()
    {
        ModeloBD db = new ModeloBD();

        var listaRutas = from r in db.Ruta
                         join s in db.Sucursal on r.inicio_ruta equals s.id_sucursal
                         join su in db.Sucursal on r.llegada_ruta equals su.id_sucursal
                         join v in db.Vehiculo on r.id_vehiculo equals v.id_vehiculo
                         select new
                         {
                             Nombre = r.nombre_ruta,
                             Descripcion = r.descripcion_ruta,

                             Inicio = s.nombre_sucursal,
                             Llegada = su.nombre_sucursal,
                             Vehiculo = v.nombre_vehiculo,
                         };
        listadoRutas.DataSource = listaRutas.ToList();
        listadoRutas.DataBind();
    }

    protected void cmdAddRuta_Click(object sender, EventArgs e)
    {
        Ruta r = new Ruta();
        ModeloBD db = new ModeloBD();

        var resultado = db.Ruta.Count(x => x.nombre_ruta.Equals(nombreInput.Text));
        if (resultado==0)
        {
            if (!nombreInput.Text.Equals("") && ddInicio.SelectedIndex>0 && ddLlegada.SelectedIndex>0)
            {
                r.nombre_ruta = nombreInput.Text.Trim();
                r.descripcion_ruta = descripcionInput.Text.Trim();
                r.inicio_ruta = Convert.ToInt32(ddInicio.Text.Trim());
                r.llegada_ruta = Convert.ToInt32(ddLlegada.Text.Trim());
                r.id_vehiculo = Convert.ToInt32(ddVehiculo.Text.Trim());

                nombreInput.Text = "";
                ddInicio.SelectedIndex = 0;
                descripcionInput.Text = "";
                ddLlegada.SelectedIndex = 0;

                try
                {
                    db.Ruta.Add(r);
                    db.SaveChanges();
                    LtMensaje.Text = "<span class='alert alert-success'>Ruta agregada exitosamente</span>";
                    LlenarRutas();


                }
                catch (Exception ex)
                {
                    LtMensaje.Text = "<span class='alert alert-warning'>No se pudo agregar la ruta</span>";
                }

            }
            else
            {
                LtMensaje.Text = "<span class='alert alert-warning'>Los campos no pueden estar vacios</span>";
            }
            

        }
        else
        {
            LtMensaje.Text = "No se puede asignar un mismo nombre";
        }
        

       

    }

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        if (!BuscarInput.Text.Trim().Equals(""))
        {
            ModeloBD db = new ModeloBD();
            var rutas =
            from r in db.Ruta
            join s in db.Sucursal on r.inicio_ruta equals s.id_sucursal
            join su in db.Sucursal on r.llegada_ruta equals su.id_sucursal
            join v in db.Vehiculo on r.id_vehiculo equals v.id_vehiculo
            where r.nombre_ruta.Equals(BuscarInput.Text.Trim())

            select new
            {
                Nombre = r.nombre_ruta,
                Descripcion = r.descripcion_ruta,
                Inicio = s.nombre_sucursal,
                Llegada = su.nombre_sucursal,
                Vehiculo = v.nombre_vehiculo,

            };


            if (rutas.Any())
            {
                listadoRutas.DataSource = rutas.ToList();
                listadoRutas.DataBind();

            }
            else
            {
                listadoRutas.DataSource = null;
                listadoRutas.DataBind();
                ltModificar.Text = "<h4>No se encontro ninguna ruta </h4>";
            }


        }
        else
        {
            LlenarRutas();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ModeloBD bd = new ModeloBD();
        var resultado = bd.Ruta.FirstOrDefault(x => x.nombre_ruta.Equals(BuscarInput.Text.Trim()));

        if (resultado != null)
        {
            bd.Ruta.Remove(resultado);
            bd.SaveChanges();
            LlenarRutas();
            ltModificar.Text = "eliminado";
            BuscarInput.Text = "";
        }
        else
        {
            ltModificar.Text = "ocurrio un error";
        }
    }
}