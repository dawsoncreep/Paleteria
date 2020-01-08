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
    public partial class inicialCaja : Form
    {
        private TextBox txtActivo = new TextBox();
        decimal cantidad;
       
        public inicialCaja()
        {
            InitializeComponent();
            
        }

        private void inicialCaja_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuarios = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsuario = usuarios.GetData("S", null, "", "", "", null, "");
                cmbUsuario.DataSource = dtUsuario;
                cmbUsuario.ValueMember = "idUsuario";
                cmbUsuario.DisplayMember = "uid";
                cmbUsuario.Refresh();

                //pone el txtactivo a cantidad
                txtActivo = txtCantidad;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexion a BD", "Conexion BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //hace login primero para hacer la validación
            //despues ingresa el total de caja del dia de hoy
            //el total de caja solo es por un dia por caja
            cantidad = decimal.Parse(txtCantidad.Text);
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuarios = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsuario = usuarios.GetData("L", (int)cmbUsuario.SelectedValue, "", "", "", null, txtContrasena.Text.Trim());
                if (dtUsuario.Rows.Count > 0)
                {
                   //si se valida el usuario se hace el ingreso de caja
                    DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
                    qta.guardarContenidoInicialCajon(cantidad, 1, 2);//se queda fijo para la caja

                    this.Close();

                }
                else
                {
                    MessageBox.Show("PIN Incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El usuario no corresponde", "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
