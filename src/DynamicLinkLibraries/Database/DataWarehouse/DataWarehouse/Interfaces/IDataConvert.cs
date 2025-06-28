
namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Conversion to leaf data
    /// </summary>
    public interface IDataConvert
    {
        ILeafData Convert {  get; }
    }
}
