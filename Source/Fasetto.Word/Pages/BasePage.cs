using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Animation;
using Fasetto.Word.ViewModel.Base;

namespace Fasetto.Word.Pages
{
    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<TVM> : Page where TVM : BaseViewModel, new()
    {
        #region Private Member

        private TVM _viewModel;

        #endregion
        #region Public Properties

        /// <summary>
        /// The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation the play when the page is first unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutFromLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The View Model associated w/ this Page
        /// </summary>
        public TVM ViewModel
        {
            get => _viewModel;
            set
            {
                // if nothing has changed, return
                if(_viewModel == value)
                    return;

                // update the value
                _viewModel = value;

                // Set the data context
                this.DataContext = _viewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // if we are animating in ,hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;

            // create a new View Model
            this.ViewModel = new TVM();
        }

        #endregion

        #region Animation Load / Unload
       

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateIn();
        }

        /// <summary>
        /// animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            // Make sure we have something to do 
            if(this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    // start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            // Make sure we have something to do 
            if(this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutFromLeft:
                    // start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;

                default:
                    return;
            }
        }

        #region Animation Helpers 

        

        #endregion

        #endregion

    }
}
