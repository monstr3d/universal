using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Collections;
using System.Reflection;
using System.Diagnostics;




using Diagram.UI;
using Diagram.UI.Operations;
using Diagram.UI.Interfaces;

using Diagram.UI.Forms;

using DataPerformer.Interfaces;

using DataWarehouse;

using DataWarehouse.Interfaces;

using ResourceService;


using BasicEngineering.UI.Factory.Interfaces;

using ToolBox;

using DataWarehouse.Forms;



using WindowsExtensions;
using ErrorHandler;




namespace BasicEngineering.UI.Factory.Forms
{
    public partial class FormMain : Form, IBlob, IExceptionHandler, IProcess, IStartStop
    {

        #region Fields
        private PanelDesktop active;
        ToolsDiagram tools;
        EngineeringUIFactory factory;
        DatabaseInterface data;
       // private string text;
        private FormContainerDesigner formContainer;

        //private FormDatabaseTree formData;
        FormTools formTools;

        string fn = "";

        private IApplicationCreator creator;

        private Dictionary<string, object>[] resources;

        private bool isChecked = true;

        private bool closed = false;

        private TestCategory.Interfaces.ITest test;

        private ToolStripButton[][] startStopPauseButtons;

        #endregion

        #region Ctor

        private FormMain()
        {
            StaticExtensionDiagramUIForms.PostFormLoad =
                (Form form) => { form.LoadControlResources(); };
            StaticExtensionDiagramUIForms.PostLabelLoad =
                (Diagram.UI.Interfaces.Labels.IObjectLabelUI label) => 
                {  (label as Control).LoadControlResources(); };
            InitializeComponent();
            startStopPauseButtons = new ToolStripButton[][] { toolStripButtonStart.ToSingleArray<ToolStripButton>(), toolStripButtonStop.ToSingleArray<ToolStripButton>() };
        }

        internal FormMain(IApplicationCreator creator)
            : this()
        {
            this.creator = creator;
            if (creator.DatabaseCoordinator == null)
            {
                databaseToolStripMenuItem.Visible = false;
                savetodatabaseToolStripMenuItem.Visible = false;
                loadfromdatabaseToolStripMenuItem.Visible = false;
            }
            if (creator.Log != null)
            {
                toolStripButtonTest.Visible = true;
                Action close = () => 
                { 
                    if (creator.Log is IDisposable ds)
                    {
                        ds.Dispose();
                    }
                };
                Application.ThreadExit += (object o, EventArgs e) => { close(); };
 
            }
            Text = creator.Text;
            // creator.
            creator.LoadResources();
            Dictionary<string, object>[] standardResources = Common.UI.Resources.Utils.ControlUtilites.Resources;
            if (Diagram.UI.Utils.ControlUtilites.Resources == null)
            {
                Diagram.UI.Utils.ControlUtilites.Resources =
                    standardResources;
            }
            resources = Localizator.CreateResources(new Dictionary<string, object>[][]
            {
                creator.Resources,
                Common.Engineering.Localization.Utils.ControlUtilites.Resources,
                standardResources
            }
            );
            this.Icon = creator.Icon;
            filename = creator.Filename;
            if (filename == null)
            {
                filename = "";
            }
            this.LoadControlResources(resources);
            toolStripComboBoxChekDetails.SelectedIndex = Properties.Settings.Default.CheckLevel;
           /* formTree = new FormDockableTree();
            formTree.OnHide += delegate()
            {
                Properties.Settings.Default.ShowTree = false;
                Properties.Settings.Default.Save();
            };*/
            SetSettings();
        }


        /* public FormMain(PureDesktopPeer edit)
             : this()
         {
             this.edit = edit;
             prepare();
         }*/

        #endregion

        #region IExceptionHandler Members


