﻿#pragma checksum "..\..\..\Pages\productManager.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4108D1D8517CAFEA97687E2FAC105EA416A1A88B0252B956F7B038F5C92578BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SemesterProject_WPF_DB;
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


namespace SemesterProject_WPF_DB {
    
    
    /// <summary>
    /// productManager
    /// </summary>
    public partial class productManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid productDataGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product_ManufacturerTextBox2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product_NameTextBox2;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product_CategoryTextBox2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product_PriceTextBox2;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product_CostTextBox2;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_productUpdate;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_productReload;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_productDelete;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\productManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_productCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/SemesterProject_WPF_DB;component/pages/productmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\productManager.xaml"
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
            
            #line 12 "..\..\..\Pages\productManager.xaml"
            ((SemesterProject_WPF_DB.productManager)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.productDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\..\Pages\productManager.xaml"
            this.productDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.productGrid_Selection);
            
            #line default
            #line hidden
            return;
            case 3:
            this.product_ManufacturerTextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.product_NameTextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.product_CategoryTextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.product_PriceTextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.product_CostTextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.button_productUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Pages\productManager.xaml"
            this.button_productUpdate.Click += new System.Windows.RoutedEventHandler(this.button_productUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button_productReload = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Pages\productManager.xaml"
            this.button_productReload.Click += new System.Windows.RoutedEventHandler(this.button_productReload_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.button_productDelete = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Pages\productManager.xaml"
            this.button_productDelete.Click += new System.Windows.RoutedEventHandler(this.button_productDelete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button_productCancel = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\productManager.xaml"
            this.button_productCancel.Click += new System.Windows.RoutedEventHandler(this.button_closeWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
