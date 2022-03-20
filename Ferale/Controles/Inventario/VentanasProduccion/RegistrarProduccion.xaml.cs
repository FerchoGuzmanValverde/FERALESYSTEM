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

namespace Ferale.Controles.Inventario.VentanasProduccion
{
    /// <summary>
    /// Lógica de interacción para RegistrarProduccion.xaml
    /// </summary>
    public partial class RegistrarProduccion : Window
    {
        ProduccionBRL brl;

        Produccion produccion;
        List<MateriaProduccion> detalles;

        MateriaProduccion mp;
        int indice;

        TipoProductoBRL tipoBrl;
        ProductoBRL productoBrl;
        MateriaPrimaBRL materiaBrl;
        int ban = 0;
        public RegistrarProduccion()
        {
            InitializeComponent();
        }

        public void FillTipoProducto()
        {
            try
            {
                tipoBrl = new TipoProductoBRL();
                cbxTipoProducto.DisplayMemberPath = "nombreTipo";
                cbxTipoProducto.SelectedValuePath = "idTipoProducto";
                cbxTipoProducto.ItemsSource = tipoBrl.SelectIdName().DefaultView;
                cbxTipoProducto.SelectedIndex = 0;
                FillProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillProducto()
        {
            try
            {
                productoBrl = new ProductoBRL();
                cbxProducto.DisplayMemberPath = "descripcionProducto";
                cbxProducto.SelectedValuePath = "idProducto";
                cbxProducto.ItemsSource = productoBrl.SelectByIdName(byte.Parse(cbxTipoProducto.SelectedValue.ToString())).DefaultView;
                cbxProducto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillMaterias()
        {
            try
            {
                materiaBrl = new MateriaPrimaBRL();
                cbxMateriaPrima.DisplayMemberPath = "nombre";
                cbxMateriaPrima.SelectedValuePath = "idMateria";
                cbxMateriaPrima.ItemsSource = materiaBrl.SelectIdName().DefaultView;
                cbxMateriaPrima.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregarDetalleVenta_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Agregar Producto Boton
            MateriaProduccion nuevo = new MateriaProduccion();
            ban = 0;
            if (txtCantidadMateria.Text != "" && short.Parse(txtCantidadMateria.Text) > 0)
            {
                if (cbxMateriaPrima.SelectedItem != null)
                {
                    nuevo.IdMateria = short.Parse(cbxMateriaPrima.SelectedValue.ToString());
                    nuevo.Cantidad = short.Parse(txtCantidadMateria.Text);
                    foreach (MateriaProduccion item in detalles)
                    {
                        if (item.IdMateria == nuevo.IdMateria)
                        {
                            MessageBox.Show("El producto ya esta añadido a la lista. Seleccionelo para editar su cantidad o su precio.");
                            ban = 1;
                            break;
                        }
                    }
                    if (ban == 0)
                    {
                        detalles.Add(nuevo);
                    }
                }
                else
                {
                    MessageBox.Show("No se seleccionó una materia prima");
                }
            }
            else
            {
                MessageBox.Show("La cantidad de material utilizado no puede quedar vacío ni ser menor a 1.");
            }

            RefreshDetails();
        }

        public void RefreshDetails()
        {
            lstDetalleMateria.Items.Clear();
            txtCantidadMateria.Text = "";

            foreach (MateriaProduccion item in detalles)
            {
                lstDetalleMateria.Items.Add(materiaBrl.Get(item.IdMateria).Nombre + "\t ||\tCantidad: " + item.Cantidad);
            }
        }

        private void cardDeleteItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (lstDetalleMateria.Items.Count > 0 && lstDetalleMateria.SelectedItem != null)
                {
                    detalles.RemoveAt(lstDetalleMateria.SelectedIndex);
                    RefreshDetails();
                    btnEditarDetalleVenta.IsEnabled = false;
                    btnEditarDetalleVenta.Opacity = 0.6;
                    btnAgregarDetalleVenta.IsEnabled = true;
                    btnAgregarDetalleVenta.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("Es necesario seleccionar una materia o no existen materias primas agregadas!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditarDetalleVenta_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mp.Cantidad = short.Parse(txtCantidadMateria.Text);
            mp.IdMateria = short.Parse(cbxMateriaPrima.SelectedValue.ToString());
            RefreshDetails();
            btnAgregarDetalleVenta.IsEnabled = true;
            btnAgregarDetalleVenta.Opacity = 1;
            btnEditarDetalleVenta.IsEnabled = false;
            btnEditarDetalleVenta.Opacity = 0.6;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            detalles = new List<MateriaProduccion>();

            FillTipoProducto();
            FillMaterias();
            btnEditarDetalleVenta.IsEnabled = false;
            btnEditarDetalleVenta.Opacity = 0.6;
        }

        private void cardCancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void cardGuardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtCantidadProducto.Text = txtCantidadProducto.Text.Trim();
            if (txtCantidadProducto.Text != "")
            {
                if (lstDetalleMateria.Items.Count > 0)
                {
                    try
                    {
                        if (Validations.OnlyNumbers(txtCantidadProducto.Text))
                        {
                            if(dtpFechaVencimiento.SelectedDate != null)
                            {
                                produccion = new Produccion(short.Parse(cbxProducto.SelectedValue.ToString()), short.Parse(txtCantidadProducto.Text), dtpFechaVencimiento.SelectedDate.Value, detalles);
                                brl = new ProduccionBRL(produccion);
                                brl.Insert();
                                MessageBox.Show("La producción se ha registrado correctamente..", "INSERTO UNA PRODUCCIÓN", MessageBoxButton.OK);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Debe seleccionar una fecha de vencimiento.", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de productos ingresado no es valido.", "Error al insertar");
                            txtCantidadProducto.Text = "";
                            txtCantidadProducto.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad de matriales no puede quedar vacía..!!", "Error al insertar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("La cantidad de productos no puede quedar vacía..!!", "Error al insertar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbxTipoProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillProducto();
        }

        private void lstDetalleMateria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstDetalleMateria.SelectedItem != null)
            {
                btnAgregarDetalleVenta.IsEnabled = false;
                btnAgregarDetalleVenta.Opacity = 0.6;
                btnEditarDetalleVenta.IsEnabled = true;
                btnEditarDetalleVenta.Opacity = 1;
                indice = lstDetalleMateria.SelectedIndex;
                mp = detalles.ElementAt(indice);
                txtCantidadMateria.Text = mp.Cantidad.ToString();
                cbxMateriaPrima.SelectedValue = mp.IdMateria;
            }
        }
    }
}
