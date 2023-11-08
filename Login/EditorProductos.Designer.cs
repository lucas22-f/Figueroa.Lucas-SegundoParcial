namespace App
{
    partial class EditorProductos
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
            dataGridProductos = new DataGridView();
            btnAgregarListProd = new Button();
            btnEditarP = new Button();
            btnEliminarProd = new Button();
            txtNombre = new TextBox();
            txtCantidad = new TextBox();
            txtDescripcion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDescripcionEdit = new TextBox();
            txtCantidadEdit = new TextBox();
            txtNombreEdit = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).BeginInit();
            SuspendLayout();
            // 
            // dataGridProductos
            // 
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductos.Location = new Point(21, 41);
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.RowTemplate.Height = 25;
            dataGridProductos.Size = new Size(767, 280);
            dataGridProductos.TabIndex = 0;
            // 
            // btnAgregarListProd
            // 
            btnAgregarListProd.Location = new Point(21, 498);
            btnAgregarListProd.Name = "btnAgregarListProd";
            btnAgregarListProd.Size = new Size(105, 44);
            btnAgregarListProd.TabIndex = 1;
            btnAgregarListProd.Text = "Agregar";
            btnAgregarListProd.UseVisualStyleBackColor = true;
            btnAgregarListProd.Click += btnAgregarListProd_Click;
            // 
            // btnEditarP
            // 
            btnEditarP.Location = new Point(332, 498);
            btnEditarP.Name = "btnEditarP";
            btnEditarP.Size = new Size(105, 44);
            btnEditarP.TabIndex = 2;
            btnEditarP.Text = "Editar";
            btnEditarP.UseVisualStyleBackColor = true;
            btnEditarP.Click += btnEditarP_Click;
            // 
            // btnEliminarProd
            // 
            btnEliminarProd.Location = new Point(643, 427);
            btnEliminarProd.Name = "btnEliminarProd";
            btnEliminarProd.Size = new Size(105, 44);
            btnEliminarProd.TabIndex = 3;
            btnEliminarProd.Text = "Eliminar Lista ";
            btnEliminarProd.UseVisualStyleBackColor = true;
            btnEliminarProd.Click += btnEliminarProd_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(21, 370);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(21, 414);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(125, 23);
            txtCantidad.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(21, 460);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 23);
            txtDescripcion.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 352);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 7;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 396);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 8;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 442);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 9;
            label3.Text = "Descripcion";
            // 
            // txtDescripcionEdit
            // 
            txtDescripcionEdit.Location = new Point(332, 460);
            txtDescripcionEdit.Name = "txtDescripcionEdit";
            txtDescripcionEdit.Size = new Size(146, 23);
            txtDescripcionEdit.TabIndex = 12;
            // 
            // txtCantidadEdit
            // 
            txtCantidadEdit.Location = new Point(332, 414);
            txtCantidadEdit.Name = "txtCantidadEdit";
            txtCantidadEdit.Size = new Size(146, 23);
            txtCantidadEdit.TabIndex = 11;
            // 
            // txtNombreEdit
            // 
            txtNombreEdit.Location = new Point(332, 370);
            txtNombreEdit.Name = "txtNombreEdit";
            txtNombreEdit.Size = new Size(146, 23);
            txtNombreEdit.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 442);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 15;
            label4.Text = "Descripcion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(332, 396);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 14;
            label5.Text = "Cantidad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(332, 352);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 13;
            label6.Text = "Nombre";
            // 
            // EditorProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 563);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtDescripcionEdit);
            Controls.Add(txtCantidadEdit);
            Controls.Add(txtNombreEdit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCantidad);
            Controls.Add(txtNombre);
            Controls.Add(btnEliminarProd);
            Controls.Add(btnEditarP);
            Controls.Add(btnAgregarListProd);
            Controls.Add(dataGridProductos);
            Name = "EditorProductos";
            Text = "EditorProductos";
            ((System.ComponentModel.ISupportInitialize)dataGridProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProductos;
        private Button btnAgregarListProd;
        private Button btnEditarP;
        private Button btnEliminarProd;
        private TextBox txtNombre;
        private TextBox txtCantidad;
        private TextBox txtDescripcion;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDescripcionEdit;
        private TextBox txtCantidadEdit;
        private TextBox txtNombreEdit;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}