namespace App
{
    partial class FrmAgregarCliente
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
            lblNombre = new Label();
            txtBoxNombre = new TextBox();
            txtBoxDNI = new TextBox();
            lblDNI = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(50, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre :";
            // 
            // txtBoxNombre
            // 
            txtBoxNombre.Location = new Point(50, 56);
            txtBoxNombre.Name = "txtBoxNombre";
            txtBoxNombre.Size = new Size(242, 23);
            txtBoxNombre.TabIndex = 1;
            // 
            // txtBoxDNI
            // 
            txtBoxDNI.Location = new Point(50, 121);
            txtBoxDNI.Name = "txtBoxDNI";
            txtBoxDNI.Size = new Size(242, 23);
            txtBoxDNI.TabIndex = 3;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(50, 103);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(33, 15);
            lblDNI.TabIndex = 2;
            lblDNI.Text = "DNI :";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(50, 267);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(217, 267);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(50, 188);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(242, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(50, 170);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(58, 15);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Telefono :";
            // 
            // FrmAgregarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 328);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtBoxDNI);
            Controls.Add(lblDNI);
            Controls.Add(txtBoxNombre);
            Controls.Add(lblNombre);
            Name = "FrmAgregarCliente";
            Text = "FrmAgregarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtBoxNombre;
        private TextBox txtBoxDNI;
        private Label lblDNI;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtTelefono;
        private Label lblTelefono;
    }
}