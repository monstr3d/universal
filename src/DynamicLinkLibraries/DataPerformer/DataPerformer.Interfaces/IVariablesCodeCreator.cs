using System.Collections.Generic;

namespace DataPerformer.Interfaces
{
    public interface IVariablesCodeCreator
    {
        Dictionary<string, List<string>> Create(IMeasurements measurements);
    }
}
