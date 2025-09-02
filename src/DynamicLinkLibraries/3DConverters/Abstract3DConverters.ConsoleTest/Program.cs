using Abstract3DConverters;
using Abstract3DConverters.ConsoleTest;
using Abstract3DConverters.Converters;
using Abstract3DConverters.ErrorHandlers;


Console.WriteLine("Hello, World!");
var dir = @"c:\AUsers\1MySoft\CSharp\03D\GOOD";

var writer = new StreamWriter(Path.Combine(dir, "1.log"), false);

var a = (Exception e, TextWriter t) =>
{
    t.Flush();
};




using var eh = new TextWiterErrorHandler(writer);

var hand = new ErrorHandler.ExceptionHandlerCollection([eh, new ConsoleExceptionHandler()]);
ErrorHandler.StaticExtensionErrorHandler.Set(hand);


StaticExtensionAbstract3DConverters.FileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>([".ac"], null) },
           { "Obj file format",  new  Tuple<string[], string>([ ".obj" ], null)},
             { "Collada 1.5 file format", new Tuple<string[], string>( [ ".dae" ], "1.5.0")},
             { "Collada 1.4 file format", new Tuple<string[], string>([ ".dae" ], "1.4.1")},
               { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
        };

StaticExtensionAbstract3DConverters.UseDirectory = true;

StaticExtensionAbstract3DConverters.CheckFile = CheckFile.Check;


try
{
    // dir = @"c:\";
    // dir.TestACTetxures();
    //  @"c:\0\1.txt".Finish();

    dir.TestDirectory(true);
    dir.TestDirectory(false);

}
catch (Exception e)
{
    e.HandleException();
}

void TestConstrurctor()
{
    try
    {
        new AcConverter([]);
    }
    catch
    {

    }
    var ac = new AcConverter([]);
}

//writer.Flush();

//writer.Dispose();
