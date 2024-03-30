using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab03
{
    /// <summary>
    /// Lógica de interacción para DataReaderDesconectado.xaml
    /// </summary>
    public partial class DataReaderDesconectado : Window
    {
        public DataReaderDesconectado()
        {
            InitializeComponent();

            string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS; Initial Catalog=Lab03; User Id=Tecsup; " +
                "Password=123456";

            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM STUDENTS", connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet, "Estudiantes");
                }

                List<Estudiante> estudiantes = new List<Estudiante>();

                foreach (DataRow row in dataSet.Tables["Estudiantes"].Rows)
                {
                    int studentId = Convert.ToInt32(row["StudentId"]);
                    string firstName = row["FirstName"].ToString();
                    string lastName = row["LastName"].ToString();

                    estudiantes.Add(new Estudiante { StudentId = studentId, FirstName = firstName, LastName = lastName });
                }

                // Asignar la lista de estudiantes al DataGrid
                dataGridEstudiantes.ItemsSource = estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
