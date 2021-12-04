using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.UI.Consultas;
using ProyectoFinalAplicada.UI.Registros;

namespace ProyectoFinalAplicada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {

            rUsuarios rUsuario = new rUsuarios();
            rUsuario.Show();
        }

        private void VentasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RolesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void EmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {

            cUsuarios cUsuario = new cUsuarios();
            cUsuario.Show();
        }

        private void ConsultarVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarRolesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarEmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
