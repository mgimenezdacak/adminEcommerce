﻿#pragma checksum "..\..\w_TipoProducto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "320CCB75619CF6F68BD6B65CFC1BBD9D03360BC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using EcommerceUaa;
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


namespace EcommerceUaa {
    
    
    /// <summary>
    /// w_TipoProducto
    /// </summary>
    public partial class w_TipoProducto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvTipoProducto;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificar;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescripcion;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\w_TipoProducto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
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
            System.Uri resourceLocater = new System.Uri("/EcommerceUaa;component/w_tipoproducto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\w_TipoProducto.xaml"
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
            
            #line 8 "..\..\w_TipoProducto.xaml"
            ((EcommerceUaa.w_TipoProducto)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindoLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgvTipoProducto = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\w_TipoProducto.xaml"
            this.dgvTipoProducto.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ChangeDgvChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAgregar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\w_TipoProducto.xaml"
            this.btnAgregar.Click += new System.Windows.RoutedEventHandler(this.BtnAgregar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnModificar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\w_TipoProducto.xaml"
            this.btnModificar.Click += new System.Windows.RoutedEventHandler(this.BtnModificar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\w_TipoProducto.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.BtnEliminar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtDescripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\w_TipoProducto.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.BtnCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\w_TipoProducto.xaml"
            this.btnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

