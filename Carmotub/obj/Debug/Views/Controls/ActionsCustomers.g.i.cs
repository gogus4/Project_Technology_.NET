﻿#pragma checksum "..\..\..\..\Views\Controls\ActionsCustomers.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3771C952CBE5F595E958382EFB01BC47"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Carmotub.Views.Controls {
    
    
    /// <summary>
    /// ActionsCustomers
    /// </summary>
    public partial class ActionsCustomers : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run NumberCustomers;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchBy;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SearchBorder;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBoxText;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBackupDatabase;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridCustomers;
        
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
            System.Uri resourceLocater = new System.Uri("/Carmotub;component/views/controls/actionscustomers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
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
            
            #line 6 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
            ((Carmotub.Views.Controls.ActionsCustomers)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.UserControl_Unloaded);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
            ((Carmotub.Views.Controls.ActionsCustomers)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NumberCustomers = ((System.Windows.Documents.Run)(target));
            return;
            case 3:
            this.SearchBy = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.SearchBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.SearchBoxText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProgressBackupDatabase = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.DataGridCustomers = ((System.Windows.Controls.DataGrid)(target));
            
            #line 42 "..\..\..\..\Views\Controls\ActionsCustomers.xaml"
            this.DataGridCustomers.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGridCustomers_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

