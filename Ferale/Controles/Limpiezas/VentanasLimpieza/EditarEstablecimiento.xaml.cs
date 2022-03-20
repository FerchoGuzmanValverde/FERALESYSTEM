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

namespace Ferale.Controles.Limpiezas.VentanasLimpieza
{
    /// <summary>
    /// Lógica de interacción para EditarEstablecimiento.xaml
    /// </summary>
    public partial class EditarEstablecimiento : Window
    {
        Establecimiento establecimiento;
        EstablecimientoBRL brl;
        public EditarEstablecimiento(Establecimiento establecimiento)
        {
            InitializeComponent();
            this.establecimiento = establecimiento;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtEstablecimiento.Text = txtEstablecimiento.Text.Trim();

            if (txtEstablecimiento.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtEstablecimiento.Text))
                    {
                        establecimiento.NombreEstablecimiento = txtEstablecimiento.Text;
                        brl = new EstablecimientoBRL(establecimiento);
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
            CargarTipo();
        }

        public void CargarTipo()
        {
            try
            {
                brl = new EstablecimientoBRL();
                txtEstablecimiento.Text = brl.Get(establecimiento.IdEstablecimiento).NombreEstablecimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
