using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.CodeCreators;
using Motion6D.Interfaces;
using Motion6D.Portable.Aggregates;
using System;
using System.Collections.Generic;

namespace Motion6D.Portable.CodeCreators
{
    [Language("C#")]
    class CSCodeCreator : BaseClassCodeCreator
    {

        static string an = typeof(CSCodeCreator).Assembly.FullName;

        protected Dictionary<Func<object, bool>, Func<object, List<string>>> dict;

        internal CSCodeCreator() : base(false)
        {
           this.AddClassCodeCreator();
            dict = new()
            {
                    { (o) => { return o is ReferenceFrameData; }, CreateRefetenceFrameData },
                    { (o) => { return o is RigidReferenceFrame; } , CreateRigidReferenceFrame },
                    { (o) => { return o is MechanicalAggregateLink; } , CreateMechanicalAggregateLink },
                    { (o) => { return o is AggregableWrapper; } , CreateAggregableWrapper },
                    { (o) => { return o is ReferenceFrameArrow; } , CreateString },
                    { (o) => { return o is RelativeMeasurementsLink; } , CreateString },
                    { (o) => { return o is RelativeMeasurements; } , CreateString },
       };



        }

        #region IClassCodeCreator Members


        protected override List<string> CreateCode(string preffix, object obj, string volume)
        {
            List<string> l = new List<string>();
            foreach (var item in dict)
            {
                if (item.Key(obj))
                {
                    var t = item.Value(obj);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        #endregion

        List<string> CreateAggregableWrapper(object o)
        { 
            AggregableWrapper data = o as AggregableWrapper;
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.AggregableWrapper");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\taggregate = new MechanicalAggregate();");
            l.Add("\t\tPrepare();");
            l.Add("\t}");
            List<string> lt = new List<string>();
            IAggregableMechanicalObject agg = data.Aggregate;
            if (agg is RigidBody rb)
            {
                lt = CreateRigidBody(rb);
            }
            l.Add("\t\tinternal class MechanicalAggregate :");
            for (int i = 0; i < lt.Count; i++)
            {
                string s = lt[i];
                if (s.Contains("CategoryObject()"))
                {
                    lt[i] = s.Replace("CategoryObject()", "MechanicalAggregate()");
                    break;
                }
            }
            l.AddRange(lt);
            l.Add("");
            l.Add("}");
            return l;
        }

        List<string> CreateRigidBody(object o)
        {
            var data = o as RigidBody;
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.Aggregates.RigidBody");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tmomentOfInertia =  new double[,]");
            l.Add("\t\t{");
            data.MomentOfInertia.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            if (data.Connections != null)
            {
                l.Add("\t\tconnections =  new double[][]");
                l.Add("\t\t{");
                data.Connections.ToCodeCreator(l);
                l.Add("\t\t};");
                l.Add("");
            }
            l.Add("\t\taliasNames =  new Dictionary<int, string>()");
            l.Add("\t\t{");
            data.AliasNames.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t\tinerialAccelerationStr =  new string[]");
            l.Add("\t\t{");
            data.InertialAcceleration.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t\tforcesStr =  new string[]");
            l.Add("\t\t{");
            data.ForcesStr.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t\tmass = " + data.Mass.StringValue() + ";");
            l.Add("");
            l.Add("\t\tinitialState =  new double[]");
            l.Add("\t\t{");
            data.InitialState.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t}");
            l.Add("");
            l.Add("}");
            l.Add("");
            return l;
        }

        List<string> CreateMechanicalAggregateLink(object o)
        {
            var data = o as MechanicalAggregateLink;
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.MechanicalAggregateLink");
            int s = data.SourceConnection;
            int t = data.TargetConnection;
            l.Add("\tCategoryArrow()");
            l.Add("\t{");
            l.Add("\t\tconnection = new int[] {" + s + ", " + t +"};");
            l.Add("\t}");
            l.Add("");
            l.Add("}");
            return l;
        }

        List<string> CreateRigidReferenceFrame(object o)
        {
            var data = o as RigidReferenceFrame;
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.RigidReferenceFrame");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\trelativePosition = new double[]");
            l.Add("\t\t{");
            double[] pos = data.RelativePosition;
            pos.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
            l.Add("\t\trelativeQuaternion = new double[]");
            l.Add("\t\t{");
            double[] quaternion = data.RelativeFrame.Quaternion;
            quaternion.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("");
           // !!! DELETE  l.Add("\t\tisSerialized = true;");
            l.Add("\t\tInit();");
            l.Add("\t}");
            l.Add("");
            l.Add("}");
            l.Add("");
            return l;
        }

        List<string> CreateString(object data)
        {
            var t = data.GetType();
            string s = null;
            if (t.Assembly.FullName == an)
            {
                s = t.FullName;
            }
            else
            {
                t = t.BaseType;
                if (t.Assembly.FullName == an)
                {
                    s = t.FullName;
                }

            }
            if (s != null)
            {
                var l = new List<string>();
                l.Add(s);
                l.Add("{");
                l.Add("}");
                return l;

            }
            return null;

        }


        List<string> CreateRefetenceFrameData(object o)
        {
            var data = o as ReferenceFrameData;
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.ReferenceFrameData");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tparameters = new List<string>()");
            l.Add("\t\t{");
            List<string> par = data.Parameters;
            par.ToCodeCreator(l);
            l.Add("\t\t};");
            l.Add("\t}");
            l.Add("");
            l.Add("}");
            return l;
        }
    }
}
