using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Motion6D.Portable.CoreCreators
{
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCSharpCodeCreator();
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
            if (obj is MechanicalAggregateLink)
            {
                return CreateMechanicalAggregateLink(obj as MechanicalAggregateLink);
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
            l.Add("\t\tisSerialized = true;");
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
