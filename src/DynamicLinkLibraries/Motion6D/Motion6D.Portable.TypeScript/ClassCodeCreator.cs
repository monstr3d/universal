using BaseTypes.Attributes;
using CategoryTheory;
using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using Motion6D.Interfaces;
using Motion6D.Portable.TypeScript.Interfaces;
using NamedTree.Interfaces;

namespace Motion6D.Portable.TypeScript
{
    [Language("TS")]
    public class ClassCodeCreator : DataPerformer.Portable.TypeScript.ClassCodeCreator, ICreateSuffix,
        IChildrenCodeCreator
    {
        IPositionCodeFactory factory;

        protected virtual ICreateSuffix CreateSuffix { get; set; } 

        IDesktopCodeCreator IChildrenCodeCreator.DesktopCodeCreator
        {
            get => DesktopCodeCreator;
            set { }
        }



        protected ClassCodeCreator(bool b) : base(b) 
        { 
        
        
        }



        internal ClassCodeCreator(IPositionCodeFactory factory) : base(true)
        {
            ChildrenCodeCreator = this;
            CreateSuffix = this;

            this.factory = factory;
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                      { (object o) => { return o.GetType().Name.Contains("RigidReferenceFrame"); } , CreateReferenceFrame },
                      { (object o) => { return o is ReferenceFrameArrow; } , CreateReferenceFrameArrow },
                      { (object o) => { return o is VisibleConsumerLink;  } , CreateVisibleCosumerLink },
                  { (object o) => { return o is ReferenceFrameData; } , CreateReferenceFrameData},
                  { (object o) => { return o is Camera; } , CreateCamera},
                          { (object o) => { return o is SerializablePosition; } , CreateSerializablePosition},
    };


            this.AddClassCodeCreator();
        }

        protected override  List<string> CreateCode(string prefix, object obj, string volume)
        {
            if (factory != null)
            {
                var t = factory.CreateCode(prefix, obj, volume);
                if (t != null) { return t; }
            }
            return base.CreateCode(prefix, obj, volume);
        }


        List<string> CreateReferenceFrame(string preffix, object obj)
        {
            var l = new List<string>();
            var frame = obj as RigidReferenceFrame;
            var s = performer.ClassString(preffix, "RigidReferenceFrame");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t\tthis.relativePosition = []");
            l.Add("\t\tthis.relativeQuaternion = []");
            var ll = Get("relativePosition", frame.RelativePosition);
            Add(l, ll, 1);
            ll = Get("relativeQuaternion", frame.RelativeQuaternion);
            Add(l, ll, 1);
            l.Add("\t}");
            l.Add("}");
            return l;
        }


        List<string> CreateReferenceFrameData(string preffix, object obj)
        {

            var l = new List<string>();
            var frame = obj as ReferenceFrameData;
            var s = performer.ClassString(preffix, "ReferenceFrameData");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var ll = Get("this.parametersList", frame.Parameters);
            Add(l, ll, 0);
            l.Add("\t}");
            l.Add("}");
            return l;
        }

        protected virtual string CreateSuffixProtected(object obj)
        {
            if (obj is IVisible)
            {
                return "_Visible";
            }
            return null;

        }

        string ICreateSuffix.CreateSuffix(object obj)
        {
            return CreateSuffixProtected(obj);
        }


        List<string> CreateSerializablePosition(string preffix, object obj)
        {
            var l = new List<string>();
            var sp = obj as SerializablePosition;
            var ll = ChildrenCodeCreator.CreateChildren(preffix, sp, "");
            l.AddRange(ll);
            var s = performer.ClassString(preffix, "SerializablePosition");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            ll = ChildrenCodeCreator.InsertChidren(preffix, sp, "");
            l.AddRange(ll);
            l.Add("\t}");
            l.Add("}");
            return l;
        }


        List<string> CreateCamera(string preffix, object obj)
        {
            var l = new List<string>();
            var c = obj as Camera;
            var fov = DoubleToString(c.FieldOfView);
            var nd = DoubleToString(c.NearPlaneDistance);
            var fd = DoubleToString(c.FarPlaneDistance);
            var s = performer.ClassString(preffix, "BasicCamera");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t\tthis.fieldOfView = " + fov);
            l.Add("\t\tthis.nearDistance = " + nd);
            l.Add("\t\tthis.farDistance = " + fd);
            l.Add("\t}");
            l.Add("}");
            return l;
        }
 
