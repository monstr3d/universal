using CategoryTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BasicEngineering.UI.Factory
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionBasicEngineering
    {
        static StaticExtensionBasicEngineering()
        {

        }

        public static bool StaticClassGenerated
        {
            get => Properties.Settings.Default.StaticClassGenerated;
            set => Properties.Settings.Default.StaticClassGenerated = value;
        }

        /// <summary>
        /// Server
        /// </summary>
        public static string Server
        {
            get
            {
                return Properties.Settings.Default.Server;
            }
            set
            {
                Properties.Settings.Default.Server = value;
            }
        }

        /// <summary>
        /// The "has log" sign
        /// </summary>
        public static  bool HasLog
        {
            get => Properties.Settings.Default.HasLog;
            set
            {
                Properties.Settings.Default.HasLog = value;
                Properties.Settings.Default.Save();
                Event.Interfaces.StaticExtensionEventInterfaces.HasLog = value;
            }
        }

        /// <summary>
        /// Sound directory
        /// </summary>
        public static string SoundDirectory
        {
            get
            {
                SoundService.StaticExtensionSoundService.SoundDirectory = Properties.Settings.Default.SoundDirectory;
                return Properties.Settings.Default.SoundDirectory;
            }
            set
            {
                Properties.Settings.Default.SoundDirectory = value;
                SoundService.StaticExtensionSoundService.SoundDirectory = value;
            }
        }


        /// <summary>
        /// Full screen sign
        /// </summary>
        public static bool FullScreen
        {
            get
            {
                return Properties.Settings.Default.FullScreen;
            }
            set
            {
                Properties.Settings.Default.FullScreen = value;
            }
        }


        /// <summary>
        /// Start time
        /// </summary>
        public static double StartTime
        {
            get
            {
                return Properties.Settings.Default.StartTime;
            }
            set
            {
                Properties.Settings.Default.StartTime = value;
            }
        }

        /// <summary>
        /// Pause
        /// </summary>
        public static int Pause
        {
            get
            {
                return Properties.Settings.Default.Pause;
            }
            set
            {
                Properties.Settings.Default.Pause = value;
            }
        }

        /// <summary>
        /// Time indicator
        /// </summary>
        public static int TimeIndicator
        {
            get
            {
                return Properties.Settings.Default.TimeIndicator;
            }
            set
            {
                Properties.Settings.Default.TimeIndicator = value;
            }
        }

        /// <summary>
        /// Start step
        /// </summary>
        public static int StartStep
        {
            get
            {
                return Properties.Settings.Default.StartStep;
            }
            set
            {
                Properties.Settings.Default.StartStep = value;
            }
        }

        /// <summary>
        /// Count of steps
        /// </summary>
        public static int StepCount
        {
            get
            {
                return Properties.Settings.Default.StepCount;
            }
            set
            {
                Properties.Settings.Default.StepCount = value;
            }
        }

        /// <summary>
        /// Step
        /// </summary>
        public static double Step
        {
            get
            {
                return Properties.Settings.Default.Step;
            }
            set
            {
                Properties.Settings.Default.Step = value;
            }
        }

        /// <summary>
        /// List of connection strings
        /// </summary>
        public static global::System.Collections.Specialized.StringCollection ConnectionStrings
        {
            get
            {
                return Properties.Settings.Default.ConnectionStrings;
            }
            set
            {
                Properties.Settings.Default.ConnectionStrings = value;
            }
        }

        /// <summary>
        /// Saved state
        /// </summary>
        public static string SavedState
        {
            get
            {
                return Properties.Settings.Default.SavedState;
            }
            set
            {
                Properties.Settings.Default.SavedState = value;
            }
        }

        /// <summary>
        /// Log coonection string
        /// </summary>
        public static string LogConnectionString
        {
            get
            {
                return Properties.Settings.Default.LogConnectionString;
            }
            set
            {
                Properties.Settings.Default.LogConnectionString = value;
            }
        }


        /// <summary>
        /// Top of main window
        /// </summary>
        public static int Top
        {
            get
            {
                return Properties.Settings.Default.Top;
            }
            set
            {
                Properties.Settings.Default.Top = value;
            }
        }

        /// <summary>
        /// Left of main window
        /// </summary>
        public static int Left
        {
            get
            {
                return Properties.Settings.Default.Left;
            }
            set
            {
                Properties.Settings.Default.Left = value;
            }
        }

        /// <summary>
        /// Width of main window
        /// </summary>
        public static int Width
        {
            get
            {
                return Properties.Settings.Default.Width;
            }
            set
            {
                Properties.Settings.Default.Width = value;
            }
        }

        /// <summary>
        /// Height of main window
        /// </summary>
        public static int Height
        {
            get
            {
                return Properties.Settings.Default.Height;
            }
            set
            {
                Properties.Settings.Default.Height = value;
            }
        }

        /// <summary>
        /// Left portion of floating windows
        /// </summary>
        public static double LeftPortion
        {
            get
            {
                return Properties.Settings.Default.LeftPortion;
            }
            set
            {
                Properties.Settings.Default.LeftPortion = value;
            }
        }

        /// <summary>
        /// Right portion of floating windows
        /// </summary>
        public static double RightPortion
        {
            get
            {
                return Properties.Settings.Default.RightPortion;
            }
            set
            {
                Properties.Settings.Default.RightPortion = value;
            }
        }

        /// <summary>
        /// The "show tree" sign
        /// </summary>
        public static bool ShowTree
        {
            get
            {
                return Properties.Settings.Default.ShowTree;
            }
            set
            {
                Properties.Settings.Default.ShowTree = value;
            }
        }

        /// <summary>
        /// The "show tools" sign
        /// </summary>
        public static bool ShowTools
        {
            get
            {
                return Properties.Settings.Default.ShowTools;
            }
            set
            {
                Properties.Settings.Default.ShowTools = value;
            }
        }

        /// <summary>
        /// The "show warnings" sign
        /// </summary>
        public static bool ShowWarnings
        {
            get
            {
                return Properties.Settings.Default.ShowWarnings;
            }
            set
            {
                Properties.Settings.Default.ShowWarnings = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// The "show database" sign
        /// </summary>
        public static bool ShowDatabase
        {
            get
            {
                return Properties.Settings.Default.ShowDatabase;
            }
            set
            {
                Properties.Settings.Default.ShowDatabase = value;
            }
        }


        /// <summary>
        /// Level of checking
        /// </summary>
        public static int CheckLevel
        {
            get
            {
                return Properties.Settings.Default.CheckLevel;
            }
            set
            {
                Properties.Settings.Default.CheckLevel = value;
            }
        }

        /// <summary>
        /// Level of checking
        /// </summary>
        public static string DirectoryOfGeneratedFiles
        {
            get
            {
                return Properties.Settings.Default.DirectoryOfGeneratedFiles;
            }
            set
            {
                Properties.Settings.Default.DirectoryOfGeneratedFiles = value;
            }
        }


        /// <summary>
        /// Level of checking
        /// </summary>
        public static string GeneratedClassName
        {
            get
            {
                return Properties.Settings.Default.GeneratedClassName;
            }
            set
            {
                Properties.Settings.Default.GeneratedClassName = value;
                Properties.Settings.Default.Save();
            }
        }




        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
