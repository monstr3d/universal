using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;

namespace DataPerformer.Python.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Buttons of objects
        /// </summary>
        public static readonly ButtonWrapper[] ObjectButtons =
                new ButtonWrapper[]
                {
                     new ButtonWrapper(typeof(Wrapper.Objects.PythonTransformer),
                    "",
                    "Python transformer", Resource.Python,
                    null, true, false)
                 };

        /// <summary>
        /// Buttons of arrows
        /// </summary>
        public static readonly ButtonWrapper[] ArrowButtons = new ButtonWrapper[]
        {
        };


        /// <summary>
        /// Singleton
        /// </summary>
        //     public static readonly IUIFactory Factory = new UIFactory();

        #endregion

        #region Ctor

        internal UIFactory()
        {
            this.Add();
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            Type type = button.ReflectionType;

            /*!!! EXAMPLE            if (type.Equals(typeof(Basic.Events.ImportedEvent)))
                        {
                            return new Basic.Events.ImportedEvent(kind);
                        }
                        if (type.Equals(typeof(Basic.Data.Events.ImportedEventReader)))
                        {
                            return new Basic.Data.Events.ImportedEventReader(kind);
                        }
                        if (type.Equals(typeof(Basic.Data.Events.ImportedEventWriter)))
                        {
                            return new Basic.Data.Events.ImportedEventWriter(kind);
                        }
                        if (type.Equals(typeof(Basic.Events.ThresholdEvent)))
                        {
                            return new Basic.Events.ThresholdEvent();
                        }

                        if (type.Equals(typeof(Basic.Data.Events.ForcedEventData)))
                        {
                            if (kind.Equals("CircularControl2D"))
                            {
                                double a = 0;
                                Basic.Data.Events.ForcedEventData forcedEventData =
                                    new Basic.Data.Events.ForcedEventData();
                                forcedEventData.Types = new List<Tuple<string, object>>()
                            {
                                new Tuple<string, object>("X", a),
                                new Tuple<string, object>("Y", a)
                            };
                                forcedEventData.Initial = new object[] { a, a };
                                return forcedEventData;
                            }
                        }*/
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            string kind = button.Kind;
            if (type == typeof(Wrapper.Objects.PythonTransformer))
            {
                return (new Labels.DataPerformerLabel(type, kind, button.ButtonImage as System.Drawing.Image)).CreateLabelUI(Resource.Python, false);
            }
            // Type t = Type.GetType(kind);
            /* !!!REMOVED   if (t.Equals(typeof(Remote.RemoteEvent)))
               {
                   return
                        (new Labels.RemotingEventLabel(type, kind, 
                            button.ButtonImage as System.Drawing.Image)).CreateLabelUI(Properties.Resources.Network_Event, false);
               }
            */
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent component)
        {

            return null;
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            /* !!! EXAMPLE  if (obj is LogIterator)
              {
                  LogIterator iterator = obj as LogIterator;
                  Labels.LogIteratorLabel l = new Labels.LogIteratorLabel();
                  l.Object = obj;
                  return l.CreateLabelUI(Properties.Resources.logIterator.ToBitmap(), false);
              }*/
            return null;
        }

        #endregion

    }

}
