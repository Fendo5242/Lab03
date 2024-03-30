using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Lógica de interacción para DataTableConect.xaml
    /// </summary>
    public partial class DataTableConect : Window
    {
        System.Data.DataTable dataTable = new System.Data.DataTable();
        public DataTableConect()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAB1504-09\\SQLEXPRESS; Initial Catalog=Lab03; User Id=Tecsup; " +
                "Password=123456";
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM STUDENTS", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int StudentId = reader.GetInt32("StudentId");
                    string FirstName = reader.GetString("FirstName");
                    string LastName = reader.GetString("LastName");

                    estudiantes.Add(new Estudiante { StudentId = StudentId, FirstName = FirstName, LastName = LastName });
                }
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
