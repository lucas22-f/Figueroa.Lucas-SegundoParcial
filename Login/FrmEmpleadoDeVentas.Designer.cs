namespace App
{
    partial class FrmEmpleadoDeVentas
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
            Clientes = new Label();
            cmboBoxCliente = new ComboBox();
            cmboBoxProductos = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // Clientes
            // 
            Clientes.AutoSize = true;
            Clientes.Location = new Point(41, 290);
            Clientes.Name = "Clientes";
            Clientes.Size = new Size(44, 15);
            Clientes.TabIndex = 10;
            Clientes.Text = "Cliente";
            // 
            // cmboBoxCliente
            // 
            cmboBoxCliente.FormattingEnabled = true;
            cmboBoxCliente.Location = new Point(41, 308);
            cmboBoxCliente.Name = "cmboBoxCliente";
            cmboBoxCliente.Size = new Size(347, 23);
            cmboBoxCliente.TabIndex = 11;
            // 
            // cmboBoxProductos
            // 
            cmboBoxProductos.FormattingEnabled = true;
            cmboBoxProductos.Location = new Point(41, 388);
            cmboBoxProductos.Name = "cmboBoxProductos";
            cmboBoxProductos.Size = new Size(347, 23);
            cmboBoxProductos.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 370);
            label5.Name = "label5";
            label5.Size = new Size(139, 15);
            label5.TabIndex = 13;
            label5.Text = "Conjunto de productos : ";
            // 
            // FrmEmpleadoDeVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 485);
            Controls.Add(label5);
            Controls.Add(cmboBoxProductos);
            Controls.Add(cmboBoxCliente);
            Controls.Add(Clientes);
            Name = "FrmEmpleadoDeVentas";
            Text = "FrmEmpleadoDeVentas";
            Controls.SetChildIndex(Clientes, 0);
            Controls.SetChildIndex(cmboBoxCliente, 0);
            Controls.SetChildIndex(cmboBoxProductos, 0);
            Controls.SetChildIndex(label5, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Clientes;
        private ComboBox cmboBoxCliente;
        private ComboBox cmboBoxProductos;
        private Label label5;
    }
}