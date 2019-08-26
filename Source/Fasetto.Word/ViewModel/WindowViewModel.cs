using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word.ViewModel
{
    public class WindowViewModel : Base.BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window _window;

        /// <summary>
        /// the margin around the windows to allow for a drop shadow
        /// </summary>
        private int _outerMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;


        #endregion

        #region Constructor

        public WindowViewModel()
        {
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        public Thickness  ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        public int 

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            this._window = window;
        }
    }
}
