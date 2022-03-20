using BRL;
using Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ferale.Controles.Registros.VentanasProductos
{
    /// <summary>
    /// Lógica de interacción para InsertarProducto.xaml
    /// </summary>
    public partial class InsertarProducto : Window
    {
        Producto producto;
        ProductoBRL brl;

        TipoProductoBRL tipoBrl;
        System.Drawing.Image imagen;
        public InsertarProducto()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtDescripionProducto.Text = txtDescripionProducto.Text.Trim();
            txtPrecioBase.Text = txtPrecioBase.Text.Trim();
            txtIndicaciones.Text = txtIndicaciones.Text.Trim();
            txtVariedad.Text = txtVariedad.Text.Trim();
            txtStock.Text = txtStock.Text.Trim();
            byte[] foto = null;

            if (txtDescripionProducto.Text != "" && txtIndicaciones.Text != "" && txtVariedad.Text != "" && txtPrecioBase.Text != "" && txtStock.Text != "" && imgProducto != null)
            {
                try
                {
                    if (Validations.OnlyLettersAndSpaces(txtDescripionProducto.Text))
                    {
                        if (Validations.OnlyLettersAndSpaces(txtIndicaciones.Text))
                        {
                            if (Validations.OnlyLettersAndSpaces(txtVariedad.Text))
                            {
                                if (Validations.Precios(txtPrecioBase.Text))
                                {
                                    if (Validations.OnlyNumbers(txtStock.Text))
                                    {
                                        if (imgProducto != null)
                                        {
                                            MemoryStream mStream = new MemoryStream();
                                            imagen.Save(mStream, imagen.RawFormat);
                                            foto = mStream.ToArray();
                                        }

                                        producto = new Producto(txtDescripionProducto.Text, double.Parse(txtPrecioBase.Text), foto, txtIndicaciones.Text, short.Parse(txtStock.Text), txtVariedad.Text, byte.Parse(cbxTipoProducto.SelectedValue.ToString()));
                                        brl = new ProductoBRL(producto);
                                        brl.Insert();
                                        MessageBox.Show("El producto se ha registrado correctamente..", "INSERTO UN PRODUCTO", MessageBoxButton.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El stock del producto no es válido...!! ", "Error al insertar");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El precio base del producto no es válido...!! ", "Error al insertar");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La variedad del producto no es válida...!! ", "Error al insertar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La indicación del producto no es válida...!! ", "Error al insertar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La descripción del producto no es válida...!! ", "Error al insertar");
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
            FillTipoProducto();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialogImage = new OpenFileDialog();
            openFileDialogImage.ShowDialog();
            //openFileDialogImage.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files(*.png)|*.png|JPG";
            openFileDialogImage.DefaultExt = ".jpeg";

            ImageSource imageSource = new BitmapImage(new Uri(openFileDialogImage.FileName));
            imagen = System.Drawing.Image.FromFile(openFileDialogImage.FileName);
            imgProducto.Source = imageSource;
        }
    }
}
