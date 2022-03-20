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
    /// Lógica de interacción para EditarAlmacen.xaml
    /// </summary>
    public partial class EditarAlmacen : Window
    {
        Almacen almacen;
        AlmacenBRL brl;
        Location puntoubicacion;
        Pushpin marcador;
        public EditarAlmacen(Almacen almacen)
        {
            InitializeComponent();
            this.almacen = almacen;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtAlmacen.Text = txtAlmacen.Text.Trim();
            txtDireccion.Text = txtDireccion.Text.Trim();

            if (txtAlmacen.Text != "" && txtDireccion.Text != "" && mapaAlmacen != null)
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtAlmacen.Text))
                    {
                        if (Validations.OnlyLettersAndSpaces(txtDireccion.Text))
                        {
                            almacen.NombreAlmacen = txtAlmacen.Text;
                            almacen.Latitud = (float)puntoubicacion.Latitude;
                            almacen.Longitud = (float)puntoubicacion.Longitude;
                            almacen.Direccion = txtDireccion.Text;
                            brl = new AlmacenBRL(almacen);
                            brl.Update();
                            this.Close();
                            MessageBox.Show("Se modifico el registro correctamente");
                        }
                        else
                        {
                            MessageBox.Show("La dirección no es válida!", "ERROR AL INSERTAR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre no es válido!", "ERROR AL INSERTAR", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarAlmacen();
        }

        public void CargarAlmacen()
        {
            try
            {
                brl = new AlmacenBRL();
                txtAlmacen.Text = brl.Get(almacen.IdAlmacen).NombreAlmacen;
                txtDireccion.Text = brl.Get(almacen.IdAlmacen).Direccion;
                marcador = new Pushpin();
                puntoubicacion= new Location(brl.Get(almacen.IdAlmacen).Latitud, brl.Get(almacen.IdAlmacen).Longitud);
                marcador.Location = puntoubicacion;
                mapaAlmacen.Children.Clear();
                mapaAlmacen.Children.Add(marcador);
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

        private void mapaAlmacen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePosicion = e.GetPosition((UIElement)sender);
            puntoubicacion = mapaAlmacen.ViewportPointToLocation(mousePosicion);
            marcador = new Pushpin();
            marcador.Location = puntoubicacion;
            mapaAlmacen.Children.Clear();
            mapaAlmacen.Children.Add(marcador);
        }
    }
}
