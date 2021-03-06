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

namespace Ferale.Controles.Limpiezas.VentanasLimpieza
{
    /// <summary>
    /// Lógica de interacción para AdminEstablecimientos.xaml
    /// </summary>
    public partial class AdminEstablecimientos : Window
    {
        EstablecimientoBRL brl;
        Establecimiento establecimiento;
        public AdminEstablecimientos()
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
                brl = new EstablecimientoBRL();
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
            InsertarEstablecimiento nuevaVentana = new InsertarEstablecimiento();
            nuevaVentana.ShowDialog();
            DataGridLoadRefresh();
        }

        private void Update_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (establecimiento != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                try
                {
                    EditarEstablecimiento nuevaVentana = new EditarEstablecimiento(establecimiento);
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
            if (establecimiento != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new EstablecimientoBRL(establecimiento);
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
                    brl = new EstablecimientoBRL();
                    establecimiento = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
