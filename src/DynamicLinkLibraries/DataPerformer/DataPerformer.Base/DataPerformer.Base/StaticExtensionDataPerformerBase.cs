using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using MathGraph;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Aliases;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using AssemblyService.Attributes;

namespace DataPerformer
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerBase
    {

        #region Fields


        static private readonly string illegal = "Illegal sequence of time providers";


        /// <summary>
        /// First
        /// </summary>
        static bool first = true;

        #endregion

        #region Ctor

        static StaticExtensionDataPerformerBase()
        {
            Func<object, object> f = BaseTypes.Extended.ArrayReturnType.Convert;
            f.AddTypeConverter();
            new Binder();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets double value function
        /// </summary>
        /// <param name="measure">Measure</param>
        /// <returns>Function</returns>
        public static Func<object, double> GetDoubleFunction(this IMeasurement measure)
        {
            return StaticExtensionBaseTypes.GetDoubleFunction(measure.Type);
        }

        /// <summary>
        /// Sets link checker
        /// </summary>
        static public void SetLinkChecker()
        {
            DataLink.Checker = Check;
        }

        /// <summary>
        /// Checks desktop
        /// </summary>
        /// <param name="desktop"></param>
        static public void Check(this IDesktop desktop)
        {
            IDesktop d = desktop.Root;
            CheckObject ch = new CheckObject(checkLink);
            List<IObjectLabel> objects;
            List<IArrowLabel> arrows;
            PureDesktopPeer.GetFullList(d, out objects, out arrows);
            Digraph graph = PureDesktop.CreateDigraph(objects, arrows, null, ch);
            List<DigraphLoop> loops = graph.Loops;
            foreach (DigraphLoop loop in loops)
            {
                Check(loop);
            }
        }
     
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
            if (!first)
            {
                return;
            }
            first = false;
            new Binder();
        }

        /// <summary>
        /// Gets all measurements of one dimension real array
        /// </summary>
        /// <param name="ao">Associated object</param>
        /// <returns>Names of measurements</returns>
        public static string[] GetOneDimensionRealArrays(this IAssociatedObject ao)
        {
            INamedComponent nc = null;
            if (ao is INamedComponent)
            {
                nc = ao as INamedComponent;
            }
            else
            {
                nc = ao.Object as INamedComponent;
            }
            IDesktop desktop = nc.Root.Desktop;
            if (desktop == null)
            {
                desktop = nc.Desktop;
            }
            if (desktop == null)
            {
                return new string[0];
            }
            List<string> l = new List<string>();
            desktop.ForEach((IMeasurements m) =>
                {
                    IAssociatedObject aob = m as IAssociatedObject;
                    INamedComponent ncm = aob.Object as INamedComponent;
                    string nm = ncm.GetName(desktop);
                    for (int i = 0; i < m.Count; i++)
                    {
                        IMeasurement mea = m[i];
                        if (mea == null)
                        {
                            continue;
                        }
                        object t = mea.Type;
                        if (!(t is ArrayReturnType))
                        {
                            continue;
                        }
                        ArrayReturnType art = t as ArrayReturnType;
                        Double a = 0;
                        if (!art.ElementType.Equals(a))
                        {
                            continue;
                        }
                        if (art.Dimension.Length != 1)
                        {
                            continue;
                        }
                        l.Add(nm + "." + mea.Name);

                    }
                });
            return l.ToArray();
        }

        /// <summary>
        /// Gets one dimensional array by name
        /// </summary>
        /// <param name="ao">Associated object</param>
        /// <param name="name">Full name of array</param>
        /// <returns>The array</returns>
        public static Array GetOneDimensionRealArray(this IAssociatedObject ao, string name)
        {
            INamedComponent nc = null;
            if (ao is INamedComponent)
            {
                nc = ao as INamedComponent;
            }
            else
            {
                nc = ao.Object as INamedComponent;
            }
            IDesktop desktop = nc.Root.Desktop;
            Array arr = null;
            desktop.ForEach((IMeasurements m) =>
            {

                IAssociatedObject aob = m as IAssociatedObject;
                INamedComponent ncm = aob.Object as INamedComponent;
                string nm = ncm.GetName(desktop);
                for (int i = 0; i < m.Count; i++)
                {
                    try
                    {
                        IMeasurement mea = m[i];
                        if (mea == null)
                        {
                            continue;
                        }
                        string nn = nm + "." + mea.Name;
                        if (name.Equals(nn))
                        {
                            if (arr != null)
                            {
                                ao.Throw("Ambigous");
                            }
                            arr = mea.Parameter() as Array;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError(10);
                    }
                }
            });
            return arr;
        }

        /// <summary>
        /// Gets variables form collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>The variables</returns>
        public static List<string[]> GetDoubleVariables(this IComponentCollection collection)
        {
            List<string[]> l = new List<string[]>();
            Action<IStateDoubleVariables> action = (IStateDoubleVariables v) =>
                {
                    object o = v;
                    string n = o.GetName(collection);
                    List<string> ll = v.Variables;
                    foreach (string ss in ll)
                    {
                        l.Add(new string[] { n, ss });
                    }
                };
            collection.ForEach(action);
            return l;
        }

        /// <summary>
        /// Gets state vector of collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="output">The state vector</param>
        public static void GetStateVector(this IComponentCollection collection, double[] output)
        {
            int i = 0;
            Action<IStateDoubleVariables> action = (IStateDoubleVariables v) =>
            {
                double[] x = v.Vector;
                int n = x.Length;
                Array.Copy(x, 0, output, i, n);
                i += n;
            };
            collection.ForEach(action);
        }

        /// <summary>
        /// Gets state vector of collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="input">The state vector</param>
        public static void SetStateVector(this IComponentCollection collection, double[] input)
        {
            int i = 0;
            Action<IStateDoubleVariables> action = (IStateDoubleVariables v) =>
            {
                double[] x = v.Vector;
                int n = x.Length;
                v.Set(input, i, x.Length);
                i += n;
            };
            collection.ForEach(action);
        }

        /// <summary>
        /// Sets collection
        /// </summary>
        /// <param name="processor">The processor</param>
        /// <param name="collection">The colletion</param>
        /// <returns>List of variables</returns>
        static public void Set(this IDifferentialEquationProcessor processor, IComponentCollection collection)
        {
            processor.Set(collection);
        }

        /// <summary>
        /// Performs ation with array of arguments
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="array">Array of arguments</param>
        /// <param name="collection">Desktop</param>
        /// <param name="provider">Provider of time measure</param>
        /// <param name="processor">Differential equation processor</param>
        /// <param name="priority">Priority</param>
        /// <param name="action">Additional action</param>
        /// <param name="reason">Reason</param>
        static public void PerformArray(this IDataConsumer consumer, Array array, IComponentCollection collection, ITimeMeasurementProvider provider,
            IDifferentialEquationProcessor processor, int priority, Action action, string reason)
        {
            using (var backup = new TimeProviderBackup(collection, provider, processor, priority, reason))
            {
                IDataRuntime runtime = backup.Runtime;
                ITimeMeasurementProvider old = processor.TimeProvider;
                processor.TimeProvider = provider;
                IStep st = null;
                if (runtime is IStep)
                {
                    st = runtime as IStep;
                }
                int n = array.Length;
                double t = (double)array.GetValue(0);
                double last = t;
                Action<double, double, long> act = 
                    runtime.Step(processor, (double time) => 
                    { provider.Time = time; }, reason);
                for (int i = 0; i < n; i++)
                {
                    t = (double)array.GetValue(i);
                    act(last, t, (long)i);
                   /* last = t;
                    if (i == 0)
                    {
                        runtime.StartAll((double)array.GetValue(0));
                    }
                    if (st != null)
                    {
                        st.Step = i;
                    }
                    runtime.UpdateAll();
                    provider.Time = (double)array.GetValue(i);
                    if (i > 0 & processor != null)
                    {
                        processor.Step((double)array.GetValue(i - 1), (double)array.GetValue(i));
                    }
                    provider.Time = (double)array.GetValue(i);*/
                    action();
                    //collection.ResetUpdatedMeasurements();
                }
                processor.TimeProvider = old;
            }
        }
 

        #endregion

        #region Private Members

        static private void Check(DataLink l)
        {
            object o = l.Object;
            if (o != null)
            {
                if (o is INamedComponent)
                {
                    INamedComponent nc = o as INamedComponent;
                    IDesktop d = nc.Desktop;
                    Check(d);
                }
            }
        }

        static private void Check(DigraphLoop loop)
        {
            ITimeMeasurementProvider[] p = new ITimeMeasurementProvider[] { GetProvider(loop[0]), GetProvider(loop[1]) };
            if (p[0] == null | p[1] == null)
            {
                return;
            }
            if (p[0] != p[1])
            {
                throw new Exception(illegal);
            }
        }

        static private void Check(DataPerformer.Portable.DataLink l)
        {
            object o = l.Object;
            if (o != null)
            {
                if (o is INamedComponent)
                {
                    INamedComponent nc = o as INamedComponent;
                    IDesktop d = nc.Desktop;
                    Check(d);
                }
            }
        }



        static private ITimeMeasurementProvider GetProvider(DigraphPath path)
        {
            ITimeMeasurementProvider p = null;
            for (int i = 0; i < path.Count - 1; i++)
            {
                ICategoryObject ob = path[i].CategoryObject;
                if (ob is ITimeMeasurementProvider)
                {
                    p = ob as ITimeMeasurementProvider;
                }
            }
            return p;
        }

        static private bool checkLink(object obj)
        {
            return obj is DataLink;
        }

        /// <summary>
        /// The unity
        /// </summary>
        /// <returns>Unity</returns>
        static private object Unity()
        {
            return (double)1;
        }

        #endregion

        #region Helper class

        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            static readonly Dictionary<string, string> ass = new Dictionary<string, string>()
        {
            {"DataPerformerBase", typeof(StaticExtensionDataPerformerBase).Assembly.FullName}
        };
            internal Binder()
            {
                this.Add();
            }
            readonly string[] types = new string[] { "DataPerformerBase", "DataPerformer.Base" };
            public override Type BindToType(string assemblyName, string typeName)
            {
                foreach (string key in ass.Keys)
                {
                    if (assemblyName.Contains(key))
                    {
                        return Type.GetType(String.Format("{0}, {1}",
                            typeName,
                            ass[key]));
                    }
                }
                return null;
            }
        }

        #endregion
    }
}