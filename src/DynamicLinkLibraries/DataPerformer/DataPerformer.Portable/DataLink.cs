using System;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;
using ErrorHandler;
using NamedTree;


namespace DataPerformer.Portable
{

    /// <summary>
    /// The link between data provider and data consumer
    /// </summary>
    public class DataLink : ICategoryArrow,
        IDisposable, IDataLinkFactory
    {

        #region Fields

        /// <summary>
        /// Error message
        /// </summary>
        public static readonly string SetProviderBefore = "You should create measurements source before consumer";

        /// <summary>
        /// DataLink checker
        /// </summary>
        protected static Action<DataLink> checker;

        /// <summary>
        /// The source of this arrow
        /// </summary>
        protected IDataConsumer source;

        /// <summary>
        /// The target of this arrow
        /// </summary>
        protected IMeasurements target;


        /// <summary>
        /// Linked object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Data link factory
        /// </summary>
        protected static IDataLinkFactory dataLinkFactory;// = new DataLink();

        protected MeasurementsWrapper mv = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataLink()
        {
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static DataLink()
        {
            dataLinkFactory = new DataLink();
        }

        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Source
        {
            set
            {
                if (source != null)
                {
                    throw new OwnException("Data link source null");
                }
                IDataLinkFactory f = this;
                source = f.GetConsumer(value);
            }
            get
            {
                return source as ICategoryObject;
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                if (target != null)
                {
                    throw new OwnException("Data link targret null");
                }
                IDataLinkFactory f = this;
                IMeasurements t = f.GetMeasurements(value);
                if (t is MeasurementsWrapper)
                {
                    mv = t as MeasurementsWrapper;
                }
                bool check = true;
                IAssociatedObject s = source as IAssociatedObject;
                if (s.Object != null & value.Object != null)
                {
                    if (check)
                    {
                        INamedComponent ns = s.Object as INamedComponent;
                        INamedComponent nt = value.Object as INamedComponent;
                        if (nt != null & ns != null)
                        {
                            if (nt.GetDifference(ns) >= 0)
                            {
                                throw new OwnException(SetProviderBefore);
                            }
                        }
                    }
                    source.AddChild(t);
                    target = value as IMeasurements;
                }
                if (!check)
                {
                    return;
                }
                try
                {
                    if (checker != null)
                    {
                        checker(this);
                    }
                }
                catch (Exception e)
                {
                    e.HandleException(10);
                    source.RemoveChild(target);
                    throw e;
                }
            }
        }


        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// The post remove operation
        /// </summary>
        void IDisposable.Dispose()
        {
            if (source == null | target == null)
            {
                return;
            }
            if (mv != null)
            {
                source.RemoveChild(mv);
                return;
            }
            source.RemoveChild(target);
        }

        #endregion

        #region IDataLinkFactory Members

        IDataConsumer IDataLinkFactory.GetConsumer(ICategoryObject source)
        {
            if (source is IDataConsumer)
            {
                return source as IDataConsumer;
            }
         /*   if (source is IChildrenObject)
            {
                IDataConsumer dcc = (source as IChildrenObject).GetChildren<IDataConsumer>();
                if (dcc != null)
                {
                    return dcc;
                }
            }*/
            IAssociatedObject ao = source;
            object o = ao.Object;
            if (o is INamedComponent)
            {
                IDataConsumer dcl = null;
                INamedComponent comp = o as INamedComponent;
                IDesktop desktop = comp.Root.Desktop;
                desktop.ForEach((DataLink dl) =>
                {
                    if (dcl != null)
                    {
                        return;
                    }
                    object dt = dl.Source;
                    if (dt is IAssociatedObject)
                    {
                        IAssociatedObject aot = dt as IAssociatedObject;
                        if (aot.Object == o)
                        {
                            dcl = dl.source as IDataConsumer;
                        }
                    }
                });
               
                if (dcl != null)
                {
                    return dcl;
                }
            }

            IDataConsumer dc = DataConsumerWrapper.Create(source);
            if (dc == null)
            {
                CategoryException.ThrowIllegalTargetException();
            }
            return dc;
        }

        IMeasurements IDataLinkFactory.GetMeasurements(ICategoryObject target)
        {
            try
            {
                IAssociatedObject ao = target;
                object o = ao.Object;
                if (o is INamedComponent)
                {
                    IMeasurements ml = null;
                    INamedComponent comp = o as INamedComponent;
                    IDesktop d = null;
                    INamedComponent r = comp.Root;
                    if (r != null)
                    {
                        d = r.Desktop;
                    }
                    else
                    {
                        d = comp.Desktop;
                    }
                    if (d != null)
                    {
                        d.ForEach((DataLink dl) =>
                        {
                            if (ml != null)
                            {
                                return;
                            }
                            object dt = dl.Target;
                            if (dt is IAssociatedObject)
                            {
                                IAssociatedObject aot = dt as IAssociatedObject;
                                if (aot.Object == o & (!(aot is IChildren<IAssociatedObject>)))
                                {
                                    ml = dl.Target as IMeasurements;
                                }
                            }
                        });
                        if (ml != null)
                        {
                            return ml;
                        }
                    }
                }
                IMeasurements m = MeasurementsWrapper.Create(target);
                if (m == null)
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                return m;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Data link. Get measurements");
            }
            return null;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Checker of data link
        /// </summary>
        public static Action<DataLink> Checker
        {
            set
            {
                checker = value;
            }
        }

        /// <summary>
        /// Data link factory
        /// </summary>
        public static IDataLinkFactory DataLinkFactory
        {
            get
            {
                return dataLinkFactory;
            }
            set
            {
                dataLinkFactory = value;
            }
        }


        /// <summary>
        /// Target
        /// </summary>
        public IMeasurements Target
        {
            get => target;
        }

        /// <summary>
        /// Source
        /// </summary>
        public IDataConsumer Source
        {
            get => source;
        }

        #endregion

    }

}

