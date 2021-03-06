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

namespace Ferale.Controles.Limpiezas
{
    /// <summary>
    /// Lógica de interacción para ControlPlagas.xaml
    /// </summary>
    public partial class ControlPlagas : UserControl
    {
        PlagaBRL brl;
        Plaga plaga;
        public ControlPlagas()
        {
            InitializeComponent();
        }

        void RefreshDataGrid()
        {
            try
            {
                brl = new PlagaBRL();
                dgDatos.ItemsSource = brl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
                {
                    DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;

                    int id = int.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new PlagaBRL();
                    plaga = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanasPlaga.InsertarPlaga nuevaVentana = new VentanasPlaga.InsertarPlaga();
            nuevaVentana.ShowDialog();
            RefreshDataGrid();
        }

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (plaga != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                try
                {
                    VentanasPlaga.EditarPlaga nuevaVentana = new VentanasPlaga.EditarPlaga(plaga);
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

        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (plaga != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new PlagaBRL(plaga);
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

        private void Reports_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
