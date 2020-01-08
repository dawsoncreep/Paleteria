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
    public partial class ventasDia : Form
    {
        public ventasDia()
        {
            InitializeComponent();
        }

        private void dtpVenta_DateChanged(object sender, DateRangeEventArgs e)
        {
            cargarVentas(dtpVenta.SelectionEnd);
        }

        private void ventasDia_Load(object sender, EventArgs e)
        {
            cargarVentas(DateTime.Now);        
        }
        private void cargarVentas(DateTime fecha)
        {

            DataSet1TableAdapters.llenarGridVentasTableAdapter gita = new Paleteria.DataSet1TableAdapters.llenarGridVentasTableAdapter();
            dgvVenta.DataSource = gita.GetData(fecha);
            dgvVenta.Refresh();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //crear corte x 
            //se hace el corte x desde el ultimo corte que se haya hecho
            int idUsuario = 1;//checar como meter al usuario por ahora solo es caja

            DataSet1TableAdapters.llenarGridVentasTableAdapter gita = new Paleteria.DataSet1TableAdapters.llenarGridVentasTableAdapter();
            DataTable dtVentas =  gita.GetData(dtpVenta.SelectionEnd);
            
            if (dtVentas.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para imprimir", "Alerta");
                return;
            }
            try
            {

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



                tick.AddHeaderLine("Detalles Venta X Día ");
                tick.AddHeaderLine("FECHA: " + dtpVenta.SelectionEnd.ToShortDateString());

                tick.AddHeaderLine("Usuario: " + nombreUsuario);

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Fecha consulta: " + DateTime.Now.ToShortDateString());
                tick.AddHeaderLine("Hora consulta: " + DateTime.Now.ToShortTimeString());
                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Producto        Cantidad ");
                tick.AddHeaderLine("-------------------------");

                foreach (DataRow row in dtVentas.Rows)
                {
                    //hacer que el producto no se imprima completo ya que solo son 25 caracteres por linea
                    // vamos a dejar 20 para el nombre y 5 para a cantidad
                    //
                    string linea = row["nombreProducto"].ToString()
                        + "" + row["cantidad"].ToString();


                    tick.AddHeaderLine(linea);
                }

              

                tick.AddFooterLine(leyenda);
                tick.PrintTicket(impresora);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
