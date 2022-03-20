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
    /// Lógica de interacción para ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        Usuario user;
        UsuarioBRL brl;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = txtCodigo.Text.Trim();

            if (txtCodigo.Text != "" && txtPassword.Password != "" && txtRePassword.Password != "")
            {
                if (txtPassword.Password == txtRePassword.Password)
                {
                    try
                    {
                        if (Validations.Password(txtPassword.Password))
                        {
                            brl = new UsuarioBRL();
                            user = brl.GetByCode(txtCodigo.Text);

                            if (user.Settings == 1)
                            {
                                user.PasswordUsuario = txtPassword.Password;
                                user.Settings = 0;

                                brl = new UsuarioBRL(user);
                                brl.Update();

                                MessageBox.Show("Su contraseña fue re-establecida!!", "DATOS GUARDADOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("El usuario esta configurado. Ingrese a su cuenta para modificarlo!!", "Usuario Configurado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enviar Email. Para recibir un código de verificación!!", "PRIMER PASO", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            txtCodigo.IsEnabled = false;
            txtPassword.IsEnabled = false;
            txtRePassword.IsEnabled = false;
            btnGuardar.IsEnabled = false;
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            txtMail.Text = txtMail.Text.Trim();

            if (txtMail.Text != "")
            {
                try
                {
                    if (Validations.Emails(txtMail.Text))
                    {
                        List<string> datos = new List<string>();
                        brl = new UsuarioBRL();
                        datos = brl.GetByEmail(txtMail.Text);

                        if (datos.Count > 0)
                        {
                            brl = new UsuarioBRL();
                            user = brl.GetUserByEmail(txtMail.Text);
                            user.Codigo = SecurityMethods.GenerarCodigo(datos.ElementAt(0), datos.ElementAt(1));
                            user.Settings = 1;

                            brl = new UsuarioBRL(user);
                            brl.Update();
                            brl.CrearEmail();

                            txtCodigo.IsEnabled = true;
                            txtPassword.IsEnabled = true;
                            txtRePassword.IsEnabled = true;
                            btnGuardar.IsEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("El email ingresado no esta registrado en el sistema!!. Si no recuerda su email, contactese con administración!!", "EMAIL NO REGISTRADO", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email ingresado es inválido y/o incorrecto", "EMAIL NO VALIDO", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un email!!", "EMAIL REQUERIDO", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
