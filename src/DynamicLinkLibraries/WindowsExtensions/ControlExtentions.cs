using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using System.Windows.Forms;
using WindowsExtensions.Interfaces;
using WindowsExtensions.MouseOperations;

namespace WindowsExtensions
{
    /// <summary>
    /// Extensitions of control
    /// </summary>
    public static class ControlExtensions
    {

        #region Fields


        static private IModalMessageBox modalMessageBox =
            new MessageBoxImplementation.TrivialMessageBox();

        #endregion

       
        /// <summary>
        /// Enables mouse wheel resize
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="enable">The "enable" sign</param>
        public static void EnableMouseWheelResize(this Control control, bool enable)
        {
            MouseWheelResizer resizer = null;
            var tag = control.Tag;
            if (tag is MouseWheelResizer)
            {
                resizer = (MouseWheelResizer)tag;
            }
            else
            {
                resizer = new MouseWheelResizer(control);
            }
            resizer.Set(enable);
        }
        
        /// <summary>
        /// Gets all children of a control
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>The Children</returns>
        public static IEnumerable<Control> GetAllChildren(this Control control)
        {
            foreach (var o in control.Controls)
            {
                if (!(o is Control)) continue;
                var c= (Control)o;
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
        public static void EnabledLock(this IEnumerable<object> controls, Action action)
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
        public static void EnabledLock(this object control, Action action)
        {
            (new object[] { control }).EnabledLock(action);
        }

        /// <summary>
        /// Action with disable control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="action">Rhe action</param>
        public static void DisableAction(this Control control, Action action)
        {
            using (new Disable(control))
            {
                action();
            }
        }

        /// <summary>
        /// Modal message box implementation
        /// </summary>
        public static IModalMessageBox ModalMessageBox
        {
            get
            {
                return modalMessageBox;
            }
            set
            {
                modalMessageBox = value;
            }
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        public static void InvokeIfNeeded(this Control control, Action doit)
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
        public static void InvokeIfNeeded<T>(this Control control, Action<T> doit, T arg)
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
        public static void InvokeIfNeeded<T1, T2>(this Control control, Action<T1, T2> doit, T1 arg1, T2 arg2)
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
        public static void InvokeIfNeeded<T1, T2, T3>(this Control control, Action<T1, T2, T3> doit, T1 arg1, T2 arg2, T3 arg3)
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
        public static void InvokeIfNeeded<T1, T2, T3, T4>(this Control control, Action<T1, T2, T3, T4> doit, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowMessageBoxModal(string text)
        {
            return modalMessageBox.Show(text);
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
            return modalMessageBox.Show(text, caption);
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
            return modalMessageBox.Show(owner, text);
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
            return modalMessageBox.Show(owner, text, caption);
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
            return ControlExtensions.ShowMessageBoxModal(text, caption, buttons);
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
            return modalMessageBox.Show(owner, text, caption, buttons);
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
            return modalMessageBox.Show(text, caption, buttons, icon);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, displayHelpButton);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
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
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
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
    Object param
)
        {
            return modalMessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
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
            return modalMessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

    }
}