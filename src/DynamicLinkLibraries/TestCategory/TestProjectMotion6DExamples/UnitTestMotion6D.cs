namespace TestProjectMotion6DExamples
{
    /// <summary>
    /// Testing for examples
    /// </summary>
    public class UnitTestMotion6D
    {
        [Fact]
        public void TestMotionODE()
        {
            Resources.MotionODE.Fact();
        }


        [Fact]
        public void TestMotionODE1()
        {
            Resources.MotionODE1.Fact();
        }


        [Fact]
        public void TestDeltaFunction()
        {
            Resources.DeltaFunction.Fact();
        }

    }
}