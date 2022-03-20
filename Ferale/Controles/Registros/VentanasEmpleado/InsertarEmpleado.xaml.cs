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
    /// Lógica de interacción para InsertarEditarEmpleado.xaml
    /// </summary>
    public partial class InsertarEditarEmpleado : Window
    {
        EmpleadoBRL brl;
        Empleado empleado;
        Usuario user;

        AreaEmpresaBRL brlAreaEmpresa;
        public InsertarEditarEmpleado()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.Trim();
            txtPrimerApellido.Text = txtPrimerApellido.Text.Trim();
            txtCi.Text = txtCi.Text.Trim();
            txtNroCuenta.Text = txtNroCuenta.Text.Trim();

            if (txtNombre.Text != "" && txtPrimerApellido.Text != "" && txtCi.Text != "" && txtNroCuenta.Text != "" && dpFechaNacimiento.SelectedDate != null)
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtNombre.Text))
                    {
                        if (Validations.OnlyLetters(txtPrimerApellido.Text))
                        {
                            if (Validations.Nit(txtCi.Text))
                            {
                                if (Validations.DateOfBirth(dpFechaNacimiento.SelectedDate.Value))
                                {
                                    if (Validations.OnlyNumbers(txtNroCuenta.Text))
                                    {
                                        if (Validations.OnlyNumbersAndSeparators(txtTelefono.Text))
                                        {
                                            if (Validations.OnlyLettersAndSpaces(txtDomicilio.Text))
                                            {
                                                if (Validations.Emails(txtCorreo.Text))
                                                {
                                                    byte sexo; byte cargo;
                                                    if (cbxSexo.SelectionBoxItem.ToString() == "Masculino") { sexo = 0; }
                                                    else { sexo = 1; }
                                                    byte[] foto = { 0 };
                                                    user = new Usuario(cbxCargo.SelectionBoxItem.ToString(), "", "", 1, txtCorreo.Text, SecurityMethods.GenerarCodigo(txtNombre.Text, txtCi.Text));
                                                    empleado = new Empleado(txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtCi.Text, dpFechaNacimiento.SelectedDate.Value, sexo, int.Parse(txtNroCuenta.Text), byte.Parse(cbxAreaEmpresa.SelectedValue.ToString()), txtTelefono.Text, foto, txtDomicilio.Text, txtCorreo.Text, user);
                                                    brl = new EmpleadoBRL(empleado);
                                                    brl.Insert();
                                                    MessageBox.Show("El empleado se ha registrado correctamente..", "INSERTO UN EMPLEADO", MessageBoxButton.OK);
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El correo ingresado no es válido..!!", "Error al insertar");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El domicilio ingresado no es válido..!!", "Error al insertar");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El teléfono ingresado no es válido..!!", "Error al insertar");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La cuenta bancaria ingresada no es válida..!!", "Error al insertar");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La fecha de nacimiento ingresada no es válida..!!", "Error al insertar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El CI ingresado no es válido..!!", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El apellido paterno ingresado no es válido..!! ", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre ingresado no es válido..!! ", "Error al insertar");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillAreaTrabajo();
        }

        private void FillAreaTrabajo()
        {
            try
            {
                brlAreaEmpresa = new AreaEmpresaBRL();
                cbxAreaEmpresa.DisplayMemberPath = "areaEmpresa";
                cbxAreaEmpresa.SelectedValuePath = "idAreaEmpresa";
                cbxAreaEmpresa.ItemsSource = brlAreaEmpresa.SelectIdName().DefaultView;
                cbxAreaEmpresa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
