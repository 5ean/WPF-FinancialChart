﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "002BA11C4256FD6B161D79B1D165D5B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinancialHistoricLineChart;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
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


namespace FinancialHistoricLineChart {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PART_HeaderView;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PriceCheckBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Ave20CheckBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Ave60CheckBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Ave120CheckBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox dateWindow;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart GoogleFinanceChart;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Price;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Trend20;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Trend60;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LineSeries Trend120;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.DateTimeAxis xAxis;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.LinearAxis yAxis;
        
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
            System.Uri resourceLocater = new System.Uri("/FinancialHistoricLineChart;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.PART_HeaderView = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.PriceCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 51 "..\..\MainWindow.xaml"
            this.PriceCheckBox.Checked += new System.Windows.RoutedEventHandler(this.PriceCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 51 "..\..\MainWindow.xaml"
            this.PriceCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.PriceCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Ave20CheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 52 "..\..\MainWindow.xaml"
            this.Ave20CheckBox.Checked += new System.Windows.RoutedEventHandler(this.Ave20CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 52 "..\..\MainWindow.xaml"
            this.Ave20CheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.Ave20CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Ave60CheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\MainWindow.xaml"
            this.Ave60CheckBox.Checked += new System.Windows.RoutedEventHandler(this.Ave60CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 53 "..\..\MainWindow.xaml"
            this.Ave60CheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.Ave60CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Ave120CheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 54 "..\..\MainWindow.xaml"
            this.Ave120CheckBox.Checked += new System.Windows.RoutedEventHandler(this.Ave120CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 54 "..\..\MainWindow.xaml"
            this.Ave120CheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.Ave120CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dateWindow = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\MainWindow.xaml"
            this.dateWindow.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dateWindow_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GoogleFinanceChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            
            #line 64 "..\..\MainWindow.xaml"
            this.GoogleFinanceChart.MouseMove += new System.Windows.Input.MouseEventHandler(this.GoogleFinanceChart_MouseMove);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Price = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 9:
            this.Trend20 = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 10:
            this.Trend60 = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 11:
            this.Trend120 = ((System.Windows.Controls.DataVisualization.Charting.LineSeries)(target));
            return;
            case 12:
            this.xAxis = ((System.Windows.Controls.DataVisualization.Charting.DateTimeAxis)(target));
            return;
            case 13:
            this.yAxis = ((System.Windows.Controls.DataVisualization.Charting.LinearAxis)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
