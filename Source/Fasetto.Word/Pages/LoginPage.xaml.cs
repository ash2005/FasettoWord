using System.Security;
using Fasetto.Word.ViewModel;
using Fasetto.Word.ViewModel.Base;

namespace Fasetto.Word.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The secure password for this view
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
