#pragma checksum "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3DA99456DD45567C10386F61035DEC4CE77AE49C951AD62D3C6145934EC33B78"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Ferale.Controles.GestionEconomica.SubControlesCompras;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Ferale.Controles.GestionEconomica.SubControlesCompras {
    
    
    /// <summary>
    /// EditarCompra
    /// </summary>
    public partial class EditarCompra : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroFactura;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNroAutorizacion;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCodigoControl;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxProveedor;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardGuardar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardCancelar;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCantidad;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrecioUnitario;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxMaterial;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardDeleteItem;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstDetalleProductos;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalCompra;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ferale;component/controles/gestioneconomica/subcontrolescompras/editarcompra.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            ((Ferale.Controles.GestionEconomica.SubControlesCompras.EditarCompra)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtNroFactura = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtNroAutorizacion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCodigoControl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbxProveedor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            this.cbxProveedor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbxProveedor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cardGuardar = ((MaterialDesignThemes.Wpf.Card)(target));
            
            #line 33 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            this.cardGuardar.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Guardar_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cardCancelar = ((MaterialDesignThemes.Wpf.Card)(target));
            
            #line 36 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            this.cardCancelar.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Cancelar_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtCantidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txtPrecioUnitario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.cbxMaterial = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            
            #line 44 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Card_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 13:
            this.cardDeleteItem = ((MaterialDesignThemes.Wpf.Card)(target));
            
            #line 49 "..\..\..\..\..\Controles\GestionEconomica\SubControlesCompras\EditarCompra.xaml"
            this.cardDeleteItem.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.CardDeleteItem_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lstDetalleProductos = ((System.Windows.Controls.ListBox)(target));
            return;
            case 15:
            this.lblTotalCompra = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

