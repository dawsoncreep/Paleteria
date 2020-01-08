namespace Paleteria
{
    partial class Pago
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
            this.tecladoNumerico = new System.Windows.Forms.Panel();
            this.btnTeclado = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.Categoria = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tecladoNumerico.SuspendLayout();
            this.SuspendLayout();
            // 
            // tecladoNumerico
            // 
            this.tecladoNumerico.Controls.Add(this.btnTeclado);
            this.tecladoNumerico.Controls.Add(this.btnAccept);
            this.tecladoNumerico.Controls.Add(this.btn0);
            this.tecladoNumerico.Controls.Add(this.btnCancel);
            this.tecladoNumerico.Controls.Add(this.btn9);
            this.tecladoNumerico.Controls.Add(this.btn8);
            this.tecladoNumerico.Controls.Add(this.btn7);
            this.tecladoNumerico.Controls.Add(this.btn6);
            this.tecladoNumerico.Controls.Add(this.btn5);
            this.tecladoNumerico.Controls.Add(this.btn4);
            this.tecladoNumerico.Controls.Add(this.btn3);
            this.tecladoNumerico.Controls.Add(this.btn2);
            this.tecladoNumerico.Controls.Add(this.btn1);
            this.tecladoNumerico.Dock = System.Windows.Forms.DockStyle.Right;
            this.tecladoNumerico.Location = new System.Drawing.Point(385, 0);
            this.tecladoNumerico.Name = "tecladoNumerico";
            this.tecladoNumerico.Size = new System.Drawing.Size(250, 533);
            this.tecladoNumerico.TabIndex = 1;
            // 
            // btnTeclado
            // 
            this.btnTeclado.Location = new System.Drawing.Point(17, 426);
            this.btnTeclado.Name = "btnTeclado";
            this.btnTeclado.Size = new System.Drawing.Size(222, 98);
            this.btnTeclado.TabIndex = 12;
            this.btnTeclado.Text = "Teclado";
            this.btnTeclado.UseVisualStyleBackColor = true;
            this.btnTeclado.Click += new System.EventHandler(this.btnTeclado_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(167, 324);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 98);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(91, 323);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 98);
            this.btn0.TabIndex = 10;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 98);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(167, 224);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 98);
            this.btn9.TabIndex = 8;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(91, 224);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 98);
            this.btn8.TabIndex = 7;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(15, 224);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 98);
            this.btn7.TabIndex = 6;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(167, 122);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 98);
            this.btn6.TabIndex = 5;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(91, 122);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 98);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(15, 122);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 98);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(167, 20);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 98);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(91, 20);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 98);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(15, 20);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 98);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // Categoria
            // 
            this.Categoria.AutoSize = true;
            this.Categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categoria.Location = new System.Drawing.Point(12, 20);
            this.Categoria.Name = "Categoria";
            this.Categoria.Size = new System.Drawing.Size(169, 32);
            this.Categoria.TabIndex = 37;
            this.Categoria.Text = "Total Venta:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(18, 55);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(327, 38);
            this.txtTotal.TabIndex = 38;
            // 
            // txtPago
            // 
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago.Location = new System.Drawing.Point(18, 148);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(327, 38);
            this.txtPago.TabIndex = 40;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            this.txtPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPago_KeyDown);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 39;
            this.label1.Text = "Pago:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 41;
            this.label2.Text = "Cambio:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(23, 253);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(190, 69);
            this.lblCambio.TabIndex = 42;
            this.lblCambio.Text = "label3";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(27, 374);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(318, 98);
            this.btnCerrar.TabIndex = 43;
            this.btnCerrar.Text = "ACEPTAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Pago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 533);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.Categoria);
            this.Controls.Add(this.tecladoNumerico);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pago";
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.Pago_Load);
            this.Shown += new System.EventHandler(this.Pago_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pago_FormClosing);
            this.tecladoNumerico.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tecladoNumerico;
        private System.Windows.Forms.Button btnTeclado;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label Categoria;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Button btnCerrar;
    }
}