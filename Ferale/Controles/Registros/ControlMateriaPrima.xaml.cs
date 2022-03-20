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

namespace Ferale.Controles.Registros
{
    /// <summary>
    /// Lógica de interacción para ControlMateriaPrima.xaml
    /// </summary>
    public partial class ControlMateriaPrima : UserControl
    {
        MateriaPrimaBRL brl;
        MateriaPrima materia;
        public ControlMateriaPrima()
        {
            InitializeComponent();
        }

        private void AdminAlmacen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanasMateriaPrima.WindowAlmacen ventanaAlmacen = new VentanasMateriaPrima.WindowAlmacen();
            ventanaAlmacen.ShowDialog();
        }

        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (materia != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new MateriaPrimaBRL(materia);
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

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (materia != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                try
                {
                    VentanasMateriaPrima.EditarMateriaPrima nuevaVentana = new VentanasMateriaPrima.EditarMateriaPrima(materia);
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

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanasMateriaPrima.InsertarMateriaPrima nuevaVentana = new VentanasMateriaPrima.InsertarMateriaPrima();
            nuevaVentana.ShowDialog();
            RefreshDataGrid();
        }

        private void Select_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        void RefreshDataGrid()
        {
            try
            {
                brl = new MateriaPrimaBRL();
                dgDatos.ItemsSource = brl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Hidden;
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

                    short id = short.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new MateriaPrimaBRL();
                    materia = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
