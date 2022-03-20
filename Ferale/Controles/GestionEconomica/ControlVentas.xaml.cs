using BRL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Ferale.Controles.GestionEconomica
{
    /// <summary>
    /// Lógica de interacción para ControlVentas.xaml
    /// </summary>
    public partial class ControlVentas : UserControl
    {
        Venta venta;
        VentaBRL brl;
        VentaDetalleBRL detalleBrl;
        ProductoBRL productoBrl;

        public ControlVentas()
        {
            InitializeComponent();
        }

        private void Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SubControlesVentas.InsertarVenta nuevaVentana = new SubControlesVentas.InsertarVenta();
            nuevaVentana.ShowDialog();
            RefreshDataGrid();
        }

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (venta != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                try
                {
                    SubControlesVentas.EditarVenta nuevaVentana = new SubControlesVentas.EditarVenta(venta);
                    nuevaVentana.ShowDialog();
                    RefreshDataGrid();
                    dgDetalles.ItemsSource = null;
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

        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (venta != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new VentaBRL(venta);
                        brl.Delete();
                        MessageBox.Show("Se ha eliminado el registro con éxito...!!", "Registro Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        RefreshDataGrid();
                        dgDetalles.ItemsSource = null;
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

        private void Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            try
            {
                brl = new VentaBRL();
                dgDatos.ItemsSource = brl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshDetails(int id)
        {
            try
            {
                detalleBrl = new VentaDetalleBRL();
                dgDetalles.ItemsSource = detalleBrl.listDetalles(id);
                dgDetalles.Columns[0].Visibility = Visibility.Hidden;
                dgDetalles.Columns[1].Visibility = Visibility.Hidden;
                dgDetalles.Columns[5].Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
                {
                    DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;

                    int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new VentaBRL();
                    venta = brl.Get(id);
                    RefreshDetails(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
