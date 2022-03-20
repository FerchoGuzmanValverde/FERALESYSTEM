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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ferale.Controles.Reportes
{
    /// <summary>
    /// Lógica de interacción para ControlReporteLimpiezas.xaml
    /// </summary>
    public partial class ControlReporteLimpiezas : UserControl
    {
        TipoLimpiezaBRL brlTipoLimpieza;
        EstablecimientoBRL brlEstablecimiento;

        public ControlReporteLimpiezas()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillTipoLimpieza();
            FillEstablecimiento();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (rbtFiltro1.IsChecked == true)
            {
                if (dpFechaInicio.SelectedDate != null && dpFechaFin.SelectedDate != null)
                {
                    LimpiezaListaReporte reporte = new LimpiezaListaReporte();
                    DBFeraleDataSet dataset = LimpiezaListBRL.ObtenerListaEmpleadoReporte1(dpFechaInicio.SelectedDate.Value, dpFechaFin.SelectedDate.Value);
                    reporte.Load("LimpiezaListaReporte.rpt");
                    reporte.SetDataSource(dataset);
                    rvLimmpiezas.ViewerCore.ReportSource = reporte;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar las fechas de inicio y fin para filtrar..!!", "Error en las fechas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if(rbtFiltro2.IsChecked == true)
            {
                LimpiezaListaReporte reporte = new LimpiezaListaReporte();
                DBFeraleDataSet dataset = LimpiezaListBRL.ObtenerListaEmpleadoReporte2(byte.Parse(cbxEstablecimiento.SelectedValue.ToString()));
                reporte.Load("LimpiezaListaReporte.rpt");
                reporte.SetDataSource(dataset);
                rvLimmpiezas.ViewerCore.ReportSource = reporte;
            }
            else if(rbtFiltro3.IsChecked == true)
            {
                LimpiezaListaReporte reporte = new LimpiezaListaReporte();
                DBFeraleDataSet dataset = LimpiezaListBRL.ObtenerListaEmpleadoReporte3(byte.Parse(cbxTipoLimmpieza.SelectedValue.ToString()));
                reporte.Load("LimpiezaListaReporte.rpt");
                reporte.SetDataSource(dataset);
                rvLimmpiezas.ViewerCore.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("Ocurrio un error al seleccionar filtro..!!", "Error de Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void FillTipoLimpieza()
        {
            try
            {
                brlTipoLimpieza = new TipoLimpiezaBRL();
                cbxTipoLimmpieza.DisplayMemberPath = "tipoLimpieza";
                cbxTipoLimmpieza.SelectedValuePath = "idTipoLimpieza";
                cbxTipoLimmpieza.ItemsSource = brlTipoLimpieza.SelectIdName().DefaultView;
                cbxTipoLimmpieza.SelectedIndex = 0;
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
