using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// App Name - Sharp Auto Form
/// Author - Balpreet Pnia 200335082
/// App Description - This application takes in various inputs from the user and accordingly outputs the amount due for them.
/// COMP1004 - Assignment 2
/// /// </summary>

namespace Assignment2
{
    public partial class SharpAutoForm : Form
    {
        // Private variables

        private Double _basePrice;
        private Double _additionalOptions;
        private Double _subTotal;
        private Double _salesTax;
        private Double _total;
        private Double _tradeInAllowance;
        private Double _amountDue;

        /// <summary>
        /// Default Costructor
        /// </summary>
        
        public SharpAutoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method brings up the font dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            basePriceTextBox.Font = fontDialog.Font;
            amountDueTextBox.Font = fontDialog.Font;
        }
        /// <summary>
        /// This method brings up the color dialog and applies it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            basePriceTextBox.BackColor = colorDialog.Color;
            amountDueTextBox.BackColor = colorDialog.Color;
        }
        /// <summary>
        /// This method brings up the about form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutForm = new AboutBox();

            aboutForm.ShowDialog();
        }
        /// <summary>
        /// This method lets the user input only number in the base price field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void basePriceTextBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(basePriceTextBox.Text, "[^0-9]")) 
            {
                MessageBox.Show("Please enter only numbers.");
            }

            else if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// This method puts the value in the additional textbot to its equivalent variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void additionalOptionsTextBox_TextChanged(object sender, EventArgs e)
        {
            _additionalOptions = double.Parse(additionalOptionsTextBox.Text);
        }
        /// <summary>
        /// This method puts the value in the tradeinallowance textbot to its equivalent variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tradeInAllowanceTextBox_TextChanged(object sender, EventArgs e)
        {
            _tradeInAllowance = double.Parse(tradeInAllowanceTextBox.Text);
        }
        /// <summary>
        /// This method hold the alorithm for the calculate button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void calculateButton_Click(object sender, EventArgs e)
        {
            //This is to check if the base price field holds some value.
            if (basePriceTextBox.Text != "")
            {
                //returns the value from the text field to the variable in type double
                _basePrice = double.Parse(basePriceTextBox.Text);

                //sum for subtotal
                _subTotal = _basePrice + _additionalOptions;

                //calculating sales tax
                _salesTax = 0.13 * _subTotal;

                //calculating total
                _total = _subTotal + _salesTax;

                //calculating tradeinallowance
                _amountDue = _total - _tradeInAllowance;


                //The following lines display the contents in the respective fields, converted into type string.
                basePriceTextBox.Text = Convert.ToString(_basePrice);

                subTotalTextBox.Text = _subTotal.ToString("F");

                salesTaxTextBox.Text = _salesTax.ToString("F");

                totalTextBox.Text = _total.ToString("F");

                amountDueTextBox.Text = "$ " + _amountDue.ToString("F");
            }

            else
            {
                MessageBox.Show("Please enter a base price to calculate");
            }
        }

        /// <summary>
        /// The following methods check the state of the check box or radio button and respectively apply the value to the additional field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void stereoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(stereoCheckBox.Checked)
            {
                //the varialble _additionalOptions hold the value for the field additional options
                _additionalOptions += 425.76;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 425.76;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void leatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leatherInteriorCheckBox.Checked)
            {
                _additionalOptions += 987.41;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 987.41;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void computerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (computerNavigationCheckBox.Checked)
            {
                _additionalOptions += 1741.23;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 1741.23;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void autoParkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoParkCheckBox.Checked)
            {
                _additionalOptions += 2399.99;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 2399.99;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void pearlizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(pearlizedRadioButton.Checked)
            {
                _additionalOptions += 345.72;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 345.72;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void customizedDetailingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customizedDetailingRadioButton.Checked)
            {
                _additionalOptions += 599.99;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 599.99;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        private void mattFinishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mattFinishRadioButton.Checked)
            {
                _additionalOptions += 368.46;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
            else
            {
                _additionalOptions -= 368.46;
                additionalOptionsTextBox.Text = Convert.ToString(_additionalOptions);
            }
        }

        /// <summary>
        /// This method clears everything from the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void clearButton_Click(object sender, EventArgs e)
        {
            basePriceTextBox.Clear();
            subTotalTextBox.Clear();
            salesTaxTextBox.Clear();
            totalTextBox.Clear();
            tradeInAllowanceTextBox.Text = Convert.ToString(0);
            amountDueTextBox.Clear();

            stereoCheckBox.Checked = false;
            leatherInteriorCheckBox.Checked = false;
            computerNavigationCheckBox.Checked = false;
            autoParkCheckBox.Checked = false;

            standardRadioButton.Checked = true;


        }

        /// <summary>
        /// This method exits the application by calling the formClosing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method confirms and then closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SharpAutoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// This method calls the formClosing 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method calls the calculatebutton event handler to perform the same function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculateButton_Click(sender, e);
        }

        /// <summary>
        /// This method calls the clearbutton event handler to perform the same function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearButton_Click(sender, e);
        }

        
    }
}
