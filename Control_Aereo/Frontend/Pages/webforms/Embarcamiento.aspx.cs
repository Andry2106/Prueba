using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.Pages.webforms
{
    public partial class Embarcamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipaje();
            }
        }
        private void CargarEquipaje()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] {
                new DataColumn("Nombre"),
                new DataColumn("Peso")
            });

            dt.Rows.Add("Maleta de cuero", "4kg");
            dt.Rows.Add("Maleta metálica", "15kg");
            dt.Rows.Add("Equipaje de materiales", "20kg");

            GvEquipaje.DataSource = dt;
            GvEquipaje.DataBind();

            mvVuelos.ActiveViewIndex = 0;
        }
    }
}