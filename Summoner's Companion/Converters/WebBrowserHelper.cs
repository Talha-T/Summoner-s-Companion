using System;
using System.Windows;
using System.Windows.Controls;

namespace Summoner_s_Companion.Converters
{
    public static class WebBrowserHelper
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(object), typeof(WebBrowserHelper),
                new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static object GetBindableSource(DependencyObject obj)
        {
            return (string) obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, object value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = o as WebBrowser;
            if (browser == null) return;

            Uri uri = null;

            var s = e.NewValue as string;
            if (s != null)
            {
                var uriString = s;
                var bindingExpression = browser.GetBindingExpression(BindableSourceProperty);
                if (bindingExpression != null)
                {
                    var binding = bindingExpression.ParentBinding;
                    uri = string.IsNullOrWhiteSpace(uriString) ? null : new Uri(string.Format(binding.StringFormat, uriString));
                }
            }
            else if (e.NewValue is Uri)
            {
                uri = (Uri) e.NewValue;
            }

            browser.Source = uri;
        }
    }
}