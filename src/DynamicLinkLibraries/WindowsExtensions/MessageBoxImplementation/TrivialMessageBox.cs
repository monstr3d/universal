using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsExtensions.Interfaces;

namespace WindowsExtensions.MessageBoxImplementation
{
    /// <summary>
    /// Trivial message box
    /// </summary>
    public class TrivialMessageBox : IModalMessageBox
    {
        #region IModalMessageBox Members

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(string text)
        {
            return MessageBox.Show(text);
        }


        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(string text,
    string caption)
        {
            return MessageBox.Show(text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(IWin32Window owner,
    string text)
        {
            return MessageBox.Show(owner, text);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(IWin32Window owner,
    string text,
    string caption)
        {
            return MessageBox.Show(owner, text, caption);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(
    string text,
    string caption,
    MessageBoxButtons buttons
)
        {
            return MessageBox.Show(text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(
    IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons
)
        {
            return MessageBox.Show(owner, text, caption, buttons);
        }

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        DialogResult IModalMessageBox.Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
)
        {
            return MessageBox.Show(text, caption, buttons, icon);
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
        DialogResult IModalMessageBox.Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon);
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
        DialogResult IModalMessageBox.Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton);
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
        DialogResult IModalMessageBox.Show(
    IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
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
        DialogResult IModalMessageBox.Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options);
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
        DialogResult IModalMessageBox.Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options
)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options);
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
        DialogResult IModalMessageBox.Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    bool displayHelpButton
)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, displayHelpButton);
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
        DialogResult IModalMessageBox.Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
        DialogResult IModalMessageBox.Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath);
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
        DialogResult IModalMessageBox.Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    string keyword
)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
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
        DialogResult IModalMessageBox.Show(
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
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
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
        DialogResult IModalMessageBox.Show(IWin32Window owner,
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
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword);
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
        DialogResult IModalMessageBox.Show(IWin32Window owner,
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
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator);
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
        DialogResult IModalMessageBox.Show(string text,
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
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
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
        DialogResult IModalMessageBox.Show(
    IWin32Window owner,
    string text,
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
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }

        #endregion
    }
}
