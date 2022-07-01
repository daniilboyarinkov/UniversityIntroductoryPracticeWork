using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoApp.Models
{
    internal class TextValueModel : INotifyPropertyChanged
    {
        private string _value;
        private string _text;
        public TextValueModel(string value, string text)
        {
            _value = value;
            _text = text;
        }
        public virtual string Value
        {
            get => _value;
            set { _value = value; NotifyPropertyChanged("Value"); }
        }
        public virtual string Text
        {
            get => _text;
            set { _text = value; NotifyPropertyChanged("Text"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
