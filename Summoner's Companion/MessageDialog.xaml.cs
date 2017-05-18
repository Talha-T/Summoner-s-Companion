using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Summoner_s_Companion.Annotations;

namespace Summoner_s_Companion
{
    /// <summary>
    /// MessageDialog.xaml etkileşim mantığı
    /// </summary>
    public partial class MessageDialog : INotifyPropertyChanged
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        public MessageDialog(string message) : this()
        {
            Message = message;
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value.Replace("<br>", Environment.NewLine);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
