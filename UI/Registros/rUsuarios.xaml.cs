using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        private Roles Rol = new Roles();
        public rUsuarios()
        {
            InitializeComponent();
            usuarios = new Usuarios();
            this.DataContext = usuarios;
            UsuarioIdTextBox.Text = "0";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            RolIdComboBox.SelectedValuePath = "RolId";
            RolIdComboBox.DisplayMemberPath = "Descripcion";
        }
        private void Limpiar()
        {
            usuarios = new Usuarios();
            this.DataContext = usuarios;
        }
        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var UsuarioEncontrado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (UsuarioEncontrado != null)
            {
                usuarios = UsuarioEncontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se pudo encontrar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            var paso = UsuariosBLL.Guardar(usuarios); ;

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el registro ", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var UsuarioEncontrado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (UsuarioEncontrado == null)
            {
                MessageBox.Show("No se pudo encontrar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                UsuariosBLL.Eliminar(usuarios.UsuarioId);
                MessageBox.Show("Eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }

        private void RolIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolIdComboBox.SelectedIndex != -1)
            {
                Rol = (Roles)RolIdComboBox.SelectedItem;
            }
        }
        private Boolean EmailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool NumeroValido(string telefono)
        {
            return Regex.Match(telefono, @"^([\+]?1[-]?|[0])?[1-9][0-9]{9}$").Success;
        }
        public static bool CedulaValida(string cedula)
        {
            return Regex.Match(cedula, @"^([\+]?1[-]?|[0])?[1-9][0-9]{10}$").Success;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (!CedulaValida(CedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }


            if (SexoComboBox.SelectedItem == null)
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
            }

            if (!NumeroValido(CelularTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Celular No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
            }

            if (!NumeroValido(TelefonoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Teléfono No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
            }

            if (!EmailValido(EmailTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Email No Valido !", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            if (string.IsNullOrEmpty(NombreDeUsuarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreDeUsuarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ContraseñaTextBox.Password))
            {
                paso = false;
                MessageBox.Show("El campo contraseña Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreDeUsuarioTextBox.Focus();
            }
            return paso;
        }
    }
}
