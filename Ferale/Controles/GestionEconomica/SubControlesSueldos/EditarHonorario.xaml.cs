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

namespace Ferale.Controles.GestionEconomica.SubControlesSueldos
{
    /// <summary>
    /// Lógica de interacción para EditarHonorario.xaml
    /// </summary>
    public partial class EditarHonorario : Window
    {
        Honorario sueldo;
        HonorarioBRL brl;
        MesBRL mesBrl;
        EmpleadoBRL empleadoBrl;

        public EditarHonorario(Honorario Honorario)
        {
            InitializeComponent();
            sueldo = Honorario;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtDiaCompleto.Text = txtDiaCompleto.Text.Trim();
            txtEmpleado.Text = txtEmpleado.Text.Trim();
            txtMedioDia.Text = txtMedioDia.Text.Trim();
            txtMontoTotalCancelado.Text = txtMontoTotalCancelado.Text.Trim();
            txtPagoMedioDia.Text = txtPagoMedioDia.Text.Trim();

            if (txtEmpleado.Text != "" && txtMontoTotalCancelado.Text != "" && txtPagoMedioDia.Text != "")
            {
                try
                {
                    if (Validations.OnlyNumbers(txtDiaCompleto.Text) && Validations.OnlyNumbers(txtMedioDia.Text))
                    {
                        empleadoBrl = new EmpleadoBRL();
                        mesBrl = new MesBRL();

                        sueldo.MontoTotalCancelado = double.Parse(txtMontoTotalCancelado.Text);
                        sueldo.DiaCompletoTrabajo = byte.Parse(txtDiaCompleto.Text);
                        sueldo.MedioDiaTrabajo = byte.Parse(txtMedioDia.Text);
                        sueldo.PagoMedioDia = double.Parse(txtPagoMedioDia.Text);
                        sueldo.IdEmpleado = 9;
                        sueldo.IdMes = short.Parse(cbxMes.SelectedValue.ToString());
                        brl = new HonorarioBRL(sueldo);
                        brl.Update();
                        MessageBox.Show("El pago se ha modificado correctamente..", "MODIFICO UN HONORARIO", MessageBoxButton.OK);
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
                MessageBox.Show("Debe ingresar los datos obligatorios...!");
            }
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillMes();
            CargarHonorario();
        }

        public void CargarHonorario()
        {
            empleadoBrl = new EmpleadoBRL();
            mesBrl = new MesBRL();

            txtMontoTotalCancelado.Text = sueldo.MontoTotalCancelado.ToString();
            txtDiaCompleto.Text = sueldo.DiaCompletoTrabajo.ToString();
            txtEmpleado.Text = empleadoBrl.Get(sueldo.IdEmpleado).Nombre + " " + empleadoBrl.Get(sueldo.IdEmpleado).PrimerApellido;
            txtMedioDia.Text = sueldo.MedioDiaTrabajo.ToString();
            txtPagoMedioDia.Text = sueldo.PagoMedioDia.ToString();
            cbxMes.Text = mesBrl.Get(sueldo.IdMes).NombreMes;
            dateDiaFinalPagado.SelectedDate = sueldo.DiaFinalPagado;
        }

        public void FillMes()
        {
            try
            {
                mesBrl = new MesBRL();
                cbxMes.DisplayMemberPath = "mes";
                cbxMes.SelectedValuePath = "idMes";
                cbxMes.ItemsSource = mesBrl.SelectByIdName().DefaultView;
                cbxMes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
