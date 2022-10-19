
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
    }
}