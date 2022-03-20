using BRL;
using Common;
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
using System.Drawing;
using Microsoft.Win32;

namespace Ferale.Controles.Registros.VentanasProductos
{
    /// <summary>
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProducto : Window
    {
        Producto producto;
        ProductoBRL brl;

        TipoProductoBRL tipoBrl;
        System.Drawing.Image imagen;
        public EditarProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
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
                                            producto.Foto = mStream.ToArray();
                                        }

                                        producto.DescripcionProducto = txtDescripionProducto.Text;
                                        producto.Indicaciones = txtIndicaciones.Text;
                                        producto.Variedad = txtVariedad.Text;
                                        producto.Stock = short.Parse(txtStock.Text);
                                        producto.PrecioBase = double.Parse(txtPrecioBase.Text);

                                        brl = new ProductoBRL(producto);
                                        brl.Update();
                                        MessageBox.Show("El producto se ha modificado correctamente..", "MODIFICO UN PRODUCTO", MessageBoxButton.OK);
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

            txtDescripionProducto.Text = producto.DescripcionProducto;
            txtIndicaciones.Text = producto.Indicaciones;
            txtPrecioBase.Text = producto.PrecioBase.ToString();
            txtStock.Text = producto.Stock.ToString();
            txtVariedad.Text = producto.Variedad;
            cbxTipoProducto.Text = tipoBrl.Get(producto.IdTipoProducto).NombreTipo;

            imgProducto.Source = ByteToImage(producto.Foto);
        }

        public void FillTipoProducto()
        {
            try
            {
                tipoBrl = new TipoProductoBRL();
                cbxTipoProducto.DisplayMemberPath = "nombreTipo";
                cbxTipoProducto.SelectedValuePath = "idTipoProducto";
                cbxTipoProducto.ItemsSource = tipoBrl.SelectIdName().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private void SeleccionarImagen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
