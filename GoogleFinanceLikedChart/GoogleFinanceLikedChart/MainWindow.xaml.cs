using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialHistoricLineChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StockInfo point = null;
        private Point prePosition;
        private Canvas _plotArea = null;
        private List<StockInfo> list;
        Line virticalLine;
        Line horizontalLine;
        TextBlock xLabel;
        TextBlock yLabel;

        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            InitializeComponent();
            list = DataAccess.GetStockInfoList();
            this.DataContext = list;
            PriceCheckBox.IsChecked = true;

            virticalLine = new Line();
            horizontalLine = new Line();
            virticalLine.Stroke = new SolidColorBrush(Colors.Black);
            virticalLine.StrokeThickness = 1.0;
            horizontalLine.Stroke = new SolidColorBrush(Colors.Black);
            horizontalLine.StrokeThickness = 1.0;
            DoubleCollection dashCollection = new DoubleCollection();
            dashCollection.Add(2);
            dashCollection.Add(4);
            virticalLine.StrokeDashArray = dashCollection;
            horizontalLine.StrokeDashArray = dashCollection;

            xLabel = new TextBlock() { Foreground = new SolidColorBrush(Colors.Blue) };
            yLabel = new TextBlock() { Foreground = new SolidColorBrush(Colors.Blue) };
            Trend20.Visibility = Visibility.Hidden;
            Trend60.Visibility = Visibility.Hidden;
            Trend120.Visibility = Visibility.Hidden;
        }
        private void PriceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Visible;
        }

        private void PriceCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Price.Visibility = Visibility.Hidden;
        }

        private void Ave20CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Trend20.Visibility = Visibility.Visible;
        }

        private void Ave20CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Trend20.Visibility = Visibility.Hidden;
        }

        private void Ave60CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Trend60.Visibility = Visibility.Visible;
        }

        private void Ave60CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Trend60.Visibility = Visibility.Hidden;
        }

        private void Ave120CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Trend120.Visibility = Visibility.Visible;
        }

        private void Ave120CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Trend120.Visibility = Visibility.Hidden;
        }

        private void dateWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            DateTime date;
            switch (combo.SelectedIndex)
            {
                case 0:
                    this.DataContext = list;
                    break;
                case 1:
                    date = list.Max(p => p.Date).Date.AddYears(-2);
                    this.DataContext = list.FindAll(p => p.Date >= date);
                    break;
                case 2:
                    date = list.Max(p=> p.Date).Date.AddYears(-1);
                    this.DataContext = list.FindAll(p => p.Date >= date);
                    break;
                case 3:
                    date = list.Max(p=> p.Date).Date.AddMonths(-6);
                    this.DataContext = list.FindAll(p => p.Date >= date);
                    break;
                case 4:
                    date = list.Max(p=> p.Date).Date.AddMonths(-3);
                    this.DataContext = list.FindAll(p => p.Date >= date);
                    break;
                case 5:
                    date = list.Max(p=> p.Date).Date.AddMonths(-1);
                    this.DataContext = list.FindAll(p => p.Date >= date);
                    break;
            }
        }

        private void GoogleFinanceChart_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(_plotArea);
            if (prePosition != null && Math.Abs(position.X - prePosition.X) > 2 && Math.Abs(position.Y - prePosition.Y) > 2)
            {
                ClearCrossHair();
                DrawCrossHair((Chart)sender, position);
            }
        }

        private void ClearCrossHair()
        {
            if(_plotArea != null)
            {
                if (_plotArea.Children.Contains(virticalLine)) _plotArea.Children.Remove(virticalLine);
                if (_plotArea.Children.Contains(horizontalLine)) _plotArea.Children.Remove(horizontalLine);
                if(xLabel != null)
                {
                    xLabel.Text = string.Empty;
                    if (_plotArea.Children.Contains(xLabel)) _plotArea.Children.Remove(xLabel);
                }
                if (yLabel != null)
                {
                    yLabel.Text = string.Empty;
                    if (_plotArea.Children.Contains(yLabel)) _plotArea.Children.Remove(yLabel);
                }
                point.PointVisibility = System.Windows.Visibility.Hidden;
            }
        }

        private void DrawCrossHair(Chart chart, Point mousePositionInPixels)
        {
            var xAxisRange = (IRangeAxis)xAxis;
            var yAxisRange = (IRangeAxis)yAxis;
            _plotArea = (Canvas)FindDescendantWithName(chart, "PlotArea");
            if (_plotArea == null)
            {
                return;
            }
            var mouseXPositionInChartUnits = ((DateTime)xAxisRange.GetValueAtPosition(new System.Windows.Controls.DataVisualization.UnitValue(mousePositionInPixels.X, System.Windows.Controls.DataVisualization.Unit.Pixels)));
            var mouseYPositionInChartUnits = ((double)yAxisRange.GetValueAtPosition(new System.Windows.Controls.DataVisualization.UnitValue(_plotArea.ActualHeight - mousePositionInPixels.Y, System.Windows.Controls.DataVisualization.Unit.Pixels)));
            if (mouseXPositionInChartUnits > list.Max(p => p.Date)) mouseXPositionInChartUnits = list.Max(p => p.Date);
            else if (mouseXPositionInChartUnits < list.Min(p => p.Date)) mouseXPositionInChartUnits = list.Min(p => p.Date);
            else
            {
                int H = list.Count; int L = 0;
                while(H >= L)
                {
                    if (mouseXPositionInChartUnits == list[(H + L) / 2].Date) { mouseXPositionInChartUnits = list[(H + L) / 2].Date;break;}
                    if (mouseXPositionInChartUnits < list[(H + L) / 2].Date) { L = (H + L) / 2 + 1; }
                    else { H = (H + L) / 2 - 1; }
                }
                if(H < L )
                {
                    if (mouseXPositionInChartUnits - list[H].Date <= list[L].Date - mouseXPositionInChartUnits)
                        mouseXPositionInChartUnits = list[L].Date;
                    else mouseXPositionInChartUnits = list[H].Date;
                }
            }
            point = (StockInfo)list.Find(p => p.Date.Equals(mouseXPositionInChartUnits));
            point.PointVisibility = Visibility.Visible;
            setVirticalLine(mousePositionInPixels.X, mouseXPositionInChartUnits);
            setHorizontalLine(mousePositionInPixels.Y, mouseYPositionInChartUnits);
        }

                private FrameworkElement FindDescendantWithName(DependencyObject root, string name)
        {
            var numChildren = VisualTreeHelper.GetChildrenCount(root);
            for (var i = 0; i < numChildren; i++)
            {
                var child = (FrameworkElement)VisualTreeHelper.GetChild(root, i);
                if (child.Name == name)
                {
                    return child;
                }

                var descendantOfChild = FindDescendantWithName(child, name);
                if (descendantOfChild != null)
                {
                    return descendantOfChild;
                }
            }
            return null;
        }

        private void setVirticalLine(double xPosition, DateTime value)
        {
            virticalLine.X1 = xPosition;
            virticalLine.X2 = xPosition;
            virticalLine.Y1 = -10.0;
            virticalLine.Y2 = _plotArea.ActualHeight;
            xLabel.Text = value.Date.ToString("ddMMMyyyy");
            xLabel.Foreground = new SolidColorBrush(Colors.Blue);
            xLabel.SetValue(Canvas.LeftProperty, xPosition + 5.0);
            xLabel.SetValue(Canvas.TopProperty, _plotArea.ActualHeight - 20);
            _plotArea.Children.Add(virticalLine);
            _plotArea.Children.Add(xLabel);
        }

        private void setHorizontalLine(double yPosition, double value)
        {
            horizontalLine.X1 = -10;
            horizontalLine.X2 = _plotArea.ActualWidth;
            horizontalLine.Y1 = yPosition;
            horizontalLine.Y2 = yPosition;
            yLabel.Text = value.ToString("C");
            yLabel.Foreground = new SolidColorBrush(Colors.Blue);
            yLabel.SetValue(Canvas.TopProperty, yPosition);
            yLabel.SetValue(Canvas.LeftProperty, 5.0);
            _plotArea.Children.Add(horizontalLine);
            _plotArea.Children.Add(yLabel);
        }
    }
}
