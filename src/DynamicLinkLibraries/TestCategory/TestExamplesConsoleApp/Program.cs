using TestExamplesConsoleApp;
using TestExamplesConsoleApp.Properties;

var t = @"c:\AUsers\1MySoft\CSharp\Tests\DatabaseSelection.cfa".Test();
return;
//var t = @"c:\AUsers\1MySoft\CSharp\Tests\OrbitDetermination.cfa".Test();
//var t = @"c:\AUsers\1MySoft\CSharp\Tests\DeltaFunction.cfa".Test
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
