﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace Collada.Wpf
{
    public class WpfMaterialCreator : Abstract3DConverters.AbstractMaterialCreator
    {
        public WpfMaterialCreator()
        {
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

        public override object Create(Abstract3DConverters.DiffuseMaterial material)
        {
            return new DiffuseMaterial();  
        }

        public override object Create(Abstract3DConverters.SpecularMaterial material)
        {
            return new SpecularMaterial();
        }

        public override object Create(Abstract3DConverters.EmissiveMaterial material)
        {
            return new EmissiveMaterial();
        }

        public override object CreateGroup(Abstract3DConverters.MaterialGroup materialGroup)
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
            br.Opacity = 1;
            d.Brush = br;
        }

        public override void SetOpacicty(object material, float opacity)
        {
            var d = material as DiffuseMaterial;
            ImageBrush br = d.Brush as ImageBrush;
            br.Opacity = opacity;
           
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

    }
}