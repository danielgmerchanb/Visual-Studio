using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinClientWSKatarrValidity.WSKatarrValidity;
using WinClientWSKatarrValidity.Properties;

namespace WinClientWSKatarrValidity
{
    public partial class WinClient : Form
    {
        public WinClient()
        {
            InitializeComponent();
        }

        private void bEjecutar_Click(object sender, EventArgs e)
        {
            if (this.tcnWinClient.SelectedIndex == 0)
            {
                KatarrValidityService servicio = new KatarrValidityService();

                servicio.Proxy = new System.Net.WebProxy(Settings.Default.ProxyHttp, Convert.ToInt32(Settings.Default.Puerto));
                servicio.Proxy.Credentials = new System.Net.NetworkCredential(Settings.Default.Username, Settings.Default.Password);

                servicio.ActivateItem(txtContrato.Text, txtReferencia.Text, Convert.ToInt32(txtMovimiento.Text), Convert.ToInt32(txtSistema.Text));

                MessageBox.Show("Termino el llamado al servicio.", "ActivateItem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                KatarrValidityService servicio = new KatarrValidityService();

                servicio.Proxy = new System.Net.WebProxy(Settings.Default.ProxyHttp, Convert.ToInt32(Settings.Default.Puerto));
                servicio.Proxy.Credentials = new System.Net.NetworkCredential(Settings.Default.Username, Settings.Default.Password);

                servicio.ActivateProduct(txtEmpresa.Text, txtProducto.Text, Convert.ToInt32(txtSistemaProducto.Text));

                MessageBox.Show("Termino el llamado al servicio.", "ActivateProduct", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void bBorrar_Click(object sender, EventArgs e)
        {
            txtContrato.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            txtMovimiento.Text = string.Empty;
            txtSistema.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtSistemaProducto.Text = string.Empty;
        }
    }
}