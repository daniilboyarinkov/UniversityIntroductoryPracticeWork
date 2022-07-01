using System.Windows;
using TodoApp.BLogic;

namespace TodoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Logic();
        }
    }
}
