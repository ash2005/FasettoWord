using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Serurity;
using Fasetto.Word.ViewModel.Base;

namespace Fasetto.Word.ViewModel
{
    /// <summary>
    /// View Model for the Login Screen 
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// the email fo the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag that login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }


        #endregion

        #region Commands


        /// <summary>
        /// The command to Login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Attempts to log in the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the user's password</param>
        /// <returns></returns>
        private async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = this.Email;

                var pass = (parameter as IHavePassword)?.SecurePassword.Unsecure();
            });
        }

        #endregion
    }
}