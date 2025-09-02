using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Assembly of initalizers
    /// </summary>
    public class ApplicationInitializerAssembly : IApplicationInitializer
    {
        #region Fields

        private IApplicationInitializer[] initializers;

        static private bool isInitialized = false;

        private bool throwsRepeatException;

        #endregion

        #region Ctor


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initializers">Initializers</param>
        /// <param name="throwsRepeatException">The "Throws repeat initialization exception" sign</param>
        public ApplicationInitializerAssembly(IApplicationInitializer[] initializers, bool throwsRepeatException)
        {
            this.initializers = initializers;
            this.throwsRepeatException = throwsRepeatException;
        }

        #endregion

        #region IApplicationInitializer Members

        /// <summary>
        /// Initializes application
        /// </summary>
        public virtual void InitializeApplication()
        {
            if (isInitialized)
            {
                if (throwsRepeatException)
                {
                    throw new OwnException("Double initialization");
                }
            }
            isInitialized = true;
            if (initializers == null)
            {
                return;
            }
            foreach (IApplicationInitializer i in initializers)
            {
                i.InitializeApplication();
            }
        }

        #endregion
    }
}
