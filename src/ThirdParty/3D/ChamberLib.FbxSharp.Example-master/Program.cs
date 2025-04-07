using System;
using ChamberLib.OpenTK;
using ChamberLib.Content;

namespace ChamberLib.FbxSharp.Example
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var glsl = new GlslShaderImporter();
            importer =
                new BuiltinContentImporter(                     // resolve builtin resources
                    new ContentImporter(
                        new FbxModelImporter().ImportModel,         // model importer
                        new BasicTextureImporter().ImportTexture,   // texture importer
                        new GlslShaderImporter().ImportShaderStage, // shader importer
                        null,                                       // font importer
                        null,                                       // song importer
                        null));                                     // sound effect importer


            subsystem = new OpenTKSubsystem(
                3, 3,
                onLoadMethod: Load,
                onRenderFrameMethod: Draw,
                contentImporter: importer);

            view = Matrix.CreateLookAt (new Vector3 (2, 1.5f, -4),
                Vector3.Zero, Vector3.UnitY);
            projection = Matrix.CreateOrthographic (6, 4, 0.25f, 10);

            subsystem.Run ();
        }

        static IContentImporter importer;
        static ISubsystem subsystem;
        static Matrix view;
        static Matrix projection;
        static IModel model;
        static ChamberLib.DirectionalLight _light =
            new ChamberLib.DirectionalLight(
                direction: new Vector3(-1, -1, 0).Normalized(),
                diffuseColor: new Vector3(0.9f, 0.8f, 0.7f),
                specularColor: Vector3.Zero,
                enabled: true);

        public static void Load()
        {
            model = subsystem.ContentManager.LoadModel("model.fbx");
            model.SetAmbientLightColor(new Vector3(0.3f, 0.3f, 0.3f));
            model.SetDirectionalLight(_light, 0);
        }

        public static void Draw(GameTime gameTime)
        {
            var id = Matrix.Identity;
            subsystem.Renderer.DrawLine (Vector3.UnitX, id, view, projection, Vector3.Zero, Vector3.UnitX);
            subsystem.Renderer.DrawLine (Vector3.UnitY, id, view, projection, Vector3.Zero, Vector3.UnitY);
            subsystem.Renderer.DrawLine (Vector3.UnitZ, id, view, projection, Vector3.Zero, Vector3.UnitZ);
            var world = Matrix.CreateScale (0.005f);
            model.Draw (world, view, projection);
        }

    }
}
