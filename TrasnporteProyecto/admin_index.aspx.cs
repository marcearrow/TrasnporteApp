using EntityModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LlenarTabla();
    }

    private void LlenarTablaConductores()
    {
        ModeloBD bd = new ModeloBD();
        var listado = from e in bd.Empleado
                      join r in bd.Rol on e.id_rol equals r.id_rol
                      where e.id_rol == 2
                      select new
                      {
                          Rut = e.rut_empleado,
                          Empleado = e.nombre_empleado + " " + e.apellidom_empleado + " " + e.apellidom_empleado,
                          Telefono = e.telefono_empleado,
                          Email = e.email_empleado,
                          Dirección = e.direccion_empleado,
                      };

        GridView1.DataSource = listado.ToList();
        GridView1.DataBind();
    }

    private void LlenarTablaVendedores()
    {
        ModeloBD bd = new ModeloBD();
        var listado = from e in bd.Empleado
                      join r in bd.Rol on e.id_rol equals r.id_rol
                      where e.id_rol == 3
                      select new
                      {
                          Rut = e.rut_empleado,
                          Nombre = e.nombre_empleado + " " + e.apellidom_empleado + " " + e.apellidom_empleado,
                          Telefono = e.telefono_empleado,
                          Email = e.email_empleado,
                          Dirección = e.direccion_empleado,
                      };

        GridView2.DataSource = listado.ToList();
        GridView2.DataBind();
    }

    private void LlenarTabla()
    {

        LlenarTablaConductores();
        LlenarTablaVendedores();

    }


}