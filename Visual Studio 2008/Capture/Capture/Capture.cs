using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Capture
{
    public partial class Capture : Form
    {
        private int Count;

        private bool init = false;

        private ContextMenu ContextMenuCapture = new ContextMenu();

        private IntPtr _ClipboardViewerNext;

        public Capture()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(Capture_SizeChanged);
            this.ContextMenuCapture.MenuItems.Add("&Restore", new EventHandler(this.Restore));
            this.ContextMenuCapture.MenuItems.Add("&Salir", new EventHandler(this.Exit));
            this.notifyIconCapture.ContextMenu = ContextMenuCapture;
        }

        private void RegisterClipboardViewer()
        {
            _ClipboardViewerNext = User32.SetClipboardViewer(this.Handle);
        }

        /// <summary>
        /// Remove this form from the Clipboard Viewer list
        /// </summary>
        private void UnregisterClipboardViewer()
        {
            User32.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
        }

        protected override void WndProc(ref Message m)
        {
            switch ((Msgs)m.Msg)
            {
                case Msgs.WM_DRAWCLIPBOARD:
                    this.validImage();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void saveImage()
        {
            Microsoft.VisualBasic.Devices.Computer My = new Microsoft.VisualBasic.Devices.Computer();
            if (My.Clipboard.ContainsImage())
                My.Clipboard.GetImage().Save(GetImagePath(), ImageFormat.Jpeg);
           
        }

        private string GetImagePath()
        {
            return this.GetDirectoryPath() + this.GetImageNumber();
        }

        private string GetDirectoryPath()
        {
            string directoryPath = string.Empty;

            if (this.txtDirectorio.Text == string.Empty)
                directoryPath = SettingsConfiguration.Default.Path;
            else
                directoryPath = this.txtDirectorio.Text;

            directoryPath.TrimEnd('\\');

            directoryPath += "\\" + this.txtCapture.Text + "\\";

            return directoryPath;
        }

        private string GetImageNumber()
        {
            do
            {
                this.Count++;
            }
            while (this.Exists());

            return this.Count.ToString() + ". " + this.txtCapture.Text + ".jpg";
        }

        private bool Exists()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(this.GetDirectoryPath());

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            return File.Exists(this.GetDirectoryPath() + "\\" + this.Count.ToString() + ". " + this.txtCapture.Text + ".jpg");
        }

        private void validImage()
        {
            Microsoft.VisualBasic.Devices.Computer My = new Microsoft.VisualBasic.Devices.Computer();
            if (My.Clipboard.ContainsImage() && this.init)
            {
                if (string.IsNullOrEmpty(this.txtCapture.Text) || this.txtCapture.Text.Contains(" "))
                    MessageBox.Show("No olvide colocar el caso correctamente", "Error", MessageBoxButtons.OK);
                else
                    this.saveImage();
            }
            this.init = true;
        }

        #region Events

        private void Restore(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarCapture_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = (double)this.trackBarCapture.Value / 100;
        }

        private void Capture_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void txtCapture_TextChanged(object sender, EventArgs e)
        {
            this.Count = 0;
        }

        private void Capture_Load(object sender, EventArgs e)
        {
            RegisterClipboardViewer();
            SettingsConfiguration.Default.Reload();
            this.txtDirectorio.Text = SettingsConfiguration.Default.Directorio;
            this.txtCapture.Text = SettingsConfiguration.Default.Nombre;
        }

        private void Capture_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterClipboardViewer();
            SettingsConfiguration.Default.Directorio = this.txtDirectorio.Text;
            SettingsConfiguration.Default.Nombre = this.txtCapture.Text;
            SettingsConfiguration.Default.Save();
        }

        private void btnAbrirDirectorio_Click(object sender, EventArgs e)
        {
            fbdDialogoDirectorio.SelectedPath = this.txtDirectorio.Text;

            if (fbdDialogoDirectorio.ShowDialog() == DialogResult.OK)
            {
                this.txtDirectorio.Text = fbdDialogoDirectorio.SelectedPath;
            }
        }

        private void notifyIconCapture_DoubleClick(object sender, EventArgs e)
        {
            this.Restore(null, null);
        }

        #endregion
    }
}
