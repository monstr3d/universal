using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace WpfInterface.Wpf
{
    public class BoundaryParameters : DependencyObject
    {
        #region Fields

        static public readonly DependencyProperty MeshProperty =
            DependencyProperty.Register("Mesh", typeof(MeshGeometry3D), typeof(BoundaryParameters));

        static public readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(Material), typeof(BoundaryParameters));

        static public readonly DependencyProperty IntIndexProperty =
            DependencyProperty.Register("IntIndex", typeof(Int32Collection), typeof(BoundaryParameters));

        static public readonly DependencyProperty IntParametersProperty =
            DependencyProperty.Register("IntParameters", typeof(Int32Collection), typeof(BoundaryParameters));

        static public readonly DependencyProperty DoubleIndexProperty =
            DependencyProperty.Register("DoubleIndex", typeof(Int32Collection), typeof(BoundaryParameters));

        static public readonly DependencyProperty DoubleParametersProperty =
            DependencyProperty.Register("DoubleParameters", typeof(DoubleCollection), typeof(BoundaryParameters));

        static public readonly DependencyProperty IntVariablesIndexProperty =
             DependencyProperty.Register("IntVariablesIndex", typeof(int), typeof(BoundaryParameters));

        static public readonly DependencyProperty IntVariablesProperty =
            DependencyProperty.Register("IntVariables", typeof(Int32Collection), typeof(BoundaryParameters));

        static public readonly DependencyProperty DoubleVariablesIndexProperty =
            DependencyProperty.Register("DoubleVariablesIndex", typeof(int), typeof(BoundaryParameters));

        static public readonly DependencyProperty DoubleVariablesProperty =
            DependencyProperty.Register("DoubleVariables", typeof(DoubleCollection), typeof(BoundaryParameters));




        #endregion

        #region Ctor

        public BoundaryParameters()
        {
        }

        public BoundaryParameters(MeshGeometry3D mesh, Material material, Int32Collection intIndex, Int32Collection intParameters,
            Int32Collection doubleIndex, DoubleCollection doubleParameters, int intVariablesIndex, Int32Collection intVariables,
            int doubleVariablesIndex, DoubleCollection doubleVariables)
        {
            Mesh = mesh;
            this.Material = material;
            IntIndex = intIndex;
            IntParameters = intParameters;
            DoubleIndex = doubleIndex;
            DoubleParameters = doubleParameters;
            IntVariablesIndex = intVariablesIndex;
            IntVariables = intVariables;
            DoubleVariablesIndex = doubleVariablesIndex;
            DoubleVariables = doubleVariables;
        }

        #endregion

        #region Properties


        public MeshGeometry3D Mesh
        {
            get
            {
                return GetValue(MeshProperty) as MeshGeometry3D;
            }
            set
            {
                SetValue(MeshProperty, value);
            }
        }

        public Material Material
        {
            get
            {
                return GetValue(MaterialProperty) as Material;
            }
            set
            {
                SetValue(MaterialProperty, value);
            }
        }

         public DoubleCollection DoubleVariables
        {
            get
            {
                return GetValue(DoubleVariablesProperty) as DoubleCollection;
            }
            set
            {
                SetValue(DoubleVariablesProperty, value);
            }
        }
 


        public Int32Collection IntIndex
        {
            get
            {
                return GetValue(IntIndexProperty) as Int32Collection;
            }
            set
            {
                SetValue(IntIndexProperty, value);
            }
        }
        public Int32Collection IntParameters
        {
            get
            {
                return GetValue(IntParametersProperty) as Int32Collection;
            }
            set
            {
                SetValue(IntParametersProperty, value);
            }
        }
        public Int32Collection DoubleIndex
        {
            get
            {
                return GetValue(DoubleIndexProperty) as Int32Collection;
            }
            set
            {
                SetValue(DoubleIndexProperty, value);
            }
        }


        public DoubleCollection DoubleParameters
        {
            get
            {
                return GetValue(DoubleParametersProperty) as DoubleCollection;
            }
            set
            {
                SetValue(DoubleParametersProperty, value);
            }
        }
        

        public int IntVariablesIndex
        {
           get
            {
                return (int)GetValue(IntVariablesIndexProperty);
            }
            set
            {
                SetValue(IntVariablesIndexProperty, value);
            }
       }

        public Int32Collection IntVariables
        {
             get
            {
                return GetValue(IntVariablesProperty) as Int32Collection;
            }
            set
            {
                SetValue(IntVariablesProperty, value);
            }
        }


        
        public int DoubleVariablesIndex
        {
           get
            {
                return (int)GetValue(DoubleVariablesIndexProperty);
            }
            set
            {
                SetValue(DoubleVariablesIndexProperty, value);
            }
       }

        #endregion
    }
}
