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
    public partial class Productos : Form
    {
        string nombre;
        decimal costo, precio, precioMayoreo;
        int idProducto = 0;


        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            cargarProductos();
            chbActivo.Checked = true;
        }
        
        private void cargarCategorias()
        {
            DataSet1TableAdapters.SP_tabla_categoriaTableAdapter categta = new Paleteria.DataSet1TableAdapters.SP_tabla_categoriaTableAdapter();
            DataTable catdt = categta.GetData("S", null, "", null, null);
            cmbCategoria.DataSource = catdt;
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.Refresh();
        }

        private void cargarProductos()
        {
            DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
            DataTable proddt = prodta.GetData("S", null,"",null,null,null,null,null,null);
            dgvProductos.DataSource = proddt;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            
            dgvProductos.Refresh();
            dgvProductos.Columns[7].Visible = false;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
            DataTable proddt = prodta.GetData("F", null,txtNombre.Text, null, null, null, null, null, null);
            dgvProductos.DataSource = proddt;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Refresh();

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    txtImagen.Text = openFileDialog1.FileName;
                    pbImagen.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                txtImagen.Text = "";
                pbImagen.Image = null;
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string valida= validate();
            if (valida == "OK")
            {
                try
                {
                     DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
               
                    if (pbImagen.Image != null) 
                        prodta.GetData("I", null, nombre, costo, precio, precioMayoreo, (int)cmbCategoria.SelectedValue,
                        chbActivo.Checked, ConvertImageToByteArray(pbImagen.Image));
                    else
                      prodta.GetData("I", null, nombre, costo, precio, precioMayoreo, (int)cmbCategoria.SelectedValue,
                        chbActivo.Checked, null);
                    cargarProductos();
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

        private string validate()
        {
            if (txtNombre.Text.Trim().Length == 0)            
                return "Debe ingresar un nombre";
            else nombre = txtNombre.Text.ToUpper();
            if (idProducto == 0) //solo si se esta ingresando uno nuevo 
            {
                DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
                DataTable proddt = prodta.GetData("R", null, txtNombre.Text, null, null, null, null, null, null);
                if (proddt.Rows.Count == 1)
                {
                    return "El nombre del producto ya ha sido ingresado";
                }
            }
            if (txtPrecio.Text.Trim().Length>0)
                 decimal.TryParse(txtPrecio.Text, out precio);
            if (txtPrecioMayoreo.Text.Trim().Length > 0)
                decimal.TryParse(txtPrecioMayoreo.Text, out precioMayoreo);
            if (txtCosto.Text.Trim().Length > 0)
                decimal.TryParse(txtCosto.Text, out costo);

            if (precio == 0)
            {
                return "Debe ingresar un precio de venta";
            }
            if (costo == 0) costo = precio;
            if (precioMayoreo == 0) precioMayoreo = precio;
            return "OK";
        }

        public static byte[] ConvertImageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch { return null; }
        }

        public static Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
                {
                    Image returnImage = Image.FromStream(ms);
                    return returnImage;
                }
            }
            catch { return null; }
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
                        DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();

                        if (pbImagen.Image != null)
                            prodta.GetData("U", idProducto, nombre, costo, precio, precioMayoreo, (int)cmbCategoria.SelectedValue,
                            chbActivo.Checked, ConvertImageToByteArray(pbImagen.Image));
                        else
                            prodta.GetData("U", idProducto, nombre, costo, precio, precioMayoreo, (int)cmbCategoria.SelectedValue,
                              chbActivo.Checked, null);
                        cargarProductos();
                        idProducto = 0;
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
                        idProducto = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                    else return;
                    btnAgregar.Enabled = false;
                    //btnActualizar.Enabled = true;
                    btnActualizar.Text = "Guardar";
                    DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
                    DataTable proddt = prodta.GetData("M", idProducto, "", null, null, null, null, null, null);
                    if (proddt.Rows.Count == 1)
                    {
                        txtNombre.Text = proddt.Rows[0]["nombreProducto"].ToString();
                        txtCosto.Text = proddt.Rows[0]["costo"].ToString();
                        txtPrecio.Text = proddt.Rows[0]["precio"].ToString();
                        txtPrecioMayoreo.Text = proddt.Rows[0]["precioMayoreo"].ToString();
                        chbActivo.Checked = (bool)proddt.Rows[0]["activo"];
                        pbImagen.Image = ConvertByteArrayToImage((byte[])proddt.Rows[0]["imagen"]);
                    }


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre;
            if (dgvProductos.SelectedRows.Count > 0){
            
                idProducto = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
                nombre = dgvProductos.SelectedRows[0].Cells[1].Value.ToString();
            }
            else return;

           DialogResult response = MessageBox.Show(string.Format("Esta seguro de eliminar el producto {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
           if (response == DialogResult.Yes)
           {
               DataSet1TableAdapters.SP_tabla_productoTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_productoTableAdapter();
               DataTable proddt = prodta.GetData("D", idProducto, "", null, null, null, null, null, null);
           }
           cargarProductos();
           limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            txtPrecioMayoreo.Text = "";
            idProducto = 0;
            costo = 0;
            precio = 0;
            precioMayoreo = 0;
            nombre = "";

        }
    }
}
