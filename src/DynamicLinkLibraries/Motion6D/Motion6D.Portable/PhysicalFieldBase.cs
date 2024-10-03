using System;
using System.Collections.Generic;
using System.Text;


using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;

using PhysicalField.Portable;

namespace Motion6D.Portable
{
    /// <summary>
    /// Base class of physical fields
    /// </summary>
    public class PhysicalFieldBase : PhysicalFieldDataConsumer,
        IPositionObject, IFieldTransformerField
    {
        #region Fields

        private IPosition position;

        private IFieldTransformer[] transformers;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PhysicalFieldBase()
        {

        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Dimension of space
        /// </summary>
        public override int SpaceDimension
        {
            get { return 3; }
        }

        /// <summary>
        /// Post set arrow operation
        /// </summary>
        public override void PostSetArrow()
        {
            base.PostSetArrow();
            SetTrans();
        }


        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        #endregion

        #region IFieldTransformerField Members

        IFieldTransformer IFieldTransformerField.GetTransformer(int n)
        {
            return transformers[n];
        }

        #endregion

        #region Specific Members

        private void SetTrans()
        {
            transformers = new IFieldTransformer[transformationTypes.Length];
            for (int i = 0; i < transformers.Length; i++)
            {
                string s = transformationTypes[i] + "";
                if (s.Equals(""))
                {
                    transformers[i] = ScalarFieldTransformer.Object;
                    continue;
                }
                if (s.Equals("Vector"))
                {
                    transformers[i] = new VectorFieldTransformer();
                }
            }
        }

        #endregion
    }
}
