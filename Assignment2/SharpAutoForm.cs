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

        private void basePriceTextBox_TextChanged(object sender, EventArgs e)
        {
            _basePrice = double.Parse(basePriceTextBox.Text);
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
            _subTotal = _basePrice + _additionalOptions;
            _salesTax = 0.13 * _subTotal;
            _total = _subTotal + _salesTax;
            _amountDue = _total - _tradeInAllowance;

            basePriceTextBox.Text = Convert.ToString(_basePrice);

            subTotalTextBox.Text = Convert.ToString(_subTotal);

            salesTaxTextBox.Text = Convert.ToString(_salesTax);

            totalTextBox.Text = Convert.ToString(_total);

            amountDueTextBox.Text = Convert.ToString(_amountDue);
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            //basePriceTextBox.Clear();
            subTotalTextBox.Clear();
            salesTaxTextBox.Clear();
            totalTextBox.Clear();
            tradeInAllowanceTextBox.Text = Convert.ToString(0);
            amountDueTextBox.Clear();

            stereoCheckBox.Checked = false;
            leatherInteriorCheckBox.Checked = false;
            computerNavigationCheckBox.Checked = false;

            standardRadioButton.Checked = true;


        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
