using TestCategory;
using TestCategory.Standard;
using TestExamplesConsoleApp;
using TestExamplesConsoleApp.Properties;

StaticExtension.Init();

var t = @"c:\AUsers\1MySoft\CSharp\Tests\MotionODE.cfa".Test();
var t1 = @"c:\AUsers\1MySoft\CSharp\Tests\ImagePoly_5.cfa".Test();
var t2 = @"c:\AUsers\1MySoft\CSharp\Tests\DatabaseSelection.cfa".Test();
var t3 = @"c:\AUsers\1MySoft\CSharp\Tests\OrbitDetermination.cfa".Test();
var t4 = @"c:\AUsers\1MySoft\CSharp\Tests\DeltaFunction.cfa".Test();//*/
return;
using (Stream stream = File.OpenRead(@"c:\AUsers\1MySoft\CSharp\Tests\DatabaseSelection.cfa"))
{
    for (int i = 0; i < 10; i++)
    {
        var obj = stream.ReadObject();
        if (!stream.CanRead)
        {
            break;
        }
    }
}
return;

var o = Resources.OrbitDetermination.Test();
if (o is Exception)
{

}



Console.WriteLine("Hello, World!");
