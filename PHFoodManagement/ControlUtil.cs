﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHFoodManagement
{
    /// <summary>
    /// Common methods needed with dealing with Windows Forms.
    /// Changes disabled, enabled, and ReadOnly properties for textboxes, buttons and other controls.
    /// </summary>
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
            EnableButtons(true, btns);
        }

        /// <summary>
        /// Disables give (variable length) buttons.
        /// <code>
        ///     DisableButtons(btn1, btn2, btn3);
        /// </code> 
        /// </summary>
        /// <param name="btns">Buttons to be disabled.</param>
        public static void DisableButtons(params Button[] btns)
        {
            EnableButtons(false, btns);
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
        /// <code>
        ///     DisableTextBoxes(tb1, tb2, tb3);
        /// </code> 
        /// </summary>
        /// <param name="tboxes"></param>
        public static void DisableTextBoxes(params TextBox[] tboxes)
        {
            ReadOnlyTextBoxes(true, tboxes);
        }

        private static void EnableButtons(bool on, params Button[] btns)
        {
            foreach(Button b in btns)
            {
                b.Enabled = on;
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
