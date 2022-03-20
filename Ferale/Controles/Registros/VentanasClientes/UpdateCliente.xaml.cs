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

namespace Ferale.Controles.Registros.VentanasClientes
{
    /// <summary>
    /// Lógica de interacción para UpdateCliente.xaml
    /// </summary>
    public partial class UpdateCliente : Window
    {
        ClienteBRL brl;
        Cliente cliente;
        public UpdateCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtRazonSocial.Text = txtRazonSocial.Text.Trim();
            txtNit.Text = txtNit.Text.Trim();

            if (txtRazonSocial.Text != "" && txtNit.Text != "")
            {
                try
                {
                    if (Validations.RazonSocial(txtRazonSocial.Text))
                    {
                        if (Validations.Nit(txtNit.Text))
                        {
                            cliente.RazonSocial = txtRazonSocial.Text;
                            cliente.Nit = txtNit.Text;
                            brl = new ClienteBRL(cliente);
                            brl.Update();
                            MessageBox.Show("El cliente se ha modificado correctamente..", "MODIFICO UN CLIENTE", MessageBoxButton.OK);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El nit ingresado no es válido!!", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La razon social ingresada no es válida!!", "Error al insertar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos obligatorios...!");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtRazonSocial.Text = cliente.RazonSocial;
            txtNit.Text = cliente.Nit;
        }
    }
}
