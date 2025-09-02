using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using BitmapConsumer;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI;
using Diagram.UI.Aliases;
using Diagram.UI.Interfaces;
using NamedTree;

namespace ImageTransformations
{
    /// <summary>
    /// Transformer of bitmap.
    /// This component enable us to transform bitmap
    /// using dataflow
    /// </summary>
    [Serializable()]
    public class BitmapTransformer : CategoryObject, ISerializable, IDataConsumer, 
        IBitmapProvider, IBitmapConsumer, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };


        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 
        
        /// <summary>
        /// Left shift
        /// </summary>
        private int left;

        /// <summary>
        /// Top shift
        /// </summary>
        private int top;

        /// <summary>
        /// Aliases of colors
        /// </summary>
        private string[, ,] colorAliases;

        /// <summary>
        /// Aliases of coordinates
        /// </summary>
        private string[] coordAliases = new string[2];

        /// <summary>
        /// Output colors
        /// </summary>
        private string[] colors = new string[3];

        /// <summary>
        /// Aliases of external colors
        /// </summary>
        private AliasName[, ,] extColors;

        /// <summary>
        /// Aliases of coordinates
        /// </summary>
        private AliasName[] coord = new AliasName[2];

        /// <summary>
        /// Measures of colors
        /// </summary>
        private IMeasurement[] measures = new IMeasurement[3];

        /// <summary>
        /// Provider
        /// </summary>
        private IBitmapProvider provider;

        /// <summary>
        /// Helper colors
        /// </summary>
        private int[] hc = new int[3];


        /// <summary>
        /// Helper colors
        /// </summary>
        private int[] hco = new int[3];

        private Action update;

        private IComponentCollection collection;

        private List<IUpdatableObject> updatable = new List<IUpdatableObject>();

        private List<IMeasurements> childMeasurements =
            new List<IMeasurements>();

        /// <summary>
        /// Bitmap
        /// </summary>
        private Bitmap bmp;

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurements> measurements = new List<IMeasurements>();


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BitmapTransformer()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BitmapTransformer(SerializationInfo info, StreamingContext context)
        {
            top = (int)info.GetValue("Top", typeof(int));
            left = (int)info.GetValue("Left", typeof(int));
            colorAliases = info.GetValue("ExtColors", typeof(string[, ,])) as string[, ,];
            colors = info.GetValue("IntColors", typeof(string[])) as string[];
            coordAliases = info.GetValue("Coord", typeof(string[])) as string[];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Top", top, typeof(int));
            info.AddValue("Left", left, typeof(int));
            info.AddValue("ExtColors", colorAliases, typeof(string[, ,]));
            info.AddValue("IntColors", colors, typeof(string[]));
            info.AddValue("Coord", coordAliases, typeof(string[]));
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IBitmapProvider Members

        Bitmap IBitmapProvider.Bitmap
        {
            get { return bmp; }
        }

        #endregion

        #region IBitmapConsumer Members

        void IBitmapConsumer.Process()
        {
            Process();
        }

        /// <summary>
        /// Providers
        /// </summary>
        IEnumerable<IBitmapProvider> IBitmapConsumer.Providers
        {
            get
            {
                if (provider != null)
                {
                    yield return provider;
                }
            }
        }

        /// <summary>
        /// Adds a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Add(IBitmapProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Removes a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Remove(IBitmapProvider provider)
        {
            this.provider = null;
        }

        /// <summary>
        /// Add remove event of provider. If "bool" is true then adding
        /// </summary>
        event Action<IBitmapProvider, bool> IBitmapConsumer.AddRemove
        {
            add { addRemove += value; }
            remove { addRemove -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region Specific Members

        public void Set(string[, ,] colorAliases, string[] coordAliases, string[] colors, int left, int top)
        {
            this.colorAliases = colorAliases;
            if (colorAliases == null)
            {
                colorAliases = new string[0, 0, 0];
            }
            this.coordAliases = coordAliases;
            this.colors = colors;
            this.left = left;
            this.top = top;
            Post();
        }

        /// <summary>
        /// Left shift
        /// </summary>
        public int Left
        {
            get
            {
                return left;
            }
        }

        /// <summary>
        /// Top shift
        /// </summary>
        public int Top
        {
            get
            {
                return top;
            }
        }

        /// <summary>
        /// Names of coordinates' aliases
        /// </summary>
        public string[] Coordinates
        {
            get
            {
                return coordAliases;
            }
        }

        /// <summary>
        /// Names of colors' measurements
        /// </summary>
        public string[] Colors
        {
            get
            {
                return colors;
            }
        }

        /// <summary>
        /// Names of colors of external colors
        /// </summary>
        public string[, ,] ExternalColors
        {
            get
            {
                return colorAliases;
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;


        /// <summary>
        /// Posts itself
        /// </summary>
        private void Post()
        {
            IComponentCollection cc = this.GetDependentCollection();
            cc.GetAll(childMeasurements);
            cc.GetAll(updatable);
            if (updatable.Count == 0)
            {
                update = UpdateChildren;
            }
            else
            {
                update = () =>
                    {
                        UpdateChildren();
                        foreach (IUpdatableObject uo in updatable)
                        {
                           if (uo.Update != null)
                           {
                               uo.Update();
                           }
                        }
                        UpdateChildren();
                    };
            }
            SetAliases();
            SetMea();
            Process();
        }

        private void UpdateChildren()
        {
            foreach (IMeasurements m in childMeasurements)
            {
                m.IsUpdated = false;
                m.UpdateMeasurements();
            }
        }

        /// <summary>
        /// Process
        /// </summary>
        private void Process()
        {
            IDataConsumer cons = this;
            if (provider == null)
            {
                bmp = null;
                return;
            }
            if (provider.Bitmap == null)
            {
                return;
            }
            if (colorAliases == null)
            {
                return;
            }
            if (extColors == null)
            {
                return;
            }
            Bitmap b = provider.Bitmap;
            if (b == null)
            {
                return;
            }
            bmp = new Bitmap(b.Width, b.Height);
            int right = colorAliases.GetLength(0) - left;
            int bottom = colorAliases.GetLength(1) - top;
            for (int i = 0; i < bmp.Width; i++)
            {
                int ii = i - left;
                if ((ii < 0) | (i + right >= bmp.Width))
                {
                    continue;
                }
                for (int j = 0; j < bmp.Height; j++)
                {
                    int jj = j - top;
                    if ((jj < 0) | (j + bottom >= bmp.Height))
                    {
                        continue;
                    }
                    double x = (double)i;
                    double y = (double)j;
                    if (coord[0] != null)
                    {
                        coord[0].SetValue(x);
                    }
                    if (coord[1] != null)
                    {
                        coord[1].SetValue(y);
                    }
                    for (int k = 0; k < extColors.GetLength(0); k++)
                    {
                        int xc = ii + k;
                        for (int l = 0; l < extColors.GetLength(1); l++)
                        {
                            int yc = jj + l;
                            Color c = b.GetPixel(xc, yc);
                            hc[0] = c.R;
                            hc[1] = c.G;
                            hc[2] = c.B;
                            for (int m = 0; m < hc.Length; m++)
                            {
                                AliasName ext = extColors[k, l, m];
                                if (ext != null)
                                {
                                    ext.SetValue(((double)hc[m]) / 255);
                                }
                            }
                        }
                    }
                    update();
                    for (int n = 0; n < measures.Length; n++)
                    {
                        IMeasurement mea = measures[n];
                        if (mea == null)
                        {
                            hco[n] = 0;
                        }
                        else
                        {
                            double cd = (double)mea.Parameter();
                            int cn = (int)(cd * 255);
                            if (cn > 255)
                            {
                                cn = 255;
                            }
                            hco[n] = cn;
                        }
                    }
                    Color co = Color.FromArgb(255, hco[0], hco[1], hco[2]);
                    bmp.SetPixel(i, j, co);
                }
            }
        }

        /// <summary>
        /// Sets aliases
        /// </summary>
        private void SetAliases()
        {
            coord = this.FindAliases(coordAliases, true);
            if (colorAliases == null)
            {
                colorAliases = new string[0, 0, 0];
            }
            extColors = new AliasName[colorAliases.GetLength(0), colorAliases.GetLength(1), colorAliases.GetLength(2)];
            for (int i = 0; i < colorAliases.GetLength(0); i++)
            {
                for (int j = 0; j < colorAliases.GetLength(1); j++)
                {
                    for (int k = 0; k < colorAliases.GetLength(2); k++)
                    {
                        string sal = colorAliases[i, j, k];
                        if (sal != null)
                        {
                            extColors[i, j, k] = this.FindAliasName(sal, true);
                        }
                    }
                }
            }
        }

        private void SetMea()
        {
            measures = this.FindMeasurements(colors, true);
         }

        #endregion

        #region Fiction

        #endregion

    }
}
