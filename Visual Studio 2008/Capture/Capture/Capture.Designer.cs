namespace Capture
{
    partial class Capture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Capture));
            this.notifyIconCapture = new System.Windows.Forms.NotifyIcon(this.components);
            this.trackBarCapture = new System.Windows.Forms.TrackBar();
            this.txtCapture = new System.Windows.Forms.TextBox();
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.gbxRuta = new System.Windows.Forms.GroupBox();
            this.btnAbrirDirectorio = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDirectorio = new System.Windows.Forms.Label();
            this.gbxOpacidad = new System.Windows.Forms.GroupBox();
            this.fbdDialogoDirectorio = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCapture)).BeginInit();
            this.gbxRuta.SuspendLayout();
            this.gbxOpacidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconCapture
            // 
            this.notifyIconCapture.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconCapture.BalloonTipText = "Capture";
            this.notifyIconCapture.BalloonTipTitle = "Capture";
            this.notifyIconCapture.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconCapture.Icon")));
            this.notifyIconCapture.Text = "notifyIconCapture";
            this.notifyIconCapture.Visible = true;
            this.notifyIconCapture.DoubleClick += new System.EventHandler(this.notifyIconCapture_DoubleClick);
            // 
            // trackBarCapture
            // 
            this.trackBarCapture.LargeChange = 10;
            this.trackBarCapture.Location = new System.Drawing.Point(6, 20);
            this.trackBarCapture.Maximum = 100;
            this.trackBarCapture.Name = "trackBarCapture";
            this.trackBarCapture.Size = new System.Drawing.Size(456, 45);
            this.trackBarCapture.SmallChange = 10;
            this.trackBarCapture.TabIndex = 0;
            this.trackBarCapture.TickFrequency = 10;
            this.trackBarCapture.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarCapture.Value = 100;
            this.trackBarCapture.ValueChanged += new System.EventHandler(this.trackBarCapture_ValueChanged);
            // 
            // txtCapture
            // 
            this.txtCapture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapture.Location = new System.Drawing.Point(75, 47);
            this.txtCapture.Name = "txtCapture";
            this.txtCapture.Size = new System.Drawing.Size(387, 21);
            this.txtCapture.TabIndex = 4;
            this.txtCapture.TextChanged += new System.EventHandler(this.txtCapture_TextChanged);
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectorio.Location = new System.Drawing.Point(75, 20);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(365, 21);
            this.txtDirectorio.TabIndex = 1;
            // 
            // gbxRuta
            // 
            this.gbxRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRuta.Controls.Add(this.btnAbrirDirectorio);
            this.gbxRuta.Controls.Add(this.lblNombre);
            this.gbxRuta.Controls.Add(this.txtCapture);
            this.gbxRuta.Controls.Add(this.txtDirectorio);
            this.gbxRuta.Controls.Add(this.lblDirectorio);
            this.gbxRuta.Location = new System.Drawing.Point(12, 12);
            this.gbxRuta.Name = "gbxRuta";
            this.gbxRuta.Size = new System.Drawing.Size(468, 87);
            this.gbxRuta.TabIndex = 0;
            this.gbxRuta.TabStop = false;
            this.gbxRuta.Text = "Ruta de Archivo";
            // 
            // btnAbrirDirectorio
            // 
            this.btnAbrirDirectorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirDirectorio.Location = new System.Drawing.Point(438, 19);
            this.btnAbrirDirectorio.Name = "btnAbrirDirectorio";
            this.btnAbrirDirectorio.Size = new System.Drawing.Size(24, 23);
            this.btnAbrirDirectorio.TabIndex = 2;
            this.btnAbrirDirectorio.Text = "...";
            this.btnAbrirDirectorio.UseVisualStyleBackColor = true;
            this.btnAbrirDirectorio.Click += new System.EventHandler(this.btnAbrirDirectorio_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDirectorio
            // 
            this.lblDirectorio.AutoSize = true;
            this.lblDirectorio.Location = new System.Drawing.Point(6, 23);
            this.lblDirectorio.Name = "lblDirectorio";
            this.lblDirectorio.Size = new System.Drawing.Size(63, 15);
            this.lblDirectorio.TabIndex = 0;
            this.lblDirectorio.Text = "Directorio:";
            // 
            // gbxOpacidad
            // 
            this.gbxOpacidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOpacidad.Controls.Add(this.trackBarCapture);
            this.gbxOpacidad.Location = new System.Drawing.Point(12, 105);
            this.gbxOpacidad.Name = "gbxOpacidad";
            this.gbxOpacidad.Size = new System.Drawing.Size(468, 78);
            this.gbxOpacidad.TabIndex = 1;
            this.gbxOpacidad.TabStop = false;
            this.gbxOpacidad.Text = "Opacidad";
            // 
            // Capture
            // 
            this.AcceptButton = this.btnAbrirDirectorio;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(492, 197);
            this.Controls.Add(this.gbxOpacidad);
            this.Controls.Add(this.gbxRuta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "Capture";
            this.Text = "Capture";
            this.Load += new System.EventHandler(this.Capture_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Capture_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCapture)).EndInit();
            this.gbxRuta.ResumeLayout(false);
            this.gbxRuta.PerformLayout();
            this.gbxOpacidad.ResumeLayout(false);
            this.gbxOpacidad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconCapture;
        private System.Windows.Forms.TrackBar trackBarCapture;
        private System.Windows.Forms.TextBox txtCapture;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.GroupBox gbxRuta;
        private System.Windows.Forms.Label lblDirectorio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbxOpacidad;
        private System.Windows.Forms.Button btnAbrirDirectorio;
        private System.Windows.Forms.FolderBrowserDialog fbdDialogoDirectorio;
    }
}

