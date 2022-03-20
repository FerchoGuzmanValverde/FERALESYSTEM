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

namespace Ferale.Controles.Registros.VentanasProveedor
{
    /// <summary>
    /// Lógica de interacción para InsertarProveedor.xaml
    /// </summary>
    public partial class InsertarProveedor : Window
    {
        ProveedorBRL brl;
        Proveedor proveedor;
        public InsertarProveedor()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtRazonSocial.Text = txtRazonSocial.Text.Trim();
            txtNit.Text = txtNit.Text.Trim();
            txtNroCuentaBanco.Text = txtNroCuentaBanco.Text.Trim();
            txtTelefono.Text = txtTelefono.Text.Trim();

            if (txtRazonSocial.Text != "" && txtNit.Text != "" && txtNroCuentaBanco.Text != "" && txtTelefono.Text != "")
            {
                try
                {
                    if (Validations.RazonSocial(txtRazonSocial.Text))
                    {
                        if (Validations.Nit(txtNit.Text))
                        {
                            if (Validations.OnlyNumbers(txtNroCuentaBanco.Text))
                            {
                                if (Validations.OnlyNumbersAndSeparators(txtTelefono.Text))
                                {
                                    proveedor = new Proveedor(txtRazonSocial.Text, txtNit.Text, txtTelefono.Text, int.Parse(txtNroCuentaBanco.Text));
                                    brl = new ProveedorBRL(proveedor);
                                    brl.Insert();
                                    MessageBox.Show("El proveedor se ha registrado correctamente..", "INSERTO UN PROVEEDOR", MessageBoxButton.OK);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("El nro. de teléfono no es válido...!! ", "Error al insertar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El número de cuenta bancaria no es válido...!! ", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El nit no es válido...!! ", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La razon social no es válida...!! ", "Error al insertar");
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
