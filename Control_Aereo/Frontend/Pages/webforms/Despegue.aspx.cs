using Frontend.Logic;
using System;
using System.Data;
using System.Web.UI;

namespace Frontend.Pages.webforms
{
    public partial class Despegue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["VueloSeleccionado"] != null && Session["IdAvionSeleccionado"] != null)
                {
                    btmAutorizar.Enabled = false;
                    string vuelo = Session["VueloSeleccionado"].ToString();
                    string avion = Session["IdAvionSeleccionado"].ToString();
                    string origen = Session["Origen"].ToString();
                    string destino = Session["Destino"].ToString();
                    lblVuelo.Text = "N.Vuelo: " + vuelo;
                    lblIdentificacionAvion.Text = "Identificacion del avion: " + avion;
                    int vueloID = int.Parse(vuelo);
                    int avionID = int.Parse(avion);
                    DespegueLogic despegueLogic = new DespegueLogic();
                    DataTable datosVuelo = despegueLogic.ObtenerVueloPorID(vueloID);
                    DataTable datosAvion = despegueLogic.ObtenerAvionPorID(avionID);

                    if (datosVuelo.Rows.Count > 0 && datosAvion.Rows.Count > 0)
                    {
                        lblOrigen.Text = "Origen: " + datosVuelo.Rows[0]["Origen"].ToString();
                        lblDestino.Text = "Destino: " + datosVuelo.Rows[0]["Destino"].ToString();
                        lblHoraSalida.Text = "Hora de salida: " + ((DateTime)datosVuelo.Rows[0]["HoraSalida"]).ToString("dd/MM/yyyy HH:mm");
                        lblHoraLlegada.Text = "Hora de llegada: " + ((DateTime)datosVuelo.Rows[0]["HoraLlegada"]).ToString("dd/MM/yyyy HH:mm");
                        lblModelo.Text = "Modelo: " + datosAvion.Rows[0]["Modelo"].ToString();
                        lblPesoMaximo.Text = "Peso máximo: " + datosAvion.Rows[0]["CapacidadCarga"].ToString() + " kg";
                        lblCapacidadPasajeros.Text = "Capacidad de pasajeros: " + datosAvion.Rows[0]["CapacidadPasajeros"].ToString();
                        lblCapacidadCombustible.Text = "Capacidad de combustible: " + datosAvion.Rows[0]["CapacidadCombustible"].ToString() + " litros";
                        lblUltimaRevision.Text = "Última revisión: " + ((DateTime)datosAvion.Rows[0]["UltimaRevision"]).ToString("dd/MM/yyyy");
                        lblProximaRevision.Text = "Próxima revisión: " + ((DateTime)datosAvion.Rows[0]["ProximaRevision"]).ToString("dd/MM/yyyy");
                        lblCompaniaAerea.Text = "Compañía aérea: " + datosAvion.Rows[0]["CompaniaAerea"].ToString();
                        lblObservaciones.Text = "Observaciones: " + datosAvion.Rows[0]["Observaciones"].ToString();
                        lblEstado.Text = "Estado: " + datosAvion.Rows[0]["Estado"].ToString();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron datos del vuelo o del avión.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudieron cargar los datos.');", true);
                }
            }
        }
        protected void btmDenegar_Click(object sender, EventArgs e)
        {
            try
            {
                string vuelo = Session["VueloSeleccionado"].ToString();
                int vueloID = int.Parse(vuelo);
                DespegueLogic despegueLogic = new DespegueLogic();
                Label1.Text = vueloID.ToString();
                despegueLogic.CambiarEstadoVuelo(vueloID, 0);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se denego el despegue de manera correcta:');", true);
                Response.Redirect("ListaVuelos.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al intentar el denegar el despegue: " + ex.Message + "');", true);
            }
        }
        protected void btmAutorizar_Click(object sender, EventArgs e)
        {
            try
            {
                string origen = Session["Origen"].ToString();
                string destino = Session["Destino"].ToString();
                string vuelo = Session["VueloSeleccionado"].ToString();
                int vueloID = int.Parse(vuelo);
                DateTime horaDespegue = DateTime.Now;
                string horaDespegueTexto = horaDespegue.ToString("yyyy-MM-dd HH:mm:ss");
                DespegueLogic despegueLogic = new DespegueLogic();
                despegueLogic.InsertarDespegue(horaDespegueTexto, origen, destino, vueloID, 1, 1);
                despegueLogic.PasarDespegue(vueloID);
                despegueLogic.BorrarVueloPorNumero(vueloID);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se autorizo correctamente.');", true);
                Response.Redirect("ListaVuelos.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al intentar el despegue: " + ex.Message + "');", true);
            }
        }
        protected void btmValidar_Click(object sender, EventArgs e)
        {
            string vuelo = Session["VueloSeleccionado"].ToString();
            int vueloID = int.Parse(vuelo);

            DespegueLogic despegueLogic = new DespegueLogic();

            despegueLogic.InsertarValidacionesDespegue02(vueloID);

            int resultadoValidacion = despegueLogic.ValidarValidacionesDespegue(vueloID);

            if (resultadoValidacion == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se cumplieron todas las validaciones.');", true);
                btmAutorizar.Enabled = true;
            }
            else if (resultadoValidacion == -1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Fallaron las validaciones no se puede autorizar el despegue.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El estado de las validaciones es indeterminado.');", true);
            }
        }
    }
}
