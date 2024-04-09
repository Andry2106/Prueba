using System.Data;
using Frontend.DataAccess;

namespace Frontend.Logic
{
    public class ListaVuelosLogic
    {
        private ListaVuelosData listaVuelosData;

        public ListaVuelosLogic()
        {
            listaVuelosData = new ListaVuelosData();
        }
        public DataTable ListadoVuelos(int operacion)
        {
            return listaVuelosData.ListadoVuelos(operacion);
        }
    }
}
