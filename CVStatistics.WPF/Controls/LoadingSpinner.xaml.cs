using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CVStatistics.WPF.Controls
{
    /// <summary>
    /// Interaction logic for LoadingSpinner.xaml
    /// </summary>
    public partial class LoadingSpinner : UserControl
    {
        public static readonly DependencyProperty _IsLoadingProperty =
           DependencyProperty.Register("_IsLoading", typeof(bool), typeof(LoadingSpinner),
               new PropertyMetadata(false));

        public bool _IsLoading
        {
            get { return (bool)GetValue(_IsLoadingProperty); }
            set { SetValue(_IsLoadingProperty, value); }
        }
        public static readonly DependencyProperty _DiameterProperty =
            DependencyProperty.Register("_Diameter", typeof(double), typeof(LoadingSpinner),
                new PropertyMetadata(50.0));

        public double _Diameter
        {
            get { return (double)GetValue(_DiameterProperty); }
            set { SetValue(_DiameterProperty, value); }
        }
        public static readonly DependencyProperty _ThicknessProperty =
            DependencyProperty.Register("_Thickness", typeof(double), typeof(LoadingSpinner),
                new PropertyMetadata(5.0));

        public double _Thickness
        {
            get { return (double)GetValue(_ThicknessProperty); }
            set { SetValue(_ThicknessProperty, value); }
        }
        public static readonly DependencyProperty _ColorProperty =
            DependencyProperty.Register("_Color", typeof(Brush), typeof(LoadingSpinner),
                new PropertyMetadata(Brushes.Black));

        public Brush _Color
        {
            get { return (Brush)GetValue(_ColorProperty); }
            set { SetValue(_ColorProperty, value); }
        }
        public static readonly DependencyProperty _CapProperty =
            DependencyProperty.Register("_Cap", typeof(PenLineCap), typeof(LoadingSpinner),
                new PropertyMetadata(PenLineCap.Flat));

        public PenLineCap _Cap
        {
            get { return (PenLineCap)GetValue(_CapProperty); }
            set { SetValue(_CapProperty, value); }
        }

        public static readonly DependencyProperty _FontSizeProperty =
            DependencyProperty.Register("_FontSize", typeof(double), typeof(LoadingSpinner),
                new PropertyMetadata(12.0));
        public double _FontSize
        {
            get { return (double)GetValue(_FontSizeProperty); }
            set { SetValue(_FontSizeProperty, value); }
        }
        public static readonly DependencyProperty _TextProperty =
            DependencyProperty.Register("_Text", typeof(string), typeof(LoadingSpinner),
                new PropertyMetadata("Loading..."));
        public string _Text
        {
            get { return (string)GetValue(_TextProperty); }
            set { SetValue(_TextProperty, value); }
        }
        #region Constructor
        public LoadingSpinner()
        {
            InitializeComponent();
        }
        #endregion
    }
}
