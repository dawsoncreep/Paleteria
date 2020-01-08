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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            cargarUbicaciones();
            cargarInventario();

        }

        private void cargarInventario()
        {
            if (cmbUbicacion.SelectedIndex > -1)
            {
                DataSet1TableAdapters.llenarGridInventarioTableAdapter gita = new Paleteria.DataSet1TableAdapters.llenarGridInventarioTableAdapter();
                dgvInventario.DataSource = gita.GetData(1);
                dgvInventario.Refresh();
            }
        }

        private void cargarUbicaciones()
        {
            DataSet1TableAdapters.SP_tabla_ubicacionTableAdapter uta = new Paleteria.DataSet1TableAdapters.SP_tabla_ubicacionTableAdapter();
            DataTable udt = uta.GetData("S", null, "", null, null);
            cmbUbicacion.DataSource = udt;
            cmbUbicacion.DisplayMember = "nombreUbicacion";
            cmbUbicacion.ValueMember = "idUbicacion";
            cmbUbicacion.Refresh();
        }

        private void cmbUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarInventario();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //idusuario = 1; por lo pronto
            int idUsuario = 1;
            DataSet1TableAdapters.llenarGridInventarioTableAdapter gita = new Paleteria.DataSet1TableAdapters.llenarGridInventarioTableAdapter();
            DataTable dtInventario = gita.GetData(1);

            DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
            
            string impresora = qta.obtenerParametro("nombreImpresora");
            string nombreEmpresa = qta.obtenerParametro("nombreEmpresa");
            string leyenda = qta.obtenerParametro("leyenda");
            string nombreUsuario = qta.obtenerNombreUsuario(idUsuario);
            Ticket tick = new Ticket();
            if (!(tick.PrinterExists(impresora)))
            {
                MessageBox.Show("La impresora no esta conectada", "Error");
                return;
            }
            tick.AddHeaderLine(nombreEmpresa);

            tick.AddHeaderLine("Inventario ");

            tick.AddHeaderLine("Usuario: " + nombreUsuario);
           

            tick.AddHeaderLine("-------------------------");
            tick.AddHeaderLine("Fecha: " + DateTime.Now.ToShortDateString());
            tick.AddHeaderLine("Hora : " + DateTime.Now.ToShortTimeString());
            tick.AddHeaderLine("-------------------------");
            tick.AddHeaderLine("Producto        Cantidad ");
            tick.AddHeaderLine("-------------------------");
            foreach (DataRow row in dtInventario.Rows)
            {
                //hacer que el producto no se imprima completo ya que solo son 25 caracteres por linea
                // vamos a dejar 20 para el nombre y 5 para a cantidad
                //
                string linea = row["nombreProducto"].ToString()
                    +""+ row["cantidad"].ToString();
                
                
                tick.AddHeaderLine(linea);
            }
            tick.AddHeaderLine("-------------------------");
            tick.AddFooterLine(leyenda);
            tick.PrintTicket(impresora);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
