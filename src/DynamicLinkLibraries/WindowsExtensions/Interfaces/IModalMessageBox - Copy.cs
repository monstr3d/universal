using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsExtensions.Interfaces
{
    /// <summary>
    /// Abstract modal message box
    /// </summary>
    public interface IModalMessageBox
    {
       /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(string text);





        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(string text,
    string caption);




        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(IWin32Window owner,
    string text);

  

        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(IWin32Window owner,
    string text,
    string caption);




        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(
    string text,
    string caption,
    MessageBoxButtons buttons
);


        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(
    IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons
);




        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
);





        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="owner">Owner</param>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon
);




        /// <summary>
        /// Modal show of dialog
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="caption">Caption</param>
        /// <param name="buttons">Message box buttons</param>
        /// <param name="icon">Message box icon</param>
        /// <param name="defaultButton">Message box default button</param>
        /// <returns>Dialog result</returns>
        DialogResult Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton);




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
        DialogResult Show(
    IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton);




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
        DialogResult Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options);







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
        DialogResult Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options
);




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
        DialogResult Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    bool displayHelpButton
);




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
        DialogResult Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
);




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
        DialogResult Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath
);




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
        DialogResult Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    string keyword
);




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
        DialogResult Show(
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator
);




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
        DialogResult Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    string keyword
);




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
        DialogResult Show(IWin32Window owner,
    string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator
);




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
        DialogResult Show(string text,
    string caption,
    MessageBoxButtons buttons,
    MessageBoxIcon icon,
    MessageBoxDefaultButton defaultButton,
    MessageBoxOptions options,
    string helpFilePath,
    HelpNavigator navigator,
    Object param
);




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
        DialogResult Show(
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
);
    }
}
