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
    public partial class IngresoInventario : Form
    {
        int a,b=0;
        decimal preciomay, precio, total;
        int valorc, valorp;
        string categoria = "";
        string nombre = "";
        tecladoNum t = new tecladoNum(true);
        List<string> lproductos = new List<string>();
        Button botonCategoria = new System.Windows.Forms.Button();
        Button botonProducto = new System.Windows.Forms.Button();
     
        public IngresoInventario()
        {
            InitializeComponent();
        }

        private void IngresoInventario_Load(object sender, EventArgs e)
        {
            CargaCategorias();
           
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

                  if (i <= 5)
                  {
                      botonProducto.Location = new System.Drawing.Point((i - 1) * 100, 0);
                  }
                  if (i <= 10 && i > 5)
                  {
                      botonProducto.Location = new System.Drawing.Point((i - 6) * 100, 80);
                  }
                  if (i <= 15 && i > 10)
                  {
                      botonProducto.Location = new System.Drawing.Point((i - 11) * 100, 160);
                  }
                  botonProducto.Name = productos.Rows[i - 1][1].ToString();
                  botonProducto.Text = productos.Rows[i - 1][1].ToString();
                  botonProducto.Size = new Size(94, 73);
                  botonProducto.TabIndex = 0;
                  botonProducto.TabStop = false;
                  pnlProducto.Controls.Add(botonProducto);
                  botonProducto.Click += new EventHandler(btnproducto_Click);
              }
          }
         
      }

      private void dibujabottonCategoria(DataTable categorias)
        {
            for (int i = 1; i <= categorias.Rows.Count; i++)
            {
                Button botonCategoria = new System.Windows.Forms.Button();
                
                if (i <= 5)
                {
                    botonCategoria.Location = new System.Drawing.Point((i-1)*100, 0);
                }
                if(i<=10 && i>5)
                {
                    botonCategoria.Location = new System.Drawing.Point((i - 6) * 100, 80);
                }
                if (i <= 15 && i > 10)
                {
                    botonCategoria.Location = new System.Drawing.Point((i - 11) * 100, 160);
                }
                botonCategoria.Name = categorias.Rows[i - 1][1].ToString();
                botonCategoria.Text = categorias.Rows[i-1][1].ToString();
                botonCategoria.Size = new Size(94, 73);
                botonCategoria.TabIndex = 0;
                botonCategoria.TabStop = false;
                pnlCategorias.Controls.Add(botonCategoria);
                botonCategoria.Click += new EventHandler(btncategoria_Click);
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
      {  a = sender.ToString().Length;
          if (nombre != sender.ToString().Substring(35, a - 35))
          {
            
              nombre = sender.ToString().Substring(35, a - 35);
              lproductos.Add(nombre);
              valorp = recueraIdProducto(nombre);
              label1.Text = nombre;
          }
          else {
              nombre = sender.ToString().Substring(35, a - 35);
              lproductos.Add(nombre);
              this.label1_TextChanged(sender, e); }


      }

      private void label1_TextChanged(object sender, EventArgs e)
      {

          int c = 0;
          for (int i = 0; i <= lproductos.Count() - 1; i++)
          {
              if (lproductos[i].ToString() == label1.Text.Trim())
              {
                  c = c + 1;
              }
          }
          int bandera = 0;
          int r1,r2;
          if (dataGridView1.Rows[0].Cells[0].Value!=null)
          {
              for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
              {
                  r1 = int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                  r2 = recueraIdProducto(label1.Text.Trim());
                  if (r1 == r2)
                  {
                      dataGridView1.Rows[j].Cells[3].Value = c;
                      bandera = 1;
                  }
              }
              if (bandera == 0)
              {
                  dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, preciomay);

              }
          }
          else
              dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, preciomay);

      }

      private void btn_agregarvarios_Click(object sender, EventArgs e)
      {
          tecladoNum teclado = new tecladoNum(false);
          teclado.ShowDialog();
          int c = int.Parse(teclado.response.ToString());
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
                  r1 = int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                  r2 = recueraIdProducto(label1.Text.Trim());
                  if (r1 == r2)
                  {
                      dataGridView1.Rows[j].Cells[3].Value = c;
                      bandera = 1;
                  }
              }
              if (bandera == 0)
              {
                  dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, preciomay);

              }
          }
          else
              dataGridView1.Rows.Add(recuperaidCategoria(categoria), recueraIdProducto(label1.Text.Trim()), label1.Text.Trim(), c, preciomay);

          //falta funcionalida de recuperar el dato del teclado 
          agregaLista(int.Parse(teclado.response.ToString()), label1.Text.Trim());

      }
      private void agregaLista(int cantidad, string prod)
      {
          for (int i = 1; i <= cantidad; i++)
          {
              lproductos.Add(prod);
          }
      }

      private void btn_agregar_Click(object sender, EventArgs e)
      {
          lproductos.Add(nombre);
          this.label1_TextChanged(sender, e);
      }

      private void btn_eliminartodos_Click(object sender, EventArgs e)
      {
          dataGridView1.Rows.Clear();
          lproductos.Clear();
      }

      private void btn_eliminar_Click(object sender, EventArgs e)
      {
        

          if (dataGridView1.Rows[0].Cells[0].Value != null)
          {
              string datoeliminado = dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
              //   lproductos.Remove(datoeliminado);
              lproductos.RemoveAll(c => c.Equals(datoeliminado));
              dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            //  txt_total.Text = calculatotal();
              
          }
         
      }

      private void btn_guardar_Click(object sender, EventArgs e)
      {
          //jdr
          // no puedo agregar nada de data set a la bd mejor cuando vea al jaime :P pero en teoria jala asi

          //int idprod, cantidad=0;
          //for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
          //{
          //    idprod=int.Parse(dataGridView1.Rows[i].Cells[1].Value);
          //    cantidad = int.Parse(dataGridView1.Rows[i].Cells[3].Value);
          //    try
          //    {
          //        DataSet1TableAdapters.SP_tabla_productoUbicaciónTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_xxx("U", idprod, 0, cantidad);

          //    }
          //    catch (Exception e)
          //    {
          //        DataSet1TableAdapters.SP_tabla_productoUbicaciónTableAdapter produc = new Paleteria.DataSet1TableAdapters.SP_xxx("I", idprod, "", cantidad);
          //    }
          //}
      }
    }
}
