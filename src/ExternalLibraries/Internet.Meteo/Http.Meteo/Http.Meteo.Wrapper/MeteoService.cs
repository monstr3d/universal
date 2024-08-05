using CategoryTheory;

using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace Http.Meteo.Wrapper
{
    /// <summary>
    /// Meteorological service
    /// </summary>
    public class MeteoService : Meteo.MeteoService, ICategoryObject,
         IMeasurements
    {

        #region Fields

        protected IMeasurement[] measurements;

        object obj;
   
        #endregion

        public MeteoService()
            : base()
        {
            CreateMeasurements();
       }

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return measurements[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            DateTime now = DateTime.Now;
            if (now > nextTime)
            {
                Update();
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return DateTime.Now < nextTime;
            }
            set
            {
            }
        }

        object IAssociatedObject.Object { get => obj; set => obj = value; }

        #endregion

        #region Members

        protected override void ShowError(Exception exception)
        {
            exception.ShowError();
            return;
            ("Bad Internet connection to Hydrometeorological Center of Russia. Error: " +
                exception.Message).Show(10);

        }

        protected void CreateMeasurements()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            for (int i = 0; i < types.Length; i++)
            {
                int[] k = new int[] { i + 2 };
                Func<object> f = () => { return values[k[0]]; };
                l.Add(new Measurement(types[i], f, names[i]));
            }
            measurements = l.ToArray();
        }


        protected override void Process(ref int i, ref int j)
        {
            foreach (IMeasurement m in measurements)
            {
                if (m.Name.Equals(names[6]))
                {
                    ++j;
                    continue;
                }
                if (!Find(tags[i]))
                {
                    return;
                }
                object t = m.Type;
                Func<IEnumerator<string>, object> f = df[t];
                values[i + j] = f(enumerable);
                ++i;
            }

        }





        protected override void ShowMessage(string msg)
        {
            msg.Show();
        }


        #endregion

    }
}