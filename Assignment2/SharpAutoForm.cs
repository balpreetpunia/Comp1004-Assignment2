using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoForm : Form
    {

        private Double _basePrice;
        private Double _additionalOptions;
        private Double _subTotal;
        private Double _salesTax;
        private Double _total;
        private Double _tradeInAllowance;
        private Double _amountDue;


        public SharpAutoForm()
        {
            InitializeComponent();
        }



        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            basePriceTextBox.Font = fontDialog.Font;
            amountDueTextBox.Font = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            basePriceTextBox.BackColor = colorDialog.Color;
            amountDueTextBox.BackColor = colorDialog.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutForm = new AboutBox();

            aboutForm.ShowDialog();
        }

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

        private void additionalOptionsTextBox_TextChanged(object sender, EventArgs e)
        {
            _additionalOptions = double.Parse(additionalOptionsTextBox.Text);
        }

        private void tradeInAllowanceTextBox_TextChanged(object sender, EventArgs e)
        {
            _tradeInAllowance = double.Parse(tradeInAllowanceTextBox.Text);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (basePriceTextBox.Text != "")
            {
                _basePrice = double.Parse(basePriceTextBox.Text);

                _subTotal = _basePrice + _additionalOptions;
                _salesTax = 0.13 * _subTotal;
                _total = _subTotal + _salesTax;
                _amountDue = _total - _tradeInAllowance;

                basePriceTextBox.Text = Convert.ToString(_basePrice);

                subTotalTextBox.Text = _subTotal.ToString("F");

                salesTaxTextBox.Text = _salesTax.ToString("F");

                totalTextBox.Text = _total.ToString("F");

                amountDueTextBox.Text = _amountDue.ToString("F");
            }

            else
            {
                MessageBox.Show("Please enter a base price to calculate");
            }
        }

        private void stereoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(stereoCheckBox.Checked)
            {
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SharpAutoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculateButton_Click(sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearButton_Click(sender, e);
        }

        
    }
}
