using System.Windows;
using System.Windows.Input;
using Fasetto.Word.ViewModel.Base;
using Fasetto.Word.Window;

namespace Fasetto.Word.ViewModel
{
    public class WindowViewModel : Base.BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private readonly System.Windows.Window _window;

        /// <summary>
        /// the margin around the windows to allow for a drop shadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// the margin around the windows to allow for a drop shadow
        /// </summary>
        private int _outerMarginThickness = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;

        #endregion

        #region Constructor

        public WindowViewModel()
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(System.Windows.Window window)
        {
            this._window = window;

            // listen out for the window resize
            _window.StateChanged += (source, e) =>
            {
                // Fire off events for all properties that are affected by  a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Create the commands
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition(_window)));

            // Fix the resizing issure
            var resizer = new WindowResizer(_window);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Window Maximum Width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// Window minimum Height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);


        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentThickness => new Thickness(ResizeBorder);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// The window radius of the edge of the window
        /// </summary>
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The window radius of the edge of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(WindowRadius);

        /// <summary>
        /// The height of the title bar / captio of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Private Helpers

        /*        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        }*/

        private static Point GetMousePosition(System.Windows.Window window)
        {
            // var w32Mouse = new Win32Point();
            // GetCursorPos(ref w32Mouse);
            // return new Point(w32Mouse.X, w32Mouse.Y);
            // another solutions
            // Get Position of the mouse relative to the window
            var pos = Mouse.GetPosition(window);

            // Add the window position so it s a ToScreen
            return new Point(pos.X + window.Left, pos.Y + window.Top);
        }

        #endregion
    }
}