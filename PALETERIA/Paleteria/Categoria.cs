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
    public partial class Categoria : Form
    {
        bool aplicaVenta, aplicaInventario;
        string nombre;
        int idCategoria;


        public Categoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            cargarCategorias();

        }

        private void cargarCategorias()
        {
            DataSet1TableAdapters.SP_tabla_categoriaTableAdapter categta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
            DataTable catdt = categta.GetData("S", null, "", null, null);
            dgvCategoria.DataSource = catdt;
            dgvCategoria.Refresh();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string valida = validate();
            if (valida == "OK")
            {
                try
                {
                    DataSet1TableAdapters.SP_tabla_categoriaTableAdapter cta  = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
                    cta.GetData("I", null, nombre, aplicaInventario, aplicaVenta);
                    cargarCategorias();
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(valida, "Valida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            chbCuentaVenta.Checked = true;
            chbCuentaInventario.Checked = true;
        }

        private string validate()
        {
            if (txtNombre.Text == "")
                return "Ingrese el nombre";
            else
            {
                nombre = txtNombre.Text.ToUpper();
                aplicaInventario = chbCuentaInventario.Checked;
                aplicaVenta = chbCuentaVenta.Checked;
                return "OK";

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (btnActualizar.Text == "Guardar")
            {
                string valida = validate();
                if (valida == "OK")
                {
                    try
                    {
                        DataSet1TableAdapters.SP_tabla_categoriaTableAdapter cta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();

                        cta.GetData("U", idCategoria, nombre, aplicaInventario, aplicaVenta);
                        cargarCategorias();
                        idCategoria = 0;
                        btnActualizar.Text = "Actualizar";
                        btnAgregar.Enabled = true;
                        limpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(valida, "Valida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

            }
            else
            {


                try
                {

                    if (dgvCategoria.SelectedRows.Count > 0)
                        idCategoria = (int)dgvCategoria.SelectedRows[0].Cells[0].Value;
                    else return;
                    btnAgregar.Enabled = false;
                    //btnActualizar.Enabled = true;
                    btnActualizar.Text = "Guardar";
                    DataSet1TableAdapters.SP_tabla_categoriaTableAdapter cta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
                    DataTable cdt = cta.GetData("F", idCategoria,"", null,null);
                    if (cdt.Rows.Count == 1)
                    {
                        txtNombre.Text = cdt.Rows[0]["nombre"].ToString();
                        chbCuentaInventario.Checked = bool.Parse( cdt.Rows[0]["cuentaInventario"].ToString());
                        chbCuentaVenta.Checked = bool.Parse( cdt.Rows[0]["cuentaVenta"].ToString());
                    }


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoria.SelectedRows.Count > 0)
                {

                    idCategoria = (int)dgvCategoria.SelectedRows[0].Cells[0].Value;
                    nombre = dgvCategoria.SelectedRows[0].Cells[1].Value.ToString();
                }
                else return;

                DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar la categoria {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response == DialogResult.Yes)
                {
                    DataSet1TableAdapters.SP_tabla_categoriaTableAdapter cta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
                    cta.GetData("D", idCategoria, "", null, null);
                }
                cargarCategorias();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }






    }
}
