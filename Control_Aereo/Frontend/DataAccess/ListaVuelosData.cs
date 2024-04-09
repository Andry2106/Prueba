using System;
using System.Data;
using System.Data.SqlClient;

namespace Frontend.DataAccess
{
    public class ListaVuelosData
    {
        private readonly Conexion conexion;
        string connectionString = "Server=tiusr9pl.cuc-carrera-ti.ac.cr\\MSSQLSERVER2019;Database=ControlAereoGeneral;User Id=ControlAereo;Password=ControlAereo;";

        public ListaVuelosData()
        {
            conexion = new Conexion();
        }
        public DataTable ListadoVuelos(int operacion)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SP_ListadoVuelos", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Operacion", operacion);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ListadoVuelos: " + ex.Message);
            }
            return dataTable;
        }
    }
}
