using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;

using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Diagram.UI.Interfaces;

using Motion6D.Interfaces;

using NamedTree;

using WpfInterface.Interfaces;

namespace WpfInterface.Objects3D
{
    [Serializable()]
    public class DeformedWpfShape : WpfShape, IDataConsumer, IVisibleConsumer, IPostSetArrow
    {

        #region Fields

        #region Add Remove Events

        /// <summary>
        /// Add event
        /// </summary>
        event Action<IVisible> onAdd = (IVisible v) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IVisible> onRemove = (IVisible v) => { };

        /// <summary>
        /// Post event
        /// </summary>
        event Action<IVisible> onPost = (IVisible v) => { };

        #endregion


        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        private WpfShape source;


        private IMeasurement[] m = new IMeasurement[3];

        private AlName[] al = new AlName[3];

        private IList<IMeasurements> measurements = new List<IMeasurements>();

        private string[] output = new string[3];

        private string[] input = new string[3];

        private List<Point3DCollection> lmesh = new List<Point3DCollection>();
 

        #endregion

        #region Ctor

        public DeformedWpfShape()
        {
        }


        protected DeformedWpfShape(SerializationInfo info, StreamingContext context)
        {
            input = info.GetValue("Input", typeof(string[])) as string[];
            output = info.GetValue("Output", typeof(string[])) as string[];
        }

        #endregion

        #region Overriden Members

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Input", input, typeof(string[]));
            info.AddValue("Output", output, typeof(string[]));
        }

