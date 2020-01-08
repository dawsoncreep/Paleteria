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
    public partial class Parametros : Form
    {

        string nombre, descripcion, tipoDato;
        int idParametro;
        public Parametros()
        {
            InitializeComponent();
        }

        private void Parametros_Load(object sender, EventArgs e)
        {
            cargarParametros();
        }

        private void cargarParametros()
        {
            DataSet1TableAdapters.SP_tabla_parametroTableAdapter tpta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();
            dgvProductos.DataSource = tpta.GetData("S", null, "", "", "");
            dgvProductos.Refresh();
            dgvProductos.Columns[0].Visible = false;
        }

        private void limpiarCampos()
        {
            txtDesc.Text = "";
            txtNombre.Text = "";
            cmbTipoDato.SelectedIndex = -1;
            nombre = "";
            descripcion = "";
            tipoDato = "";
            idParametro = 0;
        }

        private string validate()
        {
            if (txtNombre.Text.Trim().Length == 0)
                return "Debe ingresar un nombre";
            else nombre = txtNombre.Text;

           if (txtDesc.Text.Trim().Length == 0)
                return "Debe ingresar una descripción";
            else descripcion = txtDesc.Text;

            if (cmbTipoDato.SelectedIndex < 0)
            {
                return "Seleccione un tipo de dato";
            }
            else tipoDato = cmbTipoDato.SelectedText;

            if (idParametro == 0) //solo si se esta ingresando uno nuevo 
            {
                DataSet1TableAdapters.SP_tabla_parametroTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();
                DataTable usudt = usuta.GetData("R", null, nombre, "", "");
                if (usudt.Rows.Count == 1)
                {
                    return "El nombre del parametro ya ha sido ingresado";
                }
            }

            return "OK";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string valida = validate();
            if (valida == "OK")
            {
                try
                {
                    DataSet1TableAdapters.SP_tabla_parametroTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();


                    usuta.GetData("I", null, nombre, descripcion, tipoDato);
                    DataTable udt = usuta.GetData("R", null, nombre, "", "");
                    cargarParametros();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (btnActualizar.Text == "Guardar")
            {
                string valida = validate();
                if (valida == "OK")
                {
                    try
                    {
                        DataSet1TableAdapters.SP_tabla_parametroTableAdapter usudta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();

                        usudta.GetData("U", idParametro, nombre, descripcion, tipoDato);
                        cargarParametros();
                        idParametro  = 0;
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

                    if (dgvProductos.SelectedRows.Count > 0)
                        idParametro = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                    else return;
                    btnAgregar.Enabled = false;
                    //btnActualizar.Enabled = true;
                    btnActualizar.Text = "Guardar";
                    DataSet1TableAdapters.SP_tabla_parametroTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();
                    DataTable usudt = prodta.GetData("F", idParametro, "", "","");
                    if (usudt.Rows.Count == 1)
                    {
                        txtNombre.Text = usudt.Rows[0]["nombreParametro"].ToString();
                        txtDesc.Text = usudt.Rows[0]["descripcion"].ToString();
                        cmbTipoDato.SelectedText = usudt.Rows[0]["tipoDato"].ToString() ;
                    }


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            if (dgvProductos.SelectedRows.Count > 0)
            {

                idParametro = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                nombre = dgvProductos.SelectedRows[0].Cells[1].Value.ToString();
            }
            else return;

            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el parametro {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                DataSet1TableAdapters.SP_tabla_parametroTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_parametroTableAdapter();
                usuta.GetData("D", idParametro, "", "",""); 
            }
            cargarParametros();
            limpiarCampos();
        }

        private void cmbTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
