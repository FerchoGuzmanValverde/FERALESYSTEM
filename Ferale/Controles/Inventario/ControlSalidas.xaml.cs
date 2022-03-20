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
using BRL;
using Common;
using System.Data;

namespace Ferale.Controles.Inventario
{
    /// <summary>
    /// Lógica de interacción para ControlSalidas.xaml
    /// </summary>
    public partial class ControlSalidas : UserControl
    {
        ProduccionBRL brl;
        Produccion produccion;
        public ControlSalidas()
        {
            InitializeComponent();
        }
        void RefreshDataGrid()
        {
            try
            {
                brl = new ProduccionBRL();
                dgDatos.ItemsSource = brl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (produccion != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new ProduccionBRL(produccion);
                        brl.Delete();
                        MessageBox.Show("Se ha eliminado el registro con éxito...!!", "Registro Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        RefreshDataGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un registro...");
            }
        }

        private void btnModificar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (produccion != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                try
                {
                    VentanasProduccion.EditarProduccion nuevaVentana = new VentanasProduccion.EditarProduccion(produccion);
                    nuevaVentana.ShowDialog();
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un registro...");
            }
        }

        private void btnRegistrar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanasProduccion.RegistrarProduccion nuevaVentana = new VentanasProduccion.RegistrarProduccion();
            nuevaVentana.ShowDialog();
            RefreshDataGrid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
                {
                    DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;

                    int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new ProduccionBRL();
                    produccion = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
