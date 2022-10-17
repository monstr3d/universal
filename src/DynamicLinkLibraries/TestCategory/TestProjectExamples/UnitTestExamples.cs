namespace TestProjectExamples
{
    public class UnitTestExamples
    {
        [Fact]
        public void TestOrbitDetermination()
        {
            var o = Properties.Resources.OrbitDetermination.Test();
            if (o is Exception)
            {

            }
        }
    }
}