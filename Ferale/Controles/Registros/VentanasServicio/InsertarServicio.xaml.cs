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

namespace Ferale.Controles.Registros.VentanasServicio
{
    /// <summary>
    /// Lógica de interacción para InsertarServicio.xaml
    /// </summary>
    public partial class InsertarServicio : Window
    {
        ServicioBRL brl;
        Common.Servicio servicio;
        public InsertarServicio()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtServicio.Text = txtServicio.Text.Trim();
            txtUnidadMedida.Text = txtUnidadMedida.Text.Trim();

            if (txtServicio.Text != "" && txtUnidadMedida.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtServicio.Text))
                    {
                        if (Validations.OnlyLetters(txtUnidadMedida.Text))
                        {
                            servicio = new Common.Servicio(txtServicio.Text, txtUnidadMedida.Text);
                            brl = new ServicioBRL(servicio);
                            brl.Insert();
                            MessageBox.Show("El servicio se ha registrado correctamente..", "INSERTO UN SERVICIO", MessageBoxButton.OK);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("La unidad de medida no es válida...!! ", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El servicio ingresado no es válido...!! ", "Error al insertar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos obligatorios...!");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
