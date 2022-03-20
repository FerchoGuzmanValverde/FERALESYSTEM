using BRL;
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
using Common;
using System.Data;

namespace Ferale.Principal
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UsuarioBRL brl;

        ApiResults ResultsData = new ApiResults();

        public Login()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.Trim();
            if (txtUsuario.Text != "" && txtPassword.Password != "")
            {
                try
                {
                    brl = new UsuarioBRL();
                    DataTable dt = brl.Login(txtUsuario.Text, txtPassword.Password);
                    if (dt.Rows.Count>0)
                    {
                        Sesion.idUsuario = int.Parse(dt.Rows[0][0].ToString());
                        Sesion.nombreUsuario = dt.Rows[0][1].ToString();
                        Sesion.rolSesion = dt.Rows[0][2].ToString();

                        if(byte.Parse(dt.Rows[0][3].ToString()) != 1)
                        {
                            MainWindow principal = new MainWindow();
                            this.Visibility = Visibility.Hidden;
                            principal.ShowDialog();
                        }
                        else
                        {
                            Settings nuevoSetting = new Settings();
                            this.Visibility = Visibility.Hidden;
                            nuevoSetting.ShowDialog();
                        }
                        this.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Nombre de Usuario y/o Password incorrectos!!","DATOS INCORRECTOS",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un usuario y un password!!", "INGRESE DATOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnFacebook_Click(object sender, RoutedEventArgs e)
        {
            FBDialog fbd = new FBDialog();
            fbd.Owner = this;
            fbd.Show();
        }

        public void SendArgumentsBack(ApiResults data)
        {
            ResultsData = data;
            if (data.ErrorFound)
            {
                MessageBox.Show(ResultsData.Error + Environment.NewLine + ResultsData.ErrorDescription + Environment.NewLine + ResultsData.ErrorReason);
            }
            else
            {
                MessageBox.Show(ResultsData.Accesstoken + Environment.NewLine + ResultsData.GrantedScopes + Environment.NewLine + ResultsData.DeniedScopes);
            }
        }

        private void btnGoogle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRecuperar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ForgotPassword nuevo = new ForgotPassword();
            this.Visibility = Visibility.Hidden;
            nuevo.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MailConfig.senderMail = "feraleempresa@outlook.com";
            MailConfig.password = "Ferale3+";
            MailConfig.host = "smtp.live.com";
            MailConfig.port = 587;
            MailConfig.ssl = true;

            MailConfig.initializaSmtp();
        }

        private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            Settings nuevoSetting = new Settings();
            this.Visibility = Visibility.Hidden;
            nuevoSetting.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
