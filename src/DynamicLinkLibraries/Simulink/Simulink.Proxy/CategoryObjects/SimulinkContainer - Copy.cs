using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

using CategoryTheory;

using SerializationInterface;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.XmlObjectFactory;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

using Simulink.Proxy.Factory;
using Simulink.Proxy.Systems;
using Simulink.Proxy.Factory.SetArrow;
using Simulink.Parser.Library;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Proxy.CategoryObjects
{
    /// <summary>
    /// Container of simulink
    /// </summary>
    [Serializable()]
    public class SimulinkContainer : ObjectContainerBase
    {
        #region Fields

        List<string> text = new List<string>();

        BinaryFormatter bf = new BinaryFormatter();


        IXmlObjectFactory factory;

        XElement doc;

        Dictionary<XElement, ICategoryObject> dictionary = new Dictionary<XElement, ICategoryObject>();

        List<Arrow> abscent;

        Dictionary<int, List<string>> arguments = new Dictionary<int, List<string>>();

        bool argLoaded = false;

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public SimulinkContainer()
            : base(new PureDesktopPeer())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SimulinkContainer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        #endregion

        #region Overriden Members

        /// <summary>
        /// The post load operation
        /// </summary>
        public override bool PostLoad()
        {
            //return base.PostLoad();
            if (!isLoaded)
            {
                return false;
            }
            if (isPostLoaded)
            {
                return true;
            }
            desktop.SetObjectNames();
            PureObjectLabel.SetLabels(desktop.Objects);
            PureArrowLabel.SetLabels(desktop.Arrows);
            IEnumerable<IArrowLabel> arrows = desktop.Arrows;
//            SetParents(desktop);
            IEnumerable<object> components = desktop.Components;
            foreach (INamedComponent nc in components)
            {
                nc.Desktop = desktop;
                //nc.Parent = Object as INamedComponent;
                if (nc is IObjectLabel)
                {
                    IObjectLabel ol = nc as IObjectLabel;
                    if (ol.Object is IObjectContainer)
                    {
                        IObjectContainer oc = ol.Object as IObjectContainer;
                        bool b = oc.PostLoad();
                        if (!b)
                        {
                            return false;
                        }
                    }
                }
            }
            foreach (IArrowLabel arrow in arrows)
            {
                arrow.Desktop = desktop;
                ICategoryObject source = arrow.Arrow.Source;
                if (source == null)
                {
                    arrow.Arrow.Source = arrow.Source.Object;
                }
                ICategoryObject target = arrow.Arrow.Target;
                if (target == null)
                {
                    arrow.Arrow.Target = arrow.Target.Object;
                }
                IAssociatedObject ass = arrow.Arrow as IAssociatedObject;
                ass.Object = arrow;
            }
            return true;
        }

        /// <summary>
        /// Saves desktop
        /// </summary>
        /// <param name="stream">Stream to save</param>
        protected override void SaveDesktop(Stream stream)
        {
            FillArguments();
            bf.Serialize(stream, arguments);
            bf.Serialize(stream, text);
            bf.Serialize(stream, Interface);
        }


        /// <summary>
        /// Loads desktop
        /// </summary>
        /// <param name="bytes">Soure bytes</param>
        /// <returns>Thrue in success and false otherwise</returns>
        protected override bool LoadDesktop(byte[] bytes)
        {
            if (bytes == null)
            {
                return false;
            }
            MemoryStream ms = new MemoryStream(bytes);
            object o = bf.Deserialize(ms);
           Dictionary<int, ArrayList> args;
            arguments = new Dictionary<int, List<string>>();
           if (o is Dictionary<int, ArrayList>)
            {
                args = o as Dictionary<int, ArrayList>;
                foreach (int key in args.Keys)
                {
                    ArrayList al = args[key];
                    List<string> ls = new List<string>();
                    arguments[key] = ls;
                    foreach (string s in al)
                    {
                        ls.Add(s);
                    }
                }
                text = bf.Deserialize(ms) as List<string>;
            }
            else
            {
                text = o as List<string>;
            }
            Hashtable t = bf.Deserialize(ms) as Hashtable;
            inter = new Dictionary<string, object>();
            foreach (string s in t.Keys)
            {
                inter[s] = t[s];
            }
            return LoadText();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Text
        /// </summary>
        public List<string> Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (!LoadText())
                {
                    text = new List<string>();
                }
            }
        }

        #endregion

        #region Private Members


        void CreateDocument()
        {
            doc = Simulink.Parser.Library.SimulinkXmlParser.Create(text);
            Simulink.Parser.Library.SimulinkXmlParser.TransformFunc(doc);
        }

        bool LoadText()
        {
            desktop.ClearAll();
            CreateAll();
            return true;
        }

        void CreateFactory()
        {
            string at = Simulink.Parser.Library.SimulinkXmlParser.BlockType;
            string an = Simulink.Parser.Library.SimulinkXmlParser.Name;
            byte[][] templ = new byte[][] { ResourceDesktop.Sin, ResourceDesktop.Sum, ResourceDesktop.Gain };
            List<IXmlObjectFactory>  ftemp = new List<IXmlObjectFactory>();
            for (int i = 0; i < templ.Length; i++)
            {
                ftemp.Add(new SerializableTemplateObjectFactory(desktop, at, an, templ[i]));
            }
            ftemp.Add(new TransferFunctionFactory(desktop));
            LabelCreationFactory lf = new LabelCreationFactory(new XmlObjectFactoryAggregate(ftemp.ToArray()));
            XmlObjectFactoryAggregate agg = new XmlObjectFactoryAggregate(
                new IXmlObjectFactory[] { lf, AliasFactory.Object });
            factory = agg;
        }

        void CreateObjects(IDictionary<XElement, ICategoryObject> dictionary)
        {
            StaticXmlObjectFactory.Create(
                doc.GetElementsByTagNameLocal(Simulink.Parser.Library.SimulinkXmlParser.Block),
                factory, dictionary);
        }

        void CreateArrows()
        {
            SystemBase.Process(doc.GetFirstLocal("Model") as XElement, desktop, out abscent);
        }

        void PostCreateArrows(IDictionary<XElement, ICategoryObject> dictionary)
        {
            ReplaceMeasurementsFactory f = new ReplaceMeasurementsFactory(desktop);
            StaticXmlObjectFactory.CreateExisting(
                doc.GetElementsByTagNameLocal(Simulink.Parser.Library.SimulinkXmlParser.Block), 
                f, dictionary);
        }

        void CreateAll()
        {
            CreateFactory();
            CreateDocument();
            CreateObjects(dictionary);
            CreateArrows();
            IEnumerable<IObjectLabel> oll = desktop.Objects;
            foreach (IObjectLabel ol in oll)
            {
                ol.Parent = Object as INamedComponent;
                ol.Desktop = desktop;
            }
            IEnumerable<IArrowLabel> all = desktop.Arrows;
            foreach (IArrowLabel al in all)
            {
                al.Parent = Object as INamedComponent;
                al.Desktop = desktop;
            }
            PostCreateArrows(dictionary);
            SetAliases();
            ExtractArguments();
        }

        void SetAliases()
        {
            foreach (Arrow a in abscent)
            {
                SetAlias(a);
            }
        }

        void SetAlias(Arrow arrow)
        {
            BlockPort bs = arrow.Source;
            BlockPort bt = arrow.Target;
            string sn = bs.Block;
            string tn = bt.Block;
            object so = desktop.GetObject(sn);
            if (!(so is IMeasurements))
            {
                return;
            }
            IMeasurements m = so as IMeasurements;
            if (!(so is ISetFeedback))
            {
                return;
            }
            ISetFeedback sf = so as ISetFeedback;
            object ta = desktop.GetObject(tn);
            if (!(ta is IAlias))
            {
                return;
            }
            IAlias al = ta as IAlias;
            sf.AddFeedback(m[0], al, al.AliasNames[0]);

        }

        void FillArguments()
        {
            IEnumerable<IObjectLabel> obje = desktop.Objects;
            List<IObjectLabel> obj = obje.ToList<IObjectLabel>();
            arguments.Clear();
            for (int i = 0; i < obj.Count; i++)
            {
                object o = obj[i].Object;
                if (o is DataPerformer.VectorFormulaConsumer)
                {
                    DataPerformer.VectorFormulaConsumer v = o as DataPerformer.VectorFormulaConsumer;
                    arguments[i] = v.Arguments;
                }
            }
        }

        void ExtractArguments()
        {
            if (argLoaded)
            {
                return;
            }
            argLoaded = true;
            IEnumerable<IObjectLabel> obje = desktop.Objects;
            List<IObjectLabel> obj = obje.ToList<IObjectLabel>();
            foreach (int i in arguments.Keys)
            {
                DataPerformer.VectorFormulaConsumer v = obj[i].Object as DataPerformer.VectorFormulaConsumer;
                v.Arguments = arguments[i];
            }
        }

        #endregion
    }
}
