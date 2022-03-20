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

namespace Ferale.Controles.Limpiezas.VentanasPlaga
{
    /// <summary>
    /// Lógica de interacción para InsertarPlaga.xaml
    /// </summary>
    public partial class InsertarPlaga : Window
    {
        LimpiezaEmpleado le;

        PlagaBRL brl;
        Plaga plaga;

        EstablecimientoBRL brlEstablecimiento;
        TipoLimpiezaBRL brlTipoLimpieza;

        EmpleadoBRL brlEmpleado;

        public InsertarPlaga()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtDescripcionPlaga.Text = txtDescripcionPlaga.Text.Trim();
            txtTratamiento.Text = txtTratamiento.Text.Trim();

            if (dpFechaLimpieza.SelectedDate != null && txtDescripcionPlaga.Text != "" && txtTratamiento.Text != "")
            {
                try
                {
                    if (Validations.DateOfBirth(dpFechaLimpieza.SelectedDate.Value) && Validations.OnlyLettersAndSpaces(txtDescripcionPlaga.Text))
                    {
                        le = new LimpiezaEmpleado(int.Parse(cbxEmpleado.SelectedValue.ToString()));
                        plaga = new Plaga(dpFechaLimpieza.SelectedDate.Value, byte.Parse(cbxTipoLimpieza.SelectedValue.ToString()), byte.Parse(cbxEstablecimiento.SelectedValue.ToString()), txtDescripcionPlaga.Text, txtTratamiento.Text, le);
                        brl = new PlagaBRL(plaga);
                        brl.Insert();
                        MessageBox.Show("El control de plaga se ha registrado correctamente..", "INSERTO UN CONTROL DE PLAGA", MessageBoxButton.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los datos ingresados no son correctos o válidos... ", "Error al insertar");
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
            FillTipoLimpieza();
            FillEstablecimiento();
            FillEmpleados();
        }

        public void FillEmpleados()
        {
            try
            {
                brlEmpleado = new EmpleadoBRL();
                cbxEmpleado.DisplayMemberPath = "empleado";
                cbxEmpleado.SelectedValuePath = "idEmpleado";
                cbxEmpleado.ItemsSource = brlEmpleado.SelectIdName().DefaultView;
                cbxEmpleado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillTipoLimpieza()
        {
            try
            {
                brlTipoLimpieza = new TipoLimpiezaBRL();
                cbxTipoLimpieza.DisplayMemberPath = "tipoLimpieza";
                cbxTipoLimpieza.SelectedValuePath = "idTipoLimpieza";
                cbxTipoLimpieza.ItemsSource = brlTipoLimpieza.SelectIdName().DefaultView;
                cbxTipoLimpieza.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillEstablecimiento()
        {
            try
            {
                brlEstablecimiento = new EstablecimientoBRL();
                cbxEstablecimiento.DisplayMemberPath = "nombreEstablecimiento";
                cbxEstablecimiento.SelectedValuePath = "idEstablecimiento";
                cbxEstablecimiento.ItemsSource = brlEstablecimiento.SelectIdName().DefaultView;
                cbxEstablecimiento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
