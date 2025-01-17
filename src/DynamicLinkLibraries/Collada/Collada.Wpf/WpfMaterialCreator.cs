using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace Collada.Wpf
{
    internal class WpfMaterialCreator : Abstract3DConverters.AbstractMaterialCreator
    {
        Dictionary<string, string> images;
        internal WpfMaterialCreator(Dictionary<string, string> images = null)
        {
            this.images = images;
        }

        public override Assembly Assembly => typeof(Material).Assembly;

        public override void Add(object group, object value)
        {
            var mg = group as MaterialGroup;
            mg.Children.Add(value as Material);
        }

        public override object Create(Abstract3DConverters.Image image)
        {
            string fn = image.FullPath; ;
            if (!System.IO.File.Exists(fn))
            {
                return null;
            }
            if (images != null)
            {
                images[fn] = image.Name;
            }
            System.Windows.Media.Imaging.BitmapImage bi =
                new System.Windows.Media.Imaging.BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(fn);
            bi.EndInit();
            return bi;
        }

        public override object Create(Abstract3DConverters.Color color)
        {
            return ToColor(color.Value);
        }

        public override object Create(Abstract3DConverters.Materials.DiffuseMaterial material)
        {
            var mat = new DiffuseMaterial();
            if (material.AmbientColor != null)
            {
                var ac = Create(material.AmbientColor);
                var ambient = (Color)ac;
                mat.AmbientColor = ambient;
            }
            return mat;
        }

        public override object Create(Abstract3DConverters.Materials.SpecularMaterial material)
        {
            return new SpecularMaterial();
        }

        public override object Create(Abstract3DConverters.Materials.EmissiveMaterial material)
        {
            return new EmissiveMaterial();
        }

        public override object CreateGroup(Abstract3DConverters.Materials.MaterialGroup materialGroup)
        {
            return new MaterialGroup();
        }

        public override void Set(object material, object color)
        {
            var t = material.GetType();
            PropertyInfo pi = t.GetProperty("Color");
            pi.SetValue(material, color, null);

        }

        public override void SetImage(object material, object image)
        {
            var d = material as DiffuseMaterial;
            ImageSource iso = image as ImageSource;
            ImageBrush br = new ImageBrush(iso);
            br.ViewportUnits = BrushMappingMode.Absolute;
            d.Brush = br;
        }

        public override void SetOpacicty(object material, float opacity)
        {
            var d = material as DiffuseMaterial;
            ImageBrush br = d.Brush as ImageBrush;
            if (br != null)
            {
                br.Opacity = opacity;
            }
           
        }

        public override void SetPower(object material, float power)
        {
            var s = material as SpecularMaterial;
            s.SpecularPower = power;
        }

        byte ToByte(float d)
        {
            var x = Math.Floor(d * 256);
            if (x == 256)
            {
                x = 255;
            }
            int k = (int)x;
            return (byte)k;
        }

        public  Color ToColor(float[] d)
        {
            if (d.Length == 3)
            {
                return Color.FromRgb(ToByte(d[0]), ToByte(d[1]), ToByte(d[2]));
            }
            else if (d.Length == 4)
            {
                return Color.FromArgb(ToByte(d[3]), ToByte(d[0]), ToByte(d[1]), ToByte(d[2]));
            }
            throw new Exception();
        }

        public override object Create(string key, Abstract3DConverters.Image image)
        {
            throw new NotImplementedException();
        }

        public override object Create(string key, Abstract3DConverters.Materials.Material material)
        {
            throw new NotImplementedException();
        }

        public override object Create(string key, Abstract3DConverters.Materials.MaterialGroup material)
        {
            throw new NotImplementedException();
        }
    }
}
