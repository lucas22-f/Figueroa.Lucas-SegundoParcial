namespace App
{
    partial class FrmEmpleadoBase
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtBoxNombre = new TextBox();
            txtBoxSueldo = new TextBox();
            txtBoxDNI = new TextBox();
            cmboBoxExp = new ComboBox();
            Aceptar = new Button();
            Cancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 31);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 85);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Sueldo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 136);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 202);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 3;
            label4.Text = "Experiencia";
            // 
            // txtBoxNombre
            // 
            txtBoxNombre.Location = new Point(41, 49);
            txtBoxNombre.Name = "txtBoxNombre";
            txtBoxNombre.Size = new Size(159, 23);
            txtBoxNombre.TabIndex = 4;
            // 
            // txtBoxSueldo
            // 
            txtBoxSueldo.Location = new Point(41, 110);
            txtBoxSueldo.Name = "txtBoxSueldo";
            txtBoxSueldo.Size = new Size(159, 23);
            txtBoxSueldo.TabIndex = 5;
            // 
            // txtBoxDNI
            // 
            txtBoxDNI.Location = new Point(41, 157);
            txtBoxDNI.Name = "txtBoxDNI";
            txtBoxDNI.Size = new Size(159, 23);
            txtBoxDNI.TabIndex = 6;
            // 
            // cmboBoxExp
            // 
            cmboBoxExp.FormattingEnabled = true;
            cmboBoxExp.Location = new Point(41, 234);
            cmboBoxExp.Name = "cmboBoxExp";
            cmboBoxExp.Size = new Size(121, 23);
            cmboBoxExp.TabIndex = 7;
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(313, 77);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(75, 23);
            Aceptar.TabIndex = 8;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(313, 157);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(75, 23);
            Cancelar.TabIndex = 9;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // FrmEmpleadoBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 315);
            Controls.Add(Cancelar);
            Controls.Add(Aceptar);
            Controls.Add(cmboBoxExp);
            Controls.Add(txtBoxDNI);
            Controls.Add(txtBoxSueldo);
            Controls.Add(txtBoxNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmEmpleadoBase";
            Text = "FrmEmpleadoBase";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtBoxNombre;
        private TextBox txtBoxSueldo;
        private TextBox txtBoxDNI;
        private ComboBox cmboBoxExp;
        private Button Aceptar;
        private Button Cancelar;
    }
}