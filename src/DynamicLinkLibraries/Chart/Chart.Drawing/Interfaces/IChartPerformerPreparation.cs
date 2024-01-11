namespace Chart.Drawing.Interfaces
{
    public interface IChartPerformerPreparation
    {
        /// <summary>
        /// Prepares Chart performer
        /// </summary>
        /// <param name="performer"></param>
        /// <param name="obj"></param>
        void Prepare(ChartPerformer performer, object obj);
    }
}
