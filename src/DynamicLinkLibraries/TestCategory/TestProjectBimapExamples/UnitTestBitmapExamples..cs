



namespace TestProjectBimapExamples
{
    public class Tests
    {
       [SetUp]
        public void Setup()
        {
            StaticExtensionBitmapExamples.Init();
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
