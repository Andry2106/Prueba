using System;
using System.Data;
using System.Web.UI.WebControls;
using Frontend.Logic;

namespace Frontend.Pages
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVuelosProgramados();
            }
        }
        protected void lnkVuelosProgramados_Click(object sender, EventArgs e)
        {
            HiddenFieldVuelo.Value =null;
            btmSeleccionar.Visible = true;
            GvListaVuelos.Visible = true;
            CargarVuelosProgramados();
            GvVuelosCancelados.Visible = false;
        }
        protected void lnkVuelosCancelados_Click(object sender, EventArgs e)
        {
            btmSeleccionar.Visible=false;
            GvVuelosCancelados.Visible = true;
            CargarVuelosCancelados();
            GvListaVuelos.Visible = false;
        }
        private void CargarVuelosProgramados()
        {
            try
            {
                ListaVuelosLogic listaVuelosLogic = new ListaVuelosLogic();
                DataTable vuelosProgramados = listaVuelosLogic.ListadoVuelos(1);
                GvListaVuelos.DataSource = vuelosProgramados;
                GvListaVuelos.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al cargar los datos de los vuelos: " + ex.Message + "');", true);
            }
        }
        private void CargarVuelosCancelados()
        {
            try
            {
                ListaVuelosLogic listaVuelosLogic = new ListaVuelosLogic();
                DataTable vuelosCancelados = listaVuelosLogic.ListadoVuelos(2);
                GvVuelosCancelados.DataSource = vuelosCancelados;
                GvVuelosCancelados.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al cargar los datos de los vuelos: " + ex.Message + "');", true);
            }
        }
        protected void GvListaVuelos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "handleRowClickListado(" + e.Row.RowIndex + ");";
            }
        }
        protected void GvVuelosCancelados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "handleRowClickCancelado(" + e.Row.RowIndex + ");";
            }
        }
        protected void btmSeleccionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HiddenFieldVuelo.Value) || string.IsNullOrEmpty(HiddenFieldIdAvion.Value) || string.IsNullOrEmpty(HiddenFieldOrigen.Value) || string.IsNullOrEmpty(HiddenFieldDestino.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor seleccione un vuelo antes de continuar.');", true);
                return;
            }
            string vuelo = HiddenFieldVuelo.Value;
            string avion = HiddenFieldIdAvion.Value;
            string origen = HiddenFieldOrigen.Value;
            string destino = HiddenFieldDestino.Value;
            Session["VueloSeleccionado"] = vuelo;
            Session["IdAvionSeleccionado"] = avion;
            Session["Origen"] = origen;
            Session["Destino"] = destino;
            Response.Redirect("Despegue.aspx");
        }

    }
}
