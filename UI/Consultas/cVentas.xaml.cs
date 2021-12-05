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
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = VentasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.VentaId == id);
                        break;
                    case 3:
                        decimal total;
                        total = int.Parse(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(o => o.Total == total);
                        break;

                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = VentasBLL.GetList(x => x.FechaVenta.Date >= fecha.Date && x.FechaVenta.Date <= fecha.Date);
                        break;

                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
            {
                listado = VentasBLL.GetList(x => x.FechaVenta.Date >= DesdeDateTimePicker.SelectedDate && x.FechaVenta.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = VentasBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
