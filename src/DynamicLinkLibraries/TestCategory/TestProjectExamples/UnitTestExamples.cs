
namespace TestProjectExamples
{
    /// <summary>
    /// Testing for examples
    /// </summary>
    public class UnitTestExamples
    {
 
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

    }
}