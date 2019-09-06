using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fasetto.Word.Expression;

namespace Fasetto.Word.ViewModel.Base
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Protected Members

        /// <summary>
        /// A global lock for property checks so prevent locking on different instances of expressions.
        /// Considering how fast this check will always be it isn't an issue to globally lock all callers.
        /// </summary>
        protected object mPropertyValueCheckLock = new object();

        #endregion

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers


        #endregion

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set
        /// if the flag is true, indicating the function is already runnign) then the actio nis not run
        /// if the flag is false (indicating no running function) then athe action is run.
        /// </summary>
        /// <param name="updatingFlag">The Boolean property flag if the command is already running</param>
        /// <param name="action">the action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // check if the flag property is true (meaning the function is already running)
            // if(updatingFlag.Compile().Invoke())
            if(updatingFlag.GetPropertyValue())
                return;

            // Set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // run the passed in action
                await action();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // set the property flag back to false now it is finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
