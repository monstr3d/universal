using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;

using Event.Interfaces;
using Event.Portable;

namespace Event.UI.Factory
{
    /// <summary>
    /// Event UI Factory
    /// </summary>
    public class UIFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Buttons of objects
        /// </summary>
        public static readonly ButtonWrapper[] ObjectButtons =
                new ButtonWrapper[] 
                {
                     new ButtonWrapper(typeof(Basic.Events.Timer),
                    "", 
                    "Timer event", Properties.Resources.Clock.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Events.EventCollection),
                    "", 
                    "Collection of events", Properties.Resources.EventCollection.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Events.ForcedEvent),
                    "", 
                    "Forced event", Properties.Resources.Alert.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Data.Events.ForcedEventData),
                    "", 
                    "Forced data event", Properties.Resources.Joystick, 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Events.ThresholdEvent),
                    "",
                    "Threshold event", Properties.Resources.Threshold.ToBitmap(),
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Data.Events.ForcedEventData),
                    "CircularControl2D", 
                    "Forced data event + circular control", Properties.Resources.JoystickCircular, 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Events.TransientProcessEvent),
                    "", 
                    "Transient process event", Properties.Resources.EventTransient, 
                    null, true, false),
                  new ButtonWrapper(typeof(Basic.Events.ImportedEvent),
                    "Event.Remote.RemoteEvent,Event.Remote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", 
                    "Remoting event", Properties.Resources.Network_Event.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Data.Events.ImportedEventReader),
                    "Event.Data.Remote.Client,Event.Data.Remote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", 
                    "Remoting event data", Properties.Resources.Network_Event_Data.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Data.Events.ImportedEventWriter),
                    "Event.Data.Remote.Server,Event.Data.Remote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", 
                    "Data server", Properties.Resources.SeverEvent.ToBitmap(), 
                    null, true, false),
                    new ButtonWrapper(typeof(Basic.Data.LogHolder), "", "Saved log",
                       Properties.Resources.log, null, true, false),
                      new ButtonWrapper(typeof(Basic.Data.LogIterator), "", "Log iterator",
                       Properties.Resources.logIterator, null, true, false)
              };
    
           /// <summary>
        /// Buttons of arrows
        /// </summary>
        public static readonly ButtonWrapper[] ArrowButtons = new ButtonWrapper[]
        {
                      new ButtonWrapper(typeof(Basic.Arrows.EventLink),
                    "", 
                    "Event Link", Properties.Resources.EventLink.ToBitmap(), 
                    null, true, true)
      };


        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly IUIFactory Factory = new UIFactory();

        #endregion

        #region Ctor

        private UIFactory()
        {
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
            string kind = button.Kind;
            if (type.Equals(typeof(Basic.Events.ImportedEvent)))
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
            }
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
            if (type.Equals(typeof(Basic.Events.ImportedEvent)))
            {
                Type t = Type.GetType(kind);
             /* !!!REMOVED   if (t.Equals(typeof(Remote.RemoteEvent)))
                {
                    return
                         (new Labels.RemotingEventLabel(type, kind, 
                             button.ButtonImage as System.Drawing.Image)).CreateLabelUI(Properties.Resources.Network_Event, false);
                }
             */
            }
            if (type.Equals(typeof(Basic.Data.Events.ImportedEventReader)))
            {
                return  
                       (new Labels.ImportedEventReaderLabel(type, kind, 
                           button.ButtonImage as System.Drawing.Image)).CreateLabelUI(Properties.Resources.Network_Event, false);
            }
            if (type.Equals(typeof(Basic.Data.Events.ImportedEventWriter)))
            {
                return (new Labels.ImportedEventWriterLabel(type, kind, 
                    button.ButtonImage as System.Drawing.Image)).CreateLabelUI(Properties.Resources.Network_Event, false);
            }
            if (type.Equals(typeof(Basic.Events.ForcedEvent)))
            {
                return
                    (new Labels.ForcedEventLabel(type,
                        kind, button.ButtonImage as System.Drawing.Image)).CreateLabelUI(button.ButtonImage, false);
            }
            if (type.Equals(typeof(Basic.Events.ThresholdEvent)))
            {
                return
                    (new Labels.ThresholdEventLabel(type,
                        kind, button.ButtonImage as System.Drawing.Image)).CreateLabelUI(button.ButtonImage, false);
            }
            if (type.Equals(typeof(Basic.Events.Timer)))
            {
                      return (new Labels.TimerLabel(type, kind, 
                            button.ButtonImage as System.Drawing.Image)).CreateLabelUI(
                            Properties.Resources.Clock,  true);
              
            }
            if (type.Equals(typeof(Basic.Data.Events.ForcedEventData)))
            {
             
                /*if (kind.Equals("CircularControl2D"))
                {
                   return (new Labels.Circular2DControlLabel()).CreateLabelUI(
                        button.ButtonImage,
                          false);
                }*/
               return
                    (new Labels.ForcedEventDataLabel(
                        type, kind, button.ButtonImage as 
                        System.Drawing.Image)).CreateLabelUI(button.ButtonImage, 
                        false);
            }
            if (type.Equals(typeof(Basic.Events.TransientProcessEvent)))
            {
                return (new Labels.TransientProcessEventLabel()).CreateLabelUI(button.ButtonImage,
                    false);

            }
            if (type.Equals(typeof(Basic.Data.LogHolder)))
            {
                return (new Labels.LogLabel()).CreateLabelUI(button.ButtonImage,
                    true);

            }
            if (type.Equals(typeof(Basic.Data.LogIterator)))
            {
                return (new Labels.LogIteratorLabel()).CreateLabelUI(button.ButtonImage,
                    true);

            }
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent component)
        {
            if (component is IObjectLabel)
            {
                IObjectLabel lab = component as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is ITimerEvent)
                {
                    ITimerEvent timer = obj as ITimerEvent;
                    return new Forms.FormTimer(obj as ITimerEvent);
                }
            }
            return null;
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            if (obj is LogIterator)
            {
                LogIterator iterator = obj as LogIterator;
                Labels.LogIteratorLabel l = new Labels.LogIteratorLabel();
                (l as IObjectLabel).Object = obj;
                return l.CreateLabelUI(Properties.Resources.logIterator.ToBitmap(), false);
            }
            return null;
        }

        #endregion

    }
}
