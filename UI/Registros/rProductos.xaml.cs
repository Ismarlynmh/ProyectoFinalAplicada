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
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.BLL;


namespace ProyectoFinalAplicada.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        private Productos productos;

        public rProductos()
        {
            InitializeComponent();
            this.DataContext = productos;
            ProductoIdTextBox.Text = "0";
        }
        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            NombreProductoTextBox.Text = string.Empty;
            MarcaProductoTextBox.Text = string.Empty;
            InventarioTextBox.Text = "0";
            PrecioCompraTextBox.Text = "0";
            PrecioVentaTextBox.Text = "0";
            //FechaIngresoDatePicker = DateTime.Now;
            SuplidorIdTextBox.Text = "0";

        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(ProductoIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductoIdTextBox.Focus();
            }
            if (string.IsNullOrEmpty(NombreProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreProductoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(MarcaProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Marca no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                MarcaProductoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(InventarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Inventario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                InventarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(PrecioCompraTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Precio Compra no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                PrecioCompraTextBox.Focus();
            }

            if (string.IsNullOrEmpty(PrecioVentaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Precio Compra no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                PrecioVentaTextBox.Focus();
            }

            return paso;
        }

        private bool Existe()
        {
            Productos productos = ProductosBLL.Busacar(int.Parse(ProductoIdTextBox.Text));
            return (productos != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos anterior = ProductosBLL.Busacar(int.Parse(ProductoIdTextBox.Text));

            if (productos != null)
            {
                productos = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (string.IsNullOrEmpty(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                paso = ProductosBLL.Guardar(productos);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe en la base de datos");
                    return;
                }
                paso = ProductosBLL.Modificar(productos);
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);

            if (ProductosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
