using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DataPerformer.Interfaces
{


    /// <summary>
    /// Common interface of data transformers
    /// </summary>
    public interface IDataTransformer : IMeasurements, IDataConsumer
    {

    }

        /// <summary>
    /// Factory of data transformers
    /// </summary>
    public interface IDataTransformerFactory
    {
        /// <summary>
        /// Gets data transformer by name
        /// </summary>
        /// <param name="name">The name of data transformer</param>
        /// <returns>Data transformer name</returns>
        IDataTransformer this[string name]
        {
            get;
        }

        /// <summary>
        /// Names of transformers
        /// </summary>
        string[] Transformers
        {
            get;
        }
    }

    /// <summary>
    /// The time dynamical object
    /// </summary>
    public interface IDynamical
    {
        /// <summary>
        /// The time
        /// </summary>
        double Time
        {
            set;
        }
    }

    /// <summary>
    /// Object with arguments
    /// </summary>
    public interface IArguments
    {
        /// <summary>
        /// Arguments
        /// </summary>
        ICollection Arguments
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Step dependend component
    /// </summary>
    public interface IStep
    {
        /// <summary>
        /// Step number
        /// </summary>
        long Step
        {
            get;
            set;
        }
    }

    /// <summary>
    /// The object that should be started
    /// </summary>
    public interface IStarted
    {
        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="time">Start time</param>
        void Start(double time);

    }

    /// <summary>
    /// Object with rumtime update
    /// </summary>
    public interface IRuntimeUpdate
    {
        /// <summary>
        /// The "Should Runtime Update" sign
        /// </summary>
        bool ShouldRuntimeUpdate
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Selection with arguments
    /// </summary>
    public interface IArgumentSelection : IStructuredSelection
    {
        /// <summary>
        /// Count of points
        /// </summary>
        int PointsCount
        {
            get;
        }

        /// <summary>
        /// Free variables
        /// </summary>
        string[] Variables
        {
            get;
        }
        /// <summary>
        /// Dimension of output vector
        /// </summary>
        int VectorDimension
        {
            get;
        }



        /// <summary>
        /// Gets value of variable
        /// </summary>
        double this[int i, string str]
        {
            get;
        }

        /// <summary>
        /// Calculates synchronized selection
        /// </summary>
        /// <param name="selection">The etalon selection</param>
        /// <returns>Synchronized selection</returns>
        IArgumentSelection SynchronizedSelection(IArgumentSelection selection);

    }

    /// <summary>
    /// Collection of structured selections
    /// </summary>
    public interface IStructuredSelectionCollection
    {
        /// <summary>
        /// Count of selections
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// The i - th selection
        /// </summary>
        IStructuredSelection this[int i]
        {
            get;
        }
    }

    /// <summary>
    /// Structured selection
    /// </summary>
    public interface IStructuredSelection
    {
        /// <summary>
        /// Dimension of data
        /// </summary>
        int DataDimension
        {
            get;
        }

        /// <summary>
        /// Access to n - th element
        /// </summary>
        double? this[int number]
        {
            get;
        }

        /// <summary>
        /// Weight of n - th element
        /// </summary>
        /// <param name="number">Element number</param>
        /// <returns>The weight</returns>
        double GetWeight(int number);

        /// <summary>
        /// Aprior weight of n - th element
        /// </summary>
        /// <param name="number">Element number</param>
        /// <returns>The weight</returns>
        double GetApriorWeight(int number);

        /// <summary>
        /// Tolerance of it - th element
        /// </summary>
        /// <param name="number">Element number</param>
        /// <returns>Tolerance</returns>
        int GetTolerance(int n);

        /// <summary>
        /// Sets tolerance of n - th element
        /// </summary>
        /// <param name="number">Element number</param>
        /// <param name="tolerance">Tolerance to set</param>
        void SetTolerance(int number, int tolerance);

        /// <summary>
        /// The "is fixed amount" sign
        /// </summary>
        bool HasFixedAmount
        {
            get;
        }

        /// <summary>
        /// Selection name
        /// </summary>
        string Name
        {
            get;
        }
    }

    /// <summary>
    /// Structured calculation
    /// </summary>
    public interface IStructuredCalculation
    {
        /// <summary>
        /// Calculates parameters
        /// </summary>
        /// <param name="x">Input</param>
        /// <param name="selection">Selection</param>
        /// <param name="y">Output</param>
        void Calculate(double[] x, IStructuredSelection selection, double?[] y);

        /// <summary>
        /// Dimension of estimated vector
        /// </summary>
        int Dimension
        {
            get;
        }
    }

    /// <summary>
    /// Updatable selection
    /// </summary>
    public interface IUpdatableSelection
    {
        /// <summary>
        /// Updates selection
        /// </summary>
        void UpdateSelection();
    }


    /// <summary>
    /// Consumer of structured selection
    /// </summary>
    public interface IStructuredSelectionConsumer
    {
        /// <summary>
        /// Adds selection collection
        /// </summary>
        /// <param name="selection">Selection to add</param>
        void Add(IStructuredSelectionCollection selection);

        /// <summary>
        /// Removes selection collecion
        /// </summary>
        /// <param name="selection">Selection to remove</param>
        void Remove(IStructuredSelectionCollection selection);
    }

}
