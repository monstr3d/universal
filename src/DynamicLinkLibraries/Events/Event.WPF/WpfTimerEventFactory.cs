using Event.Interfaces;


namespace Event.WPF
{
    /// <summary>
    /// WPF timer factory
    /// </summary>
    public class WpfTimerEventFactory : ITimerEventFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static WpfTimerEventFactory Singleton = new WpfTimerEventFactory();

        #endregion

        #region Ctor


        private WpfTimerEventFactory()
        {

        }

        #endregion

        #region ITimerEventFactory Members


        ITimerEvent ITimerEventFactory.NewTimer
        {
            get
            {
                return new TimerEvent();
            }
        }


        #endregion
    }
}