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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtContrasena.Focus();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuarios = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsuario = usuarios.GetData("S", null, "", "", "", null, "");
                cmbUsuario.DataSource = dtUsuario;
                cmbUsuario.ValueMember = "idUsuario";
                cmbUsuario.DisplayMember = "uid";
                cmbUsuario.Refresh();
                txtContrasena.Focus();

            }catch ( Exception ex )
                
                {
                    MessageBox.Show("No hay conexion a BD","Conexion BD",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet1TableAdapters.SP_tabla_usuarioTableAdapter usuarios = new Paleteria.DataSet1TableAdapters.SP_tabla_usuarioTableAdapter();
                DataTable dtUsuario = usuarios.GetData("L",(int)cmbUsuario.SelectedValue,"","", "", null, txtContrasena.Text.Trim());
                if (dtUsuario.Rows.Count > 0)
                {
                    List<int> permisos= new List<int>();
                    DataSet1TableAdapters.permisosPorUsuarioTableAdapter puta = new Paleteria.DataSet1TableAdapters.permisosPorUsuarioTableAdapter();
                    DataTable pudt = puta.GetData((int)cmbUsuario.SelectedValue);
                    foreach (DataRow permiso in pudt.Rows)
                    {
                        permisos.Add((int)permiso["idPantalla"]);
                    }
                    //  MessageBox.Show("Logueo correcto");
                    this.Hide();
                    Principal menu = new Principal();
                    menu.permisos = permisos;
                    menu.idUsuario = (int)cmbUsuario.SelectedValue;
                    //menu.usuario = dtUsuario.Rows[0]["uid"].ToString();
                    menu.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("PIN Incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El usuario no corresponde", "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtContrasena.Focus();
            txtContrasena.Text += ((Button)sender).Text;           
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtContrasena.Text = "";
            cmbUsuario.SelectedIndex = -1;

        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
              System.Diagnostics.Process.Start("osk.exe");
            //prueba Teclado Numerico
            //tecladoNum teclado = new tecladoNum(true);
            //teclado.ShowDialog();
            //MessageBox.Show(teclado.response.ToString());
            //teclado.Dispose();
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, new EventArgs());
            }

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            txtContrasena.Focus();
        }

       
    }
}
