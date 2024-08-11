namespace Internet.Meteo
{
    using Diagram.UI;
    using Newtonsoft.Json;
 
    public class Sensor : IDisposable
    {

        #region Fields

        HttpClient client = new HttpClient();

        protected string kind;

        protected double value = 0;

        object block = new object();

        Task task;

        Dictionary<string, Func<string>> requests;

        AutoResetEvent ev;

        dynamic weather;



        Func<string> requestf;


        public event Action<double> OnValueChange;

        public Action<bool> OnEnabledChange;


        CancellationTokenSource ctx = null;

        TimeSpan span;

        string body = "";


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
            requests = new Dictionary<string, Func<string>>()
            {
                {"thermometer", currentTemperature }
            };
            
        }

        #endregion

        #region Public Members

        public string Key
        { get; set; } = "";

        public string Position 
        { get; set; } = "";

        public double GetValue()
        {
            lock (block)
            {
                var dt = DateTime.Now;
                var h = weather.hours[dt.Hour];
                var m = dt.Minute;

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
                        ctx = new();
                        ev = new AutoResetEvent(false);
                        task = new Task(DoWork);
                        task.Start();
                        if (ev != null)
                        {
                            ev.WaitOne();
                            ev = null;
                        }    
                    }
                    OnEnabledChange?.Invoke(true);
                    return;
                }
                if (task != null)
                {
                    KillTask();
                    OnEnabledChange?.Invoke(false);
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
            requestf = requests[kind];
        }

        async void Request()
        {
            try
            {
                var s = requestf();


                var request = new HttpRequestMessage(HttpMethod.Get, s);

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception if error

                var body = await response.Content.ReadAsStringAsync();
                lock (block)
                {
                    weather = JsonConvert.DeserializeObject(body);
                    weather = weather.days[0];
                }
                ev.Set();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        async void DoWork()
        {
            while (true)
            {
                try
                {
                    if (ctx.IsCancellationRequested)
                    {
                        ctx = null;
                        return;
                    }
                    var now = DateTime.Now;
                    var dateTime = now.AddDays(1);
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                    var span = dateTime - now;
                    Task t = new Task(Request);
                    t.Start();
                    ctx = new();
                    await Task.Delay(span, ctx.Token);
                    if (ctx.IsCancellationRequested)
                    {
                        ctx = null;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ctx = null;
                    return;
                }
            }
        }



        #endregion

        #region Private Members


        string currentTemperature()
        {
            var s = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/";
            return s + Position + "?key=" + Key;
        }

        void KillTask()
        {
            if (ctx != null)
            {
                ctx.Cancel();
            }
        }

        #endregion

    }
}
