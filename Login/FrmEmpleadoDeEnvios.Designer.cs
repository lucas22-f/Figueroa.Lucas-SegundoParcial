namespace App
{
    partial class FrmEmpleadoDeEnvios
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
            cmbBoxPedido = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // cmbBoxPedido
            // 
            cmbBoxPedido.FormattingEnabled = true;
            cmbBoxPedido.Location = new Point(41, 303);
            cmbBoxPedido.Name = "cmbBoxPedido";
            cmbBoxPedido.Size = new Size(274, 23);
            cmbBoxPedido.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 281);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 11;
            label5.Text = "Pedido";
            // 
            // FrmEmpleadoDeEnvios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 514);
            Controls.Add(label5);
            Controls.Add(cmbBoxPedido);
            Name = "FrmEmpleadoDeEnvios";
            Text = "FrmEmpleadoDeEnvios";
            Controls.SetChildIndex(cmbBoxPedido, 0);
            Controls.SetChildIndex(label5, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBoxPedido;
        private Label label5;
    }
}