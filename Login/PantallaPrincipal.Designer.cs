namespace App
{
    partial class PantallaPrincipal
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
            pictureBox1 = new PictureBox();
            btnPedidos = new Button();
            btnVendedores = new Button();
            btnClientes = new Button();
            btnTransportistas = new Button();
            lblNombre = new Label();
            lblCorreo = new Label();
            lblPerfil = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnExit = new Button();
            imgHome = new PictureBox();
            btnCrear = new Button();
            lblControl = new Label();
            btnEditar = new Button();
            btnEliminar = new Button();
            imgPanel = new PictureBox();
            btnHome = new Button();
            lblPanel = new Label();
            lstBoxVisor = new ListBox();
            lblInfolstBox = new Label();
            label4 = new Label();
            lblFecha = new Label();
            btnOrdenar = new Button();
            btnOrdenarDesc = new Button();
            btnReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MidnightBlue;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 731);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnPedidos
            // 
            btnPedidos.BackColor = Color.Peru;
            btnPedidos.FlatAppearance.BorderSize = 0;
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.ForeColor = SystemColors.ButtonHighlight;
            btnPedidos.Location = new Point(33, 50);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(153, 54);
            btnPedidos.TabIndex = 1;
            btnPedidos.Text = "Crear Pedido";
            btnPedidos.UseVisualStyleBackColor = false;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnVendedores
            // 
            btnVendedores.BackColor = Color.RoyalBlue;
            btnVendedores.FlatAppearance.BorderSize = 0;
            btnVendedores.FlatStyle = FlatStyle.Flat;
            btnVendedores.ForeColor = SystemColors.ButtonHighlight;
            btnVendedores.Location = new Point(33, 213);
            btnVendedores.Name = "btnVendedores";
            btnVendedores.Size = new Size(153, 54);
            btnVendedores.TabIndex = 2;
            btnVendedores.Text = "Vendedores";
            btnVendedores.UseVisualStyleBackColor = false;
            btnVendedores.Click += btnVendedores_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.RoyalBlue;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.ForeColor = SystemColors.ButtonHighlight;
            btnClientes.Location = new Point(33, 386);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(153, 54);
            btnClientes.TabIndex = 3;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnTransportistas
            // 
            btnTransportistas.BackColor = Color.RoyalBlue;
            btnTransportistas.FlatAppearance.BorderSize = 0;
            btnTransportistas.FlatStyle = FlatStyle.Flat;
            btnTransportistas.ForeColor = SystemColors.ButtonHighlight;
            btnTransportistas.Location = new Point(33, 551);
            btnTransportistas.Name = "btnTransportistas";
            btnTransportistas.Size = new Size(153, 54);
            btnTransportistas.TabIndex = 4;
            btnTransportistas.Text = "Transportistas";
            btnTransportistas.UseVisualStyleBackColor = false;
            btnTransportistas.Click += btnTransportes_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.MidnightBlue;
            lblNombre.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.ForeColor = SystemColors.ButtonHighlight;
            lblNombre.Location = new Point(305, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(46, 17);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "label1";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.BackColor = Color.MidnightBlue;
            lblCorreo.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblCorreo.ForeColor = SystemColors.ButtonHighlight;
            lblCorreo.Location = new Point(529, 9);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(46, 17);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "label2";
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.BackColor = Color.MidnightBlue;
            lblPerfil.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblPerfil.ForeColor = SystemColors.ButtonHighlight;
            lblPerfil.Location = new Point(815, 9);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(46, 17);
            lblPerfil.TabIndex = 7;
            lblPerfil.Text = "label3";
            lblPerfil.Click += lblPerfil_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MidnightBlue;
            label1.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(245, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 8;
            label1.Text = "Nombre :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MidnightBlue;
            label2.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(474, 9);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 9;
            label2.Text = "Correo :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.MidnightBlue;
            label3.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(769, 9);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 10;
            label3.Text = "Perfil :";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.MidnightBlue;
            pictureBox2.Location = new Point(214, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1040, 50);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Historic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.Location = new Point(1160, 8);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(22, 20);
            btnExit.TabIndex = 12;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // imgHome
            // 
            imgHome.Image = Properties.Resources.Diseño_sin_título__9_;
            imgHome.Location = new Point(560, 224);
            imgHome.Name = "imgHome";
            imgHome.Size = new Size(256, 252);
            imgHome.SizeMode = PictureBoxSizeMode.StretchImage;
            imgHome.TabIndex = 13;
            imgHome.TabStop = false;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.MediumAquamarine;
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCrear.Location = new Point(1057, 175);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(116, 54);
            btnCrear.TabIndex = 15;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Visible = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // lblControl
            // 
            lblControl.AutoSize = true;
            lblControl.Font = new Font("Tw Cen MT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblControl.Location = new Point(1067, 105);
            lblControl.Name = "lblControl";
            lblControl.Size = new Size(92, 31);
            lblControl.TabIndex = 16;
            lblControl.Text = "Control";
            lblControl.Visible = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.PaleGoldenrod;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Location = new Point(1057, 272);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(116, 54);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Visible = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.LightCoral;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.Location = new Point(1057, 369);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 54);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // imgPanel
            // 
            imgPanel.Image = Properties.Resources.Diseño_sin_título__9_;
            imgPanel.Location = new Point(245, 55);
            imgPanel.Name = "imgPanel";
            imgPanel.Size = new Size(106, 105);
            imgPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPanel.TabIndex = 19;
            imgPanel.TabStop = false;
            imgPanel.Visible = false;
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Tw Cen MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnHome.ForeColor = SystemColors.ActiveCaptionText;
            btnHome.Location = new Point(1036, 8);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(60, 35);
            btnHome.TabIndex = 20;
            btnHome.Text = "inicio";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // lblPanel
            // 
            lblPanel.AutoSize = true;
            lblPanel.Font = new Font("Tw Cen MT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblPanel.Location = new Point(378, 105);
            lblPanel.Name = "lblPanel";
            lblPanel.Size = new Size(92, 31);
            lblPanel.TabIndex = 21;
            lblPanel.Text = "Control";
            lblPanel.Visible = false;
            // 
            // lstBoxVisor
            // 
            lstBoxVisor.FormattingEnabled = true;
            lstBoxVisor.ItemHeight = 15;
            lstBoxVisor.Location = new Point(245, 166);
            lstBoxVisor.Name = "lstBoxVisor";
            lstBoxVisor.Size = new Size(787, 439);
            lstBoxVisor.TabIndex = 14;
            lstBoxVisor.Visible = false;
            lstBoxVisor.DoubleClick += lstBoxVisor_DoubleClick;
            // 
            // lblInfolstBox
            // 
            lblInfolstBox.AutoSize = true;
            lblInfolstBox.Location = new Point(247, 612);
            lblInfolstBox.Name = "lblInfolstBox";
            lblInfolstBox.Size = new Size(222, 15);
            lblInfolstBox.TabIndex = 22;
            lblInfolstBox.Text = "* Doble click en el dato para ver mas info";
            lblInfolstBox.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.MidnightBlue;
            label4.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(12, 11);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 23;
            label4.Text = "Fecha";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.MidnightBlue;
            lblFecha.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.ForeColor = SystemColors.ButtonHighlight;
            lblFecha.Location = new Point(73, 11);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(46, 17);
            lblFecha.TabIndex = 24;
            lblFecha.Text = "label1";
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(829, 137);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(88, 23);
            btnOrdenar.TabIndex = 25;
            btnOrdenar.Text = "Ordenar asc";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnOrdenarDesc
            // 
            btnOrdenarDesc.Location = new Point(942, 137);
            btnOrdenarDesc.Name = "btnOrdenarDesc";
            btnOrdenarDesc.Size = new Size(90, 23);
            btnOrdenarDesc.TabIndex = 26;
            btnOrdenarDesc.Text = "Ordenar Desc";
            btnOrdenarDesc.UseVisualStyleBackColor = true;
            btnOrdenarDesc.Click += btnOrdenarDesc_Click;
            // 
            // btnReporte
            // 
            btnReporte.Location = new Point(1057, 539);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(115, 66);
            btnReporte.TabIndex = 27;
            btnReporte.Text = "Guardar Reporte General";
            btnReporte.UseVisualStyleBackColor = true;
            btnReporte.Click += btnReporte_Click;
            // 
            // PantallaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(1194, 651);
            Controls.Add(btnReporte);
            Controls.Add(btnOrdenarDesc);
            Controls.Add(btnOrdenar);
            Controls.Add(lblFecha);
            Controls.Add(label4);
            Controls.Add(lblInfolstBox);
            Controls.Add(lblPanel);
            Controls.Add(btnHome);
            Controls.Add(imgPanel);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(lblControl);
            Controls.Add(btnCrear);
            Controls.Add(imgHome);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPerfil);
            Controls.Add(lblCorreo);
            Controls.Add(lblNombre);
            Controls.Add(btnTransportistas);
            Controls.Add(btnClientes);
            Controls.Add(btnVendedores);
            Controls.Add(btnPedidos);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(lstBoxVisor);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PantallaPrincipal";
            Text = "PantallaPrincipal";
            FormClosed += PantallaPrincipal_FormClosed;
            Load += PantallaPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnPedidos;
        private Button btnVendedores;
        private Button btnClientes;
        private Button btnTransportistas;
        private Label lblNombre;
        private Label lblCorreo;
        private Label lblPerfil;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Button btnExit;
        private PictureBox imgHome;
        private Button btnCrear;
        private Label lblControl;
        private Button btnEditar;
        private Button btnEliminar;
        private PictureBox imgPanel;
        private Button btnHome;
        private Label lblPanel;
        private ListBox lstBoxVisor;
        private Label lblInfolstBox;
        private Label label4;
        private Label lblFecha;
        private Button btnOrdenar;
        private Button btnOrdenarDesc;
        private Button btnReporte;
    }
}