// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Blender.Wrapper;

var f = @"c:\AUsers\1MySoft\CSharp\src\DynamicLinkLibraries\3DConverters\Blender.Files\cube.blend";
using (var stream = File.OpenRead(f))
{
    var o = stream.LoadBlender();
}