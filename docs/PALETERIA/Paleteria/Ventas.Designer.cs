namespace Paleteria
{
    partial class Ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.pnlCategorias = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lbl_tipoprecio = new System.Windows.Forms.Label();
            this.b_imprimir = new System.Windows.Forms.Button();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_agregarvarios = new System.Windows.Forms.Button();
            this.btn_eliminartodos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProducto
            // 
            this.pnlProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProducto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProducto.Location = new System.Drawing.Point(0, 237);
            this.pnlProducto.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(493, 321);
            this.pnlProducto.TabIndex = 35;
            // 
            // pnlCategorias
            // 
            this.pnlCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategorias.Controls.Add(this.pnlProducto);
            this.pnlCategorias.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCategorias.Location = new System.Drawing.Point(396, 0);
            this.pnlCategorias.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCategorias.Name = "pnlCategorias";
            this.pnlCategorias.Size = new System.Drawing.Size(495, 560);
            this.pnlCategorias.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.Column1,
            this.Column2,
            this.id_categoria,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(2, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(388, 312);
            this.dataGridView1.TabIndex = 28;
            // 
            // id_producto
            // 
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Producto";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cantidad";
            this.Column2.Name = "Column2";
            // 
            // id_categoria
            // 
            this.id_categoria.HeaderText = "Precio";
            this.id_categoria.Name = "id_categoria";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio may";
            this.Column3.Name = "Column3";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalle.Controls.Add(this.lbl_tipoprecio);
            this.pnlDetalle.Controls.Add(this.b_imprimir);
            this.pnlDetalle.Controls.Add(this.txt_total);
            this.pnlDetalle.Controls.Add(this.btn_guardar);
            this.pnlDetalle.Controls.Add(this.btn_agregar);
            this.pnlDetalle.Controls.Add(this.btn_eliminar);
            this.pnlDetalle.Controls.Add(this.btn_agregarvarios);
            this.pnlDetalle.Controls.Add(this.btn_eliminartodos);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.dataGridView1);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(397, 560);
            this.pnlDetalle.TabIndex = 1;
            // 
            // lbl_tipoprecio
            // 
            this.lbl_tipoprecio.AutoSize = true;
            this.lbl_tipoprecio.Location = new System.Drawing.Point(111, 401);
            this.lbl_tipoprecio.Name = "lbl_tipoprecio";
            this.lbl_tipoprecio.Size = new System.Drawing.Size(0, 13);
            this.lbl_tipoprecio.TabIndex = 37;
            // 
            // b_imprimir
            // 
            this.b_imprimir.Location = new System.Drawing.Point(196, 493);
            this.b_imprimir.Name = "b_imprimir";
            this.b_imprimir.Size = new System.Drawing.Size(96, 64);
            this.b_imprimir.TabIndex = 36;
            this.b_imprimir.Text = "IMPRIMIR TICKET";
            this.b_imprimir.UseVisualStyleBackColor = true;
            this.b_imprimir.Click += new System.EventHandler(this.b_imprimir_Click);
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(213, 398);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(176, 20);
            this.txt_total.TabIndex = 35;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(293, 493);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(96, 64);
            this.btn_guardar.TabIndex = 34;
            this.btn_guardar.Text = "ACEPTAR";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(293, 423);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(96, 64);
            this.btn_agregar.TabIndex = 33;
            this.btn_agregar.Text = "AGREGAR";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(100, 423);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(96, 64);
            this.btn_eliminar.TabIndex = 32;
            this.btn_eliminar.Text = "ELIMINAR PRODUCTO";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_agregarvarios
            // 
            this.btn_agregarvarios.Location = new System.Drawing.Point(196, 423);
            this.btn_agregarvarios.Name = "btn_agregarvarios";
            this.btn_agregarvarios.Size = new System.Drawing.Size(96, 64);
            this.btn_agregarvarios.TabIndex = 31;
            this.btn_agregarvarios.Text = "AGREGAR VARIOS";
            this.btn_agregarvarios.UseVisualStyleBackColor = true;
            this.btn_agregarvarios.Click += new System.EventHandler(this.btn_agregarvarios_Click);
            // 
            // btn_eliminartodos
            // 
            this.btn_eliminartodos.Location = new System.Drawing.Point(3, 423);
            this.btn_eliminartodos.Name = "btn_eliminartodos";
            this.btn_eliminartodos.Size = new System.Drawing.Size(96, 64);
            this.btn_eliminartodos.TabIndex = 30;
            this.btn_eliminartodos.Text = "ELIMINAR TODO";
            this.btn_eliminartodos.UseVisualStyleBackColor = true;
            this.btn_eliminartodos.Click += new System.EventHandler(this.btn_eliminartodos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "label1";
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 560);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlCategorias);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.IngresoInventario_Load);
            this.pnlCategorias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Panel pnlCategorias;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_agregarvarios;
        private System.Windows.Forms.Button btn_eliminartodos;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Button b_imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label lbl_tipoprecio;

    }
}