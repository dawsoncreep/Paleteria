namespace Paleteria
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnIncialCaja = new System.Windows.Forms.Button();
            this.btnCorteCaja = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnCatalogos = new System.Windows.Forms.Button();
            this.pnlCatalogos = new System.Windows.Forms.Panel();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnPantallas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnParametros = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnRol = new System.Windows.Forms.Button();
            this.pnlReportes = new System.Windows.Forms.Panel();
            this.btnVentasUsuario = new System.Windows.Forms.Button();
            this.btnInventarioRepor = new System.Windows.Forms.Button();
            this.btnVentasDia = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlCatalogos.SuspendLayout();
            this.pnlReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnIngreso);
            this.pnlMenu.Controls.Add(this.btnReportes);
            this.pnlMenu.Controls.Add(this.btnIncialCaja);
            this.pnlMenu.Controls.Add(this.btnCorteCaja);
            this.pnlMenu.Controls.Add(this.btnInventario);
            this.pnlMenu.Controls.Add(this.btnVenta);
            this.pnlMenu.Controls.Add(this.btnCatalogos);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(235, 679);
            this.pnlMenu.TabIndex = 12;
            // 
            // btnIngreso
            // 
            this.btnIngreso.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.Location = new System.Drawing.Point(0, 570);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(235, 95);
            this.btnIngreso.TabIndex = 19;
            this.btnIngreso.Text = "Ingreso ";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(0, 475);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(235, 95);
            this.btnReportes.TabIndex = 17;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Visible = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnIncialCaja
            // 
            this.btnIncialCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIncialCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncialCaja.Location = new System.Drawing.Point(0, 380);
            this.btnIncialCaja.Name = "btnIncialCaja";
            this.btnIncialCaja.Size = new System.Drawing.Size(235, 95);
            this.btnIncialCaja.TabIndex = 16;
            this.btnIncialCaja.Text = "Inicial de Caja";
            this.btnIncialCaja.UseVisualStyleBackColor = true;
            this.btnIncialCaja.Click += new System.EventHandler(this.btnIncialCaja_Click);
            // 
            // btnCorteCaja
            // 
            this.btnCorteCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCorteCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorteCaja.Location = new System.Drawing.Point(0, 285);
            this.btnCorteCaja.Name = "btnCorteCaja";
            this.btnCorteCaja.Size = new System.Drawing.Size(235, 95);
            this.btnCorteCaja.TabIndex = 15;
            this.btnCorteCaja.Text = "Corte X";
            this.btnCorteCaja.UseVisualStyleBackColor = true;
            this.btnCorteCaja.Click += new System.EventHandler(this.btnCorteCaja_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(0, 190);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(235, 95);
            this.btnInventario.TabIndex = 14;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Visible = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnVenta
            // 
            this.btnVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.Location = new System.Drawing.Point(0, 95);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(235, 95);
            this.btnVenta.TabIndex = 13;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Visible = false;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnCatalogos
            // 
            this.btnCatalogos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCatalogos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogos.Location = new System.Drawing.Point(0, 0);
            this.btnCatalogos.Name = "btnCatalogos";
            this.btnCatalogos.Size = new System.Drawing.Size(235, 95);
            this.btnCatalogos.TabIndex = 12;
            this.btnCatalogos.Text = "Catálogos";
            this.btnCatalogos.UseVisualStyleBackColor = true;
            this.btnCatalogos.Visible = false;
            this.btnCatalogos.Click += new System.EventHandler(this.btnCatalogos_Click);
            // 
            // pnlCatalogos
            // 
            this.pnlCatalogos.BackColor = System.Drawing.Color.Transparent;
            this.pnlCatalogos.Controls.Add(this.btnCategorias);
            this.pnlCatalogos.Controls.Add(this.btnPantallas);
            this.pnlCatalogos.Controls.Add(this.btnProductos);
            this.pnlCatalogos.Controls.Add(this.btnParametros);
            this.pnlCatalogos.Controls.Add(this.btnUsuarios);
            this.pnlCatalogos.Controls.Add(this.btnRol);
            this.pnlCatalogos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCatalogos.Location = new System.Drawing.Point(235, 0);
            this.pnlCatalogos.Name = "pnlCatalogos";
            this.pnlCatalogos.Size = new System.Drawing.Size(210, 679);
            this.pnlCatalogos.TabIndex = 13;
            this.pnlCatalogos.Visible = false;
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.Location = new System.Drawing.Point(0, 475);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(210, 95);
            this.btnCategorias.TabIndex = 23;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnPantallas
            // 
            this.btnPantallas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPantallas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPantallas.Location = new System.Drawing.Point(0, 380);
            this.btnPantallas.Name = "btnPantallas";
            this.btnPantallas.Size = new System.Drawing.Size(210, 95);
            this.btnPantallas.TabIndex = 22;
            this.btnPantallas.Text = "Pantallas";
            this.btnPantallas.UseVisualStyleBackColor = true;
            this.btnPantallas.Visible = false;
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Location = new System.Drawing.Point(0, 285);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(210, 95);
            this.btnProductos.TabIndex = 21;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnParametros
            // 
            this.btnParametros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParametros.Location = new System.Drawing.Point(0, 190);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(210, 95);
            this.btnParametros.TabIndex = 20;
            this.btnParametros.Text = "Parametros";
            this.btnParametros.UseVisualStyleBackColor = true;
            this.btnParametros.Click += new System.EventHandler(this.btnParametros_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Location = new System.Drawing.Point(0, 95);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(210, 95);
            this.btnUsuarios.TabIndex = 19;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Visible = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnRol
            // 
            this.btnRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRol.Location = new System.Drawing.Point(0, 0);
            this.btnRol.Name = "btnRol";
            this.btnRol.Size = new System.Drawing.Size(210, 95);
            this.btnRol.TabIndex = 18;
            this.btnRol.Text = "Roles";
            this.btnRol.UseVisualStyleBackColor = true;
            this.btnRol.Visible = false;
            // 
            // pnlReportes
            // 
            this.pnlReportes.BackColor = System.Drawing.Color.Transparent;
            this.pnlReportes.Controls.Add(this.btnVentasUsuario);
            this.pnlReportes.Controls.Add(this.btnInventarioRepor);
            this.pnlReportes.Controls.Add(this.btnVentasDia);
            this.pnlReportes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlReportes.Location = new System.Drawing.Point(445, 0);
            this.pnlReportes.Name = "pnlReportes";
            this.pnlReportes.Size = new System.Drawing.Size(210, 679);
            this.pnlReportes.TabIndex = 14;
            this.pnlReportes.Visible = false;
            // 
            // btnVentasUsuario
            // 
            this.btnVentasUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentasUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasUsuario.Location = new System.Drawing.Point(0, 190);
            this.btnVentasUsuario.Name = "btnVentasUsuario";
            this.btnVentasUsuario.Size = new System.Drawing.Size(210, 95);
            this.btnVentasUsuario.TabIndex = 20;
            this.btnVentasUsuario.Text = "Ventas por Usuario";
            this.btnVentasUsuario.UseVisualStyleBackColor = true;
            this.btnVentasUsuario.Visible = false;
            // 
            // btnInventarioRepor
            // 
            this.btnInventarioRepor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventarioRepor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioRepor.Location = new System.Drawing.Point(0, 95);
            this.btnInventarioRepor.Name = "btnInventarioRepor";
            this.btnInventarioRepor.Size = new System.Drawing.Size(210, 95);
            this.btnInventarioRepor.TabIndex = 19;
            this.btnInventarioRepor.Text = "Inventario";
            this.btnInventarioRepor.UseVisualStyleBackColor = true;
            this.btnInventarioRepor.Click += new System.EventHandler(this.btnInventarioRepor_Click);
            // 
            // btnVentasDia
            // 
            this.btnVentasDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentasDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasDia.Location = new System.Drawing.Point(0, 0);
            this.btnVentasDia.Name = "btnVentasDia";
            this.btnVentasDia.Size = new System.Drawing.Size(210, 95);
            this.btnVentasDia.TabIndex = 18;
            this.btnVentasDia.Text = "Ventas por Día";
            this.btnVentasDia.UseVisualStyleBackColor = true;
            this.btnVentasDia.Click += new System.EventHandler(this.btnVentasDia_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(900, 679);
            this.Controls.Add(this.pnlReportes);
            this.Controls.Add(this.pnlCatalogos);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlCatalogos.ResumeLayout(false);
            this.pnlReportes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnIncialCaja;
        private System.Windows.Forms.Button btnCorteCaja;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCatalogos;
        private System.Windows.Forms.Panel pnlCatalogos;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnPantallas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnParametros;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnRol;
        private System.Windows.Forms.Panel pnlReportes;
        private System.Windows.Forms.Button btnVentasUsuario;
        private System.Windows.Forms.Button btnInventarioRepor;
        private System.Windows.Forms.Button btnVentasDia;
        private System.Windows.Forms.Button btnIngreso;

    }
}