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
        Literal1.Text = "<h3>Bienvenido "+Session["nombre_empleado"]+" </h3>";
  
        ListaPasajes();
        
    }
    private void ListaPasajes()
    {
        ModeloBD db = new ModeloBD();

        int id = Convert.ToInt32(Session["id"]);

        var listaPasajes = from p in db.Pasaje
                           join r in db.Ruta on p.id_ruta equals r.id_ruta
                           join v in db.Vehiculo on r.id_vehiculo equals v.id_vehiculo
                           join s in db.Sucursal on r.inicio_ruta equals s.id_sucursal
                           join su in db.Sucursal on r.llegada_ruta equals su.id_sucursal
                           join em in db.Empleado on v.id_empleado equals em.id_empleado
                           where em.id_empleado.Equals(id)

                           select new
                           {
                               Pasaje=p.nombre_pasaje,
                               Ruta=r.nombre_ruta,
                               Descripcíon=r.descripcion_ruta,
                               Fecha=p.fecha_pasaje,
                               Inicio=s.nombre_sucursal,
                               Termino=su.nombre_sucursal,
                               Vehihulo=v.nombre_vehiculo,
                              

                           };
        if (listaPasajes.Any())
        {
            listadoPasajes.DataSource = listaPasajes.ToList();
            listadoPasajes.DataBind();
        }
        else
        {
            literal2.Text = "<h3 class='alert alert-success'>No se encuentran rutas por realizar</h3>";
        }
        
    }

   
}