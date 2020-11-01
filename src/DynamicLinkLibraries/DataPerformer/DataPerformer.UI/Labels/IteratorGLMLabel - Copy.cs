﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using DataPerformer.UI.UserControls;

using Regression;
using DataPerformer.UI.Forms;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for GLM iterator
    /// </summary>
    [Serializable()]
    public class IteratorGLMLabel : UserControlBaseLabel
    {
        #region Fields

        IteratorGLM acc;

        UserControlIteratorGLM uc;

        Form form;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorGLMLabel()
            : base(typeof(IteratorGLM), "", ResourceImage.RecoursiveGLM.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected IteratorGLMLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControlIteratorGLM();
                return uc;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return acc;
            }
            set
            {
                if (!(value is IteratorGLM))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                acc = value as IteratorGLM;
                acc.Object = this;
                uc.Iterator = acc;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
           
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {
            form = new FormIterateGLM(this);
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        #endregion

    }
}
