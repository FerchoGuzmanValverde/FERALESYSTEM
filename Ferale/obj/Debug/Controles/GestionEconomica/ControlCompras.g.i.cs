﻿#pragma checksum "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1487D145D9A9C2CCB8434503639EE23D00B62FEBEBEF862CBFF2619973061E53"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Ferale.Controles.GestionEconomica;
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


namespace Ferale.Controles.GestionEconomica {
    
    
    /// <summary>
    /// ControlCompras
    /// </summary>
    public partial class ControlCompras : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDatos;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescripcion;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Ferale;component/controles/gestioneconomica/controlcompras.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
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
            
            #line 7 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((Ferale.Controles.GestionEconomica.ControlCompras)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgDatos = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            this.dgDatos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgDatos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtDescripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 29 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Search_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.comboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 42 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Reports_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 60 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Insert_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 63 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Edit_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 66 "..\..\..\..\Controles\GestionEconomica\ControlCompras.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Delete_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

