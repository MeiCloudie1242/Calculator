using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormCalc : Form
    {
        String operation = "";
        Double value = 0;
        bool isOperationPressed = false;

        public FormCalc()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if ((txbResult.Text == "0") || (isOperationPressed))
            {
                txbResult.Clear();
            }

            isOperationPressed = false;
            Button btn = (Button)sender;
            if (btn.Text == ",")
            {
                if (!txbResult.Text.Contains(","))
                {
                    txbResult.Text = txbResult.Text + btn.Text;
                }
            }else
                txbResult.Text = txbResult.Text + btn.Text;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (value != 0)
            {
                btnEqual.PerformClick();
                operation = btn.Text;
                lblEquation.Text = value + " " + operation;

                isOperationPressed = true;
            }
            else
            {
                operation = btn.Text;
                value = Double.Parse(txbResult.Text);
                lblEquation.Text = value + " " + operation;

                isOperationPressed = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            lblEquation.Text = "";

            switch (operation)
            {
                case "+":
                    txbResult.Text = (value + Double.Parse(txbResult.Text)).ToString();
                    break;
                case "-":
                    txbResult.Text = (value - Double.Parse(txbResult.Text)).ToString();
                    break;
                case "*":
                    txbResult.Text = (value * Double.Parse(txbResult.Text)).ToString();
                    break;
                case "/":
                    txbResult.Text = (value / Double.Parse(txbResult.Text)).ToString();
                    break;
                case "%":
                    txbResult.Text = (value / 100).ToString();
                    break;
                default:
                    break;
            }

            value = Double.Parse(txbResult.Text);
            isOperationPressed = false;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txbResult.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txbResult.Text = "0";
            value = 0;
        }


        //MC,MR,MS,M+,M-
        //<=
        //+-,sqrt,%,1/x

        //dk =
        //C - label
    }
}
