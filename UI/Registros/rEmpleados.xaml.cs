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
using ProyectoFinalAplicada.DAL;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.BLL;

namespace ProyectoFinalAplicada.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEmpleados.xaml
    /// </summary>
    public partial class rEmpleados : Window
    {
        private Empleados empleados;

        public rEmpleados()
        {
            InitializeComponent();
            empleados = new Empleados();
            this.DataContext = empleados;
            EmpleadoIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            empleados = new Empleados();
            this.DataContext = empleados;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(FechaIngresoDateTimePicker.Text))
            {
                paso = false;
                FechaIngresoDateTimePicker.Focus();
            }

            if (string.IsNullOrEmpty(FechaNacimientoDateTimePicker.Text))
            {
                paso = false;
                FechaNacimientoDateTimePicker.Focus();
            }

            if (string.IsNullOrEmpty(SueldoTextBox.Text))
            {
                paso = false;
                SueldoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(CargoTextBox.Text.Replace("-", "")))
            {
                paso = false;
                CargoTextBox.Focus();
            }

            //if (!EmailValido(EmailTextBox.Text))
            //{
            //    paso = false;
            //    MessageBox.Show("Email No Valido !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    EmailTextBox.Focus();
            //}

            //if (!NumeroValido(CelularTextBox.Text))
            //{
            //    paso = false;
            //    MessageBox.Show("Celular No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    CelularTextBox.Focus();
            //}

            //if (!NumeroValido(TelefonoTextBox.Text))
            //{
            //    paso = false;
            //    MessageBox.Show("Teléfono No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    TelefonoTextBox.Focus();
            //}

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                DireccionTextBox.Focus();
            }

            //if (!CedulaValida(CedulaTextBox.Text))
            //{
            //    paso = false;
            //    MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    CedulaTextBox.Focus();
            //}

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                ApellidosTextBox.Focus();

            }

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                paso = false;
                NombresTextBox.Focus();

            }
            return paso;
        }


        private void EmpleadoIdButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = EmpleadosBLL.Buscar(empleados.EmpleadoId);
            if (registro != null)
            {
                empleados = registro;
                this.DataContext = empleados;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            var ok = EmpleadosBLL.Guardar(empleados); ;
            if (ok)
                if (EmpleadosBLL.Guardar(empleados))
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
            if (EmpleadosBLL.Eliminar(empleados.EmpleadoId))
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
