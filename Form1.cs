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
    public partial class Calculator : Form
    {
        Double result = 0.0;
        String operation = "";
        bool operationPerformed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void onClickEvent(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == ".") 
            { 
                textBoxResult.Text = textBoxResult.Text;
            }
            else 
            {
                if ((textBoxResult.Text == "0") || (operationPerformed))
                    textBoxResult.Text = "";
            }
            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                    textBoxResult.Text = textBoxResult.Text + button.Text;
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + button.Text;
            }
            operationPerformed = false;
        }

        private void operator_clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                btnResult.PerformClick();
                labelTempResult.Text = textBoxResult.Text;
                operation = button.Text;
                if (labelTempResult.Text == "")
                {
                    labelTempResult.Text = result + " " + operation;
                }
                else
                {
                    labelTempResult.Text = labelTempResult.Text + " " + operation;
                }
                operationPerformed = true;
            }
            else
            {
                labelTempResult.Text = textBoxResult.Text;
                operation = button.Text;
                result = Double.Parse(textBoxResult.Text);
                if (labelTempResult.Text == "")
                {
                    labelTempResult.Text = result + " " + operation;
                }
                else
                {
                    labelTempResult.Text = labelTempResult.Text + " " + operation;
                }
                operationPerformed = true;
            }
        }

        private void btnClearEmpt_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            result = 0;
            labelTempResult.Text = "";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            switch(operation)
            {
                case "+":
                    textBoxResult.Text = (result + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (result - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (result / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (result * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textBoxResult.Text);
            labelTempResult.Text = "";
        }
    }
}
