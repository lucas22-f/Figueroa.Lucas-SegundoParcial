namespace Login
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuario = new Label();
            lblContrasenia = new Label();
            txtboxCorreo = new TextBox();
            txtBoxClave = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            pictureBox3 = new PictureBox();
            progresBarLogin = new ProgressBar();
            lblProgressBar = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.ForeColor = SystemColors.ButtonHighlight;
            lblUsuario.Location = new Point(57, 240);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(66, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario :";
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblContrasenia.ForeColor = SystemColors.ButtonHighlight;
            lblContrasenia.Location = new Point(57, 354);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(90, 20);
            lblContrasenia.TabIndex = 1;
            lblContrasenia.Text = "Contraseña :";
            // 
            // txtboxCorreo
            // 
            txtboxCorreo.BackColor = Color.CornflowerBlue;
            txtboxCorreo.BorderStyle = BorderStyle.None;
            txtboxCorreo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxCorreo.Location = new Point(67, 290);
            txtboxCorreo.Name = "txtboxCorreo";
            txtboxCorreo.Size = new Size(314, 22);
            txtboxCorreo.TabIndex = 2;
            // 
            // txtBoxClave
            // 
            txtBoxClave.BackColor = Color.CornflowerBlue;
            txtBoxClave.BorderStyle = BorderStyle.None;
            txtBoxClave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxClave.Location = new Point(67, 397);
            txtBoxClave.Name = "txtBoxClave";
            txtBoxClave.PasswordChar = '●';
            txtBoxClave.Size = new Size(314, 22);
            txtBoxClave.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RoyalBlue;
            pictureBox1.Location = new Point(57, 319);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(324, 2);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.RoyalBlue;
            pictureBox2.Location = new Point(57, 425);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(324, 2);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(57, 516);
            button1.Name = "button1";
            button1.Size = new Size(324, 36);
            button1.TabIndex = 7;
            button1.Text = "Iniciar Sesion";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(401, 12);
            button2.Name = "button2";
            button2.Size = new Size(22, 24);
            button2.TabIndex = 9;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = App.Properties.Resources.Diseño_sin_título__9_;
            pictureBox3.Location = new Point(150, 78);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(135, 132);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // progresBarLogin
            // 
            progresBarLogin.Location = new Point(57, 593);
            progresBarLogin.Name = "progresBarLogin";
            progresBarLogin.Size = new Size(324, 26);
            progresBarLogin.TabIndex = 11;
            // 
            // lblProgressBar
            // 
            lblProgressBar.AutoSize = true;
            lblProgressBar.Location = new Point(55, 575);
            lblProgressBar.Name = "lblProgressBar";
            lblProgressBar.Size = new Size(68, 15);
            lblProgressBar.TabIndex = 12;
            lblProgressBar.Text = "Cargando...";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(435, 631);
            Controls.Add(lblProgressBar);
            Controls.Add(progresBarLogin);
            Controls.Add(pictureBox3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(txtBoxClave);
            Controls.Add(txtboxCorreo);
            Controls.Add(lblContrasenia);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Label lblContrasenia;
        private TextBox txtboxCorreo;
        private TextBox txtBoxClave;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox3;
        private ProgressBar progresBarLogin;
        private Label lblProgressBar;
    }
}