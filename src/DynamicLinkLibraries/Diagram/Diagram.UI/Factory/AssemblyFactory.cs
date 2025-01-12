using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;

namespace Diagram.UI.Factory
{
    /// <summary>
    /// Factory those is an assembly of factories
    /// </summary>
    public class AssemblyFactory : IUIFactory
    {
        #region Fields

        /// <summary>
        /// Factories
        /// </summary>
        protected IUIFactory[] factories;

        /// <summary>
        /// Default value sign
        /// </summary>
        protected bool defaultValue;

        /// <summary>
        /// Tools
        /// </summary>
        protected IToolsDiagram tools;

        /// <summary>
        /// Default factory
        /// </summary>
        protected IDefaultLabelFactory factory;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factories">Factories</param>
        /// <param name="defaultValue">The "Default Form" sign</param>
        public AssemblyFactory(IUIFactory[] factories, bool defaultValue)
        {
            factory = StaticExtensionDiagramUIFactory.Factory;
            this.factories = factories;
            this.defaultValue = defaultValue;
            foreach (IUIFactory f in factories)
            {
                f.Parent = this;
            }
        }

        #endregion

        #region IUIFactory Members

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public virtual ICategoryObject CreateObject(IPaletteButton button)
        {
            foreach (IUIFactory f in factories)
            {
                ICategoryObject o = f.CreateObject(button);
                if (o != null)
                {
                    return o;
                }
            }
            if (defaultValue)
            {
                Type t = button.ReflectionType;
                string kind = button.Kind;
                if (t != null)
                {
                    if (kind.Length > 0) // Kind or additional parameter
                    {
                        // Searches constructor from string
                        ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(string) });
                        if (ci != null)
                        {
                            // Creates an object
                            ICategoryObject ob = ci.Invoke(new object[] { kind }) as ICategoryObject;
                            if (ob is ISeparatedAssemblyEditedObject)
                            {
                                ISeparatedAssemblyEditedObject sa = ob as ISeparatedAssemblyEditedObject;
                                if (sa.AssemblyBytes == null)
                                {
                                    sa.FirstLoad();
                                }
                            }
                            return ob; // returns the object
                        }
                    }
                    if (t.Equals(typeof(ObjectsCollection)))
                    {
                        string s = button.Kind;
                        Type to = Type.GetType(s, true, false);
                        return new ObjectsCollection(to);
                    }
                    if (t.GetInterface(typeof(IObjectFactory).ToString()) != null)
                    {
                        IObjectFactory of = null;
                        FieldInfo fi = t.GetField("Object");
                        if (fi != null)
                        {
                            of = fi.GetValue("Object") as IObjectFactory;
                        }
                        else
                        {
                            of = t.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IObjectFactory;
                        }
                        return of[kind];
                    }
                    ConstructorInfo cons = t.GetConstructor(new Type[0]);
                    if (cons != null)
                    {
                        ICategoryObject ob = cons.Invoke(null) as ICategoryObject;
                        if (ob is ISeparatedAssemblyEditedObject)
                        {
                            ISeparatedAssemblyEditedObject sa = ob as ISeparatedAssemblyEditedObject;
                            if (sa.AssemblyBytes == null)
                            {
                                sa.FirstLoad();
                            }
                        }
                        return ob;
                    }

                }
            }
            return null;
        }

        /// <summary>
        /// Creates an arrow the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created arrow</returns>
        public virtual ICategoryArrow CreateArrow(IPaletteButton button)
        {
            foreach (IUIFactory f in factories)
            {
                ICategoryArrow a = f.CreateArrow(button);
                if (a != null)
                {
                    return a;
                }
            }
            if (defaultValue)
            {
                Type t = button.ReflectionType;
                if (t != null)
                {
                    ConstructorInfo cons = t.GetConstructor(new System.Type[0]);
                    if (cons != null)
                    {
                        return cons.Invoke(null) as ICategoryArrow;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The result form</returns>
        public virtual object CreateForm(INamedComponent comp)
        {
            foreach (IUIFactory f in factories)
            {
                object form = f.CreateForm(comp);
                if (form != null)
                {
                    return form;
                }
            }
            if (defaultValue)
            {
              StaticExtensionDiagramUIFactory.Factory.CreateDefaultForm(comp);
            }
            object o = null;
            if (comp is IObjectLabel)
            {
                o = (comp as IObjectLabel).Object;
            }
            else if (comp is IArrowLabel)
            {
                o = (comp as IArrowLabel).Arrow;
            }
            if (o is IPropertiesEditor)
            {
                object ob = (o as IPropertiesEditor).Editor;
                if (ob is object[])
                {
                    return (o as object[])[0];
                }
                return ob;
            }
            return null;
        }



        /// <summary>
        /// Creates arrow label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <param name="arrow">Corresponding arrow</param>
        /// <param name="source">Soource label</param>
        /// <param name="target">Target label</param>
        /// <returns>The arrow label</returns>
        public virtual IArrowLabelUI CreateArrowLabel(IPaletteButton button, ICategoryArrow arrow, IObjectLabel source, IObjectLabel target)
        {
            foreach (IUIFactory f in factories)
            {
                IArrowLabelUI a = f.CreateArrowLabel(button, arrow, source, target);
                if (a != null)
                {
                    return a;
                }
            }
            if (defaultValue)
            {
                return factory.CreateArrowLabel(button, arrow, source, target);
            }
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public virtual IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            try
            {
                foreach (IUIFactory f in factories)
                {
                    IObjectLabelUI o = f.CreateObjectLabel(button);
                    if (o != null)
                    {
                        return o;
                    }
                }
                if (defaultValue)
                {
                    return factory.CreateObjectLabel(button);
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
            return null;
        }

  


        /// <summary>
        /// Tools
        /// </summary>
        public virtual IToolsDiagram Tools
        {
            set
            {
                tools = value;
            }
        }

        /// <summary>
        /// Gets button from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The button</returns>
        public virtual IPaletteButton GetObjectButton(ICategoryObject obj)
        {
            foreach (IUIFactory f in factories)
            {
                IPaletteButton b = f.GetObjectButton(obj);
                if (b != null)
                {
                    return b;
                }
            }
            if (defaultValue)
            {

            }
            return null;
        }

        /// <summary>
        /// Gets button from arrow
        /// </summary>
        /// <param name="arrow">The arrow</param>
        /// <returns>The arrow</returns>
        public virtual IPaletteButton GetArrowButton(ICategoryArrow arrow)
        {
            foreach (IUIFactory f in factories)
            {
                IPaletteButton b = f.GetArrowButton(arrow);
                if (b != null)
                {
                    return b;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks order of desktop and throws exception if order is illegal
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public virtual void CheckOrder(IDesktop desktop)
        {
            foreach (IUIFactory f in factories)
            {
                f.CheckOrder(desktop);
            }
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public virtual IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            foreach (IUIFactory f in factories)
            {
                IObjectLabelUI o = f.CreateLabel(obj);
                if (o != null)
                {
                    return o;
                }
            }
            if (defaultValue)
            {
                IObjectLabelUI o = factory.CreateObjectLabel(obj);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// Crerates arrow label from arrow
        /// </summary>
        /// <param name="arr">The arrow</param>
        /// <returns>The label</returns>
        public virtual IArrowLabelUI CreateLabel(ICategoryArrow arr)
        {
            foreach (IUIFactory f in factories)
            {
                IArrowLabelUI a = f.CreateLabel(arr);
                if (a != null)
                {
                    return a;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets additional feature
        /// </summary>
        /// <typeparam name="T">Feature type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Feature</returns>
        public virtual object GetAdditionalFeature<T>(T obj)
        {
            foreach (IUIFactory f in factories)
            {
                object o = f.GetAdditionalFeature<T>(obj);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// Parent factory
        /// </summary>
        public IUIFactory Parent
        {
            get
            {
                return null;
            }
            set
            {
            }
        }



        #endregion

        #region Specific Members

        /// <summary>
        /// Adds a factory
        /// </summary>
        /// <param name="factory">The factory to add</param>
        public void Add(IUIFactory factory)
        {
            List<IUIFactory> l = new List<IUIFactory>(factories);
            l.Add(factory);
            factories = l.ToArray();
        }

        /// <summary>
        /// Label factory
        /// </summary>
        public IDefaultLabelFactory LabelFactory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        #endregion
    }
}
