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
using BRL;
using Common;

namespace Ferale.Controles.Registros.VentanasEmpleado
{
    /// <summary>
    /// Lógica de interacción para EditarEmpleado.xaml
    /// </summary>
    public partial class EditarEmpleado : Window
    {
        Empleado empleado;
        EmpleadoBRL brl;

        AreaEmpresaBRL brlAreaEmpresa;
        public EditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillAreaTrabajo()
        {
            try
            {
                brlAreaEmpresa = new AreaEmpresaBRL();
                cbxAreaEmpresa.DisplayMemberPath = "areaEmpresa";
                cbxAreaEmpresa.SelectedValuePath = "idAreaEmpresa";
                cbxAreaEmpresa.ItemsSource = brlAreaEmpresa.SelectIdName().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillAreaTrabajo();

            txtNombre.Text = empleado.Nombre;
            txtPrimerApellido.Text = empleado.PrimerApellido;
            txtSegundoApellido.Text = empleado.SegundoApellido;
            txtCi.Text = empleado.CedulaIdentidad;
            dpFechaNacimiento.Text = empleado.FechaNacimiento.Date.ToString();

            if(empleado.Sexo == 0) { cbxSexo.Text = "Masculino"; }
            else { cbxSexo.Text = "Femenino"; }

            cbxAreaEmpresa.Text = brlAreaEmpresa.Get(empleado.IdAreaEmpresa).NombreAreaEmpresa;
            txtNroCuenta.Text = empleado.NroCuentaBancaria.ToString();
            txtTelefono.Text = empleado.Telefono;
            txtDomicilio.Text = empleado.Domicilio;
            txtCorreo.Text = empleado.Correo;
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
                                                    empleado.Nombre = txtNombre.Text;
                                                    empleado.PrimerApellido = txtPrimerApellido.Text;
                                                    empleado.SegundoApellido = txtSegundoApellido.Text;
                                                    empleado.CedulaIdentidad = txtCi.Text;
                                                    empleado.FechaNacimiento = dpFechaNacimiento.SelectedDate.Value;

                                                    if (cbxSexo.SelectionBoxItem.ToString() == "Masculino") { empleado.Sexo = 0; }
                                                    else { empleado.Sexo = 1; }

                                                    empleado.IdAreaEmpresa = byte.Parse(cbxAreaEmpresa.SelectedValue.ToString());
                                                    empleado.NroCuentaBancaria = int.Parse(txtNroCuenta.Text);
                                                    empleado.Telefono = txtTelefono.Text;
                                                    empleado.Domicilio = txtDomicilio.Text;
                                                    empleado.Correo = txtCorreo.Text;

                                                    brl = new EmpleadoBRL(empleado);
                                                    brl.Update();
                                                    MessageBox.Show("El empleado se ha modificado correctamente..", "MODIFICO UN EMPLEADO", MessageBoxButton.OK);
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

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
