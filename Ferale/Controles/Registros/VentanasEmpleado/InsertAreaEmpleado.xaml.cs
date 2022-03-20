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
    /// Lógica de interacción para InsertAreaEmpleado.xaml
    /// </summary>
    public partial class InsertAreaEmpleado : Window
    {
        AreaEmpresa area;
        AreaEmpresaBRL brl;
        public InsertAreaEmpleado()
        {
            InitializeComponent();
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
                        area = new AreaEmpresa(txtAreaEmpresa.Text);
                        brl = new AreaEmpresaBRL(area);
                        brl.Insert();
                        MessageBox.Show("Se inserto correctamente el registro..");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados no correctos o válidos...", "Error al Insertar");
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
        
    }
}
