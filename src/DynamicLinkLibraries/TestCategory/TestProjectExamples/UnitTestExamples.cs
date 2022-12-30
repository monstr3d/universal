
namespace TestProjectExamples
{
    /// <summary>
    /// Testing for examples
    /// </summary>
    public class UnitTestExamples
    {
        /// <summary>
        /// Test of determination of orbit of spacecraft
        /// </summary>
        [Fact]
        public void TestOrbitDetermination()
        {
            Resources.OrbitDetermination.Fact();
        }

        /// <summary>
        /// Test of delta function
        /// </summary>
        [Fact]
        public void TestDeltaFunction()
        {
            Resources.DeltaFunction.Fact();
        }

        /// <summary>
        /// Test of database selection regression
        /// </summary>
        [Fact]
        public void TestDatabaseSelectionRegression()
        {
            Resources.DatabaseSelection.Fact();
        }

        /// <summary>
        /// Test of bitmap selection 
        /// </summary>
        [Fact]
        public void TestBitmapSelectionion()
        {
           Resources.ImagePoly_5.Fact();
        }


    }
}