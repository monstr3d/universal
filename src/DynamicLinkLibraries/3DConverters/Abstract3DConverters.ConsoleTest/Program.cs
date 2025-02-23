// See https://aka.ms/new-console-template for more information
using Abstract3DConverters;
using Abstract3DConverters.ErrorHandlers;
using ErrorHandler;

Console.WriteLine("Hello, World!");

using var writer = new StreamWriter(@"c:\0\1.log");

var a = (Exception e, TextWriter t) =>
{
    t.Flush();
};


var eh = new TextWiterErrorHandler(writer, a);

eh.Set();

StaticExtensionAbstract3DConverters.FileTypes = new Dictionary<string, Tuple<string[], string>>()
            {
            { "AC3D file format", new Tuple<string[], string>([".ac", "ac3d"], null) },
           { "Obj file format",  new  Tuple<string[], string>([ ".obj" ], null)},
             { "Collada 1.5 file format", new Tuple<string[], string>( [ ".dae" ], "1.5.0")},
             { "Collada 1.4 file format", new Tuple<string[], string>([ ".dae" ], "1.4.1")},
               { "WPF XAML file format", new Tuple<string[], string>([ ".xaml" ], null)}
        };

StaticExtensionAbstract3DConverters.UseDirectory = true;

try
{

    @"c:\0\03D".TestDirectory();
}
catch (Exception e)
{
    e.ShowError();
}
