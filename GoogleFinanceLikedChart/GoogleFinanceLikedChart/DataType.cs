using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace FinancialHistoricLineChart
{
    public class StockInfo:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Date { get; set; }
        public double ClosePrice { get; set; }
        public double? Ave20 { get; set; }
        public double? Ave60 { get; set; }
        public double? Ave120 { get; set; }
        public int Volume { get; set; }
        private Visibility _visibility = Visibility.Hidden;
        public Visibility PointVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("PointVisibility");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
