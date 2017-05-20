using System.Windows;
using RiotSharp.StaticDataEndpoint;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// PassiveView.xaml etkileşim mantığı
    /// </summary>
    public partial class PassiveView
    {
        public PassiveView()
        {
            InitializeComponent();
        }

        public PassiveStatic Passive
        {
            get => (PassiveStatic) GetValue(PassiveProperty);
            set => SetValue(PassiveProperty, value);
        }

        public static readonly DependencyProperty PassiveProperty =
            DependencyProperty.Register("Passive", typeof(PassiveStatic), typeof(PassiveView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender,
                    PassiveChangedCallback));

        private static void PassiveChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = (PassiveView) d;
            view.Passive = (PassiveStatic) e.NewValue;
        }

    }
}

