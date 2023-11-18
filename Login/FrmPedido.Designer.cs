namespace App
{
    partial class FrmPedido
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
            cmBoxProducto = new ComboBox();
            label1 = new Label();
            cmBoxVendedor = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cmBoxCliente = new ComboBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cmBoxProducto
            // 
            cmBoxProducto.FormattingEnabled = true;
            cmBoxProducto.Location = new Point(30, 47);
            cmBoxProducto.Name = "cmBoxProducto";
            cmBoxProducto.Size = new Size(250, 23);
            cmBoxProducto.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Producto";
            // 
            // cmBoxVendedor
            // 
            cmBoxVendedor.FormattingEnabled = true;
            cmBoxVendedor.Location = new Point(30, 116);
            cmBoxVendedor.Name = "cmBoxVendedor";
            cmBoxVendedor.Size = new Size(250, 23);
            cmBoxVendedor.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 98);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Vendedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 171);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Cliente";
            // 
            // cmBoxCliente
            // 
            cmBoxCliente.FormattingEnabled = true;
            cmBoxCliente.Location = new Point(30, 189);
            cmBoxCliente.Name = "cmBoxCliente";
            cmBoxCliente.Size = new Size(250, 23);
            cmBoxCliente.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(118, 236);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(317, 271);
            Controls.Add(btnAceptar);
            Controls.Add(cmBoxCliente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmBoxVendedor);
            Controls.Add(label1);
            Controls.Add(cmBoxProducto);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPedido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmBoxProducto;
        private Label label1;
        private ComboBox cmBoxVendedor;
        private Label label2;
        private Label label3;
        private ComboBox cmBoxCliente;
        private Button btnAceptar;
    }
}