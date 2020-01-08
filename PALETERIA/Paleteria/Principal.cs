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
    public partial class Principal : Form
    {

        public int idUsuario;
        public List<int> permisos;
        public Principal()
        {
            InitializeComponent();
            
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            pnlReportes.Visible = false;
            pnlCatalogos.Visible = true;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            pnlCatalogos.Visible = false;
            pnlReportes.Visible = true;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new Productos().Show();
            this.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Helados Daily Versión: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //hace la validacion de las pantallas por roles por usuario
            foreach (int permiso in permisos)
            switch (permiso)
            {
                case 2:
                    btnVenta.Visible = true;
                    break;
                case 3:
                    btnUsuarios.Visible = true;
                    break;
                case 4:
                    btnProductos.Visible = true;
                    break;
                case 5:
                    btnInventario.Visible = true;
                    break;
                case 6:
                    btnReportes.Visible = true;
                    break;
                case 7 :
                    btnIncialCaja.Visible = true;
                    btnCorteCaja.Visible = true;
                    break;
                case 8:
                    btnCatalogos.Visible = true;
                    break;
                default:
                    break;
            }             
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            //ingreso de inventario
            new IngresoInventario(idUsuario).ShowDialog();
            this.Show();

        }

        private void btnInventarioRepor_Click(object sender, EventArgs e)
        {
            new Inventario().Show();
        }

        private void btnCorteCaja_Click(object sender, EventArgs e)
        {

            new corteCaja().ShowDialog();
            this.Show();
            
        }

        private void btnIncialCaja_Click(object sender, EventArgs e)
        {
            //ingresa un inicial de caja para el usuario seleccionado
            //muestra una pantalla en donde se ingresa el total para el usuario caja 
            //por ahora solo hay dos usuarios y se maneja el usuario default 2 que es caja
            //para hacer el inicial
            //valida que no haya un inicial de caja desde el ultimo corte hecho
            //mete el inicial de caja para el usuario 
            //int idUsuario = 2; //ahora queda fijo para caja

            //DataSet1TableAdapters.QueriesTableAdapter qta = new Paleteria.DataSet1TableAdapters.QueriesTableAdapter();
            //if (qta.ObtenerInicialCajon(DateTime.Now)>0){
            //    //ya existe un inicial de caja registrado
            //    MessageBox.Show("Ya existe un inicial de caja hoy","Alerta");
            //}
            //else{
                new inicialCaja().ShowDialog();
                this.Show();
            //}
            
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            new Parametros().ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            new Inventario().Show();
        }

        private void btnVentasDia_Click(object sender, EventArgs e)
        {
            new ventasDia().Show();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            new Ventas(idUsuario).ShowDialog();
            this.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            new Categoria().ShowDialog();
            this.Show();

        }

      
    }
}
