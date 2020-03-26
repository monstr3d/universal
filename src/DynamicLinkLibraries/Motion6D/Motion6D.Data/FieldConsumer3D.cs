using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Aliases;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using PhysicalField.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Consumer of 3D physical field
    /// </summary>
    [Serializable()]
    public class FieldConsumer3D : CategoryObject, ISerializable, IFieldConsumer, 
        IDataConsumer, IPositionObject, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Facet object
        /// </summary>
        protected IFacet facet;

        /// <summary>
        /// Internal aliases
        /// </summary>
        protected Dictionary<int, string> intAliases = new Dictionary<int, string>();

        /// <summary>
        /// Esternal aliases
        /// </summary>
        protected Dictionary<string, Dictionary<int, string>> extAliases = new Dictionary<string, Dictionary<int, string>>();

        /// <summary>
        /// Outcoming informatin
        /// </summary>
        protected List<string> outcoming = new List<string>();

        /// <summary>
        /// List of colors
        /// </summary>
        protected List<string> colors = new List<string>();

        /// <summary>
        /// The "colored" sign
        /// </summary>
        protected bool colored = true;

        /// <summary>
        /// The "proportional" sign
        /// </summary>
        protected bool proportional = true;

        /// <summary>
        /// The "rainbow scale" sign
        /// </summary>
        protected bool rainbowScale = true;

        /// <summary>
        /// The "enabled" sign
        /// </summary>
        protected bool enabled = true;

        /// <summary>
        /// External measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// External fields
        /// </summary>
        protected List<IPhysicalField> fields = new List<IPhysicalField>();

        /// <summary>
        /// Position
        /// </summary>
        protected IPosition position;

        /// <summary>
        /// Coordinates of position
        /// </summary>
        protected double[] pos = new double[3];

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
 
        private Dictionary<IPhysicalField, Dictionary<int, Transformer>> fieldAliases =
            new Dictionary<IPhysicalField, Dictionary<int, Transformer>>();

        private Dictionary<int, AliasName> surfaceAliaes = new Dictionary<int, AliasName>();

        private ReferenceFrame relative = new ReferenceFrame();

        private object[,] parameters;

 
        private List<IMeasurement> measures = new List<IMeasurement>();

 
        private IMeasurement[] colorMea = new IMeasurement[3];

        private double[,] colorValues;

        private double[] min = new double[3];

        private double[] max = new double[3];

        private double[] tcol = new double[3];

        Action<int> simpCalc;
        Action<int> propSimpCalc;
        Action<int> colCalc;
        Action<int> propColCalc;
        Action<int> rainBowCalc;
        Action<int> propRainBowCalc;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="facet"></param>
        public FieldConsumer3D(IFacet facet)
        {
            init();
            this.facet = facet;
        }

        /// <summary>
        /// Deserialisation constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected FieldConsumer3D(SerializationInfo info, StreamingContext context)
        {
            init();
            intAliases = info.GetValue("IntAliases", typeof(Dictionary<int, string>)) as Dictionary<int, string>;
            extAliases = info.GetValue("ExtAliases", typeof(Dictionary<string, Dictionary<int, string>>)) as
                Dictionary<string, Dictionary<int, string>>;
            outcoming = info.GetValue("Outcoming", typeof(List<string>)) as List<string>;
            colors = info.GetValue("Colors", typeof(List<string>)) as List<string>;
            colored = (bool)info.GetValue("Colored", typeof(bool));
            proportional = (bool)info.GetValue("Proportional", typeof(bool));
            rainbowScale = (bool)info.GetValue("RainbowScale", typeof(bool));
            enabled = (bool)info.GetValue("Enabled", typeof(bool));
        }
        

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IntAliases", intAliases, typeof(Dictionary<int, string>));
            info.AddValue("ExtAliases", extAliases, typeof(Dictionary<string, Dictionary<int, string>>));
            info.AddValue("Outcoming", outcoming, typeof(List<string>));
            info.AddValue("Colors", colors, typeof(List<string>));
            info.AddValue("Colored", colored, typeof(bool));
            info.AddValue("Proportional", proportional, typeof(bool));
            info.AddValue("RainbowScale", rainbowScale, typeof(bool));
            info.AddValue("Enabled", enabled, typeof(bool));
        }

        #endregion

        #region IFieldConsumer Members

        int IFieldConsumer.SpaceDimension
        {
            get
            {
                return 3;
            }
        }

        int IFieldConsumer.Count
        {
            get
            {
                return fields.Count;
            }
        }

        IPhysicalField IFieldConsumer.this[int n]
        {
            get
            {
                return fields[n];
            }
        }


        void IFieldConsumer.Add(IPhysicalField field)
        {
            fields.Add(field);
        }

        void IFieldConsumer.Remove(IPhysicalField field)
        {
            fields.Remove(field);
        }

        void IFieldConsumer.Consume()
        {
            if (!enabled)
            {
                return;
            }
            update();
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
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

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (position is IAssociatedObject)
                {
                    IAssociatedObject ao = position as IAssociatedObject;
                    facet = ao.GetObject<IFacet>();
                }
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (facet.Count <= 0)
            {
                return;
            }
            setAliases();
            setMeasures();
            setParameters();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Facet object
        /// </summary>
        public IFacet Facet
        {
            get
            {
                return facet;
            }
            set
            {
                facet = value;
            }
        }

        /// <summary>
        /// The "is colored" sign
        /// </summary>
        public bool Colored
        {
            get
            {
                return colored;
            }
            set
            {
                colored = value;
            }
        }

        /// <summary>
        /// The "proportional" sign
        /// </summary>
        public bool Proportional
        {
            get
            {
                return proportional;
            }
            set
            {
                proportional = value;
            }
        }

        /// <summary>
        /// The "rainbow scale" sign
        /// </summary>
        public bool RainbowScale
        {
            get
            {
                return rainbowScale;
            }
            set
            {
                rainbowScale = value;
            }
        }

        /// <summary>
        /// Internal aliases
        /// </summary>
        public Dictionary<int, string> IntAliases
        {
            get
            {
                return intAliases;
            }
        }

       /// <summary>
       /// External aliases
       /// </summary>
        public Dictionary<string, Dictionary<int, string>> ExtAliases
        {
            get
            {
                return extAliases;
            }
        }

        /// <summary>
        /// Names of outcoming measures
        /// </summary>
        public List<string> Outcoming
        {
            get
            {
                return outcoming;
            }
        }

        /// <summary>
        /// List of colors
        /// </summary>
        public List<string> Colors
        {
            get
            {
                return colors;
            }
        }

        #endregion

        #region Private Members

        private void setAliases()
        {
            setField();
            setSurface();
        }

        void setMeasures()
        {
            measures.Clear();
            foreach (string s in outcoming)
            {
                IMeasurement m = this.FindMeasurement(s, false);
                measures.Add(m);
            }
            for (int i = 0; i < colorMea.Length; i++)
            {
                colorMea[i] = null;
                if (colors.Count > i)
                {
                    colorMea[i] = this.FindMeasurement(colors[i], true);
                }
            }
        }


        void setParameters()
        {
            parameters = new object[facet.Count, measures.Count];
            colorValues = new double[facet.Count, 3];
        }


        private void setField()
        {
            fieldAliases.Clear();
            IFieldConsumer c = this;
            foreach (string fn in extAliases.Keys)
            {
                Dictionary<int, string> an = extAliases[fn];
                foreach (IPhysicalField field in fields)
                {
                    string na = this.GetRelativeName(field as IAssociatedObject);
                    if (na.Equals(fn))
                    {
                        Dictionary<int, Transformer> d = new Dictionary<int, Transformer>();
                        fieldAliases[field] = d;
                        foreach (int num in an.Keys)
                        {
                            AliasName aln = this.FindAliasName(an[num], true);
                            Transformer tr = new Transformer();
                            tr.an = aln;
                            tr.tr = FieldTransformer.Create(field.GetType(num), field.GetTransformationType(num));
                            d[num] = tr;
                        }
                    }
                }
            }
        }


        private void setSurface()
        {
            surfaceAliaes.Clear();
            foreach (int n in intAliases.Keys)
            {
                string al = intAliases[n];
                AliasName an = this.FindAliasName(al, false);
                surfaceAliaes[n] = an;
            }
        }

        private void update()
        {
            IDataConsumer cons = this;
            ReferenceFrame frame = position.GetParentFrame();
            int ncol = colored ? 3 : 1;
            foreach (IPhysicalField field in fieldAliases.Keys)
            {
                IPositionObject po = field as IPositionObject;
                ReferenceFrame ff = po.Position.GetParentFrame();
                ReferenceFrame.GetRelativeFrame(ff, frame, relative);
                Dictionary<int, Transformer> d = fieldAliases[field];
                foreach (int nf in d.Keys)
                {
                    Transformer tr = d[nf];
                    FieldTransformer transfomer = tr.tr;
                    tr.tr.Set(relative);
                }
                int fc = facet.Count;
                for (int i = 0; i < fc; i++)
                {
                    double[] p = facet[i];
                    relative.GetRelativePosition(p, pos);
                    object[] o = field[pos];
                    foreach (int nf in d.Keys)
                    {
                        Transformer tr = d[nf];
                        object ot = tr.tr.Transform(o[nf]);
                        tr.an.SetValue(ot);
                    }
                    foreach (int ns in surfaceAliaes.Keys)
                    {
                        object sp = facet[i, ns];
                        surfaceAliaes[ns].SetValue(sp);
                    }
                    this.FullReset();
                    cons.UpdateChildrenData();
                    for (int j = 0; j < measures.Count; j++)
                    {
                        parameters[i, j] = measures[j].Parameter();
                    }
                    if (colorMea[0] == null)
                    {
                        continue;
                    }
                    for (int nnc = 0; nnc < ncol; nnc++)
                    {
                        double col = (double)colorMea[0].Parameter();
                        if (proportional)
                        {
                            if (i == 0)
                            {
                                min[nnc] = col;
                                max[nnc] = col;
                            }
                            else
                            {
                                if (min[nnc] > col)
                                {
                                    min[nnc] = col;
                                }
                                if (max[nnc] < col)
                                {
                                    max[nnc] = col;
                                }
                            }
                            colorValues[i, nnc] = col;
                        }
                    }
                }
            }
            if (colorMea[0] != null)
            {
                draw();
            }
        }

        void draw()
        {
            if (facet == null)
            {
                return;
            }
            int fc = facet.Count;
            Action<int> cc = colorCalc;
            for (int i = 0; i < fc; i++)
            {
                cc(i);
                facet.SetColor(i, 1, tcol[0], tcol[1], tcol[2]);
            }
        }

        void limit(ref double a)
        {
            if (a < 0)
            {
                a = 0;
            }
            if (a > 1)
            {
                a = 1;
            }
        }

        void scale(ref double a, double min, double max)
        {
            a = (a - min) / (max - min);
        }

        void calculateSimple(int i)
        {
            double a = colorValues[i, 0];
            limit(ref a);
            for (int j = 0; j < 3; j++)
            {
                tcol[j] = a;
            }
        }

        void caculateColor(int i)
        {
            for (int j = 0; j < 3; j++)
            {
                double a = colorValues[i, j];
                limit(ref a);
                tcol[j] = a;
            }
        }

        void calculateProp(int i)
        {
            double a = colorValues[i, 0];
            scale(ref a, min[0], max[0]);
            for (int j = 0; j < 3; j++)
            {
                tcol[j] = a;
            }
        }

        void calculateColProp(int i)
        {
            for (int j = 0; j < 3; j++)
            {
                double a = colorValues[i, j];
                scale(ref a, min[i], max[i]);
                tcol[j] = a;
            }
        }

        void rainBowCol(double a)
        {
            double x = a;// + 0.5 * a * a;
            double[] v = tcol;
            if (true)
            {
                v[0] = 0.7;
                v[1] = 0.7;
                v[2] = 0.7;
                //v[3] = 1 - x;
            }
            //v[3] = 1;
            int k = (int)(x * 5);
            if (k < 0)
            {
                k = 0;
            }
            if (k > 4)
            {
                k = 4;
            }
            double y = 5 * (x - (double)(k) / 5.0);
            if (k == 0)
            {
                v[0] = 1;
                v[1] = y;
                v[2] = 0;
            }
            else if (k == 1)
            {
                v[0] = 1 - y;
                v[1] = 1;
                v[2] = 0;
            }
            else if (k == 2)
            {
                v[0] = 0;
                v[1] = 1;
                v[2] = y;
            }
            else if (k == 3)
            {
                v[0] = 0;
                v[1] = 1 - y;
                v[2] = 1;
            }
            else
            {
                v[0] = y;
                v[1] = 0;
                v[2] = 1;
            }
        }

        void calculateRain(int i)
        {
            double a = colorValues[i, 0];
            limit(ref a);
            for (int j = 0; j < 3; j++)
            {
                rainBowCol(a);
            }
        }

        void calculatePropRain(int i)
        {
            double a = colorValues[i, 0];
            scale(ref a, min[0], max[0]);
           // for (int j = 0; j < 3; j++)
           // {
                rainBowCol(a);
           // }
        }

        void init()
        {
            simpCalc = calculateSimple;
            propSimpCalc = calculateProp;
            colCalc = caculateColor;
            propColCalc = calculateColProp;
            rainBowCalc = calculateRain;
            propRainBowCalc = calculatePropRain;
        }

        Action<int> colorCalc
        {
            get
            {
                if (colored)
                {
                    if (proportional)
                    {
                        return propColCalc;
                    }
                    return colCalc;
                }
                if (rainbowScale)
                {
                    if (proportional)
                    {
                        return propRainBowCalc;
                    }
                    return rainBowCalc;
                }
                if (proportional)
                {
                    return propSimpCalc;
                }
                return simpCalc;
            }
        }


        #endregion

        struct Transformer
        {
            public AliasName an;
            public FieldTransformer tr;
        }

 
    }
}
