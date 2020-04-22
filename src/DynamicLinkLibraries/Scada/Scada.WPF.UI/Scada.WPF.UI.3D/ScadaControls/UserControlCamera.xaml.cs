﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scada.Interfaces;
using Scada.WPF.UI._3D.Converters;

namespace Scada.WPF.UI._3D.ScadaControls
{
    /// <summary>
    /// User control for 3D camera
    /// </summary>
    public partial class UserControlCamera : UserControl, IScadaConsumer
    {
        #region Fields

       

        WpfInterface.CameraInterface.WpfCamera camera;

        IScadaInterface scada;

        bool isEnabled;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCamera()
        {
            InitializeComponent();
        }

        #endregion

        #region IScadaConsumer Members

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                scada = value;
                /*  if (scada is Motion6D.Interfaces.ICameraProvider)
                  {
                      Motion6D.Interfaces.ICameraProvider cp =
                          scada as Motion6D.Interfaces.ICameraProvider;
                      WpfInterface.CameraInterface.WpfCamera c = cp.Cameras[Camera]
                          as WpfInterface.CameraInterface.WpfCamera;
                      if (c == camera)
                      {
                          return;
                      }
                      camera = cp.Cameras[Camera] as WpfInterface.CameraInterface.WpfCamera;
                      Action<object, Action> update = (object o, Action a) =>
                      {
                          Dispatcher.Invoke(a);
                      };
                      camera.Set(this, null, update);
                      object ob = System.Windows.Markup.XamlReader.Parse(camera.CameraBackground);
                      if (ob is Brush)
                      {
                          Background = (ob as Brush);
                      }*/
                WpfInterface.CameraInterface.WpfCamera c = 
                    scada.GetObject<WpfInterface.CameraInterface.WpfCamera>(Camera);
                if (c == camera)
                {
                    return;
                }
                camera = c;
                Action<object, Action> update = (object o, Action a) =>
                {
                    Dispatcher.Invoke(a);
                };
                camera.Set(this, null, update);
                object ob = System.Windows.Markup.XamlReader.Parse(camera.CameraBackground);
                if (ob is Brush)
                {
                    Background = (ob as Brush);
                }
            }
        }

        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
            }
        }

        #endregion

        #region Public Members

        [Browsable(true)]
        [TypeConverter(typeof(CameraConverter))]
        [Category("SCADA"), Description("Camera name"), DisplayName("Camera")]
        public string Camera
        {
            get;
            set;
        }

        #endregion

        #region Private Members

        static UserControlCamera()
        {
            Application.Current.Exit += Current_Exit;
        }

        static void Current_Exit(object sender, ExitEventArgs e)
        {
            DeleteTextures();
        }

        static void DeleteTextures()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            if (dir[dir.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            {
                dir += System.IO.Path.DirectorySeparatorChar;
            }
            string[] files = System.IO.Directory.GetFiles(dir);
            foreach (string file in files)
            {
                if (file.Contains("delete_texture_file"))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        #endregion

    }
}
