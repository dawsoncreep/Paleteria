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
    public partial class retiroCaja : Form
    {
        public int idUsuario;
        private decimal cantidad;
        public retiroCaja(int idUser)
        {
            InitializeComponent();
            idUsuario = idUser;
        }


        private void retiroCaja_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuarios = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsuario = usuarios.GetData("S", null, "", "", "", null, "");
                cmbUsuario.DataSource = dtUsuario;
                cmbUsuario.ValueMember = "idUsuario";
                cmbUsuario.DisplayMember = "uid";
                cmbUsuario.Refresh();


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
                    //si se valida el usuario se hace el retiro de caja
                    DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
                    qta.guardaRetiroCaja(idUsuario, cantidad, txtDescripcion.Text);//se queda fijo para la caja
                    ImprimirTicket();
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

        private void ImprimirTicket()
        {


            try
            {
                DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();

                string impresora = qta.obtenerParametro("nombreImpresora");
                string nombreEmpresa = qta.obtenerParametro("nombreEmpresa");
                string sucursal = qta.obtenerParametro("sucursal");
                string telefono = qta.obtenerParametro("telefono");
                string leyenda = qta.obtenerParametro("leyenda");
                string nombreUsuario = qta.obtenerNombreUsuario(idUsuario);

                //crea la estructura del ticket
                Ticket tick = new Ticket();
                if (!(tick.PrinterExists(impresora)))
                {
                    MessageBox.Show("La impresora no esta conectada", "Error");
                    return;
                }

                tick.AddHeaderLine(nombreEmpresa);
                tick.AddHeaderLine(sucursal);
                tick.AddHeaderLine("Tel: " + telefono);
                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Fecha: " + DateTime.Now.ToShortDateString());
                tick.AddHeaderLine("Hora:  " + DateTime.Now.ToShortTimeString());


                tick.AddHeaderLine("Usuario: " + nombreUsuario);
                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("--RETIRO DE CAJA--");
                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Cantidad      " + cantidad.ToString());
                tick.AddHeaderLine("-------------------------");



                tick.PrintTicket(impresora);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
