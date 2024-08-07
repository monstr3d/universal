namespace Internet.Meteo
{
    public class Sensor : IDisposable
    {

        #region Fields


        protected string kind;

        double value;

        object block = new object();

        Task task;

        Func<string, string> request;

        #endregion

        #region Public Members

        public string Key { get; set; }

        public string Posiition { get; set; }


        public int Interval { get; set; }

    
        public double GetValue()
        {
            lock (block)
            {
                return value;
            }
        }

        public bool IsEnabled
        {
            get => task != null;
            set
            {
                if (value)
                {
                    if (task == null)
                    {
                        task = new Task(DoWork);
                        task.Start();
                    }
                    return;
                }
                if (task != null)
                {
                    task.Dispose();
                    task = null;
                }
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Kind</param>
        public Sensor(string kind)
        {
            Set(kind);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Sensor()
        {

        }

  
        #endregion


        void IDisposable.Dispose()
        {
            KillTask();
        }

        protected void Set(string kind)
        {
            this.kind = kind;
        }

        void DoWork()
        { 
        
        }

        void KillTask()
        {
            if (task != null)
            {
                task.Dispose();
            }
        }

    }
}
