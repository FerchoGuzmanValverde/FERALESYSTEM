﻿#pragma checksum "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6709467BC7C7FCDA7DB15BC7FBBC6461323D3DB324C297FA0092A1BC3FA3F600"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Ferale.Controles.Registros.VentanasEmpleado;
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


namespace Ferale.Controles.Registros.VentanasEmpleado {
    
    
    /// <summary>
    /// EditAreaEmpleado
    /// </summary>
    public partial class EditAreaEmpleado : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardInsertar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardEditar;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAreaEmpresa;
        
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
            System.Uri resourceLocater = new System.Uri("/Ferale;component/controles/registros/ventanasempleado/editareaempleado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
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
            
            #line 11 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
            ((Ferale.Controles.Registros.VentanasEmpleado.EditAreaEmpleado)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cardInsertar = ((MaterialDesignThemes.Wpf.Card)(target));
            
            #line 23 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
            this.cardInsertar.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Insert_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cardEditar = ((MaterialDesignThemes.Wpf.Card)(target));
            
            #line 26 "..\..\..\..\..\Controles\Registros\VentanasEmpleado\EditAreaEmpleado.xaml"
            this.cardEditar.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Cancelar_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtAreaEmpresa = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