        List<string> CreateReferenceFrameArrow(string preffix, object obj)
        {
            return CreatePure(preffix, "ReferenceFrameArrow");
        }

        List<string> CreateVisibleCosumerLink(string preffix, object obj)
        {
            return CreatePure(preffix, "VisibleConsumerLink");
        }

        List<string> IChildrenCodeCreator.CreateChildren(string prefix, IChildren<ICategoryObject> obj, string volume)
        {
            var l = new List<string>();
            var children = obj.Children;
            int i = 0;
            foreach (var child in children)
            {
                if (DesktopCodeCreator.Loaded.ContainsKey(child))
                {
                    continue;
                }
                var pr = prefix + CreateSuffix.CreateSuffix(child) + i;
                ++i;
                l.AddRange(GetChild(pr, child));
                l.Add("");
                DesktopCodeCreator.Loaded[child] = pr;
            }
            return l;
        }

        List<string> IChildrenCodeCreator.InsertChidren(string prefix, IChildren<ICategoryObject> obj, string volume)
        {
            return InsertChildren(prefix, obj, volume);
        }

        protected virtual List<string> InsertChildren(string prefix, IChildren<ICategoryObject> obj, string volume)
        {
            var l = new List<string>();
            var children = obj.Children;
            int i = 0;
            var name = "\"" + performer.GetName(obj as ICategoryObject) + "\"";
            foreach (var child in children)
            {
                var pr = prefix + CreateSuffix.CreateSuffix(child) + i;
                ++i;
                l.Add("\t\tthis.addChildT(new " + pr + "(desktop, name))");
            }
            return l;
        }

        Dictionary<string, string> types = new Dictionary<string, string>()
        {
            { ".obj", "text"},
              { ".mtl", "text"},
                  { ".jpg", "image"},
                  { ".png", "image"},
    };

        List<string> GetChild(string prefix, ICategoryObject obj)
        {
            var name = obj.Name; 
            var l = new List<string>();
             var s = performer.ClassString(prefix, "Basic3DShape");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            if (obj is ISaveGrahicalData save)
            {
                //l.Add("\t\tlet map = this.getSaveGrahicalData()");
                var d = save.GetGraphicalData("");
                foreach (var item in d)
                {
                    var v = Path.Combine(name, item.Value);
                    var ext = Path.GetExtension(v);
                    var type = "\"" + types[ext] + "\"";
                    var url = "\"" + v.Replace('\\', '/') + "\"";
                    var key = "\"" + item.Key + "\"";
                    ext = "\"" + ext + "\"";
                    var n = "\"" + item.Value + "\"";
                    l.Add("\t\tthis.addResource(" + n + ", " + url + ", " + type + ", " + ext + ")");
                }
            }
            l.Add("\t}");
            l.Add("}");
            return l;
        }

    

        /*
        protected override List<string> CreateProperties(string prefix, object obj, string volume)
        {
            if (factory is IPropertiesCodeCreator pr)
            {
                var pp = pr.CreateProperties(prefix, obj, volume);
                if (pp != null)
                {
                    return pp;
                }
            }
            return base.CreateProperties (prefix, obj, volume);    
        }*/
        /*
        protected override List<string> CreateParameters(string prefix, object parent, object obj, string volume)
        {
            if (factory is IParametersCodeCreator pr)
            {
                pr.DesktopCodeCreator = DesktopCodeCreator;
                var pp = pr.CreateParameters(prefix, parent, obj, volume);
                if (pp != null) 
                {
                    return pp;
                }
            }
            return base.CreateParameters(prefix, parent, obj, volume);
        }

        protected override List<string> SetParameters(string prefix, object parent, object obj, string volume)
        {
            if (factory is IParametersCodeCreator pr)
            {
                var pp = pr.SetParameters(prefix,  parent, obj, volume);
                if (pp != null)
                {
                    return pp;
                }
            }
            return base.SetParameters(prefix, parent, obj, volume);
        }

        protected override List<string> SetProperties(string prefix, object obj, string volume)
        {
            if (factory is IPropertiesCodeCreator pr)
            {
                var pp = pr.SetProperties(prefix, obj, volume);
                if (pp != null)
                {
                    return pp;
                }
            }
            return base.SetProperties(prefix, obj, volume);
        }
        */




    }
}
