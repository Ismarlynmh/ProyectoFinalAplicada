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
using System.Windows.Shapes;
using ProyectoFinalAplicada.BLL;
using ProyectoFinalAplicada.Entidades;

namespace ProyectoFinalAplicada.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles Rol = new Roles();
        public rRoles()
        {
            InitializeComponent();
            Rol = new Roles();
            this.DataContext = Rol;
        }
        private void Limpiar()
        {
            Rol = new Roles();
            this.DataContext = Rol;
        }
    
        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(DescripciónTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Descripcion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DescripciónTextBox.Focus();
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = RolesBLL.Buscar(Rol.RolId);
            if (registro != null)
            {
                Rol = registro;
                this.DataContext = Rol;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Guardar(Rol))
            {
                MessageBox.Show("Guardado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Rol.RolId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
