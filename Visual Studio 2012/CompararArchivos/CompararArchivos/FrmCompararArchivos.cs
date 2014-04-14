using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompararArchivos
{
    public partial class frmConsola : Form
    {
        public frmConsola()
        {
            InitializeComponent();
        }

        private Carpeta AsignarCarpeta1()
        {
            if (!string.IsNullOrWhiteSpace(tbxCarpeta1.Text))
            {
                if (Directory.Exists(tbxCarpeta1.Text))
                {
                    DirectoryInfo directoryInfo1 = new DirectoryInfo(tbxCarpeta1.Text);

                    return new Carpeta(directoryInfo1);
                }
            }

            return null;
        }

        private Carpeta AsignarCarpeta2()
        {
            if (!string.IsNullOrWhiteSpace(tbxCarpeta2.Text))
            {
                if (Directory.Exists(tbxCarpeta2.Text))
                {
                    DirectoryInfo directoryInfo2 = new DirectoryInfo(tbxCarpeta2.Text);

                    return new Carpeta(directoryInfo2);
                }
            }

            return null;
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            Carpeta carpeta1 = this.AsignarCarpeta1();
            Carpeta carpeta2 = this.AsignarCarpeta2();

            clbListaCarpetas.Items.Clear();

            List<FileInfo> list = carpeta1.ListMatchingFiles(carpeta2);

            int i = 0;

            foreach (FileInfo itemFileInfo in list)
            {
                clbListaCarpetas.Items.Add(itemFileInfo.FullName);

                i++;
            }

            this.Text = string.Format("Comparar Archivos - Encontrados {0} archivos.", i);
        }

        private void btnCarpeta1_Click(object sender, EventArgs e)
        {
            if (fbrDialogoCarpetas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxCarpeta1.Text = fbrDialogoCarpetas.SelectedPath;
            }
        }

        private void btnCarpeta2_Click(object sender, EventArgs e)
        {
            if (fbrDialogoCarpetas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxCarpeta2.Text = fbrDialogoCarpetas.SelectedPath;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbListaCarpetas.Items.Count; i++)
                clbListaCarpetas.SetItemChecked(i, true);
        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbListaCarpetas.Items.Count; i++)
                clbListaCarpetas.SetItemChecked(i, false);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            foreach (object ruta in clbListaCarpetas.CheckedItems)
                File.Delete((string)ruta);

            this.btnComparar_Click(sender, e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCarpeta2.Text))
            {
                if (Directory.Exists(tbxCarpeta2.Text))
                {
                    DirectoryInfo directoryInfo2 = new DirectoryInfo(tbxCarpeta2.Text);

                    Carpeta.EliminarCarpetasVacias(directoryInfo2);
                }
            }
        }
    }
}
