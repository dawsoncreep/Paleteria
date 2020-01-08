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
    public partial class corteCaja : Form
    {
        public corteCaja()
        {
            InitializeComponent();
        }

        private void dtpFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            //cuando cambia la fecha carga los cortes de ese dia
            DataSet1TableAdapters.obtenerCortesPorDíaTableAdapter ocpd = new Paleteria.DataSet1TableAdapters.obtenerCortesPorDíaTableAdapter();
            DataTable dtcortes = ocpd.GetData(dtpFecha.SelectionEnd);
            cmbCortes.DataSource = null;
            cmbCortes.DisplayMember = "fecha";
            cmbCortes.ValueMember = "idCorteX";
            cmbCortes.DataSource = dtcortes;
            cmbCortes.Refresh();
            if (cmbCortes.Items.Count > 0)
            {
                cmbCortes.SelectedIndex = 0;
            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //crear corte x 
            //se hace el corte x desde el ultimo corte que se haya hecho
            int idUsuario = 2;//checar como meter al usuario por ahora solo es caja

            DataSet1TableAdapters.obtenerCorteXTableAdapter ocxta = new Paleteria.DataSet1TableAdapters.obtenerCorteXTableAdapter();
            DataTable dtCorte = ocxta.GetData(idUsuario, (int) cmbCortes.SelectedValue);
            if (dtCorte.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el corte", "Alerta");
                return;
            }
            try
            {

                int idCorte = (int)dtCorte.Rows[0]["idCorteX"];
                DateTime fecha = (DateTime)dtCorte.Rows[0]["fecha"];
                decimal totalVenta = (decimal)dtCorte.Rows[0]["totalVenta"];
                decimal totalRetiros = (decimal)dtCorte.Rows[0]["totalRetiros"];
                decimal granTotal = (decimal)dtCorte.Rows[0]["GranTotal"];
                DateTime fechaInicio = (DateTime)dtCorte.Rows[0]["fechaInicio"];
                DateTime fechaFin = (DateTime)dtCorte.Rows[0]["fechaFin"];
                decimal inicialCaja = (decimal)dtCorte.Rows[0]["inicialCaja"];

                DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
                qta.meterCorteXDetalle(idUsuario, idCorte);

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



                tick.AddHeaderLine("Corte de Caja X ");

                tick.AddHeaderLine("Usuario: " + nombreUsuario);

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Hora Inicio: " + fechaInicio.ToString());

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Hora Fin: " + fechaFin.ToString());

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Inicial Caja: " + inicialCaja);

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Total Venta: " + totalVenta);

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Total Retiros: " + totalRetiros);

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Gran Total: " + granTotal);

                tick.AddFooterLine("Fecha: " + DateTime.Now.ToShortDateString());
                tick.AddFooterLine("Hora: " + DateTime.Now.ToShortTimeString());


                tick.AddFooterLine(leyenda);
                tick.PrintTicket(impresora);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void corteCaja_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.obtenerCortesPorDíaTableAdapter ocpd = new Paleteria.DataSet1TableAdapters.obtenerCortesPorDíaTableAdapter();
            DataTable dtcortes = ocpd.GetData(DateTime.Now);
            cmbCortes.DataSource = null;
            cmbCortes.DisplayMember = "fecha";
            cmbCortes.ValueMember = "idCorteX";
            cmbCortes.DataSource = dtcortes;
            cmbCortes.Refresh();


        }
    }
}
