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

namespace ProyectoFinalAplicada.UI
{
    /// <summary>
    /// Interaction logic for rCompras.xaml
    /// </summary>
    public partial class rCompras : Window
    {
        private decimal SubTotal;
        private decimal Total;
        private int Cantidad;
        private decimal Precio;
        private decimal Itbis;
        private decimal Bandera;
        private decimal AplicaPorcentaje;
        private double Porcentaje;
        private decimal Descuento;

        Compras compra = new Compras();
        List<Productos> lista = new List<Productos>();

        List<Suplidores> lista2 = new List<Suplidores>();
        public List<ComprasDetalle> Detalle { get; set; }

        public rCompras()
        {
            InitializeComponent();
            compra = new Compras();
            CompraIdTextBox.Text = "0";
            SuplidorIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";

            this.DataContext = compra;
            this.Detalle = new List<ComprasDetalle>();
            CargarGrid();

            Cantidad = (Cantidad < 0) ? Cantidad = 0 : Cantidad;
            Precio = (Precio < 0) ? Precio = 0 : Precio;
            Itbis = (Bandera < 0) ? Itbis = 0 : Itbis;
            Bandera = (Bandera < 0) ? Bandera = 0 : Bandera;
            Porcentaje = (Porcentaje < 0) ? Porcentaje = 0 : Porcentaje;
            AplicaPorcentaje = (Total < 0) ? AplicaPorcentaje = 0 : AplicaPorcentaje;
            SubTotal = (SubTotal < 0) ? SubTotal = 0 : SubTotal;
            Total = (Total < 0) ? Total = 0 : Total;
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
        //private bool ValidarSuplidorId(int id)
        //{
        //    lista2 = SuplidoresBLL.GetList(p => true);
        //    bool paso = false;

        //    foreach (var item in lista2)
        //    {
        //        if (item.SuplidorId == id)
        //        {
        //            return paso = true;
        //        }
        //    }

        //    return paso;
        //}
        private void Limpiar()
        {
            CompraIdTextBox.Text = "0";
            SuplidorIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaDeCompraTimePicker.SelectedDate = DateTime.Now;

            SubTotal = 0;
            Total = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            AplicaPorcentaje = 0;
            Porcentaje = 0;

            Compras compra = new Compras();
            this.Detalle = new List<ComprasDetalle>();
            CargarGrid();
            Actualizar();
        }

        private void CargarGrid()
        {
            CompraDetalleDataGrid.ItemsSource = null;
            CompraDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = compra;
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

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(FechaDeCompraTimePicker.Text))
            {
                paso = false;
                FechaDeCompraTimePicker.Focus();

            }


            if (string.IsNullOrEmpty(SuplidorIdTextBox.Text))
            {
                paso = false;
                SuplidorIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(CompraIdTextBox.Text))
            {
                paso = false;
                CompraIdTextBox.Focus();

            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La Compra debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var registro = ComprasBLL.Buscar(compra.CompraId);
            if (registro != null)
            {
                compra = registro;
                this.DataContext = compra;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {

            if (CompraDetalleDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<ComprasDetalle>)CompraDetalleDataGrid.ItemsSource;
            }

            if (!ValidarProductosId(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                MessageBox.Show("Producto Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            this.Detalle.Add(new ComprasDetalle
            {
                Id = 0,
                ProductoId = Convert.ToInt32(ProductoIdTextBox.Text),
                Precio = Convert.ToInt32(PrecioTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });

            CargarGrid();
            AumentarSubTotal();
            AumentarTotal();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdTextBox.Text);
            //ProductosBLL.AumentarInventario(id, valor); No se ensutra en la BLL


            ProductoIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;

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

        public decimal TotalAlterno;

        private void AumentarTotal()
        {
            Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            Total = (SubTotal + AplicaPorcentaje) - Descuento;
        }
        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (CompraDetalleDataGrid.SelectedIndex != -1)
            {
                compra.Detalle.RemoveAt(CompraDetalleDataGrid.SelectedIndex);
                ComprasDetalle aux = (ComprasDetalle)CompraDetalleDataGrid.SelectedItem;
                RemoveFromSubTotal();
                RemoveFromTotal();
                CargarGrid();
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
            var ok = ComprasBLL.Guardar(compra); ;
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
            if (ComprasBLL.Eliminar(compra.CompraId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
                compra.Total = Total;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SubTotalTextBox.Text = Convert.ToString(SubTotal);
                compra.SubTotal = SubTotal;
            }
            catch (Exception)
            {
                return;
            }
        }




    }
}
