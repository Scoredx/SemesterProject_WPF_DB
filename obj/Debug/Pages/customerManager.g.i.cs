﻿#pragma checksum "..\..\..\Pages\customerManager.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4CDF40FCE68A01216C9FE19510570257284D08604F6870A144E843F138CC6FA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
    /// customerManager
    /// </summary>
    public partial class customerManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid customerDataGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_deleteCustomer;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_surnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_address_idTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_phoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox customer_nipTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_updateCustomer;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\customerManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_createNewCustomer;
        
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
            System.Uri resourceLocater = new System.Uri("/SemesterProject_WPF_DB;component/pages/customermanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\customerManager.xaml"
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
            
            #line 8 "..\..\..\Pages\customerManager.xaml"
            ((SemesterProject_WPF_DB.customerManager)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.customerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\..\Pages\customerManager.xaml"
            this.customerDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.customerGrid_Selection);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button_deleteCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\customerManager.xaml"
            this.button_deleteCustomer.Click += new System.Windows.RoutedEventHandler(this.button_deleteCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.customer_nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.customer_surnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.customer_address_idTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.customer_phoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.customer_emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.customer_nipTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 31 "..\..\..\Pages\customerManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button_ReloadList);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button_updateCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\customerManager.xaml"
            this.button_updateCustomer.Click += new System.Windows.RoutedEventHandler(this.button_updateCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.button_createNewCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Pages\customerManager.xaml"
            this.button_createNewCustomer.Click += new System.Windows.RoutedEventHandler(this.button_createNewCustomer_click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 55 "..\..\..\Pages\customerManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.button_Exit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

