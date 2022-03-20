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
using System.Windows.Shapes;

namespace Ferale.Controles.Registros.VentanasProductos
{
    /// <summary>
    /// Lógica de interacción para AdminTipoProductos.xaml
    /// </summary>
    public partial class AdminTipoProductos : Window
    {
        TipoProductoBRL brl;
        TipoProducto tipo;
        public AdminTipoProductos()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void DataGridLoadRefresh()
        {
            try
            {
                brl = new TipoProductoBRL();
                dgArea.ItemsSource = brl.Select().DefaultView;
                dgArea.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            InsertarTipoProducto nuevaVentana = new InsertarTipoProducto();
            nuevaVentana.ShowDialog();
            DataGridLoadRefresh();
        }

        private void Update_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (tipo != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                try
                {
                    EditarTipoProducto nuevaVentana = new EditarTipoProducto(tipo);
                    nuevaVentana.ShowDialog();
                    DataGridLoadRefresh();
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
            if (tipo != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new TipoProductoBRL(tipo);
                        brl.Delete();
                        MessageBox.Show("Se ha eliminado el registro con éxito...!!", "Registro Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGridLoadRefresh();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridLoadRefresh();
        }

        private void DgArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
                {
                    DataRowView dataRow = (DataRowView)dgArea.SelectedItem;

                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new TipoProductoBRL();
                    tipo = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
