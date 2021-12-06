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

namespace ProyectoFinalAplicada.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {

        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductosBLL.GetList(x => true);
                        break;

                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.ProductoId == id);
                        break;

                    case 2:
                        listado = ProductosBLL.GetList(x => x.Nombre== CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = ProductosBLL.GetList(x => x.Marca == CriterioTextBox.Text);
                        break;

                    case 4:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= fecha.Date && x.FechaIngreso.Date <= fecha.Date);
                        break;

                    case 5:
                        int idS;
                        idS = int.Parse(CriterioTextBox.Text);
                        listado = ProductosBLL.GetList(x => x.SuplidorId == idS);
                        break;

                }
            }
            else if (FiltrarComboBox.SelectedIndex == 4)
            {
                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = ProductosBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }

    }
}
