namespace Internet.Meteo
{
    public class Sensor : IDisposable
    {

        #region Fields


        protected string kind;

        double value;

        object block = new object();

        Task task;

        Dictionary<string, Func<string, string>> requests; 


        string request;


        public event Action<float> OnValueChange;

        private string key;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Kind</param>
        public Sensor(string kind) : this()
        {
            Set(kind);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected Sensor()
        {
            requests = new Dictionary<string, Func<string, string>>()
            {
                {"thermometer", currentTemperature }
            };
        }

        #endregion

        #region Public Members

        public string Key 
        {
            get => key;
            set
            {
                key = value;
                request = requests[kind](key);
            }
        }

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
                    task = null;
                }
            }
        }

        #endregion


        #region IDisposable members

        void IDisposable.Dispose()
        {
            KillTask();
        }

        #endregion

        #region Protected Members

        protected void Set(string kind)
        {
            this.kind = kind;
        }

        void DoWork()
        {

        }

        #endregion

        #region Private Members

        string currentTemperature(string key)
        {
            return "";
        }


        void KillTask()
        {
            if (task != null)
            {
                task.Dispose();
            }
        }

        #endregion

    }
}
