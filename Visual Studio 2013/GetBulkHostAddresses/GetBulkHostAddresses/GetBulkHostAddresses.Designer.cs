namespace GetBulkHostAddresses
{
    partial class GetBulkHostAddresses
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
            this.RutasArchivo = new System.Windows.Forms.GroupBox();
            this.BotonGuardarArchivoDirecciones = new System.Windows.Forms.Button();
            this.RutaArchivoDirecciones = new System.Windows.Forms.TextBox();
            this.EtiquetaRutaArchivoDirecciones = new System.Windows.Forms.Label();
            this.BotonAbrirArchivoDominios = new System.Windows.Forms.Button();
            this.EtiquetaRutaArchivoDominios = new System.Windows.Forms.Label();
            this.RutaArchivoDominios = new System.Windows.Forms.TextBox();
            this.BotonObtenerDirecciones = new System.Windows.Forms.Button();
            this.AbrirArchivoDominios = new System.Windows.Forms.OpenFileDialog();
            this.GuardarArchivoDirecciones = new System.Windows.Forms.SaveFileDialog();
            this.RutasArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // RutasArchivo
            // 
            this.RutasArchivo.Controls.Add(this.BotonGuardarArchivoDirecciones);
            this.RutasArchivo.Controls.Add(this.RutaArchivoDirecciones);
            this.RutasArchivo.Controls.Add(this.EtiquetaRutaArchivoDirecciones);
            this.RutasArchivo.Controls.Add(this.BotonAbrirArchivoDominios);
            this.RutasArchivo.Controls.Add(this.EtiquetaRutaArchivoDominios);
            this.RutasArchivo.Controls.Add(this.RutaArchivoDominios);
            this.RutasArchivo.Location = new System.Drawing.Point(3, 12);
            this.RutasArchivo.Name = "RutasArchivo";
            this.RutasArchivo.Size = new System.Drawing.Size(486, 87);
            this.RutasArchivo.TabIndex = 0;
            this.RutasArchivo.TabStop = false;
            this.RutasArchivo.Text = "Rutas de Archivos";
            // 
            // BotonGuardarArchivoDirecciones
            // 
            this.BotonGuardarArchivoDirecciones.Location = new System.Drawing.Point(452, 48);
            this.BotonGuardarArchivoDirecciones.Name = "BotonGuardarArchivoDirecciones";
            this.BotonGuardarArchivoDirecciones.Size = new System.Drawing.Size(28, 23);
            this.BotonGuardarArchivoDirecciones.TabIndex = 5;
            this.BotonGuardarArchivoDirecciones.Text = "...";
            this.BotonGuardarArchivoDirecciones.UseVisualStyleBackColor = true;
            this.BotonGuardarArchivoDirecciones.Click += new System.EventHandler(this.BotonGuardarArchivoDirecciones_Click);
            // 
            // RutaArchivoDirecciones
            // 
            this.RutaArchivoDirecciones.Enabled = false;
            this.RutaArchivoDirecciones.Location = new System.Drawing.Point(159, 45);
            this.RutaArchivoDirecciones.Name = "RutaArchivoDirecciones";
            this.RutaArchivoDirecciones.Size = new System.Drawing.Size(287, 20);
            this.RutaArchivoDirecciones.TabIndex = 4;
            // 
            // EtiquetaRutaArchivoDirecciones
            // 
            this.EtiquetaRutaArchivoDirecciones.AutoSize = true;
            this.EtiquetaRutaArchivoDirecciones.Location = new System.Drawing.Point(9, 48);
            this.EtiquetaRutaArchivoDirecciones.Name = "EtiquetaRutaArchivoDirecciones";
            this.EtiquetaRutaArchivoDirecciones.Size = new System.Drawing.Size(144, 13);
            this.EtiquetaRutaArchivoDirecciones.TabIndex = 3;
            this.EtiquetaRutaArchivoDirecciones.Text = "Ruta Archivo Direcciones IP:";
            // 
            // BotonAbrirArchivoDominios
            // 
            this.BotonAbrirArchivoDominios.Location = new System.Drawing.Point(452, 19);
            this.BotonAbrirArchivoDominios.Name = "BotonAbrirArchivoDominios";
            this.BotonAbrirArchivoDominios.Size = new System.Drawing.Size(28, 23);
            this.BotonAbrirArchivoDominios.TabIndex = 2;
            this.BotonAbrirArchivoDominios.Text = "...";
            this.BotonAbrirArchivoDominios.UseVisualStyleBackColor = true;
            this.BotonAbrirArchivoDominios.Click += new System.EventHandler(this.BotonAbrirArchivoDominios_Click);
            // 
            // EtiquetaRutaArchivoDominios
            // 
            this.EtiquetaRutaArchivoDominios.AutoSize = true;
            this.EtiquetaRutaArchivoDominios.Location = new System.Drawing.Point(35, 22);
            this.EtiquetaRutaArchivoDominios.Name = "EtiquetaRutaArchivoDominios";
            this.EtiquetaRutaArchivoDominios.Size = new System.Drawing.Size(118, 13);
            this.EtiquetaRutaArchivoDominios.TabIndex = 1;
            this.EtiquetaRutaArchivoDominios.Text = "Ruta Archivo Dominios:";
            // 
            // RutaArchivoDominios
            // 
            this.RutaArchivoDominios.Enabled = false;
            this.RutaArchivoDominios.Location = new System.Drawing.Point(159, 19);
            this.RutaArchivoDominios.Name = "RutaArchivoDominios";
            this.RutaArchivoDominios.Size = new System.Drawing.Size(287, 20);
            this.RutaArchivoDominios.TabIndex = 0;
            // 
            // BotonObtenerDirecciones
            // 
            this.BotonObtenerDirecciones.Location = new System.Drawing.Point(414, 105);
            this.BotonObtenerDirecciones.Name = "BotonObtenerDirecciones";
            this.BotonObtenerDirecciones.Size = new System.Drawing.Size(75, 23);
            this.BotonObtenerDirecciones.TabIndex = 1;
            this.BotonObtenerDirecciones.Text = "Obtener";
            this.BotonObtenerDirecciones.UseVisualStyleBackColor = true;
            this.BotonObtenerDirecciones.Click += new System.EventHandler(this.BotonObtenerDirecciones_Click);
            // 
            // AbrirArchivoDominios
            // 
            this.AbrirArchivoDominios.DefaultExt = "*.txt";
            this.AbrirArchivoDominios.FileName = "Archivo Dominios.txt";
            this.AbrirArchivoDominios.Filter = "Archivo de Texto|*.txt";
            this.AbrirArchivoDominios.Title = "Archivo de Dominios";
            // 
            // GuardarArchivoDirecciones
            // 
            this.GuardarArchivoDirecciones.DefaultExt = "*.txt";
            this.GuardarArchivoDirecciones.Filter = "Archivo de Texto|*.txt";
            this.GuardarArchivoDirecciones.Title = "Archivo de Direcciones";
            // 
            // GetBulkHostAddresses
            // 
            this.AcceptButton = this.BotonObtenerDirecciones;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 141);
            this.Controls.Add(this.BotonObtenerDirecciones);
            this.Controls.Add(this.RutasArchivo);
            this.MaximizeBox = false;
            this.Name = "GetBulkHostAddresses";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Obtener Direcciones IP";
            this.Load += new System.EventHandler(this.GetBulkHostAddresses_Load);
            this.RutasArchivo.ResumeLayout(false);
            this.RutasArchivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RutasArchivo;
        private System.Windows.Forms.Button BotonAbrirArchivoDominios;
        private System.Windows.Forms.Label EtiquetaRutaArchivoDominios;
        private System.Windows.Forms.TextBox RutaArchivoDominios;
        private System.Windows.Forms.Button BotonGuardarArchivoDirecciones;
        private System.Windows.Forms.TextBox RutaArchivoDirecciones;
        private System.Windows.Forms.Label EtiquetaRutaArchivoDirecciones;
        private System.Windows.Forms.Button BotonObtenerDirecciones;
        private System.Windows.Forms.OpenFileDialog AbrirArchivoDominios;
        private System.Windows.Forms.SaveFileDialog GuardarArchivoDirecciones;
    }
}