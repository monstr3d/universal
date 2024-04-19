using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using WindowsExtensions.Interfaces;

namespace WindowsExtensions
{
    /// <summary>
    /// Extension object 
    /// </summary>
    public class ExtensionObject
    {

        #region Members

        /// <summary>
        /// Fills DataGridView
        /// </summary>
        /// <param name="dataGridView">The DataGridView</param>
        /// <param name="keys">Keys</param>
        /// <param name="dictionary">Dictionary</param>
        public void Fill(DataGridView dataGridView, IEnumerable<string> keys, 
            IDictionary<string, string> dictionary)
        {
            var list = new List<string>(keys);
            list.Sort();
            foreach (var item in list)
            {
                var v = dictionary.ContainsKey(item) ? dictionary[item] : "";
                dataGridView.Rows.Add([item, v]);
            }
        }

        /// <summary>
        /// Finds child of control
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="control">The control</param>
        /// <returns>The child</returns>
        public T FindControlChild<T>(Control control) where T : Control
        {
            if (control is T)
            {
                return control as T;
            }
            foreach (Control c in control.Controls)
            {
                T t = FindControlChild<T>(c);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }


        /// <summary>
        /// Fills DataGridView by DataTable
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="dataGridView">DataGridView</param>
        public void Fill(DataTable dataTable, DataGridView dataGridView)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var rv = row.ItemArray;
                dataGridView.Rows.Add(rv);
            }
        }
 
        /// <summary>
        /// Creates Data table from Data grid view
        /// </summary>
        /// <param name="dataGridView">Data grid view</param>
        /// <returns>Data table</returns>
        public DataTable ToDataTable(DataGridView dataGridView)
        {

            DataTable table = new DataTable();
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                table.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dRow = table.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                table.Rows.Add(dRow);
            }
            return table;
        }

        /// <summary>
        /// Opens folder in file explorer
        /// </summary>
        /// <param name="folderPath">The folder</param>
        public void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
        }


        /// <summary>
        /// Gets all children of a control
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>The Children</returns>
        public IEnumerable<Control> GetAllChildren(Control control)
        {
            foreach (var o in control.Controls)
            {
                if (!(o is Control)) continue;
                var c = (Control)o;
                foreach (var item in c.GetAllChildren())
                {
                    yield return item;
                }
                yield return c;
            }
        }


        /// <summary>
        /// Enabled lock execution of action
        /// </summary>
        /// <param name="controls">Controls for disable/enable</param>
        /// <param name="action">Action for execution</param>
        public void EnabledLock(IEnumerable<object> controls, Action action)
        {
            using (Internal.EnabledLock l = new Internal.EnabledLock(controls))
            {
                action();
            }
        }

        /// <summary>
        /// Enabled lock execution of action
        /// </summary>
        /// <param name="control">Control for disable/enable</param>
        /// <param name="action">Action for execution</param>
        public void EnabledLock(object control, Action action)
        {
            (new object[] { control }).EnabledLock(action);
        }

        /// <summary>
        /// Action with disable control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="action">Rhe action</param>
        public void DisableAction(Control control, Action action)
        {
            using (new Disable(control))
            {
                action();
            }
        }

        /// <summary>
        /// Modal message box implementation
        /// </summary>
        public  IModalMessageBox ModalMessageBox
        {
            get;
            set;
        }

        #endregion

        #region Invoke if needed 

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        public void InvokeIfNeeded(Control control, Action doit)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit);
                return;
            }
            doit();
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg">Argument</param>
        public void InvokeIfNeeded<T>(Control control, Action<T> doit, T arg)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit, new object[] { arg });
                return;
            }
            doit(arg);
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <typeparam name="T1">First argument type</typeparam>
        /// <typeparam name="T2">Second argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg1">First argument</param>
        /// <param name="arg2">Second argument</param>
        public void InvokeIfNeeded<T1, T2>(Control control, Action<T1, T2> doit, T1 arg1, T2 arg2)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit, arg1, arg2);
                return;
            }
            doit(arg1, arg2);
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <typeparam name="T1">First argument type</typeparam>
        /// <typeparam name="T2">Second argument type</typeparam>
        /// <typeparam name="T3">Third argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg1">First argument</param>
        /// <param name="arg2">Second argument</param>
        /// <param name="arg3">Third argument</param>
        public void InvokeIfNeeded<T1, T2, T3>(Control control, Action<T1, T2, T3> doit, T1 arg1, T2 arg2, T3 arg3)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit, arg1, arg2, arg3);
                return;
            }
            doit(arg1, arg2, arg3);
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <typeparam name="T1">First argument type</typeparam>
        /// <typeparam name="T2">Second argument type</typeparam>
        /// <typeparam name="T3">Third argument type</typeparam>
        /// <typeparam name="T4">Forth argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg1">First argument</param>
        /// <param name="arg2">Second argument</param>
        /// <param name="arg3">Third argument</param>
        /// <param name="arg4">Forth argument type</param>
        public void InvokeIfNeeded<T1, T2, T3, T4>(Control control, Action<T1, T2, T3, T4> doit, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit, arg1, arg2, arg3, arg4);
                return;
            }
            doit(arg1, arg2, arg3, arg4);
        }

        #endregion

        #region   Show MessageBox Modal

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text)
        {
            return ModalMessageBox.Show(text);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text,
            string caption)
        {
            return ModalMessageBox.Show(text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
            string text)
        {
            return ModalMessageBox.Show(owner, text);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
            string text,
            string caption)
        {
            return ModalMessageBox.Show(owner, text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
            string text,
            string caption,
            MessageBoxButtons buttons
)
        {
            return ShowMessageBoxModal(text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
            IWin32Window owner,
        string text,
        string caption,
            MessageBoxButtons buttons
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
            string text,
        string caption,
        MessageBoxButtons buttons,
    MessageBoxIcon icon
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon);
        }


        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
        string caption,
        MessageBoxButtons buttons,
    MessageBoxIcon icon
        )
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
    IWin32Window owner,
    string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
    string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="displayHelpButton"></param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
        MessageBoxOptions options,
    bool displayHelpButton
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, displayHelpButton);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
    string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="keyword">Keyword</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
        MessageBoxOptions options,
    string helpFilePath,
    string keyword
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="navigator">Help navigator</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
    string text,
    string caption,
    MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
        MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="keyword">Keyword</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    string keyword
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="navigator">Help navigator</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="navigator">Help navigator</param>
        /// <param name="param">Parameter</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator,
    Object param
)
        {
            return ModalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <param name="options">Message box options</param>
        /// <param name="helpFilePath">Help file</param>
        /// <param name="navigator">Help navigator</param>
        /// <param name="param">Parameter</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowMessageBoxModal(
    IWin32Window owner,
    string text,
    string caption,
        MessageBoxButtons buttons,
        MessageBoxIcon icon,
        MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator,
    object param
)
        {
            return ModalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

        #endregion

    }
}
