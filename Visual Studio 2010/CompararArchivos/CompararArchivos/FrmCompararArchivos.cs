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
        Carpeta carpeta1;

        Carpeta carpeta2;

        public frmConsola()
        {
            InitializeComponent();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCarpeta1.Text))
            {
                if (Directory.Exists(tbxCarpeta1.Text))
                {
                    DirectoryInfo directoryInfo1 = new DirectoryInfo(tbxCarpeta1.Text);

                    carpeta1 = new Carpeta(directoryInfo1);
                }
            }

            if (!string.IsNullOrWhiteSpace(tbxCarpeta2.Text))
            {
                if (Directory.Exists(tbxCarpeta2.Text))
                {
                    DirectoryInfo directoryInfo2 = new DirectoryInfo(tbxCarpeta1.Text);

                    carpeta2 = new Carpeta(directoryInfo2);
                }
            }

            List<FileInfo> list = carpeta2.ListMatchingFiles(carpeta1);

            string[] lines = new string[list.Count];

            int i = 0;

            foreach (FileInfo itemFileInfo in list)
            {
                lines[i] = itemFileInfo.FullName;

                i++;
            }

            tbxConsola.Lines = lines;
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
    }
}
