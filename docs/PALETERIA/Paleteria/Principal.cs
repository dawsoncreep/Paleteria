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
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            new Usuarios().Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
           

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
                    btnCorteY.Visible = true;
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

        }

        private void btnInventarioRepor_Click(object sender, EventArgs e)
        {
            new Inventario().Show();
        }
    }
}
