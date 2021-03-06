using BRL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Ferale.Controles.GestionEconomica.SubControlesVentas
{
    /// <summary>
    /// Lógica de interacción para InsertarVenta.xaml
    /// </summary>
    public partial class InsertarVenta : Window
    {
        Venta venta;
        List<VentaDetalle> detalles;
        double total = 0;
        double descuento = 0;
        int indice;
        VentaDetalle vd;
        byte ban = 0;

        VentaBRL brl;
        TipoProductoBRL tipoBrl;
        ProductoBRL productoBrl;
        ClienteBRL clienteBrl;
        EmpleadoBRL empleadoBRL;

        public InsertarVenta()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            txtAdelanto.Text = txtAdelanto.Text.Trim();
            txtCliente.Text = txtCliente.Text.Trim();
            txtDescuento.Text = txtDescuento.Text.Trim();

            if (txtAdelanto.Text != "")
            {
                if(txtCliente.Text != "")
                {
                    if(txtDescuento.Text != "")
                    {
                        if(lstDetalleProductos.Items.Count > 0)
                        {
                            try
                            {
                                if (Validations.OnlyNumbers(txtDescuento.Text))
                                {
                                    if (Validations.Precios(txtAdelanto.Text))
                                    {
                                        clienteBrl = new ClienteBRL();
                                        empleadoBRL = new EmpleadoBRL();
                                        byte estadoEntrega;
                                        if (cbxEstadoEntrega.SelectionBoxItem.ToString() == "Entregado") { estadoEntrega = 0; }
                                        else if (cbxEstadoEntrega.SelectionBoxItem.ToString() == "Pendiente") { estadoEntrega = 1; }
                                        else { estadoEntrega = 2; }
                                        int idCliente = 0;
                                        if (txtCliente.Text != null && txtCliente.Text != "" && txtCliente.Text != "0")
                                        {
                                            int banderita = clienteBrl.GetByNit(txtCliente.Text).IdCliente;
                                            if (banderita != null)
                                            {
                                                idCliente = banderita;
                                            }
                                        }
                                        venta = new Venta(total, byte.Parse(txtDescuento.Text), estadoEntrega, double.Parse(txtAdelanto.Text), idCliente, empleadoBRL.GetByUser(Sesion.idUsuario).IdEmpleado, detalles);
                                        brl = new VentaBRL(venta);
                                        brl.Insert();
                                        MessageBox.Show("La venta se ha registrado correctamente..", "INSERTO UNA VENTA", MessageBoxButton.OK);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El adelanto ingresado no es valido.", "Error al insertar");
                                        txtAdelanto.Text = "";
                                        txtAdelanto.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El descuento ingresado no es valido ", "Error al insertar");
                                    txtDescuento.Text = "";
                                    txtDescuento.Focus();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe tener productos agregados para registrar la venta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El descuento no puede quedar vacío. Inserte 0 en caso de no haber descuento.");
                        txtDescuento.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El nit no puede quedar vacío. Inserte 0 en caso de no haber nit.");
                    txtCliente.Focus();
                }
            }
            else
            {
                MessageBox.Show("El adelanto no puede quedar vacío. Inserte 0 en caso de no haber adelanto.");
                txtAdelanto.Focus();
            }
        }

        private void Cancelar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillTipoProducto();
            btnEditarDetalleVenta.IsEnabled = false;
            btnEditarDetalleVenta.Opacity = 0.6;
            detalles = new List<VentaDetalle>();
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

        private void RefreshDetails()
        {
            lstDetalleProductos.Items.Clear();
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            total = 0;

            foreach (VentaDetalle item in detalles)
            {
                lstDetalleProductos.Items.Add(productoBrl.Get(item.IdProducto).DescripcionProducto + "\t||\tCantidad: " + item.Cantidad + "\t||\tTotal: " + (item.Cantidad * item.PrecioUnitario));
                total += (item.PrecioUnitario * item.Cantidad);
            }

            lblTotalCompra.Content = "Total: " + total;
        }

        private void Card_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Agregar Producto Boton
            VentaDetalle nuevo = new VentaDetalle();
            ban = 0;
            if(txtCantidad.Text!="" && short.Parse(txtCantidad.Text)>0)
            {
                if(txtPrecioUnitario.Text!=""&& double.Parse(txtPrecioUnitario.Text)>0)
                {
                    if (cbxTipoProducto.SelectedItem != null)
                    {
                        if (cbxProducto.SelectedItem != null)
                        {
                            nuevo.IdProducto = byte.Parse(cbxProducto.SelectedValue.ToString());
                            nuevo.Cantidad = short.Parse(txtCantidad.Text);
                            nuevo.PrecioUnitario = double.Parse(txtPrecioUnitario.Text);
                            foreach (VentaDetalle item in detalles)
                            {
                                if (item.IdProducto == nuevo.IdProducto)
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
                            MessageBox.Show("No se seleccionó un producto.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó un tipo producto.");
                    }
                }
                else
                {
                    MessageBox.Show("El precio unitario no puede quedar vacío ni ser menor a 1.");
                }
            }
            else
            {
                MessageBox.Show("La cantidad no puede quedar vacía ni ser menor a 1.");
            }

            RefreshDetails();
            CalcularDescuento();
        }

        private void CbxTipoProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillProducto();
        }

        private void CardDeleteItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (lstDetalleProductos.Items.Count > 0 && lstDetalleProductos.SelectedItem != null)
                {
                    detalles.RemoveAt(lstDetalleProductos.SelectedIndex);
                    RefreshDetails();
                    CalcularDescuento();
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

        private void txtDescuento_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularDescuento();
        }

        public void CalcularDescuento()
        {
            RefreshDetails();

            if (lstDetalleProductos.Items.Count > 0)
            {
                if (txtDescuento.Text != "" && txtAdelanto.Text != "")
                {
                    if (byte.Parse(txtDescuento.Text) > 100)
                    {
                        MessageBox.Show("El descuento no puede ser mayor al 100%..!!");
                        txtDescuento.Text = "";
                    }
                    else
                    {
                        if (byte.Parse(txtAdelanto.Text) > total)
                        {
                            MessageBox.Show("El adelanto no puede ser mayor al Total de la venta..!!");
                            txtAdelanto.Text = "";
                        }
                        else
                        {
                            if (byte.Parse(txtDescuento.Text) > 0)
                            {
                                descuento = (total * byte.Parse(txtDescuento.Text)) / 100;
                                total = total - descuento;
                            }
                            if (double.Parse(txtAdelanto.Text) > 0)
                            {
                                total = total - double.Parse(txtAdelanto.Text);
                            }
                            lblTotalCompra.Content = "Total: " + total;
                        }
                    }
                }
            }
        }

        private void txtAdelanto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularDescuento();
        }

        private void lstDetalleProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstDetalleProductos.SelectedItem!= null)
            {
                btnAgregarDetalleVenta.IsEnabled = false;
                btnAgregarDetalleVenta.Opacity = 0.6;
                btnEditarDetalleVenta.IsEnabled = true;
                btnEditarDetalleVenta.Opacity = 1;
                indice = lstDetalleProductos.SelectedIndex;
                vd = detalles.ElementAt(indice);
                txtCantidad.Text = vd.Cantidad.ToString();
                txtPrecioUnitario.Text = vd.PrecioUnitario.ToString();
            }
        }

        private void btnEditarDetalleVenta_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            vd.Cantidad = short.Parse(txtCantidad.Text);
            vd.PrecioUnitario = double.Parse(txtPrecioUnitario.Text);
            RefreshDetails();
            CalcularDescuento();
            btnAgregarDetalleVenta.IsEnabled = true;
            btnAgregarDetalleVenta.Opacity = 1;
            btnEditarDetalleVenta.IsEnabled = false;
            btnEditarDetalleVenta.Opacity = 0.6;
        }
    }
}
