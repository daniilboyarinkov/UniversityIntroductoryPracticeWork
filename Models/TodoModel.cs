using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoApp.Models
{
    public class TodoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime СompletionDate { get; set; }

        private string _category = string.Empty;
        private string _content = string.Empty;
        private string _status = "Создано";
        private DateTime _deadline;

        public string Category
        {
            get => _category;
            set { _category = value; NotifyPropertyChanged("Category"); }
        }
        public DateTime Deadline
        {
            get => _deadline;
            set { _deadline = value; NotifyPropertyChanged("Deadline"); }
        }
        public string Content
        {
            get => _content;
            set { _content = value; NotifyPropertyChanged("Content"); }
        }
        public string Status
        {
            get => _status;
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
