using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMUtil
{
    /// <summary>
    /// Common methods needed with dealing with Windows Forms.
    /// Changes disabled, enabled, and ReadOnly properties for textboxes, buttons and other controls.
    /// </summary>
    /// @author Sung Min Yoon
    public static class ControlUtil
    {
        /// <summary>
        /// Enables given (variable length) buttons.
        /// <code>
        ///     EnableButtons(btn1, btn2, btn3);
        /// </code> 
        /// </summary>
        /// <param name="btns">Buttons to be enabled</param>
        public static void EnableButtons(params Button[] btns)
        {
            EnableControls(true, btns);
        }

        /// <summary>
        /// Disables given (variable length) buttons.
        /// <code>
        ///     DisableButtons(btn1, btn2, btn3);
        /// </code> 
        /// </summary>
        /// <param name="btns">Buttons to be disabled.</param>
        public static void DisableButtons(params Button[] btns)
        {
            EnableControls(false, btns);
        }

        /// <summary>
        /// Disables given (variable length) DateTimePickers.
        /// <code>
        ///     DisableDatePickers(dp1, dp2...);
        /// </code>  
        /// </summary>
        /// <param name="dps">DateTimePickers to be disabled.</param>
        public static void DisableDatePickers(params DateTimePicker[] dps)
        {
            EnableControls(false, dps);
        }

        /// <summary>
        /// Enables given (variable length) DateTimePickers.
        /// <code>
        ///     EnableDatePickers(dp1, dp2..);
        /// </code>  
        /// </summary>
        /// <param name="dps">DateTimePickers to be disabled.</param>
        public static void EnableDatePickers(params DateTimePicker[] dps)
        {
            EnableControls(true, dps);
        }

        /// <summary>
        /// "Enables" given (variable length) textboxes.  Turns off ReadOnly property.
        /// <code>
        ///     EnableTextBoxes(tb1, tb2, tb3);
        /// </code> 
        /// </summary>
        /// <param name="tboxes"></param>
        public static void EnableTextBoxes(params TextBox[] tboxes)
        {
            ReadOnlyTextBoxes(false, tboxes);
        }

        /// <summary>
        /// "Disables" given (variable length) textboxes.  Turns on ReadOnly property.
        /// To be used in forms where selecting the text by the user is required/desired.
        /// <code>
        ///     DisableTextBoxes(tb1, tb2, tb3);
        /// </code> 
        /// </summary>
        /// <param name="tboxes"></param>
        public static void DisableTextBoxes(params TextBox[] tboxes)
        {
            ReadOnlyTextBoxes(true, tboxes);
        }

        /// <summary>
        /// Enables the given NumericUpDown controls.  The NumericUpDown control
        /// parameters can be variable length.
        /// <code>
        ///     EnableNumUpDown(nm1, nm2, nm3, nm4);
        /// </code>
        /// </summary>
        /// <param name="nudboxes"></param>
        public static void EnableNumUpDown(params NumericUpDown[] nudboxes)
        {
            EnableControls(true, nudboxes);
        }

        /// <summary>
        /// Enables the given ListBox controls.  The ListBox parameters are
        /// variable length.
        /// <code>
        ///     EnableListBoxes (lst1, lst2);
        /// </code> 
        /// </summary>
        /// <param name="lboxes"></param>
        public static void EnableListBoxes(params ListBox[] lboxes)
        {
            EnableControls(true, lboxes);
        }

        /// <summary>
        /// Disables the given ListBox controls where the paramater is variable length.
        /// </summary>
        /// <param name="lboxes"></param>
        public static void DisableListBoxes(params ListBox[] lboxes)
        {
            EnableControls(false, lboxes);
        }

        public static void ResetList<T>(List<T> list, BindingSource bsrc, Control ctrl, string dispMember)
        {

            bsrc.DataSource = list;

            if (ctrl is ListBox)
            {
                ListBox tempLst = (ListBox)ctrl;
                tempLst.DataSource = bsrc;
                tempLst.DisplayMember = dispMember;
            }
            else if (ctrl is ComboBox)
            {
                ComboBox tempCbo = (ComboBox)ctrl;
                tempCbo.DataSource = bsrc;
                tempCbo.DisplayMember = dispMember;
            }

            bsrc.ResetBindings(false);
        }


        /// <summary>
        /// Enables the provided combo boxes (variable length parameter).
        /// </summary>
        /// <param name="cbos"></param>
        public static void EnableComboBoxes(params ComboBox[] cbos)
        {
            EnableControls(true, cbos);
        }
        /// <summary>
        /// Disables the provided NumericUpDown controls (variable length parameter).
        /// </summary>
        /// <param name="nudboxes"></param>
        public static void DisableNumUpDown(params NumericUpDown[] nudboxes)
        {
            EnableControls(false, nudboxes);
        }

        /// <summary>
        /// Disables given combo boxes (variable length parameter).
        /// </summary>
        /// <param name="cbos"></param>
        public static void DisableComboBoxes(params ComboBox[] cbos)
        {
            EnableControls(false, cbos);
        }
        /// <summary>
        /// Clears the given textboxes.
        /// </summary>
        /// <param name="tboxes"></param>
        public static void ClearTextBoxes(params TextBox[] tboxes)
        {
            SetText("", tboxes);
        }
        /// <summary>
        /// Sets the given NumericUpDown controls to their minimum values.
        /// </summary>
        /// <param name="numboxes"></param>
        public static void ClearNumUpDown(params NumericUpDown[] numboxes)
        {
            foreach (NumericUpDown nbox in numboxes)
            {
                nbox.Text = nbox.Minimum.ToString();
            }
        }
        /// <summary>
        /// Clears the given combo boxes.
        /// </summary>
        /// <param name="cboxes"></param>
        public static void ClearComboBoxes(params ComboBox[] cboxes)
        {
            SetText("", cboxes);
        }

        private static void EnableControls(bool on, params Control[] controls)
        {
            foreach (Control c in controls)
            {
                c.Enabled = on;
            }
        }

        private static void SetText(string val, params Control[] ctrls)
        {
            foreach (Control c in ctrls)
            {
                c.Text = val;
            }
        }
        private static void ReadOnlyTextBoxes(bool on, params TextBox[] tboxes)
        {
            foreach (TextBox tb in tboxes)
            {
                tb.ReadOnly = on;
            }
        }

    }
}
