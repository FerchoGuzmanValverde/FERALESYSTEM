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
    /// Lógica de interacción para EditarMateriaPrima.xaml
    /// </summary>
    public partial class EditarMateriaPrima : Window
    {
        MateriaPrimaBRL brl;
        MateriaPrima materia;

        AlmacenBRL brlAlmacen;
        public EditarMateriaPrima(MateriaPrima materia)
        {
            InitializeComponent();
            this.materia = materia;
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtNombreMateria.Text = txtNombreMateria.Text.Trim();
            txtCantidadMinima.Text = txtCantidadMinima.Text.Trim();
            txtUnidadMedida.Text = txtUnidadMedida.Text.Trim();
            txtStock.Text = txtStock.Text.Trim();

            if (txtNombreMateria.Text != "" && txtCantidadMinima.Text != "" && txtStock.Text != "" && txtUnidadMedida.Text != "")
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtNombreMateria.Text))
                    {
                        if (Validations.OnlyNumbers(txtCantidadMinima.Text))
                        {
                            if (Validations.OnlyLetters(txtUnidadMedida.Text))
                            {
                                if (Validations.OnlyNumbers(txtStock.Text))
                                {
                                    materia.Nombre = txtNombreMateria.Text;
                                    materia.Stock = short.Parse(txtStock.Text);
                                    materia.CantidadMinima = byte.Parse(txtCantidadMinima.Text);
                                    materia.UltimoDiaReposicion = dateUltimoDiaReposicion.SelectedDate.Value;
                                    materia.UnidadMedida = txtUnidadMedida.Text;
                                    materia.IdAlmacen = byte.Parse(cbxAlamacen.SelectedValue.ToString());
                                    brl = new MateriaPrimaBRL(materia);
                                    brl.Update();
                                    MessageBox.Show("La materia prima se ha modificado correctamente..", "MODIFICO UNA MATERIA PRIMA", MessageBoxButton.OK);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillAlmacen();

            txtNombreMateria.Text = materia.Nombre;
            txtStock.Text = materia.Stock.ToString();
            txtCantidadMinima.Text = materia.CantidadMinima.ToString();
            txtUnidadMedida.Text = materia.UnidadMedida;
            dateUltimoDiaReposicion.SelectedDate = materia.UltimoDiaReposicion;
            cbxAlamacen.Text = brlAlmacen.Get(materia.IdAlmacen).NombreAlmacen;
        }

        public void FillAlmacen()
        {
            try
            {
                brlAlmacen = new AlmacenBRL();
                cbxAlamacen.DisplayMemberPath = "nombre";
                cbxAlamacen.SelectedValuePath = "idAlmacen";
                cbxAlamacen.ItemsSource = brlAlmacen.SelectIdName().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
