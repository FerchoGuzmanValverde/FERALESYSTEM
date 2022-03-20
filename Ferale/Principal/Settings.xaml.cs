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

namespace Ferale.Principal
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        Usuario user;
        UsuarioBRL brl;

        public Settings()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.Trim();
            txtCodigo.Text = txtCodigo.Text.Trim();

            if(txtUsuario.Text != "" && txtCodigo.Text != "" && txtPassword.Password != "" && txtRePassword.Password != "")
            {
                if (txtPassword.Password == txtRePassword.Password)
                {
                    try
                    {
                        if (Validations.Password(txtPassword.Password) && Validations.Users(txtUsuario.Text))
                        {
                            brl = new UsuarioBRL();
                            user = brl.GetByCode(txtCodigo.Text);

                            if (user.Settings == 1)
                            {
                                user.NombreUsuario = txtUsuario.Text;
                                user.PasswordUsuario = txtPassword.Password;
                                user.Settings = 0;

                                brl = new UsuarioBRL(user);
                                brl.Update();

                                MessageBox.Show("Los datos fueron guardados correctamente!!", "DATOS GUARDADOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Este usuario ya fue configurado. Ingrese a su cuenta para modificarlo!!", "Usuario Configurado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                this.Close();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados son invalidos y/o incorrectos!!", "DATOS INVALIDOS", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no son iguales!!", "ERROR CONTRASEÑA", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios!!", "CAMPOS REQUERIDOS", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
