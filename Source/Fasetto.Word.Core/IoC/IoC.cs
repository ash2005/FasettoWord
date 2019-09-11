using System;
using Ninject;

namespace Fasetto.Word.Core.IoC
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// Teh Kernel for our IoC Container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all services can be found.
        /// </summary>
        public  static void Setup()
        {
            // Bind all required view models

            BindViewModels();
        }

        private static void BindViewModels()
        {
            // Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();
            // bind a single instance for application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
        #endregion

        /// <summary>
        /// Get's a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static object Get<T>()
        {
            return Kernel.Get<T>();
        }
    }

}
