using System;
using System.Collections.Generic;
using System.Text;
using CategoryTheory;

using DataPerformer.Interfaces;

namespace DataPerformer
{
    class TestDataLink : ICategoryArrow
    {
        #region Fields

        /// <summary>
        /// The source of this arrow
        /// </summary>
        private IDataConsumer source;

        /// <summary>
        /// The target of this arrow
        /// </summary>
        private IMeasurements target;

        #endregion

        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                // Проверка типа
                if (!(value is IDataConsumer))
                {
                    throw new Exception("Illegal source type");
                }
                source = value as IDataConsumer;
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                // Проверка типа
                if (!(value is IMeasurements))
                {
                    throw new Exception("Illegal target type");
                }
                target = value as IMeasurements;
                // Дополнительное действие
                source.AddChild(target);
            }
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
