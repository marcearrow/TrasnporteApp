using EntityModeloBD;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            LlenarSucursales();
        }
    }

    private void LlenarSucursales()
    {
        ModeloBD db = new ModeloBD();
        var listaSucursales = from s in db.Sucursal
                              select new
                              {
                                  Nombre = s.nombre_sucursal,
                                  Descripcion = s.descripcion_sucursal,
                                  Direccion = s.direccion_sucursal,
                              };
        listadoSucursales.DataSource = listaSucursales.ToList();
        listadoSucursales.DataBind();
    }

    protected void cmdAddSucursal_Click(object sender, EventArgs e)
    {

        Sucursal s = new Sucursal();
        ModeloBD db = new ModeloBD();

        int resultado = db.Sucursal.Count(x => x.nombre_sucursal.Equals(BuscarInput.Text.Trim()));

        if (resultado == 0)
        {
            if (!nombreInput.Text.Equals("") && !descripcionInput.Text.Equals("") && !direccionInput.Text.Equals(""))
            {
                s.nombre_sucursal = nombreInput.Text.Trim();
                s.descripcion_sucursal = descripcionInput.Text.Trim();
                s.direccion_sucursal = direccionInput.Text.Trim();

                nombreInput.Text = "";
                direccionInput.Text = "";
                descripcionInput.Text = "";


                try
                {
                    db.Sucursal.Add(s);
                    db.SaveChanges();
                    LtMensaje.Text = "<span class='alert alert-success'>Sucursal agregada exitosamente</span>";
                    LlenarSucursales();


                }
                catch (Exception ex)
                {
                    LtMensaje.Text = "<span class='alert alert-warning'>No se pudo agregar</span>";
                }
            }
            else
            {
                LtMensaje.Text = "<span class='alert alert-warning'>Los campos no pueden estar vacios</span>";
            }
            
        }
        else
        {
            LtMensaje.Text = "El nombre no se puede repetir";
        }



    }

    protected void GridViewSucursales_OnRowCommand(object sender, GridViewCommandEventArgs e)
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
            var sucursal = from s in db.Sucursal
                           where s.nombre_sucursal.Equals(BuscarInput.Text.Trim())
                           select new
                           {
                               Nombre = s.nombre_sucursal,
                               Descripcion = s.descripcion_sucursal,
                               Direccion = s.direccion_sucursal,
                           };

            if (sucursal.Any())
            {
                listadoSucursales.DataSource = sucursal.ToList();
                listadoSucursales.DataBind();

            }
            else
            {
                listadoSucursales.DataSource = null;
                listadoSucursales.DataBind();
                ltModificar.Text = "<h4>No se encontro ninguna sucursal</h4>";
            }


        }
        else
        {
            LlenarSucursales();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ModeloBD bd = new ModeloBD();
        Sucursal resultado = bd.Sucursal.First(x => x.nombre_sucursal.Equals(BuscarInput.Text));

        if (resultado != null)
        {
            bd.Sucursal.Remove(resultado);
            bd.SaveChanges();
            LlenarSucursales();
            ltModificar.Text = "eliminado";
            BuscarInput.Text = "";
        }
        else
        {
            ltModificar.Text = "ocurrio un error";
        }
    }
}