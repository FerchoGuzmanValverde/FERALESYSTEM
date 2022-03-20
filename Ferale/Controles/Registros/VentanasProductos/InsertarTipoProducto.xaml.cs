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
    /// Lógica de interacción para InsertarTipoProducto.xaml
    /// </summary>
    public partial class InsertarTipoProducto : Window
    {
        TipoProducto tipo;
        TipoProductoBRL brl;
        public InsertarTipoProducto()
        {
            InitializeComponent();
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
                        tipo = new TipoProducto(txtTipoProducto.Text);
                        brl = new TipoProductoBRL(tipo);
                        brl.Insert();
                        MessageBox.Show("Se inserto correctamente el registro..");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados no son correctos o válidos!", "ERROR AL INSERTAR", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
