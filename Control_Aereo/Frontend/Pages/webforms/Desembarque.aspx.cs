using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Frontend.Logic;


namespace Frontend.Pages.webforms
{
    public partial class Desembarque : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerHangares();
                ObtenerHangaresConAviones();
                ObtenerHangaresSinAviones();
                CargarPuertasActivas();
                CargarEmbarque();
                CargarTodosAvionesExistentes();
            }
        }

        protected void CargarTodosAvionesExistentes()
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                DataTable aviones = desembarqueLogic.CargarTodosLosAviones();

                gvAviones.DataSource = aviones;
                gvAviones.DataBind();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar todos los aviones: " + ex.Message);
            }
        }


        protected void SeleccionarHangar(object sender, EventArgs e)
        {

        }
        protected void Desembarcar_Click(object sender, EventArgs e)
        {
            // Código para procesar el desembarque, si es necesario
        }

        protected void ObtenerHangares()
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                DataTable hangaresDisponibles = desembarqueLogic.ObtenerHangares();

                foreach (DataRow row in hangaresDisponibles.Rows)
                {
                    HtmlGenericControl card = new HtmlGenericControl("div");
                    card.Attributes["class"] = "mini-card";
                    card.Attributes["id"] = "hangarCard_" + row["IdHangar"].ToString();

                    HtmlGenericControl title = new HtmlGenericControl("h2");
                    title.InnerText = row["Nombre"].ToString();
                    card.Controls.Add(title);


                    HtmlGenericControl idTipoHangar = new HtmlGenericControl("p");
                    idTipoHangar.InnerText = row["IdTipoHangar"].ToString();
                    idTipoHangar.Style.Add("display", "none");
                    card.Controls.Add(idTipoHangar);

                    HtmlGenericControl idHangar = new HtmlGenericControl("span");
                    idHangar.InnerText = row["IdHangar"].ToString();
                    idHangar.Style.Add("display", "none"); // Hace el elemento invisible
                    card.Controls.Add(idHangar);


                    HtmlGenericControl ubicacion = new HtmlGenericControl("p");
                    ubicacion.InnerText = "Ubicación: " + row["Ubicacion"].ToString();
                    ubicacion.Style.Add("display", "none"); // Oculta el elemento
                    card.Controls.Add(ubicacion);

                    HtmlGenericControl capacidad = new HtmlGenericControl("p");
                    capacidad.InnerText = "Capacidad: " + row["Capacidad"].ToString();
                    capacidad.Style.Add("display", "none"); // Oculta el elemento
                    card.Controls.Add(capacidad);

                    HtmlGenericControl estado = new HtmlGenericControl("p");
                    estado.InnerText = "Estado: " + row["Estado"].ToString();
                    estado.Style.Add("display", "none"); // Oculta el elemento
                    card.Controls.Add(estado);

                    HtmlGenericControl tamaño = new HtmlGenericControl("p");
                    tamaño.InnerText = "Tamaño: " + row["Tamaño"].ToString();
                    tamaño.Style.Add("display", "none"); // Oculta el elemento
                    card.Controls.Add(tamaño);

                    HtmlGenericControl altura = new HtmlGenericControl("p");
                    altura.InnerText = "Altura: " + row["Altura"].ToString();
                    altura.Style.Add("display", "none"); // Oculta el elemento
                    card.Controls.Add(altura);

                    // Crea el botón Info
                    Button btnInfo = new Button();
                    btnInfo.Text = "Info";
                    btnInfo.CssClass = "info-btn"; // Aplica la clase de estilo CSS
                    btnInfo.Attributes["data-idhangar"] = row["IdHangar"].ToString(); // Atributo personalizado con el ID del hangar
                    btnInfo.UseSubmitBehavior = false; // Evita que el botón envíe el formulario
                    btnInfo.OnClientClick = $"javascript:CargarInformacionHangar('{SerializeHangarData(row)}'); return false;";

                    card.Controls.Add(btnInfo);
                    miniCardsContainer.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los hangares: " + ex.Message);
            }
        }


        private string SerializeHangarData(DataRow row)
        {
            // Serializa todos los datos del hangar en una cadena JSON
            string idTipoHangar = row["IdTipoHangar"].ToString();
            string idHangar = row["IdHangar"].ToString();
            string nombre = row["Nombre"].ToString();
            string ubicacion = row["Ubicacion"].ToString();
            string capacidad = row["Capacidad"].ToString();
            string estado = row["Estado"].ToString();
            string tamaño = row["Tamaño"].ToString();
            string altura = row["altura"].ToString();

            // Construye una cadena JSON
            string serializedData = $"{{ \"IdTipoHangar\": \"{idTipoHangar}\", \"IdHangar\": \"{idHangar}\", \"Nombre\": \"{nombre}\", \"Ubicacion\": \"{ubicacion}\", \"Capacidad\": \"{capacidad}\", \"Estado\": \"{estado}\", \"Tamaño\": \"{tamaño}\", \"Altura\": \"{altura}\" }}";

            return serializedData;
        }
        protected void ObtenerHangaresConAviones()
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                DataTable hangaresConAviones = desembarqueLogic.CargarHangaresConAviones();

                foreach (DataRow row in hangaresConAviones.Rows)
                {
                    // Agrega un botón para cada hangar ocupado
                    Button btnHangar = new Button();
                    btnHangar.ID = "btnHangar_" + row["IdHangar"].ToString(); // Asigna un ID único al botón
                    btnHangar.Text = row["Nombre"].ToString();
                    btnHangar.CssClass = "hangar-button";
                    btnHangar.CssClass = "info-btn"; // Aplica la clase de estilo CSS
                    btnHangar.Attributes["data-idhangar"] = row["IdHangar"].ToString(); // Atributo personalizado con el ID del hangar
                    btnHangar.UseSubmitBehavior = false; // Evita que el botón envíe el formulario
                    btnHangar.Click += new EventHandler(SeleccionarHangar); // Asigna el manejador de eventos al botón
                    btnHangar.OnClientClick = $"javascript:MostrarIdHangar('{row["IdHangar"].ToString()}'); return false;"; // Llama a la función en JavaScript al hacer clic

                    // Agregar el botón al contenedor de hangares ocupados
                    hangarListContainer.Controls.Add(btnHangar);

                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí
                Console.WriteLine("Error al cargar los hangares con aviones: " + ex.Message);
            }
        }

        protected void ObtenerHangaresSinAviones()
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                DataTable hangaresSinAviones = desembarqueLogic.CargarHangaresSinAviones();

                foreach (DataRow row in hangaresSinAviones.Rows)
                {
                    // Agrega un botón para cada hangar sin aviones
                    Button btnHangar = new Button();
                    btnHangar.ID = "btnHangar_" + row["IdHangar"].ToString(); // Asigna un ID único al botón
                    btnHangar.Text = row["Nombre"].ToString();
                    btnHangar.CssClass = "hangar-button";
                    btnHangar.CssClass = "info-btn";
                    btnHangar.Attributes["data-idhangar"] = row["IdHangar"].ToString(); // Atributo personalizado con el ID del hangar
                    btnHangar.UseSubmitBehavior = false; // Evita que el botón envíe el formulario
                    btnHangar.Click += new EventHandler(SeleccionarHangar); // Asigna el manejador de eventos al botón
                    btnHangar.OnClientClick = $"javascript:MostrarIdHangar('{row["IdHangar"].ToString()}'); return false;"; // Llama a la función en JavaScript al hacer clic

                    // Agregar el botón al contenedor de hangares vacíos
                    hangarListVacioContainer.Controls.Add(btnHangar);

                    // Llama al método para cargar la información del avión asociado a este hangar

                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí
                Console.WriteLine("Error al cargar los hangares sin aviones: " + ex.Message);
            }
        }

        protected void btnAgregarAvion_Click(object sender, EventArgs e)
        {
            string nombreHangar = txtNombreHangar.Text;
            string numeroDeRegistroAvion = txtNumeroRegistroAvion.Text;

            AgregarAvionEnHangar(nombreHangar, numeroDeRegistroAvion);
        }

        protected void btnEliminarAvion_Click(object sender, EventArgs e)
        {
            string nombreHangar = txtNombreHangar.Text;
            string numeroDeRegistroAvion = txtNumeroRegistroAvion.Text;

            EliminarAvionDeHangar(nombreHangar, numeroDeRegistroAvion);
        }

        protected void AgregarAvionEnHangar(string nombreHangar, string numeroDeRegistroAvion)
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                desembarqueLogic.AgregarAvionEnHangar(nombreHangar, numeroDeRegistroAvion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar avión en el hangar: " + ex.Message);
            }
        }

        protected void EliminarAvionDeHangar(string nombreHangar, string numeroDeRegistroAvion)
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                desembarqueLogic.EliminarAvionDeHangar(nombreHangar, numeroDeRegistroAvion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar avión del hangar: " + ex.Message);
            }
        }
        private DataTable modelosAviones;

    

        protected void btnBuscarAviones_Click(object sender, EventArgs e)
        {
            string nombreHangar = TextBox1.Text;

 
            BuscarModelosAviones(nombreHangar);

            
            GridView1.DataSource = modelosAviones;
            GridView1.DataBind();
        }

        protected void BuscarModelosAviones(string nombreHangar)
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                
                modelosAviones = desembarqueLogic.BuscarModelosAvionesPorHangar(nombreHangar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar avión del hangar: " + ex.Message);
            }
        }
        protected void DesembarcarPasajero(int idEmbarque, int idPuerta)
        {
    
            DesembarqueLogic desembarqueLogic = new DesembarqueLogic();


            string resultado = desembarqueLogic.DesembarcarPasajero(idEmbarque, idPuerta);
            lblValoresSeleccionados.Text = "La operacion fue realizada con exito";
            CargarEmbarque();

        }


        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            // Obtener el valor del TextBox txtDatosEmbarque
            int idEmbarque;
            if (!int.TryParse(txtDatosEmbarque.Text, out idEmbarque))
            {
                // Manejar caso de error de conversión
                
                return;
            }

            // Obtener el valor seleccionado del DropDownList ddlPuertas
            int idPuerta;
            if (!int.TryParse(ddlPuertas.SelectedValue, out idPuerta))
            {
                // Manejar caso de error de conversión
                lblValoresSeleccionados.Text = "Error: Puerta inválida";
                return;
            }

            // Llamar al método DesembarcarPasajero con los valores obtenidos
            DesembarcarPasajero(idEmbarque, idPuerta);
            CargarEmbarque();
        }








        //nuevo
        protected void CargarEmbarque()
        {
            try
            {
                DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
                DataTable embarque = desembarqueLogic.CargarEmbarque();

                gvEmbarque.DataSource = embarque; // Asigna el DataTable al GridView
                gvEmbarque.DataBind(); // Enlaza los datos al GridView
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el embarque: " + ex.Message);
            }
        }


        private void CargarPuertasActivas()
        {
            DesembarqueLogic desembarqueLogic = new DesembarqueLogic();
            DataTable puertasActivas = desembarqueLogic.ObtenerPuertasActivas();

            ddlPuertas.DataSource = puertasActivas;
            ddlPuertas.DataTextField = "Nombre"; // Nombre de la columna que muestra el nombre de la puerta
            ddlPuertas.DataValueField = "Id"; // Nombre de la columna que contiene el ID de la puerta
            ddlPuertas.DataBind();
        }
    }
}


