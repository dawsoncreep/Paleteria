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
    public partial class Usuarios : Form
    {
        int idUsuario = 0;
        string PIN, nombre;
        int idRol;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void cargarRoles()
        {
            DataSet1TableAdapters.SP_tabla_rolTableAdapter rta = new Paleteria.DataSet1TableAdapters.SP_tabla_rolTableAdapter();
            DataTable rdt = rta.GetData("S",null,"","");
            cmbRol.DataSource = rdt;
            cmbRol.ValueMember = "idRol";
            cmbRol.DisplayMember = "nombreRol";
            cmbRol.Refresh();
        }

        private void guardarRolUSuario(int idRol,int idUSuario){

            DataSet1TableAdapters.SP_tabla_rolUsuarioTableAdapter ruta = new Paleteria.DataSet1TableAdapters.SP_tabla_rolUsuarioTableAdapter();
            ruta.GetData("I", idRol, idUsuario);


        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
            cargarRoles();
        }
        
        private void cargarUsuarios()
        {
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsu = usuta.GetData("C", null, "", "", "", null, "");
                dgvUsuarios.DataSource = dtUsu;

                dgvUsuarios.Refresh();
                dgvUsuarios.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string valida = validate();
            if (valida == "OK")
            {
                try
                {
                    DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();


                    usuta.GetData("I", null, nombre, nombre, nombre, chbActivo.Checked, PIN);
                    DataTable udt = usuta.GetData("F", null, nombre, "", "", null, "");

                    guardarRolUSuario(idRol, (int)udt.Rows[0]["idUsuario"]);
                    cargarUsuarios();
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

            if (txtPIN.Text.Trim().Length !=4 || txtConfirmarPIN.Text.Trim().Length !=4)
            {
                return "Debe ingresar los PIN de 4 caracteres númericos";
            }
            if (!txtConfirmarPIN.Text.Equals(txtPIN.Text))
            {
                return "Los PIN no coinciden";
            }
            if (cmbRol.SelectedIndex < 0)
            {
                return "Seleccione un rol";
            }
            else idRol = (int)cmbRol.SelectedValue;
            
            if (idUsuario == 0) //solo si se esta ingresando uno nuevo 
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable usudt = usuta.GetData("R", null, txtNombre.Text.ToUpper(), "", "", null, "");
                if (usudt.Rows.Count == 1)
                {
                    return "El nombre del usuario ya ha sido ingresado";
                }
            }
            PIN = txtPIN.Text;
           
            return "OK";
        }

        private void txtPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
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
                        DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usudta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();

                        usudta.GetData("U", idUsuario, nombre,nombre,nombre, chbActivo.Checked, PIN);
                        guardarRolUSuario(idRol, idUsuario);

                        cargarUsuarios();
                        idUsuario = 0;
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

                    if (dgvUsuarios.SelectedRows.Count > 0)
                        idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells[0].Value;
                    else return;
                    btnAgregar.Enabled = false;
                    //btnActualizar.Enabled = true;
                    btnActualizar.Text = "Guardar";
                    DataSet1TableAdapters.SP_tabla_usuarioTableAdapter prodta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                    DataTable usudt = prodta.GetData("M", idUsuario, "", "", "", null,"");
                    if (usudt.Rows.Count == 1)
                    {
                        txtNombre.Text = usudt.Rows[0]["uid"].ToString();
                        txtPIN.Text = usudt.Rows[0]["PIN"].ToString();
                        chbActivo.Checked = (bool)usudt.Rows[0]["activo"];
                    }

                    DataSet1TableAdapters.SP_tabla_rolUsuarioTableAdapter ruta = new Paleteria.DataSet1TableAdapters.SP_tabla_rolUsuarioTableAdapter();
                    DataTable rudt = ruta.GetData("F", null, idUsuario);
                    cmbRol.SelectedValue = rudt.Rows[0]["idRol"];

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }

        }

        private void limpiarCampos()
        {
            txtConfirmarPIN.Text = "";
            txtNombre.Text = "";
            txtPIN.Text = "";
            idUsuario = 0;
            idRol = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre;
            if (dgvUsuarios.SelectedRows.Count > 0)
            {

                idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells[0].Value;
                nombre = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString();
            }
            else return;

            DialogResult response = MessageBox.Show(string.Format("¿Está seguro de eliminar el usuario {0} ?", nombre), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (response == DialogResult.Yes)
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuta = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                usuta.GetData("D", idUsuario,"","","",null,"");
            }
            cargarUsuarios();
            limpiarCampos();
        }

    }
}
