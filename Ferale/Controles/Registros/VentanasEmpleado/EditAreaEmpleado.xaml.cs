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

namespace Ferale.Controles.Registros.VentanasEmpleado
{
    /// <summary>
    /// Lógica de interacción para EditAreaEmpleado.xaml
    /// </summary>
    public partial class EditAreaEmpleado : Window
    {
        AreaEmpresa area;
        AreaEmpresaBRL brl;
        public EditAreaEmpleado(AreaEmpresa area)
        {
            InitializeComponent();
            this.area = area;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Insert_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtAreaEmpresa.Text = txtAreaEmpresa.Text.Trim();

            if (txtAreaEmpresa.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtAreaEmpresa.Text))
                    {
                        area.NombreAreaEmpresa = txtAreaEmpresa.Text;
                        brl = new AreaEmpresaBRL(area);
                        brl.Update();
                        this.Close();
                        MessageBox.Show("Se modifico el registro correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados no correctos o válidos...", "Error al Modificar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
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
                brl = new AreaEmpresaBRL();
                txtAreaEmpresa.Text = brl.Get(area.IdAreaEmpresa).NombreAreaEmpresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
