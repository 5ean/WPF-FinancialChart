using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace FinancialHistoricLineChart
{
    public class AdornedControl : ContentControl
    {

        private AdornerLayer dornerLayer = null;
        private FrameworkElementAdorner adorner = null;
        private AdornerLayer adornerLayer = null;

        #region Dependency Properties
        public static readonly DependencyProperty IsAdornerVisibleProperty =
            DependencyProperty.Register("IsAdornerVisible", typeof(Visibility), typeof(AdornedControl),
                new FrameworkPropertyMetadata(IsAdornerVisible_PropertyChanged));

        public static readonly DependencyProperty AdornerContentProperty =
            DependencyProperty.Register("AdornerContent", typeof(FrameworkElement), typeof(AdornedControl),
                new FrameworkPropertyMetadata(AdornerContent_PropertyChanged));

        public static readonly DependencyProperty HorizontalAdornerPlacementProperty =
            DependencyProperty.Register("HorizontalAdornerPlacement", typeof(AdornerPlacement), typeof(AdornedControl),
                new FrameworkPropertyMetadata(HorizontalAdornerPlacement_PropertyChanged));

        public static readonly DependencyProperty VerticalAdornerPlacementProperty =
            DependencyProperty.Register("VerticalAdornerPlacement", typeof(AdornerPlacement), typeof(AdornedControl),
                new FrameworkPropertyMetadata(VerticalAdornerPlacement_PropertyChanged));

        public static readonly DependencyProperty AdornerOffsetXProperty =
            DependencyProperty.Register("AdornerOffsetX", typeof(double), typeof(AdornedControl));
        public static readonly DependencyProperty AdornerOffsetYProperty =
            DependencyProperty.Register("AdornerOffsetY", typeof(double), typeof(AdornedControl));
        #endregion  Dependency Properties

        #region Properties
        /// <summary>
        /// define the UI content of the adorner
        /// </summary>
        public FrameworkElement AdornerContent
        {
            get
            {
                return (FrameworkElement)GetValue(AdornerContentProperty);
            }
            set
            {
                SetValue(AdornerContentProperty, value);
            }
        }

        /// <summary>
        /// shows or hides the adorner.
        /// </summary>
        public Visibility IsAdornerVisible
        {
            get
            {
                return (Visibility)GetValue(IsAdornerVisibleProperty);
            }
            set
            {
                SetValue(IsAdornerVisibleProperty, value);
            }
        }

        /// <summary>
        /// Specifies the horizontal placement of the adorner relative to the adorned control.
        /// </summary>
        public AdornerPlacement HorizontalAdornerPlacement
        {
            get
            {
                return (AdornerPlacement)GetValue(HorizontalAdornerPlacementProperty);
            }
            set
            {
                SetValue(HorizontalAdornerPlacementProperty, value);
            }
        }

        /// <summary>
        /// Specifies the vertical placement of the adorner relative to the adorned control.
        /// </summary>
        public AdornerPlacement VerticalAdornerPlacement
        {
            get
            {
                return (AdornerPlacement)GetValue(VerticalAdornerPlacementProperty);
            }
            set
            {
                SetValue(VerticalAdornerPlacementProperty, value);
            }
        }

        /// <summary>
        /// x offset of the adorner
        /// </summary>
        public double AdornerOffsetX
        {
            get
            {
                return (double)GetValue(AdornerOffsetXProperty);
            }
            set
            {
                SetValue(AdornerOffsetXProperty, value);
            }
        }

        /// <summary>
        /// y offset of the adorner
        /// </summary>
        public double AdornerOffsetY
        {
            get
            {
                return (double)GetValue(AdornerOffsetYProperty);
            }
            set
            {
                SetValue(AdornerOffsetYProperty, value);
            }
        }

        #endregion Properties

        #region Commands

        public static readonly RoutedCommand ShowAdornerCommand = new RoutedCommand("ShowAdorner", typeof(AdornedControl));
        public static readonly RoutedCommand HideAdornerCommand = new RoutedCommand("HideAdorner", typeof(AdornedControl));

        private static readonly CommandBinding ShowAdornerCommandBinding = new CommandBinding(ShowAdornerCommand, ShowAdornerCommand_Executed);
        private static readonly CommandBinding HideAdornerCommandBinding = new CommandBinding(HideAdornerCommand, HideAdornerCommand_Executed);

        
        #endregion Commands

        public AdornedControl()
        {
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(AdornedControl_DataContentChanged);
        }


        #region event handlers

        private void AdornedControl_DataContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateAdornerDataContext();
        }

        
        private static void IsAdornerVisible_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AdornedControl c = (AdornedControl)d;
            c.ShowOrHideAdornerInternal();
        }

       

        private static void AdornerContent_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void HorizontalAdornerPlacement_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void VerticalAdornerPlacement_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void HideAdornerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void ShowAdornerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion even handlers


        #region private methods
        private void UpdateAdornerDataContext()
        {
            if (this.AdornerContent != null)
            {
                this.AdornerContent.DataContext = this.DataContext;
            }
        }

        private void ShowOrHideAdornerInternal()
        {
            if (IsAdornerVisible == Visibility.Visible)
            {
                ShowAdornerInternal();
            }
            else
            {
                HideAdornerInternal();
            }
        }

        private void ShowAdornerInternal()
        {
            if (this.adorner != null)
            {
                return;
            }

            if(this.AdornerContent != null)
            {
                if (this.adornerLayer == null)
                {
                    this.adornerLayer = AdornerLayer.GetAdornerLayer(this);
                }

                if (this.adornerLayer != null)
                {
                    this.adorner = new FrameworkElementAdorner(this.AdornerContent, this, this.HorizontalAdornerPlacement, this.VerticalAdornerPlacement,
                        this.AdornerOffsetX, this.AdornerOffsetY);

                    this.adornerLayer.Add(this.adorner);

                    UpdateAdornerDataContext();
                }
            }
        }

        private void HideAdornerInternal()
        {
            if (this.adornerLayer == null || this.adorner == null)
            {
                return;
            }

            this.adornerLayer.Remove(this.adorner);
            this.adorner.DisconnectChild();

            this.adorner = null;
            this.adornerLayer = null;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ShowOrHideAdornerInternal();
        }
        #endregion private methods
    }


    public enum AdornerPlacement
    {
        Inside,
        Outside
    }

    public class FrameworkElementAdorner : Adorner
    {
        private FrameworkElement child;

        private AdornerPlacement horizontalAdornerPlacement = AdornerPlacement.Inside;
        private AdornerPlacement vertialAdornerPlacement = AdornerPlacement.Inside;

        private double offsetX = 0;
        private double offsetY = 0;

        private double positionX = double.NaN;
        private double positionY = double.NaN;

        public FrameworkElementAdorner(FrameworkElement adornerChildElement, FrameworkElement adornedElement):base(adornedElement)
        {
            this.child = adornerChildElement;

            base.AddLogicalChild(adornerChildElement);
            base.AddVisualChild(adornerChildElement);
        }

        public FrameworkElementAdorner(FrameworkElement adornerChildElement, FrameworkElement adornedElement, 
                                        AdornerPlacement horizontalAdornerPlacement, AdornerPlacement verticalAdornerPlacement,
                                        double offsetX, double offsetY)
            :base(adornedElement)
        {
            this.child = adornerChildElement;
            this.horizontalAdornerPlacement = horizontalAdornerPlacement;
            this.vertialAdornerPlacement = verticalAdornerPlacement;

            this.offsetX = offsetX;
            this.offsetY = offsetY;

            adornedElement.SizeChanged += new SizeChangedEventHandler(adornedElement_SizeChanged);

            base.AddLogicalChild(adornerChildElement);
            base.AddVisualChild(adornerChildElement);
        }

        private void adornedElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            InvalidateMeasure();
        }

        public double PositionX
        {
            get
            {
                return positionX;
            }
            set
            {
                positionX = value;
            }
        }

        public double PositionY
        {
            get
            {
                return positionY;
            }
            set
            {
                positionY = value;
            }
        }

        public new FrameworkElement AdornedElement
        {
            get
            {
                return (FrameworkElement)base.AdornedElement;
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
 	        this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        private double DetermineX()
        {
            switch(child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        if(horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return child.DesiredSize.Width + offsetX;
                        }else
                        {
                            return offsetX;
                        }
                    }
                case HorizontalAlignment.Right:
                    {
                        if(horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            var adornedWidth = AdornedElement.ActualWidth;
                            return adornedWidth + offsetX;
                        }
                        else
                        {
                            double adornerWidth = this.child.DesiredSize.Width;
                            double adornedwidth = AdornedElement.ActualWidth;
                            double x = adornedwidth - adornerWidth;
                            return x + offsetX;
                        }
                    }
                case HorizontalAlignment.Center:
                    {
                        double adornerWidth = this.child.DesiredSize.Width;
                        double adornedwithd = AdornedElement.ActualWidth;
                        double x = (adornedwithd/2) - (adornerWidth /2);
                        return x + offsetX;
                    }
                case HorizontalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        private double DetermineY()
        {
            switch(child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        if(vertialAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return child.DesiredSize.Height + offsetY;
                        }else
                        {
                            return offsetY;
                        }
                    }
                case VerticalAlignment.Bottom:
                    {
                        if(vertialAdornerPlacement == AdornerPlacement.Outside)
                        {
                            var adornedHeight = AdornedElement.ActualHeight;
                            return adornedHeight + offsetY;
                        }
                        else
                        {
                            double adornerHeight = this.child.DesiredSize.Height;
                            double adornedHeight = AdornedElement.ActualHeight;
                            double x = adornerHeight - adornedHeight;
                            return x + offsetY;
                        }
                    }
                case VerticalAlignment.Center:
                    {
                        double adornerHeight = this.child.DesiredSize.Height;
                        double adornedHeight = AdornedElement.ActualHeight;
                        double x = (adornedHeight/2) - (adornerHeight /2);
                        return x + offsetY;
                    }
                case VerticalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        private double DetermineWidth()
        {
            if(!Double.IsNaN(PositionX))
            {
                return this.child.DesiredSize.Width;
            }
            switch(child.HorizontalAlignment)
            {
                case HorizontalAlignment.Stretch:
                    return AdornedElement.ActualWidth;
                default:
                    return this.child.DesiredSize.Width;
            }
            return 0.0;
        }

        private double DetermineHeight()
        {
            if(!Double.IsNaN(positionY))
            {
                return this.child.DesiredSize.Height;
            }

            switch (child.VerticalAlignment)
            {
                case VerticalAlignment.Stretch:
                    return AdornedElement.ActualHeight;
                default:
                    return this.child.DesiredSize.Height;
            }

            return 0.0;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
 	        double x = PositionX;
            if(Double.IsNaN(x))
            {
                x = DetermineX();
            }
            double y = PositionY;
            if(Double.IsNaN(y))
            {
                y = DetermineY();
            }
            double adornerWidth = DetermineWidth();
            double adornerHeight = DetermineHeight();
            this.child.Arrange(new Rect(x,y,adornerWidth,adornerHeight));
            return finalSize;
        }

        protected override int VisualChildrenCount
        {
	        get 
            {
		        return 1;
	        }
        }

        protected override System.Windows.Media.Visual GetVisualChild(int index)
        {
 	        return this.child;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add(this.child);
                return (IEnumerator)list.GetEnumerator();
            }
        } 

        public void DisconnectChild()
        {
            base.RemoveLogicalChild(child);
            base.RemoveVisualChild(child);
        }
    }
}
