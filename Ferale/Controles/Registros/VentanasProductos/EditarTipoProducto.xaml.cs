using BRL;
using Common;
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

namespace Ferale.Controles.Registros.VentanasProductos
{
    /// <summary>
    /// Lógica de interacción para EditarTipoProducto.xaml
    /// </summary>
    public partial class EditarTipoProducto : Window
    {
        TipoProducto tipo;
        TipoProductoBRL brl;
        public EditarTipoProducto(TipoProducto tipoProducto)
        {
            InitializeComponent();
            this.tipo = tipoProducto;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtTipoProducto.Text = txtTipoProducto.Text.Trim();

            if (txtTipoProducto.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtTipoProducto.Text))
                    {
                        tipo.NombreTipo = txtTipoProducto.Text;
                        brl = new TipoProductoBRL(tipo);
                        brl.Update();
                        MessageBox.Show("Se modifico el registro correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados no son correctos o válidos!", "ERROR AL MODIFICAR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los campos obligatorios!", "INGRESAR TODOS LOS DATOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarArea();
        }

        public void CargarArea()
        {
            try
            {
                brl = new TipoProductoBRL();
                txtTipoProducto.Text = brl.Get(tipo.IdTipoProducto).NombreTipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
