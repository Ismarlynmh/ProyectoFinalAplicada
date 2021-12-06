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
using ProyectoFinalAplicada.UI.Consultas;

namespace ProyectoFinalAplicada.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cSuplidores.xaml
    /// </summary>
    public partial class cSuplidores : Window
    {
        public cSuplidores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Suplidores>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = SuplidoresBLL.GetList(x => true);
                        break;

                    

                    case 1:
                        listado = SuplidoresBLL.GetList(x => x.Nombre == CriterioTextBox.Text);
                        break;

                    case 2:
                        listado = SuplidoresBLL.GetList(x => x.Apellido == CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = SuplidoresBLL.GetList(x => x.Empresa == CriterioTextBox.Text);
                        break;

                   
                    case 4:
                        listado = SuplidoresBLL.GetList(x => x.Telefono == CriterioTextBox.Text);
                        break;

                 
                    case 5:
                        listado = SuplidoresBLL.GetList(x => x.Email == CriterioTextBox.Text);
                        break;

                 
                }
            }
            else if (FiltrarComboBox.SelectedIndex == 10)
            {
                listado = SuplidoresBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = SuplidoresBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }

        private void ConsultarDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
