using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using DataPerformer.Interfaces;

using Diagram.UI;
using Diagram.UI.Aliases;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using NamedTree;

using ErrorHandler;


namespace DataPerformer.Portable
{
    public class Performer : DataPerformer.Interfaces.Performer
    {

        Type tvcc = typeof(IVariablesCodeCreator);

        public void Set(IFeedbackAliasCollection collection)
        {
            var c = collection.Aliases;
            foreach (var alias in c)
            {
                alias.Set();
            }
        }

        public override T GetLaguageObject<T>(string o) where T : class
        {
            var x = base.GetLaguageObject<T>(o);
            if (x != null)
            {
                return x;
            }
            var type = typeof(T);
            if (type == tvcc)
            {
                return StaticExtensionDataPerformerInterfaces.VariableCodeCreators[o] as T;
            }
            return null;
        }



        public int GetNumber(IDataConsumer dataConsumer, IMeasurements measurements)
        {
            var n = dataConsumer.Count;
            for (var i = 0; i < n; i++)
            {
                if (dataConsumer[i] == measurements)
                {
                    return i;
                }
            }
            return -1;
        }


        public int[] GetNumber(IDataConsumer dataConsumer, IMeasurement measurement)
        {
            var n = dataConsumer.Count;
            for (var i = 0; i < n; i++)
            {
                var measurements = dataConsumer[i];
                var m = measurements.Count;
                for (int j = 0; j < m; j++)
                {
                    if (measurements[j] == measurement)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null; 
        }



        public void Fill(IFeedbackCollectionDictionary collection, IDataConsumer consumer)
        {
            if (collection == null)
            {

            }
            if (consumer is IMeasurements measurements)
            {
                try
                {
                    var d = collection.Dictionary;
                    for (var i = 0; i < measurements.Count; i++)
                    {
                        var m = measurements[i];
                        var name = m.Name;
                        if (!d.ContainsKey(name))
                        {
                            continue;
                        }
                        if (m is IValue value)
                        {
                            var v = d[name];
                            var an = FindAliasName(consumer, v);
                            var f = new FeedbackAliasValue(value, an);
                            collection.Add(f);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.HandleException();
                }
            }

            else
            {
                throw new OwnNotImplemented(" Set(IFeedbackAliasCollection collection)");
            }
        }


        public void Fill(IFeedbackAliasCollection collection)
        {
            var holder = collection.Holder;
            if (holder is IDataConsumer consumer)
            {
                Fill(collection, consumer);
            }
            else
            {
                throw new OwnNotImplemented(" Set(IFeedbackAliasCollection collection)");
            }
        }

        /// <summary>
        /// Initial value
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="measurement">Mesurement</param>
        /// <returns>Initial value</returns>
        public IInitialValue InitialValue(IAlias alias, IMeasurement measurement)
        {
            if (measurement is  IValue measurementValue)
            {
                var attr = GetAttribute<CodeCreatorAttribute>(measurement);
                if (attr != null)
                {
                    if (attr.InitialState)
                    {
                        var an = new AliasName(alias, measurement.Name);
                        return new AliasInit(an, measurementValue);
                    }
                }
            }
            return null;
        }


        public void SetFeedBack(IMeasurements measurements)
        {
            for (int i = 0; i < measurements.Count; i++)
            {
                var m = measurements[i];
                if (m is IFeedback iv)
                {
                    iv.Set();
                }
            }
        }


        public AliasName FindAliasName(IDataConsumer consumer, string alias, bool allowNulls = false)
        {
            if (alias == null)
            {
                if (allowNulls)
                {
                    throw new OwnException("Null alias is not accepted");
                }
                return null;
            }
            IAssociatedObject ao = consumer as IAssociatedObject;
            INamedComponent nc = ao.Object as INamedComponent;
            return FindAliasName(consumer, nc.Desktop, alias);
        }

        /// <summary>
        /// Finds alias 
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">Alias name</param>
        /// <returns>Alias</returns>
        public  AliasName FindAliasName( IDataConsumer consumer,
            IDesktop desktop, string alias)
        {
            string ali = alias;
            IDesktop desk = null;
            if (ali.StartsWith("../"))
            {
                int k = ali.LastIndexOf('.');
                string n = ali.Substring(0, k);
                INamedComponent nc = PureDesktop.GetFromRoot(desktop, n);
                desk = nc.Desktop;
                k = ali.LastIndexOf("/");
                ali = ali.Substring(k + 1);
            }
            object[] o = FindAlias(consumer, desk, ali);
            if (o == null)
            {
                return null;
            }
            return new AliasName(o[0] as IAlias, o[1] as string); ;
        }


        /// <summary>
        /// Finds alias by name
        /// </summary>
        /// <param name="consumer">Data consumer</param>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">Alias name</param>
        /// <returns>Alias</returns>
        public  object[] FindAlias(IDataConsumer consumer, IDesktop desktop, string alias)
        {
            for (int i = 0; i < consumer.Count; i++)
            {
                object o = consumer[i];
                if (o is IAssociatedObject)
                {
                    IAssociatedObject ao = o as IAssociatedObject;
                    IAlias al = AliasWrapper.GetAlias(ao);
                    if (al != null)
                    {
                        if (ao.Object != null)
                        {
                            if (ao.Object is INamedComponent)
                            {
                                INamedComponent nc = ao.Object as INamedComponent;
                                string n = nc.Name;
                                IList<string> l = al.AliasNames;
                                foreach (string an in l)
                                {
                                    string s = n + "." + an;
                                    if (s.Equals(alias))
                                    {
                                        return new object[] { al, an };
                                    }
                                }
                            }
                        }
                    }
                }
                if (o is IDataConsumer)
                {
                    IDataConsumer c = o as IDataConsumer;
                    object[] r = FindAlias(c, desktop, alias);
                    if (r != null)
                    {
                        return r;
                    }
                }
            }
            return null;

        }




    }
}
