using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object which has facets
    /// </summary>
    public interface IFacet
    {
        /// <summary>
        /// Facet count
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Count of input parameters
        /// </summary>
        int ParametersCount
        {
            get;
        }

        /// <summary>
        /// Gets type of n - th parameter
        /// </summary>
        /// <param name="n">Parameter number</param>
        /// <returns></returns>
        object GetType(int n);

        /// <summary>
        /// Access to parameter
        /// </summary>
        /// <param name="facet">Facet number</param>
        /// <param name="parameter">Parameter number</param>
        /// <returns>Parameter</returns>
        object this[int facet, int parameter]
        {
            get;
        }

        /// <summary>
        /// Gets position of n - th facet
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <returns>Position of facet</returns>
        double[] this[int n]
        {
            get;
        }

        /// <summary>
        /// Sets color to n - th facet
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <param name="alpha">Alpha</param>
        /// <param name="red">Red</param>
        /// <param name="green">Green</param>
        /// <param name="blue">Blue</param>
        void SetColor(int n, double alpha, double red, double green, double blue);

        /// <summary>
        /// Id of this object
        /// it can be file or database id
        /// </summary>
        string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets facet area
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <returns>Area</returns>
        double GetArea(int n);

        /// <summary>
        /// Gets Normal
        /// </summary>
        /// <param name="n">Facet number</param>
        /// <returns>Normal</returns>
        double[] GetNormal(int n);

        /// <summary>
        /// The "is colored" sign
        /// </summary>
        bool IsColored
        {
            get;
            set;
        }
 
    }
}
