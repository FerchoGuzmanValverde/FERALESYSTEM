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
    /// Lógica de interacción para InsertarLimpieza.xaml
    /// </summary>
    public partial class InsertarLimpieza : Window
    {
        LimpiezaEmpleado le;

        LimpiezaBRL brl;
        Limpieza limpieza;

        EstablecimientoBRL brlEstablecimiento;
        TipoLimpiezaBRL brlTipoLimpieza;

        EmpleadoBRL brlEmpleado;
        Empleado empleado;

        public InsertarLimpieza()
        {
            InitializeComponent();
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
                        if (cbxEmpleado.SelectedValue != null)
                        {
                            if (cbxEstablecimiento.SelectedValue != null)
                            {
                                if (cbxTipoLimpieza.SelectedValue != null)
                                {
                                    le = new LimpiezaEmpleado(int.Parse(cbxEmpleado.SelectedValue.ToString()));
                                    limpieza = new Limpieza(dpFechaLimpieza.SelectedDate.Value, byte.Parse(cbxTipoLimpieza.SelectedValue.ToString()), byte.Parse(cbxEstablecimiento.SelectedValue.ToString()), le);
                                    brl = new LimpiezaBRL(limpieza);
                                    brl.Insert();
                                    MessageBox.Show("La limpieza se ha registrado correctamente..", "INSERTO UNA LIMPIEZA", MessageBoxButton.OK);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("De ingresar un tipo de limpieza... ", "Error al insertar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe ingresar un establecimiento... ", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar un empleado... ", "Error al insertar");
                        }
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
