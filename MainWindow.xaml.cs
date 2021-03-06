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
using ProyectoFinalAplicada.BLL;
using ProyectoFinalAplicada.UI;

namespace ProyectoFinalAplicada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public MainWindow(int UsuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = UsuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UsuarioActivoTextBox.Text = ("Usuario activo: " + usuario.NombreDeUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());
        }
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
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }

        private void ComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCompras rCompras = new rCompras();
            rCompras.Show();
        }

        private void RolesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void EmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEmpleados rEmpleados = new rEmpleados();
            rEmpleados.Show();
        }

        private void ProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }

        private void ConsultarUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {

            cUsuarios cUsuario = new cUsuarios();
            cUsuario.Show();
        }

        private void ConsultarVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }

        private void ConsultarComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {

            cCompras cCompras = new cCompras();
            cCompras.Show();
        }

        private void ConsultarSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cSuplidores = new cSuplidores();
            cSuplidores.Show();
        }

        private void ConsultarProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.Show();
        }

        private void ConsultarEmpleadosMenuItem_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
