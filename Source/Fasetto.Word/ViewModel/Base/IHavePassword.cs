

using System.Security;

namespace Fasetto.Word.ViewModel.Base
{
    /// <summary>
    /// An interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The Secure Password
        /// </summary>
         SecureString SecurePassword { get; }
    }
}
