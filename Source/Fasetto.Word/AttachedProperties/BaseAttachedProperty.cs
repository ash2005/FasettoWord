using System;
using System.Windows;

namespace Fasetto.Word.AttachedProperties
{
    /// <summary>
    /// A base attached property to replace the vanilla WPF Attached Property.
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty> where TParent : BaseAttachedProperty<TParent, TProperty>, new()
    {
        #region Public Events
        /// <summary>
        /// Fired when the value changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => {};

        #endregion

        #region Public Properties
        /// <summary>
        /// Singleton instance of our parent class
        /// </summary>
        public static TParent Instance { get; private set; } = new TParent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// Attached property of this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", typeof(TProperty), typeof(BaseAttachedProperty<TParent, TProperty>), 
            new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Call back event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e">The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // call the parent function
            Instance.OnValueChanged(d, e);

            // call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached Property
        /// </summary>
        /// <param name="d">the element to get the property from</param>
        /// <returns></returns>
        public static TProperty GetValue(DependencyObject d) => (TProperty) d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject d, TProperty value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// the method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">the UI element that this property was changed for</param>
        /// <param name="e">The Argument for this event </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

    }
}
