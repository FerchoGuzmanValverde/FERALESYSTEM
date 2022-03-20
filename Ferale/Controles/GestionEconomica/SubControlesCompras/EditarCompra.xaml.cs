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

namespace Ferale.Controles.GestionEconomica.SubControlesCompras
{
    /// <summary>
    /// Lógica de interacción para EditarCompra.xaml
    /// </summary>
    public partial class EditarCompra : Window
    {
        Common.Compra compra;
        List<CompraDetalle> detalles;
        double total = 0;

        BRL.CompraBRL brl;
        BRL.ProveedorBRL proveedorBrl;
        BRL.MateriaPrimaBRL materiaBrl;
        EmpleadoBRL empleadoBrl;

        public EditarCompra(Common.Compra Compra)
        {
            InitializeComponent();
            compra = Compra;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtNroFactura.Text = txtNroFactura.Text.Trim();
            txtNroAutorizacion.Text = txtNroAutorizacion.Text.Trim();
            txtCodigoControl.Text = txtCodigoControl.Text.Trim();

            if (lstDetalleProductos.Items.Count > 0)
            {
                try
                {
                    if (true)
                    {
                        proveedorBrl = new BRL.ProveedorBRL();
                        materiaBrl = new BRL.MateriaPrimaBRL();
                        empleadoBrl = new EmpleadoBRL();

                        compra.NroFactura = txtNroFactura.Text;
                        compra.NroAutorizacion = txtNroAutorizacion.Text;
                        compra.CodigoControl = txtCodigoControl.Text;
                        compra.Detalles = detalles;
                        compra.MontoTotalCompra = total;
                        brl = new BRL.CompraBRL(compra);
                        brl.Update();
                        MessageBox.Show("La compra se ha modificado correctamente..", "MODIFICO UNA COMPRA", MessageBoxButton.OK);
                        this.Close();
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
            FillProveedor();
            detalles = new List<CompraDetalle>();

            txtNroFactura.Text = compra.NroFactura;
            txtNroAutorizacion.Text = compra.NroAutorizacion;
            txtCodigoControl.Text = compra.CodigoControl;
            detalles = compra.Detalles;

            RefreshDetails();
        }

        public void FillProveedor()
        {
            try
            {
                proveedorBrl = new BRL.ProveedorBRL();
                cbxProveedor.DisplayMemberPath = "razonSocial";
                cbxProveedor.SelectedValuePath = "idProveedor";
                cbxProveedor.ItemsSource = proveedorBrl.SelectByIdName().DefaultView;
                cbxProveedor.SelectedIndex = 0;
                FillMateriales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillMateriales()
        {
            try
            {
                materiaBrl = new BRL.MateriaPrimaBRL();
                cbxMaterial.DisplayMemberPath = "nombre";
                cbxMaterial.SelectedValuePath = "idMateria";
                cbxMaterial.ItemsSource = materiaBrl.SelectByIdName(short.Parse(cbxProveedor.SelectedValue.ToString())).DefaultView;
                cbxMaterial.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshDetails()
        {
            lstDetalleProductos.Items.Clear();
            total = 0;

            foreach (CompraDetalle item in detalles)
            {
                lstDetalleProductos.Items.Add(materiaBrl.Get(item.IdMateria).Nombre + "\t||\tCantidad: " + item.Cantidad + "\t||\tTotal: " + (item.Cantidad * item.PrecioUnitario));
                total += (item.PrecioUnitario * item.Cantidad);
            }

            lblTotalCompra.Content = "Total: " + total;
        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Agregar Producto Boton
            CompraDetalle nuevo = new CompraDetalle();

            nuevo.IdMateria = short.Parse(cbxMaterial.SelectedValue.ToString());
            nuevo.Cantidad = short.Parse(txtCantidad.Text);
            nuevo.PrecioUnitario = double.Parse(txtPrecioUnitario.Text);

            detalles.Add(nuevo);

            RefreshDetails();
        }

        private void CardDeleteItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (lstDetalleProductos.Items.Count > 0 && lstDetalleProductos.SelectedItem != null)
                {
                    detalles.RemoveAt(lstDetalleProductos.SelectedIndex);
                    RefreshDetails();
                }
                else
                {
                    MessageBox.Show("Es necesario seleccionar un producto o no existen productos agregados!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CbxProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillMateriales();
        }
    }
}
