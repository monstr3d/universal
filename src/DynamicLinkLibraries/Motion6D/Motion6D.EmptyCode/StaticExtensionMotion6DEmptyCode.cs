using AssemblyService.Attributes;
using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Motion6D.Portable;
using Motion6D.Portable.Interfaces;
using static Motion6D.EmptyCode.StaticExtensionMotion6DEmptyCode;

namespace Motion6D.EmptyCode
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public class StaticExtensionMotion6DEmptyCode
    {
        static StaticExtensionMotion6DEmptyCode()
        {
            var a = Allow.Instance;
            var p = CodeCreator.Instance;
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        internal class Allow : ISpecificCodeCreator
        {
            static internal readonly ISpecificCodeCreator Instance = new Allow();

            private Allow()
            {
                this.Add();
            }

            bool ISpecificCodeCreator.Allow(IAllowCodeCreation allow)
            {
                if (allow is Camera)
                {
                    return true;
                }
                if (allow is SerializablePosition sp)
                {
                    var p = sp.Parameters;
                    if (p is ICameraConsumer)
                    {
                        return true;
                    }
                }
                if (allow is VisibleConsumerLink)
                {
                    return true;
                }
                return false;
            }
        }

        internal class CodeCreator : IClassCodeCreator
        {
            static internal readonly IClassCodeCreator Instance = new CodeCreator();

            private CodeCreator()
            {
                this.AddCSharpCodeCreator();
            }

            List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
            {
                if (!(obj is IAllowCodeCreation))
                {
                    return null;
                }
                if (!Allow.Instance.Allow(obj as IAllowCodeCreation))
                {
                    return null;
                }
                List<string> l = new();
                if (obj is Camera)
                {
                    string str = "Motion6D.Portable.EmptyCamera";
                    l.Add(str);
                    l.Add("{");
                    l.Add("\tinternal CategoryObject()");
                    l.Add("\t{");
                    l.Add("");
                    l.Add("\t}");
                    l.Add("}");
                    return l;
                }
                if (obj is VisibleConsumerLink)
                {
                    string str = "Motion6D.Portable.VisibleConsumerLink";
                    l.Add(str);
                    l.Add("{");
                    l.Add("\tinternal CategoryObject()");
                    l.Add("\t{");
                    l.Add("");
                    l.Add("\t}");
                    l.Add("}");
                    return l;
                }
                if (obj is SerializablePosition sp)
                {
                    var str = "Motion6D.Portable.SerializablePosition";
                    l.Add("{");
                    l.Add("\tinternal CategoryObject()");
                    l.Add("\t{");
                    var p = sp.Parameters;
                    if (p is ICameraConsumer)
                    {
                        l.Add("\t\tParameters = new  Motion6D.Portable.EmptyComeraConsumer();");
                    }
                    l.Add("\t}");
                    l.Add("}");
                    return l;
                }
                return l;
            }
        }
    }
}