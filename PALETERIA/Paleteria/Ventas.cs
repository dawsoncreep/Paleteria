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
    public partial class Ventas : Form
    {
        int a, b = 0;
        decimal preciomay, precio, total, pagot, cambio;
        int valorc, valorp;
        string categoria = "";
        string nombre = "";
        int mayoreo;
        int idUsuario;

        tecladoNum t = new tecladoNum(true);
        List<string> lproductos = new List<string>();
        Button botonCategoria = new System.Windows.Forms.Button();
        Button botonProducto = new System.Windows.Forms.Button();

        public Ventas(int Usuario)
        {
            InitializeComponent();
            idUsuario = Usuario;
            DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
            lblUsuario.Text = qta.obtenerNombreUsuario(idUsuario).ToString();
        }

        private void IngresoInventario_Load(object sender, EventArgs e)
        {
            CargaCategorias();
            DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
            mayoreo = int.Parse(qta.obtenerParametro("cantidadMayoreo"));
            lblTurno.Text = qta.obtenerTurno(DateTime.Now).ToString();
            timer1.Start();

            this.WindowState = FormWindowState.Maximized;
        }

        private void CargaCategorias()
        {
            DataSet1TableAdapters.SP_tabla_categoriaTableAdapter categta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
            DataTable catdt = categta.GetData("S", null, "", null, null);
            dibujabottonCategoria(catdt);
        }

        private int recuperaidCategoria(string nombre)
        {
            DataSet1TableAdapters.SP_tabla_categoriaTableAdapter categta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
            DataTable catdt = categta.GetData("S", null, "", null, null);
            for (int i = 0; i <= catdt.Rows.Count - 1; )
            {
                if (catdt.Rows[i][1].ToString() == nombre)
                {
                    return valorc = int.Parse(catdt.Rows[i][0].ToString());
                }
                i++;
            }
            return 0;
        }

        private int recueraIdProducto(string nombre)
        {
            DataSet1TableAdapters.SP_tabla_productoTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
            DataTable productos = produc.GetData("T", null, null, null, null, null, valorc, null, null);

            for (int i = 0; i <= productos.Rows.Count - 1; )
            {
                if (productos.Rows[i][1].ToString() == nombre)
                {
                    precio = decimal.Parse(productos.Rows[i][3].ToString());
                    preciomay = decimal.Parse(productos.Rows[i][4].ToString());
                    return valorp = int.Parse(productos.Rows[i][0].ToString());
                }
                i++;

            }
            return 0;


        }
        private void dibujabottonProductos(DataTable productos)
        {
            pnlProducto.Controls.Clear();
            if (productos.Rows.Count > 0)
            {

                for (int i = 1; i <= productos.Rows.Count; i++)
                {
                    Button botonProducto = new System.Windows.Forms.Button();

                    if (i <= 4)
                    {
                        botonProducto.Location = new System.Drawing.Point((i - 1) * 120, 0);
                    }
                    if (i <= 8 && i > 4)
                    {
                        botonProducto.Location = new System.Drawing.Point((i - 5) * 120, 80);
                    }
                    if (i <= 12 && i > 8)
                    {
                        botonProducto.Location = new System.Drawing.Point((i - 9) * 120, 160);
                    }
                    botonProducto.Name = productos.Rows[i - 1][1].ToString();
                    botonProducto.Text = productos.Rows[i - 1][1].ToString();
                    botonProducto.Size = new Size(114, 73);
                    botonProducto.TabIndex = 0;
                    botonProducto.Font = fonTBoton;

                    botonProducto.TabStop = false;
                    pnlProducto.Controls.Add(botonProducto);
                    botonProducto.Click += new EventHandler(btnproducto_Click);
                }
            }

        }
        Font fonTBoton = new Font("propio", float.Parse("11.2"));

        private void dibujabottonCategoria(DataTable categorias)
        {
            for (int i = 1; i <= categorias.Rows.Count; i++)
            {
                Button botonCategoria = new System.Windows.Forms.Button();

                if (i <= 4)
                {
                    botonCategoria.Location = new System.Drawing.Point((i - 1) * 120, 0);
                }
                if (i <= 8 && i > 4)
                {
                    botonCategoria.Location = new System.Drawing.Point((i - 5) * 120, 80);
                }
                if (i <= 12 && i > 8)
                {
                    botonCategoria.Location = new System.Drawing.Point((i - 9) * 120, 160);
                }
                botonCategoria.Name = categorias.Rows[i - 1][1].ToString();
                botonCategoria.Text = categorias.Rows[i - 1][1].ToString();
                botonCategoria.Size = new Size(114, 73);
                botonCategoria.TabIndex = 0;
                botonCategoria.Font = fonTBoton;

                botonCategoria.TabStop = false;
                pnlCategorias.Controls.Add(botonCategoria);
                botonCategoria.Click += new EventHandler(btncategoria_Click);
            }
        }

        /// <summary>
        /// AGREGA LOS PRODUCTOS CUANDO DAN CLIC EN BOTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Columns[0].Visible = true;
            int c = 0;
            for (int i = 0; i <= lproductos.Count() - 1; i++)
            {
                if (lproductos[i].ToString() == label1.Text.Trim())
                {
                    c = c + 1;
                }
            }
            int bandera = 0;
            int r1, r2;
            if (dataGridView1.Rows[0].Cells[0].Value != null)
            {
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    r1 = int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString());
                    r2 = recueraIdProducto(label1.Text.Trim());
                    if (r1 == r2)
                    {

                        dataGridView1.Rows[j].Cells[2].Value = c;
                        if (c >= mayoreo)
                            dataGridView1.Rows[j].Cells[3].Value = preciomay;

                        bandera = 1;
                    }
                }
                if (bandera == 0)
                { //idproducto, nombre. cantidad, precio                 
                    dataGridView1.Rows.Add(recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, precio);

                }
            }
            else
                dataGridView1.Rows.Add(recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, precio);
            txt_total.Text = calculatotal();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AllowUserToAddRows = false;

        }

        private string calculatotal()
        {
            total = 0;
            int cantidad = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) break;
                    decimal precio = decimal.Parse(row.Cells[3].Value.ToString());
                    cantidad = int.Parse(row.Cells[2].Value.ToString());
                    total += cantidad * precio;

                }


                //for (int i=0; i< dataGridView1.Rows.Count;i++)
                //{
                //    total += (int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                //}



                //for (int i=0; i< dataGridView1.Rows.Count-1;i++)
                //{
                //    cantidad= cantidad+int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                //}
                //for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                //{

                //    if (cantidad < 10)
                //    {
                //        dataGridView1.Columns[4].Visible = false;
                //        dataGridView1.Columns[3].Visible = true;
                //        total = total + 
                //        lbl_tipoprecio.Text = "Precio Normal";

                //    }
                //    else
                //    {
                //        dataGridView1.Columns[3].Visible = false;
                //        dataGridView1.Columns[4].Visible = true;
                //        total = total + (int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString()) * decimal.Parse(dataGridView1.Rows[j].Cells[4].Value.ToString()));
                //        lbl_tipoprecio.Text = "Precio de Mayoreo";
                //    }

                // }

            }
            return total.ToString();
        }

        private void btn_agregarvarios_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
                return;

            //prueba Teclado Numerico

            tecladoNum teclado = new tecladoNum(false);
            teclado.ShowDialog();
            int c = int.Parse(teclado.response.ToString());
            string prod = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            recueraIdProducto(prod);
            agregaLista(c, prod);
            txt_total.Text = calculatotal();

            //for (int i = 0; i <= lproductos.Count() - 1; i++)
            //{
            //    if (lproductos[i].ToString() == label1.Text.Trim())
            //    {
            //        c = c + 1;
            //    }
            //}
            //int bandera = 0;
            //int r1, r2;
            //if (dataGridView1.Rows[0].Cells[0].Value != null)
            //{
            //    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            //    {
            //        r1 = int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString());
            //        r2 = recueraIdProducto(label1.Text.Trim());
            //        if (r1 == r2)
            //        {
            //            dataGridView1.Rows[j].Cells[2].Value = c;
            //            bandera = 1;
            //        }
            //    }
            //    if (bandera == 0)
            //    {
            //        dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, preciomay);

            //    }
            //}
            //else
            //    dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c,preciomay);
            //txt_total.Text = calculatotal();
            //agregar a cantidad a lista
            //   agregaLista(int.Parse(teclado.response.ToString()), label1.Text.Trim());

        }

        private void agregaLista(int cantidad, string prod)
        {
            //for (int i = 1; i <= cantidad; i++)
            //{
            //    lproductos.Add(prod);

            //}
            int r1, r2;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                r1 = int.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString());
                r2 = recueraIdProducto(prod);
                if (r1 == r2)
                {
                    int cant = int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                    cant += cantidad;
                    dataGridView1.Rows[j].Cells[2].Value = cant;
                    if (cant >= mayoreo)
                        dataGridView1.Rows[j].Cells[3].Value = preciomay;

                }
            }


            //if (dataGridView1.Rows.Count > 0)
            //{
            //    int posicion = 0;
            //    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            //    {
            //        if (prod ==  dataGridView1.Rows[i].Cells[1].Value.ToString())
            //        {
            //            posicion = i;

            //        }
            //    }
            //    dataGridView1.Rows[posicion].Cells[2].Value = int.Parse(dataGridView1.Rows[posicion].Cells[2].Value.ToString()) + cantidad;
            //}
            //else
            //    dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), cantidad, precio);

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            recueraIdProducto(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            int qty = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            qty++;
            dataGridView1.SelectedRows[0].Cells[2].Value = qty;
            if (qty >= mayoreo)
                dataGridView1.Rows[0].Cells[3].Value = preciomay;
            txt_total.Text = calculatotal();
            //lproductos.Add(nombre);
            //this.label1_TextChanged(sender, e);
        }

        private void btn_eliminartodos_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txt_total.Text = "0";
            lproductos.Clear();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string datoeliminado = dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
                //   lproductos.Remove(datoeliminado);
                lproductos.RemoveAll(c => c.Equals(datoeliminado));
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                txt_total.Text = calculatotal();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;


            Pago pagof = new Pago();
            pagof.total = total;
            pagof.ShowDialog();
            if (pagof.DialogResult == DialogResult.Cancel)
                return;

            pagot = pagof.pago;
            cambio = pagof.cambio;
            try
            {
                //realizar venta
                //recorre el datagrid para sacar los productos, 
                //mete a la base de datos la venta y despues los detalles 
                DataSet1TableAdapters.SP_tabla_ventaTableAdapter tvta = new Paleteria.DataSet1TableAdapters.SP_tabla_ventaTableAdapter();
                DataTable venta = tvta.GetData("I", null, idUsuario, DateTime.Now);

                int idVenta = int.Parse(venta.Rows[0]["idVenta"].ToString());

                DataSet1TableAdapters.SP_tabla_ventaDetalleTableAdapter vdta = new Paleteria.DataSet1TableAdapters.SP_tabla_ventaDetalleTableAdapter();


                //Hace el descuento de las existencias.
                DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int idProd = int.Parse(row.Cells[0].Value.ToString());
                    int cantidad = int.Parse(row.Cells[2].Value.ToString());
                    bool mayor = (cantidad >= mayoreo);
                    vdta.GetData("I", 0, idProd, cantidad, mayor, idVenta);
                    qta.SP_tabla_productoUbicacion("Q", idProd, 1, cantidad);
                }




                ImprimirTicket(idVenta, pagot, cambio);
                int seg = int.Parse(qta.obtenerParametro("cierraVentanaCambio").ToString());

                AutoClosingMessageBox.Show("CAMBIO: $" + cambio.ToString(), "Información", seg * 1000);
                nuevaVenta();
                this.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            //jdr
            // no puedo agregar nada de data set a la bd mejor cuando vea al jaime :P pero en teoria jala asi

            //int idprod, cantidad=0;
            //for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            //{
            //    idprod=int.Parse(dataGridView1.Rows[i].Cells[0].Value);
            //    cantidad = int.Parse(dataGridView1.Rows[i].Cells[2].Value);
            //if (lproductos.Count() > 10)
            //{
            //    costo = decimal.Parse(dataGridView1.Rows[i].Cells[4].Value);
            //}
            //else
            //    costo = decimal.Parse(dataGridView1.Rows[i].Cells[3].Value);
            //   try
            //    {
            //        DataSet1TableAdapters.SP_tabla_productoUbicaciónTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_xxxx("U", idprod, cantidad,costo);;
            //     

            //    }
            //    catch (Exception e)
            //    {
            //        DataSet1TableAdapters.SP_tabla_productoUbicaciónTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_xxxx("I", idprod, cantidad,costo);
            //    }
            //}
        }


        private void nuevaVenta()
        {
            dataGridView1.Rows.Clear();
            txt_total.Text = "0";
            lproductos.Clear();
            DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
            total = 0;
            pagot = 0;
            precio = 0;
            preciomay = 0;

            lblTurno.Text = qta.obtenerTurno(DateTime.Now).ToString();
        }

        private void ImprimirTicket(int idVenta, decimal? pago, decimal? cambio)
        {

            try
            {
                DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
                DataSet1TableAdapters.SP_tabla_ventaTableAdapter tvta = new Paleteria.DataSet1TableAdapters.SP_tabla_ventaTableAdapter();
                DataSet1TableAdapters.SP_tabla_ventaDetalleTableAdapter tvdta = new Paleteria.DataSet1TableAdapters.SP_tabla_ventaDetalleTableAdapter();

                string impresora = qta.obtenerParametro("nombreImpresora");
                string nombreEmpresa = qta.obtenerParametro("nombreEmpresa");
                string sucursal = qta.obtenerParametro("sucursal");
                string telefono = qta.obtenerParametro("telefono");
                string leyenda = qta.obtenerParametro("leyenda");
                string nombreUsuario = qta.obtenerNombreUsuario(idUsuario);
                string turno = lblTurno.Text;

                DataTable venta = tvta.GetData("F", idVenta, null, null);
                DataTable ventaDetalle = tvdta.GetData("F", null, null, null, null, idVenta);

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

                tick.AddHeaderLine("Fecha: " + venta.Rows[0]["fechaHora"].ToString());

                tick.AddHeaderLine("Vendedor: " + qta.obtenerNombreUsuario(int.Parse(venta.Rows[0]["idUsuario"].ToString())).ToString());
                tick.AddHeaderLine("-------TURNO: " + turno + "---------");

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("Cantidad Producto        ");
                tick.AddHeaderLine("   Precio        Subtotal");
                tick.AddHeaderLine("-------------------------");


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    //hacer que el producto no se imprima completo ya que solo son 25 caracteres por linea
                    // vamos a dejar 20 para el nombre y 5 para a cantidad
                    //por ahora lo hace con el grid que ya esta dibujado
                    decimal subtotal = decimal.Parse(row.Cells[2].Value.ToString()) * decimal.Parse(row.Cells[3].Value.ToString());
                    string linea1 = row.Cells[2].Value.ToString() + "  " + row.Cells[1].Value.ToString();
                    string linea2 = "   " + row.Cells[3].Value.ToString() + "        " + subtotal.ToString();

                    tick.AddHeaderLine(linea1);
                    tick.AddHeaderLine(linea2);

                }

                tick.AddHeaderLine("-------------------------");
                tick.AddHeaderLine("TOTAL: " + total);
                tick.AddHeaderLine("SU PAGO: " + pagot);
                tick.AddHeaderLine("SU CAMBIO: " + cambio);

                NumLetra numletra = new NumLetra();
                tick.AddFooterLine(numletra.Convertir(total.ToString(), false));
                tick.AddFooterLine(leyenda);
                tick.PrintTicket(impresora);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void btncategoria_Click(object sender, System.EventArgs e)
        {
            valorc = 0;
            a = sender.ToString().Length;
            string nombre = sender.ToString().Substring(35, a - 35);
            categoria = nombre;
            valorc = recuperaidCategoria(nombre);
            DataSet1TableAdapters.SP_tabla_productoTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
            DataTable productos = produc.GetData("T", null, null, null, null, null, valorc, null, null);
            dibujabottonProductos(productos);

            //categorias.Add(nombre);
            //label1.Text = nombre;

        }

        public void btnproducto_Click(object sender, System.EventArgs e)
        {
            a = sender.ToString().Length;
            if (nombre != sender.ToString().Substring(35, a - 35))
            {

                nombre = sender.ToString().Substring(35, a - 35);
                lproductos.Add(nombre);
                valorp = recueraIdProducto(nombre);
                label1.Text = nombre;
            }
            else
            {
                nombre = sender.ToString().Substring(35, a - 35);
                lproductos.Add(nombre);
                this.label1_TextChanged(sender, e);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {

            //crear corte x 
            //se hace el corte x desde el ultimo corte que se haya hecho
            // int idUsuario = 2;//checar como meter al usuario por ahora solo es caja

            DataSet1TableAdapters.obtenerCorteXTableAdapter ocxta = new Paleteria.DataSet1TableAdapters.obtenerCorteXTableAdapter();
            DataTable dtCorte = ocxta.GetData(idUsuario, null);
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

        private void btnRetiroCaja_Click(object sender, EventArgs e)
        {
            new retiroCaja(idUsuario).ShowDialog();
        }

    }

    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}
