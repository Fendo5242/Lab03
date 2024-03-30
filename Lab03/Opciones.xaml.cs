using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab03
{
    /// <summary>
    /// Lógica de interacción para Opciones.xaml
    /// </summary>
    public partial class Opciones : Window
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTableConectado dataTableConectado = new DataTableConectado();
            dataTableConectado.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataReader dataReader = new DataReader();
            dataReader.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataTableConect dataTableConectado = new DataTableConect();
            dataTableConectado.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataReaderDesconectado dataReader = new DataReaderDesconectado();
            dataReader.ShowDialog();
        }
    }
}