        void IExceptionHandler.HandleException<T>(T exception, params object[]? o)
        {
            if (o != null)
            {
                if (o.Length == 1)
                {
                    var obj = o[0];
                    if (obj != null)
                    {
                        Type t = obj.GetType();
                        if (t.Equals(typeof(Int32)))
                        {
                            int errorLevel = (int)obj;
                            if (errorLevel == 0)
                            {
                                // Diagram.UI.Utils.ControlUtilites.HandleException(this, exception, StaticExtensionBasicEngineeringUIFactoryAdvanced.Resources);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                //ShowMessage(exception.Message, null);
            }
        }

        void IExceptionHandler.Log(string message, params object[]? obj)
        {
           // ShowMessage("", message);
        }


        #endregion

        #region IProcess Members

        void IProcess.Start()
        {
            try
            {
                double[] d = ControlDouble;
                int[] i = ControlInt;
                IStartStop ss = this;
                ss.Action(null, Diagram.UI.Interfaces.ActionType.Start);
                toolStripButtonStop.Enabled = true;
                creator.Start(d[0], d[1], i[0], i[1], i[2], active);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
               // ShowError(ex);
            }
        }

        /// <summary>
        /// Pauses process
        /// </summary>
        void IProcess.Pause()
        {
        }

        /// <summary>
        /// Terminates process
        /// </summary>
        void IProcess.Terminate()
        {
            factory.StopWorker();
        }

        /// <summary>
        /// Resumes process
        /// </summary>
        void IProcess.Resume()
        {
            Diagram.UI.Interfaces.ActionType.Resume.EnableDisableButtons(startStopPauseButtons);
            factory.Resume();
        }


        /// <summary>
        /// Shows status of process
        /// </summary>
        /// <param name="status">Status</param>
        void IProcess.ShowStatus(double status)
        {
        }

        /// <summary>
        /// Time of start
        /// </summary>
        double IProcess.StartTime
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>
        /// Step
        /// </summary>
        double IProcess.Step
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>
        /// Number of steps
        /// </summary>
        int IProcess.Count
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }


        #endregion

        #region IBlob Members

        byte[] IBlob.Bytes
        {
            get
            {
                MemoryStream stream = new MemoryStream();
                SaveAll(stream, false);
                return stream.GetBuffer();
            }
            set
            {
                MemoryStream stream = new MemoryStream(value);
                LoadFromStream(stream, ".");
            }
        }

        string IBlob.Extension
        {
            get { return "cfa"; }
            set { }
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, Diagram.UI.Interfaces.ActionType actionType)
        {
            if (actionType == Diagram.UI.Interfaces.ActionType.Start)
            {
                this.InvokeIfNeeded(StartPrivate);
            }
            else if (actionType == Diagram.UI.Interfaces.ActionType.Stop)
            {
                this.InvokeIfNeeded(StopPrivate);
            }
        }

        #endregion

        #region LoadSave

        public bool SaveAll(Stream stream, bool test)
        {
            try
            {
                Check();
                if (test)
                {
                    if (creator.TestInterface != null)
                    {
                        this.test = creator.TestInterface.Edit(this.test, active);
                    }
                }
                active.SaveAll(stream);
                if (this.test != null)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, this.test);
                }
                isChecked = false;
                return true;
            }
            catch (Exception ex)
            {
                isChecked = false;
                ex.HandleException(1);
            }
            return false;
        }

        public bool LoadFromStream(Stream stream, string ext)
        {
            bool b = active.LoadFromStream(stream, SerializationInterface.StaticExtensionSerializationInterface.Binder, ext, ".cfa");
            if (!b)
            {
                return false;
            }
            return true;
        }


        private void Check()
        {
            if (!isChecked)
            {
                isChecked = true;
                active.Check();
            }
        }

        #endregion

        #region Init

        protected void Prepare()
        {
            factory = creator.Factory as EngineeringUIFactory;
            factory.CancelProcess += () => { this.InvokeIfNeeded(StopAll); };
            creator.ApplicationInitializer.InitializeApplication();
            if (creator.Log != null)
            {
                factory.ExceptionHandler = creator.Log;
            }
            else
            {
                factory.ExceptionHandler = this;
            }
            Resources.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Environment.CurrentDirectory = Resources.CurrentDirectory + "";
            CommonOperations.CreateArrowControl(panelToolLeft, tools);
            ButtonWrapper.Add(creator.Buttons, tabControlControls, tools, new Size(35, 35), resources, true);
            ContainerPerformerUI.InitContainers(AppDomain.CurrentDomain.BaseDirectory, tools, tabControlControls,
                resources);
        }

        void StopAll()
        {
            StopEnable();
            IStartStop ss = this;
            ss.Action(null, Diagram.UI.Interfaces.ActionType.Stop);
        }

        private void initAll()
        {
            DataPerformer.Portable.StaticExtensionDataPerformerPortable.Desktop = active;
            StaticExtensionDiagramUI.PostLoadDesktop += PostLoad;
            initTools();
            initContainers();
        }

        private void initTools()
        {
            EditorReceiver.AddEditorDrag(active);
            PictureReceiver.AddImageDrag(active);
        }

        private void initContainers()
        {
            Assembly ass = typeof(FormMain).Assembly;
            string path = Path.GetDirectoryName(ass.Location);
        }

        #endregion

        #region Work with files


        private string filename
        {
            get
            {
                return fn;
            }
            set
            {
                fn = value;
                string t = Resources.GetControlResource(creator.Text, resources);
                if (fn == null)
                {
                    Text = t;
                }
                else
                {
                    if (fn.Length > 0)
                    {
                        Text = t + " [" + filename + "]";
                    }
                }
            }
        }

        private void saveas()
        {
            try
            {
                Check();
                saveFileDialogScn.InitialDirectory = ResourceService.Resources.CurrentDirectory + "scn";
                if (saveFileDialogScn.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                save(saveFileDialogScn.FileName, false);
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }


        private void save(string filename, bool test)
        {
            try
            {
                Check();
                Stream stream = File.Open(filename, FileMode.Create);
                SaveAll(stream, test);
                stream.Close();
                this.filename = filename;
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }

        private void save()
        {
            if (filename == null)
            {
                saveas();
                return;
            }
            if (filename.Length == 0)
            {
                saveas();
                return;
            }
           // check();
            save(filename, false);
        }


        void LoadContainer(Stream stream)
        {
        }

        void Open()
        {
            //openFileDialogScn.InitialDirectory = ResourceService.Resources.CurrentDirectory + "scn";
            if (openFileDialogScn.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            log(openFileDialogScn.FileName);
            string ext = Path.GetExtension(openFileDialogScn.FileName);
            Stream stream = File.OpenRead(openFileDialogScn.FileName);
         /*   if (ext.Equals("*.cont"))
            {
                LoadContainer(stream);
                return;
            }*/
            LoadFromStream(stream, ext);
            stream.Close();
            if (ext.ToLower().Equals(creator.Ext))
            {
                filename = openFileDialogScn.FileName + "";
            }
            else
            {
                filename = "";
            }
        }


        void log(string filename)
        {
            return;
          /*  string dir = AppDomain.CurrentDomain.BaseDirectory;
            if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
            {
                dir += Path.DirectorySeparatorChar;
            }
            StreamWriter wr = new StreamWriter(dir + "log.log", true, Encoding.UTF8);
            wr.WriteLine(filename);
            wr.WriteLine(DateTime.Now + "");
            wr.WriteLine("+++++++++++++++");
            Stream stream = File.OpenRead(filename);
            byte[] b = new byte[stream.Length];
            try
            {
                List<Exception> l = PureDesktopPeer.Check(b);
                if (l != null)
                {
                    foreach (Exception e in l)
                    {
                        wr.WriteLine(e.Message);
                        wr.WriteLine("------------");
                        wr.WriteLine(e.StackTrace);
                        wr.WriteLine("============");
                    }
                }
            }
            catch (Exception ex)
            {
                wr.WriteLine(ex.Message);
                wr.WriteLine("------------");
                wr.WriteLine(ex.StackTrace);
                wr.WriteLine("============");
            }
            wr.Flush();
            wr.Close();
            stream.Close();*/
        }


        #endregion

        #region Relicts

        #region Tests

        void testPerf()
        {
            /*   int n = 100;
               PureDesktopPeer d = new PureDesktopPeer();
               Stream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory +
                   "0.cfa");
               bool b = d.Load(stream, null);
               stream.Close();
               BitmapConsumer.IBitmapConsumer cons =
                   PureDesktop.GetAssociatedObject<BitmapConsumer.IBitmapConsumer>(d, "Picture map");
               StreamWriter wr = new StreamWriter("0.txt", false);
               DateTime t0 = DateTime.Now;
               wr.WriteLine(t0.ToLongTimeString());
               for (int i = 0; i < n; i++)
               {
                   cons.Process();
               }
               DateTime t1 = DateTime.Now;
               wr.WriteLine(t1.ToLongTimeString());
               TimeSpan dt = t1 - t0;
               double s = (60 * (double)dt.Minutes + (double)dt.Seconds + (double)dt.Milliseconds / 1000) / n;
               wr.WriteLine(s);
               wr.Close();*/
        }


 
        #endregion

        #region Sandcastle

        void setEnvProps(XmlDocument doc)
        {
            XmlNodeList l = doc.GetElementsByTagName("property");
            foreach (XmlElement e in l)
            {
                string name = e.Attributes["name"].Value;
                string value = e.Attributes["value"].Value;
                Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User);
            }
        }

        string systemReplace(string str)
        {
            string s = str;
            while (true)
            {
                if (!s.Contains("$"))
                {
                    break;
                }
                int n = s.IndexOf('$');
                IDictionary d = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
                foreach (object o in d.Keys)
                {
                    string ss = "${" + o + "}";
                    if (s.Contains(ss))
                    {
                        s = s.Replace(ss, d[o] + "");
                    }
                }
            }
            return s; ;
        }

        void copy(XmlDocument doc)
        {
            XmlNodeList l = doc.GetElementsByTagName("copy");
            foreach (XmlElement e in l)
            {
                copy(e);
            }
        }

        void copy(XmlElement e)
        {
            string inFile = systemReplace(e.Attributes["file"].Value);
            string outFile = systemReplace(e.Attributes["tofile"].Value);
            StreamReader r = new StreamReader(inFile);
            StreamWriter w = new StreamWriter(outFile);
            XmlNodeList l = e.GetElementsByTagName("replacestring");
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlElement el in l)
            {
                d[el.Attributes["from"].Value] = el.Attributes["to"].Value;
            }
            while (true)
            {
                string s = r.ReadLine();
                if (s == null)
                {
                    break;
                }
                foreach (string p in d.Keys)
                {
                    s = s.Replace(p, systemReplace(d[p]));
                }
                w.Write(s);
            }
            r.Close();
            w.Close();
        }


        private void exec(XmlDocument doc)
        {
            XmlNodeList l = doc.GetElementsByTagName("exec");
            exec(l[0] as XmlElement);
        }

        private void xmlToXsl(XmlDocument doc, string workDir)
        {
            string sxsl = "/xsl:";
            string sout = "/out:";

            XmlNodeList l = doc.GetElementsByTagName("arg");
            string[] s = new string[3];
            for (int i = 0; i < 3; i++)
            {
                int k = 0;

                string pref = null;
                XmlElement e = l[i] as XmlElement;
                string str = e.GetAttribute("value");
                if (str.Contains(sxsl))
                {
                    k = 1;
                    pref = sxsl;
                }
                if (str.Contains(sout))
                {
                    pref = sout;
                    k = 2;
                }
                if (pref != null)
                {
                    str = str.Substring(pref.Length);
                }
                str = systemReplace(str);
                if (str[0] == '\"' & str[str.Length - 1] == '\"')
                {
                    str = str.Substring(1, str.Length - 2);
                }
                if (File.Exists(workDir + str))
                {
                    str = workDir + str;
                }
                s[k] = str;
            }

            /*XslTransform xsl = new XslTransform();
            xsl.Load(s[1]);
            xsl.Transform(s[0], s[2]);*/

        }

        private void exec(XmlElement e)
        {
            string program = systemReplace(e.GetAttribute("program"));
            string workingDir = systemReplace(e.GetAttribute("workingdir"));
            string args = "";
            if (e.Attributes["commandline"] != null)
            {
                args = " " + e.GetAttribute("commandline");
            }
            XmlNodeList l = e.GetElementsByTagName("arg");
            foreach (XmlElement el in l)
            {
                string arg = systemReplace(el.GetAttribute("value"));
                args += " " + arg;
            }
            ProcessStartInfo info = new ProcessStartInfo(program, args);
            info.WorkingDirectory = workingDir;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p.WaitForExit();
            StreamWriter wr = new StreamWriter("1.txt");
            while (true)
            {
                string s = p.StandardOutput.ReadLine();
                if (s == null)
                {
                    break;
                }
                wr.WriteLine(s);
            }
            wr.Close();
        }

        #endregion


        #endregion

        #region Event Handlers

        #region Open & Close Window

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (creator.Holder != null)
            {
               // e
            }
            ShowDesktop();
            ShowTools();
            toolboxToolStripMenuItem.Checked = Properties.Settings.Default.ShowTools;
            objectTreelBarToolStripMenuItemObjects.Checked = Properties.Settings.Default.ShowTree;
            ShowTree();
            if (Properties.Settings.Default.ShowDatabase)
            {
                ShowData();
            }
            var hasLog = Properties.Settings.Default.HasLog;
            int ind = hasLog ? 0 : 1;
           // this.toolStripComboBoxHasLog.SelectedIndex = ind;
        ///  toolStripC
           /* if (Properties.Settings.Default.ShowControl)
            {
                ShowControl();
            }*/
            initAll();
            try
            {
                Prepare();
                ByteHolder holder = creator.Holder;
                if (holder != null)
                {
                    IDesktop edit = holder.Desktop;
                    active.Load(edit);
                }
                else
                {
                    char[] cb = Properties.Settings.Default.SavedState.ToCharArray();
                    byte[] b = new byte[cb.Length];
                    for (int i = 0; i < b.Length; i++)
                    {
                        b[i] = (byte)cb[i];
                    }
                    MemoryStream ms = null;
                    if (b.Length > 1)
                    {
                        ms = new MemoryStream(b);
                    }
                    Stream stream = ms;
                    if (filename != null)
                    {
                        if (filename.Length != 0)
                        {
                            log(filename);
                            stream = File.OpenRead(filename);
                            // ext = Path.GetExtension(filename);
                        }
                    }
                    if (stream != null)
                    {
                        LoadFromStream(stream, creator.Ext);
                        stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SaveSettings())
            {
                closed = true;
                e.Cancel = true;
            }
        }

        #endregion

        #region Click Control Events

        /// <summary>
        /// Test action
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event argumets</param>
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            active.Decompose();
        }


        private void clearallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active.RemoveAll();
            active.Redraw();
            active.Refresh();

        }

        private void clearselectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active.RemoveSelected();
            active.Redraw();
            active.Refresh();

        }


        private void deletecommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active.DeleteComments();
        }


        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }


        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Check();
                active.RefreshObjects();
                //update();

