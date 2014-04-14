namespace CompararArchivos
{
    partial class frmConsola
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbxArchivos = new System.Windows.Forms.GroupBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.lblCarpeta2 = new System.Windows.Forms.Label();
            this.btnCarpeta2 = new System.Windows.Forms.Button();
            this.tbxCarpeta2 = new System.Windows.Forms.TextBox();
            this.lblCarpeta1 = new System.Windows.Forms.Label();
            this.btnCarpeta1 = new System.Windows.Forms.Button();
            this.tbxCarpeta1 = new System.Windows.Forms.TextBox();
            this.fbrDialogoCarpetas = new System.Windows.Forms.FolderBrowserDialog();
            this.tbxConsola = new System.Windows.Forms.TextBox();
            this.gbxArchivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(397, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(316, 327);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // gbxArchivos
            // 
            this.gbxArchivos.Controls.Add(this.tbxConsola);
            this.gbxArchivos.Controls.Add(this.btnComparar);
            this.gbxArchivos.Controls.Add(this.lblCarpeta2);
            this.gbxArchivos.Controls.Add(this.btnCarpeta2);
            this.gbxArchivos.Controls.Add(this.tbxCarpeta2);
            this.gbxArchivos.Controls.Add(this.lblCarpeta1);
            this.gbxArchivos.Controls.Add(this.btnCarpeta1);
            this.gbxArchivos.Controls.Add(this.tbxCarpeta1);
            this.gbxArchivos.Location = new System.Drawing.Point(12, 12);
            this.gbxArchivos.Name = "gbxArchivos";
            this.gbxArchivos.Size = new System.Drawing.Size(460, 309);
            this.gbxArchivos.TabIndex = 2;
            this.gbxArchivos.TabStop = false;
            this.gbxArchivos.Text = "Archivos";
            // 
            // btnComparar
            // 
            this.btnComparar.Location = new System.Drawing.Point(379, 74);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(75, 23);
            this.btnComparar.TabIndex = 6;
            this.btnComparar.Text = "Com&parar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // lblCarpeta2
            // 
            this.lblCarpeta2.AutoSize = true;
            this.lblCarpeta2.Location = new System.Drawing.Point(6, 51);
            this.lblCarpeta2.Name = "lblCarpeta2";
            this.lblCarpeta2.Size = new System.Drawing.Size(56, 13);
            this.lblCarpeta2.TabIndex = 5;
            this.lblCarpeta2.Text = "Carpeta 2:";
            // 
            // btnCarpeta2
            // 
            this.btnCarpeta2.Location = new System.Drawing.Point(429, 45);
            this.btnCarpeta2.Name = "btnCarpeta2";
            this.btnCarpeta2.Size = new System.Drawing.Size(25, 23);
            this.btnCarpeta2.TabIndex = 4;
            this.btnCarpeta2.Text = "...";
            this.btnCarpeta2.UseVisualStyleBackColor = true;
            this.btnCarpeta2.Click += new System.EventHandler(this.btnCarpeta2_Click);
            // 
            // tbxCarpeta2
            // 
            this.tbxCarpeta2.Location = new System.Drawing.Point(73, 48);
            this.tbxCarpeta2.Name = "tbxCarpeta2";
            this.tbxCarpeta2.Size = new System.Drawing.Size(350, 20);
            this.tbxCarpeta2.TabIndex = 3;
            // 
            // lblCarpeta1
            // 
            this.lblCarpeta1.AutoSize = true;
            this.lblCarpeta1.Location = new System.Drawing.Point(6, 25);
            this.lblCarpeta1.Name = "lblCarpeta1";
            this.lblCarpeta1.Size = new System.Drawing.Size(56, 13);
            this.lblCarpeta1.TabIndex = 2;
            this.lblCarpeta1.Text = "Carpeta 1:";
            // 
            // btnCarpeta1
            // 
            this.btnCarpeta1.Location = new System.Drawing.Point(429, 19);
            this.btnCarpeta1.Name = "btnCarpeta1";
            this.btnCarpeta1.Size = new System.Drawing.Size(25, 23);
            this.btnCarpeta1.TabIndex = 1;
            this.btnCarpeta1.Text = "...";
            this.btnCarpeta1.UseVisualStyleBackColor = true;
            this.btnCarpeta1.Click += new System.EventHandler(this.btnCarpeta1_Click);
            // 
            // tbxCarpeta1
            // 
            this.tbxCarpeta1.Location = new System.Drawing.Point(73, 22);
            this.tbxCarpeta1.Name = "tbxCarpeta1";
            this.tbxCarpeta1.Size = new System.Drawing.Size(350, 20);
            this.tbxCarpeta1.TabIndex = 0;
            // 
            // tbxConsola
            // 
            this.tbxConsola.Location = new System.Drawing.Point(6, 103);
            this.tbxConsola.Multiline = true;
            this.tbxConsola.Name = "tbxConsola";
            this.tbxConsola.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxConsola.Size = new System.Drawing.Size(448, 200);
            this.tbxConsola.TabIndex = 7;
            this.tbxConsola.WordWrap = false;
            // 
            // frmConsola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.gbxArchivos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmConsola";
            this.Text = "Comparar Archivos";
            this.gbxArchivos.ResumeLayout(false);
            this.gbxArchivos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbxArchivos;
        private System.Windows.Forms.TextBox tbxCarpeta1;
        private System.Windows.Forms.FolderBrowserDialog fbrDialogoCarpetas;
        private System.Windows.Forms.Label lblCarpeta1;
        private System.Windows.Forms.Button btnCarpeta1;
        private System.Windows.Forms.Label lblCarpeta2;
        private System.Windows.Forms.Button btnCarpeta2;
        private System.Windows.Forms.TextBox tbxCarpeta2;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.TextBox tbxConsola;
    }
}

