using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paleteria
{
    public partial class tecladoNum : Form
    {
        public decimal response = 0;
        private string cantidad;
        private bool isDecimal;
        public tecladoNum(bool isDec)
        {
            isDecimal = isDec;
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCantidad.Focus();
            txtCantidad.Text += ((Button)sender).Text;
        }

        private void tecladoNum_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (response == 0)
            {
                decimal numDeci = 0.0M;
                int numInt = 0;
                if (isDecimal)
                {
                    Decimal.TryParse(txtCantidad.Text, out numDeci);
                }
                else
                {//quiere enteros
                    Int32.TryParse(txtCantidad.Text, out  numInt);
                    numDeci = Decimal.Parse(numInt.ToString());
                }
                response = numDeci;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            decimal numDeci = 0.0M;
            int numInt = 0;
            if (isDecimal)
            {
                Decimal.TryParse(txtCantidad.Text, out numDeci);
            }
            else
            {//quiere enteros
                Int32.TryParse(txtCantidad.Text, out  numInt);
                numDeci = Decimal.Parse(numInt.ToString());
            }
            response = numDeci;
            this.Hide();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tecladoNum_Load(object sender, EventArgs e)
        {
            txtCantidad.Focus();
        }

        private void tecladoNum_Shown(object sender, EventArgs e)
        {
            txtCantidad.Focus();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAccept_Click(sender, new EventArgs());
            }
        }

       




    }
}