                GC.Collect();
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }

        private void toolStripButtonFont_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox box = ControlPanel.GetActiveTextBox(active);
                if (box == null)
                {
                    return;
                }
                FontDialog dlg = new FontDialog();
                dlg.ShowDialog(this);
                Font font = dlg.Font;
                box.Font = font;
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }

        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            active.TempDelete();
        }


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active.SelectAll(true);
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            active.SelectAll(false);
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = "";
            data = null;
            prepareData();
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }



        private void readWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!prepareData())
            {
                return;
            }
            FormDatabase form = new FormDatabase(
                new StandardStarter(ResourceService.Resources.CurrentDirectory + "Temp\\"),
                data, true);
            form.ShowDialog(this);

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename.Length == 0)
            {
                saveasToolStripMenuItem_Click(sender, e);
                return;
            }
            try
            {
                Stream stream = File.Open(filename, FileMode.Create);
                SaveAll(stream, false);
                stream.Close();
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }


        private void loadfromdatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFromDatabase();
        }


        private void toolStripButtonLoadFromDatabase_Click(object sender, EventArgs e)
        {
            loadFromDatabase();
        }

        private void changeorderofselectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormOrder(active);
            form.ShowDialog(this);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update();
        }

        private void savetodatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToDatabase();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
           Open();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = new MemoryStream();
            active.SaveSelected(stream);
            Clipboard.SetData("AstroFrame", stream);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object o = Clipboard.GetData("AstroFrame");
            if (o == null)
            {
                return;
            }
            Stream stream = o as Stream;
            LoadFromStream(stream, creator.Ext);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearselectedToolStripMenuItem_Click(sender, e);
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveas();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void toolStripButtonStrict_Click(object sender, EventArgs e)
        {
            if (toolStripButtonStrict.Checked)
            {
               // StaticExtensionDiagramUI.SetStrictErrorHandler();
            }
            else
            {
              //  StaticExtensionDiagramUI.ErrorHandler = null;
            }
        }




        private void ActionPrivate(Diagram.UI.Interfaces.ActionType actionType)
        {
            if (actionType == Diagram.UI.Interfaces.ActionType.Start)
            {
                StartDisable();
            }
            else
            {
                StopEnable();
            }
            StaticExtensionDiagramUIFactory.Action(active, null, actionType);
        }

        void StartPrivate()
        {
            ActionPrivate(Diagram.UI.Interfaces.ActionType.Start);
        }

        void StopPrivate()
        {
            ActionPrivate(Diagram.UI.Interfaces.ActionType.Stop);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void derivationCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new DataPerformer.UI.Forms.FormDerivationCalculator("xyzt");
            f.Show();
        }

        private void containerDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showContainerDesigner();
        }

        private void toolStripButtonTest_Click(object sender, EventArgs e)
        {
            /* !!! TESTING TEMPORARILY COMMENTED
            TestCategory.UI.TestPerformerUI perf = new TestCategory.UI.TestPerformerUI();
            perf.TestData(data, null, active, "cfa", "cfa", creator.Log);
            PureDesktopPeer d = new PureDesktopPeer();
            active.Copy(d);
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, d);
            MemoryStream str = new MemoryStream(ms.GetBuffer());
            d = bf.Deserialize(str) as PureDesktopPeer;
            clearallToolStripMenuItem_Click(null, null);
            active.Load(d);
            */

        }
        private void toolStripButtonSync_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }

       /* private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl();
        }*/

        private void objectTreelBarToolStripMenuItemObjects_Click(object sender, EventArgs e)
        {
            ShowTree();
        }

        private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowTools = toolboxToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            ShowTools();
        }

        private void toolStripComboBoxChekDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCheckLevel();
        }


        #endregion

        #endregion

        #region Work with database

        private bool prepareData()
        {
            if (data != null)
            {
                return true;
            }
            string ser = "";
            try
            {
                ser = server;
                if (ser.Length == 0)
                {
                    connect();
                    if (server.Length == 0)
                    {
                        return false;
                    }
                    ser = server;
                }
                /*if (formData != null)
                {
                    formData.Hide();
                    formData = null;
                }*/
                IDatabaseInterface inter = //ReportingServer.ReportingInterface.GetService("");
                      DataWarehouse.StaticExtensionDataWarehouse.Coordinator[ser];

                IUser user = new User("", "", null);
                data = new DatabaseInterface(inter);
                ShowData();
                return true;
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                if (Properties.Settings.Default.ConnectionStrings.Contains(ser))
                {
                    Properties.Settings.Default.ConnectionStrings.Remove(ser);
                }
                Properties.Settings.Default.Server = "";
                Properties.Settings.Default.Save();
                // loadfromdatabaseToolStripMenuItem.Visible = false;
                // savetodatabaseToolStripMenuItem.Visible = false;
                /*toolStripButtonLoadFromDatabase.Visible = false;
                databaseToolStripMenuItem.Visible = false;*/
            }
            return false;
        }


        private void connect()
        {
            /*
            FormConnectToDatabase form = new FormConnectToDatabase();
            form.ShowDialog(this);*/
            System.Collections.Specialized.StringCollection str = Properties.Settings.Default.ConnectionStrings;

            List<string> l = new List<string>();
            foreach (string s in str)
            {
                l.Add(s);
            }
            l.Sort();
            string serv = server + "";
            FormConnectionString form = new FormConnectionString(l, server);
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                server = "";
                return;
            }
            serv = form.ConnectionString;
            if (!l.Contains(serv))
            {
                Properties.Settings.Default.ConnectionStrings.Add(serv);
                Properties.Settings.Default.Save();
            }
            server = serv;
        }

        private string server
        {
            get
            {

                // Properties.Settings.Default.Server = "3d-monstr";
                // Properties.Settings.Default.Save();
                string s = Properties.Settings.Default.Server;
                if (s.Length == 0)
                {
                    // dataToolStripMenuItem.Visible = false;
                }
                return Properties.Settings.Default.Server;
            }
            set
            {
                Properties.Settings.Default.Server = value;
                /*if (value.Length == 0)
                {
                    dataToolStripMenuItem.Visible = false;
                }
                else
                {
                    dataToolStripMenuItem.Visible = false;
                }*/
                Properties.Settings.Default.Save();
            }
        }



        void loadFromDatabase()
        {
            if (!prepareData())
            {
                return;
            }
            try
            {
                FormDatabase form = new FormDatabase(this, data, true);
                form.ShowDialog(this);
            }
            catch (Exception e)
            {
                e.HandleException(10);
            }
        }



        void saveToDatabase()
        {
            if (!prepareData())
            {
                return;
            }
            FormDatabase form = new FormDatabase(this, data, false);
            form.ShowDialog(this);
        }

        #endregion

        #region Shows Child Windows

        private void showContainerDesigner()
        {

            Diagram.UI.Forms.FormContainerDesigner.Show(active, ref formContainer);
        }


        private void ShowDesktop()
        {
            tools = new ToolsDiagram(creator.Factory);
            tools.Tree = treeViewObjects;
            PanelDesktop desktop = new PanelDesktop(tools);
            desktop.Extension = ".cfa";
            active = desktop;
            StaticExtensionDiagramUI.CurrentDeskop = desktop;
            desktop.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(desktop);
            active.AllowDrop = true;

           // createDockMan();

           /* if (desktop == null)
            {
                tools = new ToolsDiagram(creator.Factory);
                desktop = new FormDesktop(tools, creator.Ext);
                desktop.Desktop.AddStreamCreator("DataWarehouse.DatabaseStreamCreator");
                tools.Tree = formTree.Tree;
                //tools.Active = desktop.Desktop;
            }
            desktop.Show(dockManager);
            active = desktop.Desktop;*/

        }

        private void OpenNode(TreeNode node)
        {
            object o = node.Tag;
            if (o == null)
            {
                return;
            }
            if (!(o is ILeaf))
            {
                return;
            }
            Common.UI.IStreamCreator sc = new DatabaseStreamCreator(o as ILeaf);
            Stream stream = sc.Stream;
            active.LoadFromStream(stream, SerializationInterface.StaticExtensionSerializationInterface.Binder, active.Extension, active.Extension);
        }

        private void ShowTree()
        {
            //createDockMan();
            // formTree.Show(dockManager);
            bool b = objectTreelBarToolStripMenuItemObjects.Checked;

            splitContainerMain.Panel1Collapsed = !b;

            Properties.Settings.Default.ShowTree = b;
            Properties.Settings.Default.Save();
        }

        private void ShowControl()
        {
            toolStripTextBoxStart.Text = Properties.Settings.Default.StartTime + "";
            toolStripTextBoxStep.Text = Properties.Settings.Default.Step + "";
            toolStripTextBoxPause.Text = Properties.Settings.Default.Pause + "";
            toolStripTextBoxStepCount.Text = Properties.Settings.Default.StepCount + "";
        }



        void ShowTools()
        {
           /* if (formTools == null)
            {
                formTools = new FormTools();
                Content c = formTools;
                formTools.OnHide += delegate()
                {
                    Properties.Settings.Default.ShowTools = false;
                    Properties.Settings.Default.Save();
                };
            }
            Properties.Settings.Default.ShowTools = true;
            Properties.Settings.Default.Save();
            formTools.Show(dockManager);*/
            if (!Properties.Settings.Default.ShowTools)
            {
                if (formTools != null)
                {
                    if (!formTools.IsDisposed)
                    {
                        formTools.Close();
                    }
                }
                return;
            }
            if (formTools == null)
            {
                CreateFormTools();
            }
            if (formTools.IsDisposed)
            {
                CreateFormTools();
            }

        }

        void CreateFormTools()
        {
            formTools = new FormTools();
            formTools.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                if (!closed)
                {
                    Properties.Settings.Default.ShowTools = false;
                    Properties.Settings.Default.Save();
                }
            };

            formTools.Show();
            formTools.BringToFront();
        }


        void ShowData()
        {
            /*if (creator.DatabaseCoordinator == null)
            {
                return;
            }
            createDockMan();
            if (formData == null)
            {
                if (data == null)
                {
                    try
                    {
                        string ser = server;
                        if (ser.Length == 0)
                        {
                            return;
                        }
                        IDatabaseInterface inter = //ReportingServer.ReportingInterface.GetService("");
                       DatabaseInterface.Coordinator[ser];

                        IUser user = new User("", "", null);
                        data = new DatabaseInterface(user, inter);
                        EngineeringUIFactory.Data = data;
                    }
                    catch (Exception ex)
                    {
                        ex.HandleException(10);
                        server = "";
                        return;
                    }
                }
                try
                {
                    formData = new FormDatabaseTree(data, creator.Ext, creator.Icon.ToBitmap());
                    formData.OnHide += delegate()
                    {
                        Properties.Settings.Default.ShowDatabase = false;
                        Properties.Settings.Default.Save();
                    };
                }
                catch (Exception exc)
                {
                    exc.HandleException(10);
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(exc.Message);
                    Properties.Settings.Default.ShowDatabase = false;
                    Properties.Settings.Default.Save();
                    return;
                }
            }
            Properties.Settings.Default.ShowDatabase = true;
            Properties.Settings.Default.Save();
            formData.Show(dockManager);
             * */
        }


        #endregion

        #region Members

        #region Public Members

        public IApplicationCreator Creator
        {
            get
            {
                return creator;
            }
        }

        #endregion

        #region Nonpublic Members

        void PostLoad(IDesktop desktop)
        {
            update();
            PanelDesktop pd = desktop as PanelDesktop;
            IEnumerable<object> coll = active.AllComponents;
            foreach (object o in coll)
            {
                if (o is IStartStopConsumer)
                {
                    IStartStopConsumer ssc = o as IStartStopConsumer;
                    ssc.StartStop = this;
                }
            }
        }

        void Start()
        {
            StartDisable();
            toolStripButtonStop.Enabled = true;
            IProcess p = this;
            p.Start();

        }
        
        void Stop()
        {
            IProcess p = this;
            p.Terminate();
        }

        void StartDisable()
        {
            ToolStripItemCollection coll = toolStripMain.Items;
            foreach (ToolStripItem it in coll)
            {
                it.Enabled = false;
            }
            active.AllowDrop = false;
            menuStripMain.Enabled = false;
            tabControlControls.Enabled = false;
           // toolStripButtonStop.Enabled = true;
        }

        void StopEnable()
        {
            ToolStripItemCollection coll = toolStripMain.Items;
            foreach (ToolStripItem it in coll)
            {
                it.Enabled = true;
            }
            active.AllowDrop = true;
            menuStripMain.Enabled = true;
            tabControlControls.Enabled = true;
            toolStripButtonStop.Enabled = false;
        }

        private void update()
        {
            try
            {
                using (var backup = 
                    new DataPerformer.Portable.TimeProviderBackup(active, 0, null))
                {
                    IDataRuntime r = backup.Runtime;
                    r.Refresh();
                    r.StartAll(StartTime);
                    r.TimeProvider.Time = StartTime;
                    r.UpdateAll();
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
           }
        }

        void SetSettings()
        {
            WindowState = Properties.Settings.Default.FullScreen ? FormWindowState.Maximized : FormWindowState.Normal;
            Left = Properties.Settings.Default.Left = Left;
            Top = Properties.Settings.Default.Top = Top;
            if (Properties.Settings.Default.Width > 0)
            {
                Width = Properties.Settings.Default.Width;
                Height = Properties.Settings.Default.Height;
            }
            toolStripComboBoxChekDetails.SelectedIndex = Properties.Settings.Default.CheckLevel;
            SetCheckLevel();
            toolStripComboBoxChekDetails.SelectedIndexChanged += toolStripComboBoxChekDetails_SelectedIndexChanged;
            ShowControl();
        }

        private double StartTime
        {
            get
            {
                return GetDouble(toolStripTextBoxStart, Properties.Settings.Default.StartTime);
            }
        }

        private double GetDouble(ToolStripTextBox tb, double def)
        {
            try
            {
                return Double.Parse(tb.Text);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            return def;
        }
        
        private int GetInt(ToolStripTextBox tb, int def)
        {
            try
            {
                return Int32.Parse(tb.Text);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            return def;
        }

        private double[] GetDouble(ToolStripTextBox[] tb, double[] def)
        {
            double[] d = new double[tb.Length];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = GetDouble(tb[i], d[i]);
            }
            return d;
        }
        
        private int[] GetInt(ToolStripTextBox[] tb, int[] def)
        {
            int[] d = new int[tb.Length];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = GetInt(tb[i], d[i]);
            }
            return d;
        }

        double[] ControlDouble
        {
            get
            {
             double[] d = new double[]{Properties.Settings.Default.StartTime,
                Properties.Settings.Default.StartStep};
            double[] dx = GetDouble(new ToolStripTextBox[]
            {
                toolStripTextBoxStart,
                toolStripTextBoxStep
            }, d);
                return dx;
           }
        }


        int[] ControlInt
        {
            get
            {
                ToolStripTextBox[] tb = new ToolStripTextBox[]
                {
            toolStripTextBoxPause,
               toolStripTextBoxStepCount
                };

                int[] i = new int[]
                {
           Properties.Settings.Default.Pause,
           Properties.Settings.Default.StepCount


                };
                return GetInt(tb, i);
            }
        }

        static protected string GetControlResource(string str)
        {
            return Resources.GetControlResource(str, Diagram.UI.Utils.ControlUtilites.Resources);
        }

        bool SaveSettings()
        {

            if (creator.Holder != null)
            {
                DialogResult dr = ControlExtensions.ShowMessageBoxModal(
                 GetControlResource("Save data?"),
                   GetControlResource(creator.Text),
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
                if (dr == DialogResult.No)
                {
                    return true;
                }

            }
            Properties.Settings.Default.FullScreen = (WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Height = Height;
           /* if (dockManager != null)
            {
                dockManager.SetLayouot();
                Properties.Settings.Default.LeftPortion = dockManager.DockLeftPortion;
                Properties.Settings.Default.RightPortion = dockManager.DockRightPortion;
            }*/
            MemoryStream ms = new MemoryStream();
            if (!SaveAll(ms, false))
            {
                return false;
            }
            double[] d = ControlDouble;
            Properties.Settings.Default.StartTime = d[0];
            Properties.Settings.Default.Step = d[1];
            int[] ii = ControlInt;
            Properties.Settings.Default.Pause = ii[0];
            Properties.Settings.Default.StartStep = ii[1];
           //// Properties.Settings.Default.StepCount = ii[2];
            if (creator.Holder == null)
            {
                byte[] b = ms.GetBuffer();
                char[] cb = new char[b.Length];
                for (int k = 0; k < b.Length; k++)
                {
                    cb[k] = (char)b[k];
                }
                string str = new string(cb);
                Properties.Settings.Default.SavedState = str;
                StaticExtensionBasicEngineering.LogConnectionString = 
                    Event.Log.Database.StaticExtensionEventLogDatabase.ConnectionString;
                Properties.Settings.Default.Save();
            }
            else
            {
                PureDesktopPeer edit = new PureDesktopPeer();
                active.Copy(edit);
                ByteHolder holder = new ByteHolder();
                holder.Bytes = edit.Content;
                creator.Holder = holder;
            }
            return true;
        }

        private void SetCheckLevel()
        {
            int i = toolStripComboBoxChekDetails.SelectedIndex;
          /*  if (i == 0)
            {
                DataPerformer.Formula.FormulaMeasurement.CheckValue =
                    DataPerformer.Formula.FormulaMeasurement.Check;
            }
            else
            {
                DataPerformer.Formula.FormulaMeasurement.CheckValue =
                    DataPerformer.Formula.FormulaMeasurement.EmptyCheck;
            }*/
            Properties.Settings.Default.CheckLevel = i;
            Properties.Settings.Default.Save();
        }

        #endregion
 
        #endregion

    }
}


