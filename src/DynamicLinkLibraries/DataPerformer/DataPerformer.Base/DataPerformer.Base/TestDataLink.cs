﻿using System;
using System.Collections.Generic;
using System.Text;
using CategoryTheory;

using DataPerformer.Interfaces;
using NamedTree;

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
                    throw new ErrorHandler.OwnException("Illegal source type");
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
                    throw new ErrorHandler.OwnException("Illegal target type");
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
            get;
            set;
        }

        #endregion
    }
}
