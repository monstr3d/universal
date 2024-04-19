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
    /// Extensitions of control
    /// </summary>
    public static class ControlExtensions
    {
        #region Ctor

        static ControlExtensions()
        {
            extension = new ExtensionObject();
            extension.ModalMessageBox = new MessageBoxImplementation.TrivialMessageBox();
        }

        #endregion

        #region Fields

        static ExtensionObject extension;

        #endregion

        #region Members
        /// <summary>
        /// Fills DataGridView by DataTable
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="dataGridView">DataGridView</param>
        public static void Fill(this DataTable dataTable, DataGridView dataGridView)
        {
           extension.Fill(dataTable, dataGridView);
        }

        /// <summary>
        /// Finds child of control
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="control">The control</param>
        /// <returns>The child</returns>
        public static T FindControlChild<T>(this Control control) where T : Control
        {
            return extension.FindControlChild<T>(control);
        }

        /// <summary>
        /// Creates Data table from Data grid view
        /// </summary>
        /// <param name="dataGridView">Data grid view</param>
        /// <returns>Data table</returns>
        public static DataTable ToDataTable(this DataGridView dataGridView)
        {
            return extension.ToDataTable(dataGridView);
        }

        /// <summary>
        /// Opens folder in file explorer
        /// </summary>
        /// <param name="folderPath">The folder</param>
        public static void OpenFolder(this string folderPath)
        {
            extension.OpenFolder(folderPath);
        }

        /// <summary>
        /// Gets all children of a control
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>The Children</returns>
        public static IEnumerable<Control> GetAllChildren(this Control control)
        {
            return extension.GetAllChildren(control);
        }
        
        /// <summary>
        /// Enabled lock execution of action
        /// </summary>
        /// <param name="controls">Controls for disable/enable</param>
        /// <param name="action">Action for execution</param>
        public static void EnabledLock(this IEnumerable<object> controls, Action action)
        {
            extension.EnabledLock(controls, action);
        }

        /// <summary>
        /// Enabled lock execution of action
        /// </summary>
        /// <param name="control">Control for disable/enable</param>
        /// <param name="action">Action for execution</param>
        public static void EnabledLock(this object control, Action action)
        {
           extension.EnabledLock ([ control ], action);
        }

        /// <summary>
        /// Action with disable control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="action">Rhe action</param>
        public static void DisableAction(this Control control, Action action)
        {
            extension.DisableAction(control, action);
        }

        /// <summary>
        /// Modal message box implementation
        /// </summary>
        public static IModalMessageBox ModalMessageBox
        {
            get
            {
                return extension.ModalMessageBox;
            }
            set
            {
                extension.ModalMessageBox = value;
            }
        }

        #endregion

        #region Invoke if needed 

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        public static void InvokeIfNeeded(this Control control, Action doit)
        {
            extension.InvokeIfNeeded(control, doit);
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg">Argument</param>
        public static void InvokeIfNeeded<T>(this Control control, Action<T> doit, T arg)
        {
            extension.InvokeIfNeeded<T>(control, doit, arg);
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
        public static void InvokeIfNeeded<T1, T2>(this Control control, Action<T1, T2> doit, T1 arg1, T2 arg2)
        {
            extension.InvokeIfNeeded(control as Control, doit, arg1, arg2);
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
        public static void InvokeIfNeeded<T1, T2, T3>(this Control control, Action<T1, T2, T3> doit, T1 arg1, T2 arg2, T3 arg3)
        {
            extension.InvokeIfNeeded(control, doit, arg1, arg2, arg3);
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
        public static void InvokeIfNeeded<T1, T2, T3, T4>(this Control control, Action<T1, T2, T3, T4> doit, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            extension.InvokeIfNeeded(control, doit, arg1, arg2, arg3, arg4);
        }

        #endregion

        #region   Show MessageBox Modal

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(string text)
        {
            return extension.ShowMessageBoxModal(text);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(string text,
            string caption)
        {
            return extension.ShowMessageBoxModal(text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
            string text)
        {
            return extension.ShowMessageBoxModal(owner, text);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
            string text,
            string caption)
        {
            return extension.ShowMessageBoxModal(owner, text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(
            string text,
            string caption,
            MessageBoxButtons buttons
)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtons buttons
)
        {
            return extension.ShowMessageBoxModal(owner, text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(
            string text,
            string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon);
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
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
        )
        {
            return extension.ShowMessageBoxModal(owner, text, caption, buttons, icon);
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
        public static DialogResult ShowMessageBoxModal(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon, defaultButton);
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
        public static DialogResult ShowMessageBoxModal(
    IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return extension.ShowMessageBoxModal(owner, text, caption, buttons, icon, defaultButton);
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
        public static DialogResult ShowMessageBoxModal(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon, defaultButton, options);
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
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options
)
        {
            return extension.ShowMessageBoxModal(owner, text, caption, buttons, icon, defaultButton, options);
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
        public static DialogResult ShowMessageBoxModal(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    bool displayHelpButton
)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon, defaultButton, options, displayHelpButton);
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
        public static DialogResult ShowMessageBoxModal(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return extension.ShowMessageBoxModal(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
        public static DialogResult ShowMessageBoxModal(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    string keyword
)
        {
            return extension.ShowMessageBoxModal(text, caption, buttons, icon,
                defaultButton, options, helpFilePath, keyword);
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
        public static DialogResult ShowMessageBoxModal(
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
            return extension.ShowMessageBoxModal(text, caption, buttons, icon, 
                defaultButton, options, helpFilePath, navigator);
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
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
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
            return extension.ShowMessageBoxModal(owner, text, caption, buttons,
                icon, defaultButton, options, helpFilePath, keyword);
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
        public static DialogResult ShowMessageBoxModal(IWin32Window owner,
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
            return extension.ShowMessageBoxModal(owner, text, caption, buttons,
                icon, defaultButton, options, helpFilePath, navigator);
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
        public static DialogResult ShowMessageBoxModal(string text,
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
            return extension.ShowMessageBoxModal(text, caption, buttons, icon,
                defaultButton, options, helpFilePath, navigator, param);
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
        public static DialogResult ShowMessageBoxModal(
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
            return extension.ShowMessageBoxModal(owner, text, caption, buttons, icon,
                defaultButton, options, helpFilePath, navigator, param);
        }

        #endregion

    }
}