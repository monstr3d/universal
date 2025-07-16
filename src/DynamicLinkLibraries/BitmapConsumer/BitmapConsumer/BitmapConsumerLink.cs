using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using ErrorHandler;
using NamedTree;

namespace BitmapConsumer
{
    /// <summary>
    /// Link between bitmap consumer and bitmap provider
    /// </summary>
    [Serializable()]
    public class BitmapConsumerLink : CategoryArrow, IDisposable, ISerializable
    {
        #region Fields

        /// <summary>
        /// Error message
        /// </summary>
        static public readonly string ProviderExists = "Bitmap provider already exists";
        
        /// <summary>
        /// Error message
        /// </summary>
        public static readonly string SetProviderBefore = "You should create bitmap provider before consumer";

 
        /// <summary>
        /// Auxiliary variable
        /// </summary>
        private int a = 0;

        /// <summary>
        /// Source
        /// </summary>
        private IBitmapConsumer source;

        /// <summary>
        /// Target
        /// </summary>
        private IBitmapProvider target;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BitmapConsumerLink()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BitmapConsumerLink(SerializationInfo info, StreamingContext context)
        {
            info.GetValue("A", typeof(int));
        }

        #endregion
         
        #region ICategoryArrow Members

        public override ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetSource<IBitmapConsumer>();
            }
        }

        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IBitmapProvider>();
                source.Add(target);
             }
        }


        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (source != null & target != null)
            {
                source.Remove(target);
            }
  /*              IBitmapConsumer s = AssociatedSource;
                if (s != null)
                {
                    s.Remove(target);
                }
                if (source is IAssociatedObject)
                {
                   IAssociatedObject ao = source as IAssociatedObject;
                   object o = ao.Object;
                   if (o is IBitmapConsumer)
                   {
                       (o as IBitmapConsumer).Remove(target);
                   }
                }
            }*/
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("A", a);
        }

        #endregion

        #region Specific Members



        /// <summary>
        /// Updates consumer
        /// </summary>
        /// <param name="consumer">Consumer</param>
        public static void Update(IBitmapConsumer consumer)
        {
            IEnumerable<IBitmapProvider> providers = consumer.Providers;
            foreach (IBitmapProvider provider in providers)
            {
                if (provider is IBitmapConsumer)
                {
                    IBitmapConsumer c = provider as IBitmapConsumer;
                    Update(c);
                }
            }
            consumer.Process();
        }

        /// <summary>
        /// Gets provider for consumer
        /// </summary>
        /// <param name="provider">Provider</param>
        /// <param name="consumer">Consumer</param>
        /// <param name="mutipleProviders">The multiple providers flag</param>
        /// <returns>The provider</returns>
        public static IBitmapProvider GetProvider(IBitmapProvider provider, IBitmapConsumer consumer, bool mutipleProviders)
        {
            if (provider == null)
            {
                return null;
            }
            if (!mutipleProviders)
            {
                if ((provider != null) & consumer.Providers != null)
                {
                   // throw new Excep tion("Bitmap provider already exists");
                }
            }
            ICategoryObject t = provider as ICategoryObject;
            ICategoryObject s = consumer as ICategoryObject;
            if (s.Object != null & t.Object != null)
            {
                INamedComponent ns = s.Object as INamedComponent;
                INamedComponent nt = t.Object as INamedComponent;
                if (nt != null & ns != null)
                {
                    if (nt.Desktop == ns.Desktop)
                    {
                        if (nt.Ord >= ns.Ord)
                        {
                            throw new OwnException(SetProviderBefore);
                        }
                    }
                    else
                    {
                        if (nt.Root.Ord >= ns.Root.Ord)
                        {
                            throw new OwnException(SetProviderBefore);
                        }
                    }
                }
            }
            return provider;
        }

        #endregion

        #region Private

        IBitmapConsumer AssociatedSource
        {
            get
            {
                if (source == null)
                {
                    return null;
                }
                if (source is IAssociatedObject)
                {
                    IAssociatedObject ao = source as IAssociatedObject;
                    object o = ao.Object;
                    if (o is IBitmapConsumer)
                    {
                        return o as IBitmapConsumer;
                    }
                }
                return null;
            }
 
        }

        #endregion

        /*!!!FICTION
        void Fiction()
        {
            IBitmapProvider provider = null;
            IBitmapConsumer consumer = null;
            BitmapConsumerLink link = new BitmapConsumerLink();
            link.Source = provider as ICategoryObject;
            link.Target = consumer as ICategoryObject;

            consumer.Add(provider);

        }*/

    }
}
