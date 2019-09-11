using System.Windows;
using Fasetto.Word.Core.IoC;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immedialely anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup IoC
            IoC.Setup();

            // show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();


        }
    }
}
