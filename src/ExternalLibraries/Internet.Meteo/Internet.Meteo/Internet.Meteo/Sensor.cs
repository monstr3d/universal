namespace Internet.Meteo
{
    using Newtonsoft.Json;


    public enum FahrenheitCelsius
    {
        Fahrenheit,
        Celsius
    }

    /// <summary>
    /// Base class for the weather sensor
    /// </summary>
    public abstract class Sensor : IDisposable
    {


        #region Fields


        public readonly Dictionary<string, object> Types = new Dictionary<string, object>()
        {
            { "temp", (double)0 },
            {"feelslike", (double)0},
            {"humidity", (double)0},
          {  "dew", (double)0 },
            {"precip", (double)0 },
            {"precipprob", (double)0 },
           { "snow", (double)0 },
           { "snowdepth", (double)0 },
          //  {"preciptype", (double)0 },
           { "windgust", (double)0 },
           { "windspeed", (double)0 },
            {"winddir", (double)0 },
            {"pressure", (double)0 },
            {"visibility", (double)0 },
            {"cloudcover", (double)0 },
            {"solarradiation", (double)0 },
           { "solarenergy", (double)0 },
            {"uvindex", (double)0 } ,
           { "conditions", "" },
           { "icon","" }

        };

        public readonly Dictionary<string, string[]> names = new Dictionary<string, string[]>()
        {
            {"thermometer", ["temp"] },
            {"all", [
                "temp",
                "feelslike",
                "humidity",
                "dew",
                "precip",
                "precipprob",
                "snow",
                "snowdepth", 
                //"preciptype",
                 "windgust",
            "windspeed",
                "winddir",
                "pressure",
                "visibility",
                "cloudcover",
                "solarradiation",
                 "solarenergy",
                "uvindex",
                "conditions",
                "icon"] }

        };


        FahrenheitCelsius fahrenheitCelsius;


        // 21.5 degrees Celsius is equal to 70.7 degrees Fahrenheit.

        const double cf = 21.5 / 70.7;

        double coefficient = 1;

        HttpClient client = new HttpClient();

        protected string kind;

        protected object[] values;

        protected string[] currentNames;

        object block = new object();

        Task task;

        Dictionary<string, Tuple<Func<string>, Action>> requests;

        double cm1, cm2;

        AutoResetEvent ev;

        dynamic weather;

        Func<string> requestf;


        public event Action<object[]> OnValueChange;

        public Action<bool> OnEnabledChange;


        CancellationTokenSource ctx = null;

        TimeSpan span;

        Action Get;

        Action Init;


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
            requests = new Dictionary<string, Tuple<Func<string>, Action>>()
            {
                {"thermometer",  new Tuple<Func<string>, Action>
                ( DayForecast, GetTemperature)
                },
                {"all",  new Tuple<Func<string>, Action>
                (DayForecast, GetAll)
                }
            };

        }


        #endregion

        #region Public Members

        /// <summary>
        /// The Fahrenheit Celsius sign
        /// </summary>
        public FahrenheitCelsius FahrenheitCelsius
        {
            get => fahrenheitCelsius;
            set
            {
                fahrenheitCelsius = value;
                coefficient = (value == FahrenheitCelsius.Fahrenheit) ? 1 : cf;
            }
        }

        /// <summary>
        /// The kind
        /// </summary>
        public string Kind { get => kind; }


        /// <summary>
        /// The sofware API key
        /// </summary>
        public string Key
        { get; set; } = "";

        /// <summary>
        /// Gegraphic position
        /// </summary>
        public string Position
        { get; set; } = "";

        /// <summary>
        /// Updates itself
        /// </summary>
        public void Update()
        {
            lock (block)
            {
                if (weather == null)
                {
                    return;
                }
                Get();
            }
            OnValueChange?.Invoke(values);
        }

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
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

        /// <summary>
        /// Starts itself
        /// </summary>
        protected void Start()
        {

            IsEnabled = true;
            IsEnabled = false;
        }

        /// <summary>
        /// Sets a kind
        /// </summary>
        /// <param name="kind">The kind</param>
        protected virtual void Set(string kind)
        {
            this.kind = kind;
            var tuple = requests[kind];
            requestf = tuple.Item1;
            Get = tuple.Item2;
            currentNames = names[kind];
            values = new object[currentNames.Length];
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message</param>
        protected abstract void ShowMessage(string message);

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">The exception</param>
        protected abstract void ShowError(Exception exception);

        #endregion

        #region Private Members


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
                if (ev != null)
                {
                    ev.Set();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
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

        void SetDouble(int i, dynamic value)
        {
            object v = value.Value;
            if (v == null)
            {
                values[i] = null;
            }
            else
            {
                values[i] = (double)v;
            }
        }

        void SetDoubleDouble(int i, dynamic value)
        {
            object v = value.Value;
            if (v == null | v == null)
            {
                values[i] = null;
                return;
            }
            var a = (double)values[i];
            var b = (double)v;
            values[i] = cm1 * a + cm2 * b;
        }


        void GetAll()
        {
            if (weather == null)
            {
                return;
            }
            var dt = DateTime.Now;
            var h = dt.Hour;
            var hh = weather.hours[h];
            values[0] = coefficient * (double)hh.temp.Value;
            SetDouble(1, hh.feelslike);
            SetDouble(2, hh.humidity);
            SetDouble(3, hh.dew);
            SetDouble(4, hh.precip);
            SetDouble(5, hh.precipprob);
            SetDouble(6, hh.snow);
            SetDouble(7, hh.snowdepth);
            SetDouble(8, hh.windgust);
            SetDouble(9, hh.windspeed);
            SetDouble(10, hh.winddir);
            SetDouble(11, hh.pressure);
            SetDouble(12, hh.visibility);
            SetDouble(13, hh.cloudcover);
            SetDouble(14, hh.solarradiation);
            SetDouble(15, hh.solarenergy);
            SetDouble(16, hh.uvindex);
            values[17] = hh.conditions.Value;
            values[18] = hh.icon.Value;
            if (h == 23)
            {
                return;
            }
            cm1 = (double)dt.Minute / 60;
            cm2 = 1 - cm1;
            hh = weather.hours[h + 1];
            SetDoubleDouble(1, hh.feelslike);
            SetDoubleDouble(2, hh.humidity);
            SetDoubleDouble(3, hh.dew);
            SetDoubleDouble(4, hh.precip);
            SetDoubleDouble(5, hh.precipprob);
            SetDoubleDouble(6, hh.snow);
            SetDoubleDouble(7, hh.snowdepth);
            SetDoubleDouble(8, hh.windgust);
            SetDoubleDouble(9, hh.windspeed);
            SetDoubleDouble(10, hh.winddir);
            SetDoubleDouble(11, hh.pressure);
            SetDoubleDouble(12, hh.visibility);
            SetDoubleDouble(13, hh.cloudcover);
            SetDoubleDouble(14, hh.solarradiation);
            SetDoubleDouble(15, hh.solarenergy);
            SetDoubleDouble(16, hh.uvindex);
        }



        void GetTemperature()
        {
            var dt = DateTime.Now;
            var h = dt.Hour;
            values[0] = coefficient * (double)weather.hours[h].temp.Value;
            if (h == 23)
            {
                return;
            }
            var a = coefficient * (double)weather.hours[h + 1].temp;
            var m = (double)dt.Minute / 60;
            values[0] = (double)values[0] * (1 - m) + a * m;
        }


        string DayForecast()
        {
            // 40.7128,-74.0060
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
