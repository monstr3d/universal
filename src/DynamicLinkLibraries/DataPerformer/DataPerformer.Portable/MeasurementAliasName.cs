using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Measurement with alias name
    /// </summary>
    public class MeasurementAliasName
    {

        IMeasurement Measurement { get; init; }

        IAliasName AliasName { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measurement">The measurement</param>
        /// <param name="aliasName">The name</param>
        public MeasurementAliasName(IMeasurement measurement, IAliasName aliasName)
        {
            this.Measurement = measurement;
            this.AliasName = aliasName;
        }

        public void Update()
        {
            AliasName.Value = Measurement.Parameter();
        }
    }
}
