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

namespace Ferale.Controles.Limpiezas.VentanasLimpieza
{
    /// <summary>
    /// Lógica de interacción para EditarLimpieza.xaml
    /// </summary>
    public partial class EditarLimpieza : Window
    {
        LimpiezaEmpleado le;

        EmpleadoBRL brlEmpleado;
        Empleado empleado;

        LimpiezaBRL brl;
        Limpieza limpieza;

        EstablecimientoBRL brlEstablecimiento;
        TipoLimpiezaBRL brlTipoLimpieza;
        public EditarLimpieza(Limpieza limpieza)
        {
            InitializeComponent();
            this.limpieza = limpieza;
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dpFechaLimpieza.SelectedDate != null)
            {
                try
                {
                    if (Validations.DateOfBirth(dpFechaLimpieza.SelectedDate.Value))
                    {
                        le = new LimpiezaEmpleado(int.Parse(cbxEmpleado.SelectedValue.ToString()));
                        limpieza.FechaHoraLimpieza = dpFechaLimpieza.SelectedDate.Value;
                        limpieza.IdTipoLimpieza = byte.Parse(cbxTipoLimpieza.SelectedValue.ToString());
                        limpieza.IdEstablecimiento = byte.Parse(cbxEstablecimiento.SelectedValue.ToString());
                        limpieza.EmpleadoEncargado = le;
                        brl = new LimpiezaBRL(limpieza);
                        brl.Update();
                        MessageBox.Show("La limpieza se ha modificado correctamente..", "MODIFICO UNA LIMPIEZA", MessageBoxButton.OK);
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
                MessageBox.Show("Debe ingresar una fecha de limpieza...!");
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

            cbxTipoLimpieza.Text = brlTipoLimpieza.Get(limpieza.IdTipoLimpieza).NombreTipo;
            cbxEstablecimiento.Text = brlEstablecimiento.Get(limpieza.IdEstablecimiento).NombreEstablecimiento;
            dpFechaLimpieza.SelectedDate = limpieza.FechaHoraLimpieza;
            cbxEmpleado.SelectedValue = limpieza.EmpleadoEncargado.IdEmpleado;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
