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

namespace Ferale.Controles.Registros.VentanasMateriaPrima
{
    /// <summary>
    /// Lógica de interacción para InsertarMateriaPrima.xaml
    /// </summary>
    public partial class InsertarMateriaPrima : Window
    {
        MateriaPrimaBRL brl;
        MateriaPrima materia;

        AlmacenBRL brlAlmacen;
        public InsertarMateriaPrima()
        {
            InitializeComponent();
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtNommbre.Text = txtNommbre.Text.Trim();
            txtCantidadMinima.Text = txtCantidadMinima.Text.Trim();
            txtUnidadMedida.Text = txtUnidadMedida.Text.Trim();
            txtStock.Text = txtStock.Text.Trim();

            if (txtNommbre.Text != "" && txtCantidadMinima.Text != "" && txtStock.Text != "" && txtUnidadMedida.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtNommbre.Text))
                    {
                        if (Validations.OnlyNumbers(txtCantidadMinima.Text))
                        {
                            if (Validations.OnlyLetters(txtUnidadMedida.Text))
                            {
                                if (Validations.OnlyNumbers(txtStock.Text))
                                {
                                    materia = new MateriaPrima(txtNommbre.Text, short.Parse(txtStock.Text), byte.Parse(txtCantidadMinima.Text), dateUltimoDiaReposicion.SelectedDate.Value, txtUnidadMedida.Text, byte.Parse(cbxAlmacen.SelectedValue.ToString()));
                                    brl = new MateriaPrimaBRL(materia);
                                    brl.Insert();
                                    MessageBox.Show("La materia prima se ha registrado correctamente..", "INSERTO UNA MATERIA PRIMA", MessageBoxButton.OK);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("El stock no es válido...!! ", "Error al insertar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La unidad de medida no es válida...!! ", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad minima no es válida...!! ", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre no es válido...!! ", "Error al insertar");
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

        public void FillAlmacen()
        {
            try
            {
                brlAlmacen = new AlmacenBRL();
                cbxAlmacen.DisplayMemberPath = "nombre";
                cbxAlmacen.SelectedValuePath = "idAlmacen";
                cbxAlmacen.ItemsSource = brlAlmacen.SelectIdName().DefaultView;
                cbxAlmacen.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillAlmacen();
        }
    }
}
