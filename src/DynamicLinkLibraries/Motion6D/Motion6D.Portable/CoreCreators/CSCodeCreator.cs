using System.Collections.Generic;

using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Motion6D.Interfaces;
using Motion6D.Portable.Aggregates;

namespace Motion6D.Portable.CoreCreators
{
    [Language("C#")]

    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCodeCreator();
        }

        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            List<string> l = new List<string>();
            string name = obj.GetType().FullName;
            string str = null;
            if (obj is ReferenceFrameDataBase)
            {
                if (name.Contains("ReferenceFrameDataBase") | name.Contains("Motion6D.ReferenceFrameData"))
                {
                    return CreateRefetenceFrameData(obj as ReferenceFrameDataBase);
                }
            }
            if (obj is RigidReferenceFrame)
            {
                if (name.Contains("RigidReferenceFrame"))
                {
                    return CreateRigidReferenceFrame(obj as RigidReferenceFrame);
                }
            }
            if (obj is ReferenceFrameArrow)
            {
                str = "Motion6D.Portable.ReferenceFrameArrow";
            }
            if (obj is RelativeMeasurementsLink)
            {
                str = "Motion6D.Portable.RelativeMeasurementsLink";
            }
            if (obj is RelativeMeasurements)
            {
                str = "Motion6D.Portable.RelativeMeasurements";
            }
            if (obj is MechanicalAggregateLink)
            {
                return CreateMechanicalAggregateLink(obj as MechanicalAggregateLink);
            }
            if (obj is AggregableWrapper)
            {
                return CreateAggregableWrapper(obj as AggregableWrapper);
            }
            if (str == null)
            {
                return null;
            }
            l.Add(str);
            l.Add("{");
            l.Add("}");
            return l;
        }

        #endregion

        List<string> CreateAggregableWrapper(AggregableWrapper data)
        {
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

        List<string> CreateRigidBody(RigidBody data)
        {
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

        List<string> CreateMechanicalAggregateLink(MechanicalAggregateLink data)
        {
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

        List<string> CreateRigidReferenceFrame(RigidReferenceFrame data)
        {
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



        List<string> CreateRefetenceFrameData(ReferenceFrameDataBase data)
        {
            List<string> l = new List<string>();
            l.Add("Motion6D.Portable.ReferenceFrameDataBase");
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
