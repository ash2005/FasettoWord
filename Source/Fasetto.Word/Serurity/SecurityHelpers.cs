
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Fasetto.Word.Serurity
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecurityHelpers
    {
        /// <summary>
        /// Unsecure a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString securePassword)
        {
            if (securePassword == null)
                return string.Empty;
            // Get a pointer for an unsecure string in memory

            var unmanagedString = IntPtr.Zero;

            try
            {
                // Unsecured the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);

                return Marshal.PtrToStringUni(unmanagedString);
            }
            catch (Exception ex)
            {
                // clean up any memeory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

            return string.Empty;
        }
    }
}
