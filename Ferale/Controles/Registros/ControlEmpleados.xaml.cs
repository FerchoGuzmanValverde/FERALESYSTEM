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
using Common;
using BRL;
using System.Data;

namespace Ferale.Controles.Registros
{
    /// <summary>
    /// Lógica de interacción para ControlEmpleados.xaml
    /// </summary>
    public partial class ControlEmpleados : UserControl
    {
        EmpleadoBRL brl;
        Empleado empleado;
        public ControlEmpleados()
        {
            InitializeComponent();
        }

        void RefreshDataGrid()
        {
            try
            {
                brl = new EmpleadoBRL();
                dgDatos.ItemsSource = brl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            VentanasEmpleado.AdminAreaEmpleado ventanaArea = new VentanasEmpleado.AdminAreaEmpleado();
            ventanaArea.ShowDialog();
        }

        private void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (empleado != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Esta segur@ de eliminar el registro?", "Eliminando Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        brl = new EmpleadoBRL(empleado);
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
            if (empleado != null && dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                try
                {
                    VentanasEmpleado.EditarEmpleado nuevaVentana = new VentanasEmpleado.EditarEmpleado(empleado);
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
            VentanasEmpleado.InsertarEditarEmpleado nuevaVentana = new VentanasEmpleado.InsertarEditarEmpleado();
            nuevaVentana.ShowDialog();
            RefreshDataGrid();
        }

        private void Select_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Este campo es para realizar una busqueda de empleados con parametros
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void DgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
                {
                    DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;

                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    brl = new EmpleadoBRL();
                    empleado = brl.Get(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
