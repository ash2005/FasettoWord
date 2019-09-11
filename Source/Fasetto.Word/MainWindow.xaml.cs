using Fasetto.Word.Core;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public ApplicationViewModel ApplicationViewModel => new ApplicationViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }
    }
}
