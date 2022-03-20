using BRL;
using Common;
using Microsoft.Maps.MapControl.WPF;
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

namespace Ferale.Controles.Registros.VentanasMateriaPrima
{
    /// <summary>
    /// Lógica de interacción para InsertarAlmacen.xaml
    /// </summary>
    public partial class InsertarAlmacen : Window
    {
        Almacen almacen;
        AlmacenBRL brl;
        Location puntoubicacion;
        public InsertarAlmacen()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtNombreAlmacen.Text = txtNombreAlmacen.Text.Trim();
            txtDireccion.Text = txtDireccion.Text.Trim();

            if (txtNombreAlmacen.Text != "" && txtDireccion.Text != "" && mapaAlmacen != null)
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtNombreAlmacen.Text))
                    {
                        if (Validations.OnlyLettersAndSpaces(txtDireccion.Text))
                        {
                            almacen = new Almacen(txtNombreAlmacen.Text, (float)puntoubicacion.Latitude, (float)puntoubicacion.Longitude, txtDireccion.Text);
                            brl = new AlmacenBRL(almacen);
                            brl.Insert();
                            MessageBox.Show("Se inserto correctamente el registro..");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("La dirección no es válida!", "ERROR AL INSERTAR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre no es válido!", "ERROR AL INSERTAR",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos...", "INGRESE TODOS LOS DATOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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

        private void mapaAlmacen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePosicion = e.GetPosition((UIElement)sender);
            puntoubicacion = mapaAlmacen.ViewportPointToLocation(mousePosicion);
            Pushpin marcador = new Pushpin();
            marcador.Location = puntoubicacion;
            mapaAlmacen.Children.Clear();
            mapaAlmacen.Children.Add(marcador);
        }
    }
}
