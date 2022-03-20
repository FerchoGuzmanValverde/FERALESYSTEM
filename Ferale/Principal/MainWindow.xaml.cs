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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ferale.ViewModel;
using MaterialDesignThemes.Wpf;
using Common;

namespace Ferale
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanelMain.Children.Add(new Controles.Principal.Inicio());
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    break;
                case WindowState.Minimized:
                    // Do your stuff
                    break;
                case WindowState.Normal:

                    break;
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lblUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            lblUsuario.Content = Sesion.VerInfo();

            if (Sesion.rolSesion == "Administrador")
            {
                var menuPrincipal = new List<SubItem>();
                menuPrincipal.Add(new SubItem("Inicio", new Controles.Principal.Inicio()));
                menuPrincipal.Add(new SubItem("Sobre la Empresa", new Controles.Principal.SobreEmpresa()));
                menuPrincipal.Add(new SubItem("Sobre el Sistema", new Controles.Principal.SobreSistema()));
                var itemP = new ItemMenu("HOME", menuPrincipal, PackIconKind.Home);

                var menuRegister = new List<SubItem>();
                menuRegister.Add(new SubItem("Clientes", new Controles.Registros.ControlClientes()));
                menuRegister.Add(new SubItem("Proveedores", new Controles.Registros.ControlProveedores()));
                menuRegister.Add(new SubItem("Empleados", new Controles.Registros.ControlEmpleados()));
                menuRegister.Add(new SubItem("Productos", new Controles.Registros.ControlProductos()));
                menuRegister.Add(new SubItem("Materias Prima", new Controles.Registros.ControlMateriaPrima()));
                menuRegister.Add(new SubItem("Servicios", new Controles.Registros.Servicio()));
                var item6 = new ItemMenu("REGISTROS", menuRegister, PackIconKind.AccountBadgeHorizontal);

                var menuFinancial = new List<SubItem>();
                menuFinancial.Add(new SubItem("Compras", new Controles.GestionEconomica.ControlCompras()));
                menuFinancial.Add(new SubItem("Ventas", new Controles.GestionEconomica.ControlVentas()));
                menuFinancial.Add(new SubItem("Sueldos", new Controles.GestionEconomica.ControlSueldos()));
                var item1 = new ItemMenu("GESTIÓN\nECONÓMICA", menuFinancial, PackIconKind.Finance);

                var menuReports = new List<SubItem>();
                menuReports.Add(new SubItem("Clientes", new Controles.Reportes.ControlReporteClientes()));
                menuReports.Add(new SubItem("Proveedores", new Controles.Reportes.ControlReporteProveedores()));
                menuReports.Add(new SubItem("Productos", new Controles.Reportes.ControlReporteProductos()));
                menuReports.Add(new SubItem("Stock", new Controles.Reportes.ControlReporteStock()));
                menuReports.Add(new SubItem("Ventas", new Controles.Reportes.ControlReporteVentas()));
                menuReports.Add(new SubItem("Compras", new Controles.Reportes.ControlReporteCompras()));
                menuReports.Add(new SubItem("Limpiezas", new Controles.Reportes.ControlReporteLimpiezas()));
                var item2 = new ItemMenu("REPORTES", menuReports, PackIconKind.FileReport);

                var menuInventory = new List<SubItem>();
                menuInventory.Add(new SubItem("Ingresos", new Controles.Inventario.ControlIngresos()));
                menuInventory.Add(new SubItem("Salidas", new Controles.Inventario.ControlSalidas()));
                var item3 = new ItemMenu("INVENTARIO", menuInventory, PackIconKind.Truck);

                var menuCleaning = new List<SubItem>();
                menuCleaning.Add(new SubItem("Limpiezas", new Controles.Limpiezas.ControlLimpiezas()));
                menuCleaning.Add(new SubItem("Control de Plagas", new Controles.Limpiezas.ControlPlagas()));
                var item4 = new ItemMenu("LIMPIEZAS", menuCleaning, PackIconKind.Cleaning);

                Menu.Children.Add(new UserControlMenuItem(itemP, this));
                Menu.Children.Add(new UserControlMenuItem(item6, this));
                Menu.Children.Add(new UserControlMenuItem(item4, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item3, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
            }
            else if (Sesion.rolSesion == "Cajero")
            {
                var menuPrincipal = new List<SubItem>();
                menuPrincipal.Add(new SubItem("Inicio", new Controles.Principal.Inicio()));
                menuPrincipal.Add(new SubItem("Sobre la Empresa", new Controles.Principal.SobreEmpresa()));
                menuPrincipal.Add(new SubItem("Sobre el Sistema", new Controles.Principal.SobreSistema()));
                var itemP = new ItemMenu("HOME", menuPrincipal, PackIconKind.Home);

                var menuFinancial = new List<SubItem>();
                menuFinancial.Add(new SubItem("Compras", new Controles.GestionEconomica.ControlCompras()));
                menuFinancial.Add(new SubItem("Ventas", new Controles.GestionEconomica.ControlVentas()));
                menuFinancial.Add(new SubItem("Sueldos", new Controles.GestionEconomica.ControlSueldos()));
                var item1 = new ItemMenu("GESTIÓN\nECONÓMICA", menuFinancial, PackIconKind.Finance);

                Menu.Children.Add(new UserControlMenuItem(itemP, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
            }
            else
            {
                var menuPrincipal = new List<SubItem>();
                menuPrincipal.Add(new SubItem("Inicio", new Controles.Principal.Inicio()));
                menuPrincipal.Add(new SubItem("Sobre la Empresa", new Controles.Principal.SobreEmpresa()));
                menuPrincipal.Add(new SubItem("Sobre el Sistema", new Controles.Principal.SobreSistema()));
                var itemP = new ItemMenu("HOME", menuPrincipal, PackIconKind.Home);

                var menuInventory = new List<SubItem>();
                menuInventory.Add(new SubItem("Ingresos", new Controles.Inventario.ControlIngresos()));
                menuInventory.Add(new SubItem("Salidas", new Controles.Inventario.ControlSalidas()));
                var item3 = new ItemMenu("INVENTARIO", menuInventory, PackIconKind.Truck);

                var menuCleaning = new List<SubItem>();
                menuCleaning.Add(new SubItem("Limpiezas", new Controles.Limpiezas.ControlLimpiezas()));
                menuCleaning.Add(new SubItem("Control de Plagas", new Controles.Limpiezas.ControlPlagas()));
                var item4 = new ItemMenu("LIMPIEZAS", menuCleaning, PackIconKind.Cleaning);

                Menu.Children.Add(new UserControlMenuItem(itemP, this));
                Menu.Children.Add(new UserControlMenuItem(item4, this));
                Menu.Children.Add(new UserControlMenuItem(item3, this));
            }
        }
    }
}
