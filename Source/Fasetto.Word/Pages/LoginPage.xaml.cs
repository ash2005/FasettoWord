using System.Windows.Controls;
using Fasetto.Word.Animation;

namespace Fasetto.Word.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AnimateOut();
        }
    }
}
