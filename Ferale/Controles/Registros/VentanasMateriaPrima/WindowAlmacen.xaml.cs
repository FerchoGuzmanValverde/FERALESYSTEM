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
using BRL;
using Common;
using Microsoft.Maps.MapControl.WPF;

namespace Ferale.Controles.Registros.VentanasMateriaPrima
{
    /// <summary>
    /// Lógica de interacción para WindowAlmacen.xaml
    /// </summary>
    public partial class WindowAlmacen : Window
    {
        AlmacenBRL brl;
        Almacen almacen;
        Location puntoubicacion;
        public WindowAlmacen()
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
                brl = new AlmacenBRL();
                dgArea.ItemsSource = null;
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
            InsertarAlmacen nuevaVentana = new InsertarAlmacen();
            nuevaVentana.ShowDialog();
            DataGridLoadRefresh();
        }

        private void Update_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (almacen != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                try
                {
                    EditarAlmacen nuevaVentana = new EditarAlmacen(almacen);
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
            if (almacen != null && dgArea.Items.Count > 0 && dgArea.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new AlmacenBRL(almacen);
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
                    brl = new AlmacenBRL();
                    almacen = null;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    almacen = brl.Get(id);
                    if(almacen != null)
                    {
                        Location punto = new Location(almacen.Latitud, almacen.Longitud);
                        mapaAlmacen.SetView(punto, 18);
                        Pushpin marcador1 = new Pushpin();
                        marcador1.Location = punto;
                        mapaAlmacen.Children.Clear();
                        mapaAlmacen.Children.Add(marcador1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cardAcercar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapaAlmacen.Focus();
            mapaAlmacen.ZoomLevel++;
        }

        private void cardAlejar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapaAlmacen.Focus();
            mapaAlmacen.ZoomLevel--;
        }

        private void cardCalle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapaAlmacen.Focus();
            mapaAlmacen.Mode = new RoadMode();
        }

        private void cardSaltelite_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapaAlmacen.Focus();
            mapaAlmacen.Mode = new AerialMode(true);
        }

        
    }
}
