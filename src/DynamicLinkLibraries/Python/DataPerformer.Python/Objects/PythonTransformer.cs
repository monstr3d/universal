using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPeformer.Python.Objects
{
    /// <summary>
    /// Python transformer
    /// </summary>
    public class PythonTransformer : CategoryObject, IDataConsumer, IMeasurements, IPostSerialize, IPostSetArrow
    {

        #region Fields

        List<IMeasurements> measurements = new List<IMeasurements>();

        Microsoft.Scripting.Hosting.ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();

        Microsoft.Scripting.Hosting.ScriptScope scope;

        Microsoft.Scripting.Hosting.ScriptSource script;

        Dictionary<string, IMeasurement> dicMea = new Dictionary<string, IMeasurement>();

        event Action onChangeInput = () => { };

    
        protected IDataConsumer dc;

        private List<PythonMeasurement> outs = new List<PythonMeasurement>();

        bool isUpdated = false;

        #endregion

        #region Ctor

        public PythonTransformer()
        {
            dc = this;
        }

        #endregion

        #region IDataConsumer Members

        int IDataConsumer.Count => measurements.Count;

        IMeasurements IDataConsumer.this[int number] => measurements[number];

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            dc.UpdateChildrenData();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add
            {
                onChangeInput += value;
            }

            remove
            {
                onChangeInput -= value;
            }
        }


        void IDataConsumer.Reset()
        {
            dc.Reset();
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count => outs.Count;

        bool IMeasurements.IsUpdated { 
            get => isUpdated; 
            set => isUpdated = value; 
        }

        IMeasurement IMeasurements.this[int number] => outs[number];

        void IMeasurements.UpdateMeasurements()
        {
            Update();
        }

        #endregion


        #region IPostSerialize Members

        void IPostSerialize.PostSerialize()
        {
            CreateOutputs();
        }

        #endregion

        #region IPostSerialize Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateInputs();
        }

        #endregion




        #region Public Members

        public string Code
        {
            get;
            set;
        } = "";

        public Dictionary<string, string> Inputs
        { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, object[]> Outputs
        { get; set; } = new Dictionary<string, object[]>();


        #endregion

        #region Protected Members
        protected void CreateOutputs()
        {
            outs.Clear();
            foreach (var name in Outputs.Keys)
            {
                outs.Add(new PythonMeasurement(this, name));
            }
        }

        void CreateInputs()
        {
            dicMea.Clear();
            foreach (var key in Inputs.Keys)
            {
              dicMea[key] =  dc.FindMeasurement(Inputs[key]);
            }
        }

        protected void CreateExe()
        {
            script = engine.CreateScriptSourceFromString(Code);
            scope = engine.CreateScope();
            foreach (var key in dicMea.Keys)
            {
                scope.SetVariable(key, dicMea[key].Type);
            }
            foreach (var key in Outputs.Keys)
            {
                scope.SetVariable(key, Outputs[key][0]);
            }
        }

        protected void Update()
        {
            
            foreach (var key in dicMea.Keys)
            {
                scope.SetVariable(key, dicMea[key].Parameter());
            }
            script.Execute(scope);
            foreach (var key in Outputs.Keys)
            {
                Outputs[key][1] = scope.GetVariable(key) as object;
            }
        }


        #endregion

        class PythonMeasurement : IMeasurement
        {
            string name;


            object[] o;

            internal PythonMeasurement(PythonTransformer t, string name)
            {
                this.name = name;
                o = t.Outputs[name];
            }

            public Func<object> Parameter => () => 
            { 
                return o[1]; 
            };

            public string Name => name;

            public object Type => o[0];
        }
    }
}
