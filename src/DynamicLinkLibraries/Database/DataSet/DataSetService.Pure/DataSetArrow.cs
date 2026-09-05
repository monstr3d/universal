
using CategoryTheory;

using DataSetService.Pure.Interfaces;


namespace DataSetService.Pure
{

    /// <summary>
    /// Arrow between data set provider and data set consumer
    /// </summary>
    public class DataSetArrow : CategoryArrow, IDisposable
    {

        #region Fields

         /// <summary>
        /// Source
        /// </summary>
        protected IDataSetConsumer source;

        /// <summary>
        /// Target
        /// </summary>
        protected IDataSetProvider target;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataSetArrow()
        {
        }


        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetSource<IDataSetConsumer>(); 
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IDataSetProvider>();
                source.Factory = target.Factory;
                source.Add(target.DataSet);
            }
        }


        #endregion

        #region IDisposable Members

        /// <summary>
        /// The post remove operation
        /// </summary>
        void IDisposable.Dispose()
        {
            if (source != null & target != null)
            {
                if (target.DataSet != null)
                {
                    source.Remove(target.DataSet);
                }
            }
        }

        #endregion
    }

}