        public override Visual3D GetVisual(Motion6D.Portable.Camera camera)
        {
            if (xaml == null)
            {
                return null;
            }
            return base.GetVisual(camera);
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

        #region IVisibleConsumer Members

        void IVisibleConsumer.Add(IVisible visible)
        {
            if (source != null)
            {
                throw new ErrorHandler.OwnException("Source already exists");
            }
            source = visible as WpfShape;
            if (visible is IWpfVisible)
            {
                IWpfVisible sh = visible as IWpfVisible;
                Textures = sh.Textures;
            }
            onAdd(visible);
        }

        void IVisibleConsumer.Remove(IVisible visible)
        {
            source = null;
            onRemove(visible);
        }

        void IVisibleConsumer.Post(IVisible visible)
        {
            onPost(visible); 
        }

        event Action<IVisible> IVisibleConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnPost
        {
            add { onPost += value; }
            remove { onPost -= value; }
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
            All();
        }

        #endregion

        #region Specific Members

        #region Public Members

        public string[][] Data
        {
            get
            {
                return new string[][] { input, output };
            }
            set
            {
                input = value[0];
                output = value[1];
                All();
            }
        }

        #endregion

        #region Overriden Members

        public override Visual3D Visual
        {
            get
            {
                string s = ProcessXaml(xaml);
                Visual3D v3d = System.Windows.Markup.XamlReader.Parse(s) as Visual3D;
                List<MeshGeometry3D> l = new List<MeshGeometry3D>();
                Detect(v3d, l);
                if (lmesh.Count == l.Count)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        l[i].Positions = lmesh[i];
                    }
                }
                return v3d;
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        #endregion

        #region Private Members

        void All()
        {
            Find();
            Create();
        }

        bool Find()
        {
            IDataConsumer cons = this;
            foreach (string s in input)
            {
                if (s == null)
                {
                    return false;
                }
            }
            foreach (string s in output)
            {
                if (s == null)
                {
                    return false;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                object[] o = cons.FindAlias(input[i]);
                IAlias a = o[0] as IAlias;
                string n = o[1] as string;
                AlName an = new AlName();
                an.alias = a;
                an.name = n;
                al[i] = an;
            }
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = this.FindMeasurement(output[i], true);
            }
            return true;
        }

        #endregion

        /*       MeshGeometry3D Mesh
        {
            get
            {
                string s = source.Xaml + "";
                Visual3D v3d;
                object ob = System.Windows.Markup.XamlReader.Parse(s);
                MeshGeometry3D mg = null;
                if (ob is Visual3D)
                {
                    v3d = ob as Visual3D;
                    if (v3d is ModelVisual3D)
                    {
                        ModelVisual3D mv3d = v3d as ModelVisual3D;
                        Model3DGroup mdg = mv3d.Content as Model3DGroup;
                        foreach (Model3D g in mdg.Children)
                        {
                            if (!(g is GeometryModel3D))
                            {
                                continue;
                            }
                            GeometryModel3D g3d = g as GeometryModel3D;
                            Geometry3D geo = g3d.Geometry;
                            if (geo is MeshGeometry3D)
                            {
                                mg = geo as MeshGeometry3D;
                                return mg;
                            }
                        }
                    }
                }
                return null;
            }
        }
  */

        private void Detect(Visual3D v3d, List<MeshGeometry3D> list)
        {
            if (v3d is ModelVisual3D)
            {
                ModelVisual3D mv3d = v3d as ModelVisual3D;
                Model3D m3d = mv3d.Content;
                if (m3d is GeometryModel3D)
                {
                    GeometryModel3D g3d = m3d as GeometryModel3D;
                    Geometry3D geo = g3d.Geometry;
                    if (geo is MeshGeometry3D)
                    {
                        list.Add(geo as MeshGeometry3D);
                    }
                }
                if (m3d is Model3DGroup)
                {
                    Model3DGroup mdg = m3d as Model3DGroup;
                    foreach (Model3D g in mdg.Children)
                    {
                        if (!(g is GeometryModel3D))
                        {
                            continue;
                        }
                        GeometryModel3D g3d = g as GeometryModel3D;
                        Geometry3D geo = g3d.Geometry;
                        if (geo is MeshGeometry3D)
                        {
                           list.Add(geo as MeshGeometry3D);
                        }
                    }
                }
                else
                {
                    Visual3DCollection coll = mv3d.Children;
                    foreach (Visual3D v in coll)
                    {
                        Detect(v, list);
                    }

                }
            }
        }

        private void Create()
        {
            if (source == null)
            {
                return;
            }
            IDataConsumer cons = this;
            string x = source.Xaml;
            string s = ProcessXaml(x);
            Visual3D v3d = null;
            object ob = System.Windows.Markup.XamlReader.Parse(s);
            MeshGeometry3D mg = null;
            if (ob is Visual3D)
            {
                v3d = ob as Visual3D;
                List<MeshGeometry3D> lm = new List<MeshGeometry3D>();
                Detect(v3d, lm);
                xaml = x;
                if (source == null)
                {
                    return;
                }
                // MeshGeometry3D pattern = Mesh;
                foreach (AlName an in al)
                {
                    if (an.alias == null)
                    {
                        return;
                    }
                    if (an.name == null)
                    {
                        return;
                    }
                }
                foreach (IMeasurement mea in m)
                {
                    if (mea == null)
                    {
                        return;
                    }
                }
               /* mg.Positions.Clear();
                for (int i = 0; i < pattern.Positions.Count; i++)
                {
                    Point3D pat = pattern.Positions[i];
                    //Point3D p = mg.Positions[i];
                    for (int l = 0; l < 3; l++)
                    {
                        al[l].alias[al[l].name] = pat.GetCoordinate(l);
                    }
                    cons.UpdateChildrenData();
                    Point3D p = new Point3D((double)m[0].Parameter(), (double)m[1].Parameter(), (double)m[2].Parameter());
                    mg.Positions.Add(p);
                    this.FullReset();
                }*/
                lmesh.Clear();
                foreach (MeshGeometry3D mh in lm)
                {
                    Point3DCollection pp = mh.Positions;
                    Point3DCollection p = new Point3DCollection();
                    foreach (Point3D pat in pp)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            al[l].alias[al[l].name] = pat.GetCoordinate(l);
                        }
                        cons.UpdateChildrenData();
                        Point3D pr = new Point3D((double)m[0].Parameter(), (double)m[1].Parameter(), (double)m[2].Parameter());
                        p.Add(pr);
                        this.FullReset();
                    }
                    mh.Positions = p;
                    lmesh.Add(p);
                }
                //xaml = System.Windows.Markup.XamlWriter.Save(v3d);
            }
        }

        #endregion

        #region Auxilary class
        
        struct AlName
        {
            internal IAlias alias;
            internal string name;
        }

        #endregion

   }
}
