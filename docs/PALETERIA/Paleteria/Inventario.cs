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
            DataSet1TableAdapters.llenarGridInventarioTableAdapter gita = new Paleteria.DataSet1TableAdapters.llenarGridInventarioTableAdapter();
            dgvInventario.DataSource = gita.GetData((int)cmbUbicacion.SelectedValue);
            dgvInventario.Refresh();
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
    }
}
