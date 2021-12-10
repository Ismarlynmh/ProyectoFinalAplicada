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
using ProyectoFinalAplicada.UI.Consultas;
using System.Text.RegularExpressions;

namespace ProyectoFinalAplicada.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        private Ventas venta = new Ventas();
        
        public List<VentasDetalle> Detalle { get; set; }
         List<Productos> lista = new List<Productos>();
        private Productos producto = new Productos();
        private decimal SubTotal;
        private decimal Total;
        private int Cantidad;
        private decimal Precio;
        private decimal Itbis;
        private decimal Bandera;
        private decimal AplicaPorcentaje;
        private double Porcentaje;
        private decimal Descuento;
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;

            venta = new Ventas();
            this.Detalle = new List<VentasDetalle>();
            VentaIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;
            LLenarComboProducto();

            Cargar();


            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            Porcentaje = 0;
            AplicaPorcentaje = 0;
            SubTotal = 0;
            Total = 0;
        }
        private void AumentarSubTotal() //Metodo para aumentar el subTotal
        {
            Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            Porcentaje = Convert.ToDouble(Convert.ToDouble(ITBISTextBox.Text) / 100);
            Itbis = (decimal)Porcentaje;
            Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Bandera = Convert.ToDecimal(Precio * Cantidad);
            AplicaPorcentaje = (Bandera * Itbis);
            SubTotal += (Bandera);
        }

        private void RemoveFromSubTotal() //Metodo para Remover cantidad del Subtotal si se elimina un producto del Grid
        {
            SubTotal -= (Bandera);
        }

        private void RemoveFromTotal() //Metodo para Remover cantidad del Total si se elimina un producto del Grid
        {
            Total = SubTotal;
        }

        private void AumentarTotal()
        {
            Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            Total = (SubTotal + AplicaPorcentaje) - Descuento;
        }
        private bool ValidarProductosId(int id)
        {
            lista = ProductosBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in lista)
            {
                if (item.ProductoId == id)
                {
                    return paso = true;
                }
            }
            return paso;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                paso = false;
                TotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }


            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                paso = false;
                DescuentoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ITBISTextBox.Text))
            {
                paso = false;
                ITBISTextBox.Focus();

            }

            if (string.IsNullOrEmpty(FechaVentaDateTimePicker.Text))
            {
                paso = false;
                FechaVentaDateTimePicker.Focus();

            }
            if (string.IsNullOrEmpty(VentaIdTextBox.Text))
            {
                paso = false;
                VentaIdTextBox.Focus();
            }

            if (venta.Detalle.Count == 0)
            {
                MessageBox.Show("La venta debe tener un detalle", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            if (ProductoIdComboBox.SelectedValue == null)
            {
                
                MessageBox.Show("Seleccione un articulo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                paso = false;
            }
            return paso;
        }
         
        private void Limpiar()
        {
            venta = new Ventas();
            Cargar();
        }

        private void Cargar()
        {
            this.VentasDataGrid.ItemsSource = null;
            this.VentasDataGrid.ItemsSource = this.venta.Detalle;
            this.DataContext = null;
            this.DataContext = this.venta;
        }
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var Ventas = VentasBLL.Buscar(Utilidades.ToInt(VentaIdTextBox.Text));

            if (Ventas != null)
            {
                venta = Ventas;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se pudo encontrar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {
            var ProductoId = (int)ProductoIdComboBox.SelectedValue;
            this.venta.Detalle.Add(new VentasDetalle
            {
                Id = 0,
                ProductoId = ProductoId,

            });

            Cargar();
            AumentarSubTotal();
            AumentarTotal();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdComboBox.SelectedIndex);
            ProductosBLL.DisminuirInventario(id, valor);

            ProductoIdComboBox.SelectedIndex = 0;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;

        }

        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.SelectedIndex != -1)
            {
                venta.Detalle.RemoveAt(VentasDataGrid.SelectedIndex);
                VentasDetalle aux = (VentasDetalle)VentasDataGrid.SelectedItem;

                RemoveFromSubTotal();
                RemoveFromTotal();
                Cargar();
            }
        }

        private void LLenarComboProducto()
        {
            this.ProductoIdComboBox.ItemsSource = ProductosBLL.GetList(x => true);
            this.ProductoIdComboBox.SelectedValuePath = "ProductoId";
            this.ProductoIdComboBox.DisplayMemberPath = "MarcaProducto";

            if (ProductoIdComboBox.Items.Count > 0)
            {
                ProductoIdComboBox.SelectedIndex = 0;
            }
        }
        private void NuevoBoton_Click(object sender, RoutedEventArgs e)
        {
                Limpiar();
        }

        private void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

                        var ok = VentasBLL.Guardar(venta); 

            if (ok)
            {
                MessageBox.Show("Guardado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.Eliminar(venta.VentaId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SubTotalTextBox.Text = Convert.ToString(SubTotal);
                venta.SubTotal = SubTotal;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
                venta.Total = Total;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ProductoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ProductoIdComboBox.SelectedIndex != -1)
            {
                producto = (Productos)ProductoIdComboBox.SelectedItem;
            }
        }
    }
}
