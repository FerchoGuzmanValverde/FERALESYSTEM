#pragma checksum "..\..\..\..\Controles\Registros\ControlProveedores.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A3B19C0948E6DCF49D5E70C4CBDF48B88DBFBE5A2D01EF7AD57DD9B512C8C5D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Ferale.Controles.Registros;
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


namespace Ferale.Controles.Registros {
    
    
    /// <summary>
    /// ControlProveedores
    /// </summary>
    public partial class ControlProveedores : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDatos;
        
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
            System.Uri resourceLocater = new System.Uri("/Ferale;component/controles/registros/controlproveedores.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
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
            
            #line 7 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            ((Ferale.Controles.Registros.ControlProveedores)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgDatos = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            this.dgDatos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgDatos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 30 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Search_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Insert_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 43 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Edit_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 46 "..\..\..\..\Controles\Registros\ControlProveedores.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Delete_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

