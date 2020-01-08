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
    public partial class Pago : Form
    {
        public decimal total= 0m;
        public decimal cambio = 0m;
        public decimal pago = 0m;
        public bool inicial = true;

        public Pago()
        {
            InitializeComponent();
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                MessageBox.Show("Validar pago", "Información");
                return;
            }
            this.Hide();
            this.DialogResult = DialogResult.OK;
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            txtTotal.Text = total.ToString();
            txtPago.Text = total.ToString() ;
            pago = total;
            lblCambio.Text = "0.00";
            txtPago.Focus();
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            if (txtPago.Text.Length == 0)
                return;

            decimal.TryParse(txtPago.Text, out pago);
            if (pago > 0)
            {
                pago = decimal.Parse(txtPago.Text);
                cambio = total - pago;
                cambio *=-1;
                lblCambio.Text = cambio.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void Pago_FormClosing(object sender, FormClosingEventArgs e)
        {
                     
        }

        private bool validar()
        {
            if (pago < total)
            {
                return false;
            }else
            return true;
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                if (!validar())
                {
                    MessageBox.Show("Validar pago", "Información");
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }

            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (inicial)
            {
                txtPago.Text = "";
                inicial = false;
            }
            txtPago.Focus();
            txtPago.Text += ((Button)sender).Text;        
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        private void Pago_Shown(object sender, EventArgs e)
        {
            txtPago.Focus();
        }
    }
}
