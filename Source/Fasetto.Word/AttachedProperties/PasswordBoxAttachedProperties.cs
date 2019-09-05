﻿using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word.AttachedProperties
{
    /// <summary>
    /// The MonitorPassword attached property fro a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // get the caller...
            if (!(sender is PasswordBox passwordBox)) return;

            // Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // if the caller set MonitorPassword to true
            if (!(bool) e.NewValue)
                return;

            // Set default value
            HasTextProperties.SetValue(passwordBox);

            // Start listening out for password changes
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        /// <summary>
        /// Fired when the password box password value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Set the attached HasText value
            HasTextProperties.SetValue((PasswordBox)sender);  
        }
    }


    /// <summary>
    /// the HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperties : BaseAttachedProperty<HasTextProperties, bool>
    {
        /// <summary>
        /// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
