
namespace CategoryTheory
{

    /// <summary>
    /// Exception of category theory
    /// </summary>
    public class CategoryException : ErrorHandler.OwnException
    {
        /// <summary>
        /// Text of illegal source exception
        /// </summary>
        static public readonly string IllegalSource = "Illegal source";

        /// <summary>
        /// Text of illegal target exception
        /// </summary>
        static public readonly string IllegalTarget = "Illegal target";
  
        /// <summary>
        /// Text of illegal target exception
        /// </summary>
        static public readonly string IllegalObject = "Illegal object";

        /// <summary>
        /// Text of target - source coincidence
        /// </summary>
        static public readonly string TargetSourceCoincidence = "Target coincides with source";

        /// <summary>
        /// Text whether endpoints of two arrows do not coincide
        /// </summary>
        static public readonly string EndpointsOfTwoArrowsError = "Endpoints of arrows do not coincide";

        /// <summary>
        /// Text of direct product does not supported
        /// </summary>
        static public readonly string DirectProductNotSupported = "Category does not support direct products";

        /// <summary>
        /// Text of direct product does not supported
        /// </summary>
        static public readonly string DirectSumNotSupported = "Category does not support direct sums";

        /// <summary>
        /// Text of equalizer does not supported
        /// </summary>
        static public readonly string EqualizerNotSupported = "Category does not support equalizers";

        /// <summary>
        /// Text of equalizer does not supported
        /// </summary>
        static public readonly string CoequalizerNotSupported = "Category does not support coequalizers";

        /// <summary>
        /// Text of unique solution
        /// </summary>
        static public readonly string UniqueSolution = "The solution is unique";

        /// <summary>
        /// Text of unique solution
        /// </summary>
        static public readonly string MultipleSolution = "The solution is multiple";

        /// <summary>
        /// Text of unique solution
        /// </summary>
        static public readonly string NoSolution = "The solution does not exist";

        /// <summary>
        /// Noncommutative path text
        /// </summary>
        static public readonly string NonCommutativePath = "Diagram has noncommutative path";

        /// <summary>
        /// The "different sources" text
        /// </summary>
        static public readonly string DifferentSources = "Different sources";

        /// <summary>
        /// The "different targets" text
        /// </summary>
        static public readonly string DifferentTargets = "Different targets";

        /// <summary>
        /// Referential integrity error
        /// </summary>
        static public readonly string ReferentialIntegrity = "Object reference not set to an instance of an object.";

        /// <summary>
        /// Source already exists error
        /// </summary>
        static public readonly string SourceAlreadyExists = "Source already exists";

        /// <summary>
        /// Target already exists error
        /// </summary>
        static public readonly string TargetAlreadyExists = "Target already exists";


        /// <summary>
        /// Associated object
        /// </summary>
        private object o;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception messege</param>
        public CategoryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="o">Associated object</param>
        public CategoryException(string message, object o)
            : this(message)
        {
            this.o = o;
        }


        /// <summary>
        /// Throws message in case of illegal source
        /// </summary>
        static public void ThrowIllegalSourceException()
        {
            throw new CategoryException(IllegalSource);
        }

        /// <summary>
        /// Throws message in case of illegal target
        /// </summary>
        static public void ThrowIllegalTargetException()
        {
            throw new CategoryException(IllegalTarget);
        }
 
        /// <summary>
        /// Throws message in case of illegal object
        /// </summary>
        static public void ThrowIllegalObjectException()
        {
            throw new CategoryException(IllegalObject);
        }

        /// <summary>
        /// Throws exception if endpoints of two arrows do not coincide
        /// </summary>
        /// <param name="x">First arrow</param>
        /// <param name="y">Second arrow</param>
        static public void ThrowEndpointsException(ICategoryArrow x, ICategoryArrow y)
        {
            if ((x.Source != y.Source) | (x.Target != y.Target))
            {
                throw new CategoryException(EndpointsOfTwoArrowsError);
            }
        }


        /// <summary>
        /// Throws message in case of illegal target
        /// </summary>
        static public void ThrowSourceTargetCoincidenceException()
        {
            throw new CategoryException(TargetSourceCoincidence);
        }

        /// <summary>
        /// Throws message in case of illegal target
        /// </summary>
        static public void ThrowSourceExistsException()
        {
            throw new CategoryException(SourceAlreadyExists);
        }

        /// <summary>
        /// Throws message in case of illegal target
        /// </summary>
        static public void ThrowTargetExistsException()
        {
            throw new CategoryException(TargetAlreadyExists);
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return o;
            }
        }

    }
}
