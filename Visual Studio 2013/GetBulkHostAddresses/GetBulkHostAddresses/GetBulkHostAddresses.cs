using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBulkHostAddresses
{
    public partial class GetBulkHostAddresses : Form
    {
        #region Fields
        private string pathFileDnsReader = string.Empty;

        private string pathFileDnsWriter = string.Empty;

        private int maxThreads = Convert.ToInt32(ConfigurationManager.AppSettings["maxThreads"]);

        private int countThreads = 0;

        private int timeSleepMainProcess = Convert.ToInt32(ConfigurationManager.AppSettings["timeSleepMainProcess"]);

        private string comma = ConfigurationManager.AppSettings["comma"];

        private string finishMessage = ConfigurationManager.AppSettings["finishMessage"];

        private object thisObject = new object();
        #endregion

        #region Methods

        public GetBulkHostAddresses()
        {
            InitializeComponent();
        }

        public void ObtenerDirecciones()
        {
            List<Hostname>[] hostnameListArray = SplitListFileDNSReader(ReadFileDNSReader(pathFileDnsReader));

            for (int i = 0; i < maxThreads; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetHostAddressesList), hostnameListArray[i]);
            }

            while (maxThreads > countThreads)
            {
                Thread.Sleep(timeSleepMainProcess);
            }
        }

        private List<Hostname> ReadFileDNSReader(string pathFileDnsReader)
        {
            List<Hostname> hostnameList = new List<Hostname>();

            if (File.Exists(pathFileDnsReader))
            {
                using (StreamReader fileDNSReader = new StreamReader(pathFileDnsReader))
                {
                    while (fileDNSReader.Peek() != -1)
                        hostnameList.Add(new Hostname() { Domain = fileDNSReader.ReadLine().Replace("www.", "").Trim() });

                    fileDNSReader.Close();
                }
            }

            return hostnameList;
        }

        private List<Hostname>[] SplitListFileDNSReader(List<Hostname> hostnameList)
        {
            List<Hostname>[] hostnameListArray = new List<Hostname>[maxThreads];

            if (hostnameList != null)
            {
                int mumDomain = (int)Math.Ceiling((float)hostnameList.Count / (float)maxThreads);

                int i = 0;

                for (int j = 0; j < hostnameListArray.Length; j++)
                {
                    hostnameListArray[j] = new List<Hostname>(mumDomain);

                    for (int k = 0; k < mumDomain; k++)
                    {
                        if (i < hostnameList.Count)
                        {
                            hostnameListArray[j].Add(hostnameList[i]);
                            i++;
                        }
                        else
                            break;
                    }
                }
            }

            return hostnameListArray;
        }

        private string GetHostAddresses(string domain)
        {
            string hostAddresses = string.Empty;

            try
            {
                hostAddresses = Dns.GetHostAddresses(domain)[0].ToString();
            }
            catch (Exception exception)
            {
                hostAddresses = exception.Message;
            }

            return hostAddresses;
        }

        private void GetHostAddressesList(object hostnameList)
        {
            foreach (Hostname hostname in (List<Hostname>)hostnameList)
            {
                hostname.HostAddresses = GetHostAddresses(hostname.Domain);
            }

            lock (thisObject)
            {
                using (StreamWriter streamWriter = new StreamWriter(pathFileDnsWriter, true))
                {
                    foreach (Hostname hostname in (List<Hostname>)hostnameList)
                    {
                        streamWriter.WriteLine(hostname.Domain + comma + hostname.HostAddresses);
                    }

                    streamWriter.Close();
                }
            }

            countThreads++;
        }
        #endregion

        #region Class
        public class Hostname
        {
            public string Domain { get; set; }
            public string HostAddresses { get; set; }
        }
        #endregion

        #region Events
        private void GetBulkHostAddresses_Load(object sender, EventArgs e)
        {
            string rutaDefault = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory), "DireccionesIP.txt");
            pathFileDnsWriter = rutaDefault;
            RutaArchivoDirecciones.Text = rutaDefault;
        }

        private void BotonObtenerDirecciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(pathFileDnsReader) && !string.IsNullOrEmpty(pathFileDnsWriter))
                {
                    UseWaitCursor = true;
                    BotonObtenerDirecciones.Enabled = false;
                    Application.DoEvents();

                    ObtenerDirecciones();

                    UseWaitCursor = false;
                    BotonObtenerDirecciones.Enabled = true;
                    Application.DoEvents();

                    MessageBox.Show(string.Format("El listado de direcciones IP se encuentra en el archivo {0}.", Path.GetFileName(pathFileDnsWriter)), "Operación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Debe escoger los archivos para iniciar el proceso", "Faltan Información", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BotonAbrirArchivoDominios_Click(object sender, EventArgs e)
        {
            if (AbrirArchivoDominios.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RutaArchivoDominios.Text = AbrirArchivoDominios.FileName;
                pathFileDnsReader = AbrirArchivoDominios.FileName;
            }
        }

        private void BotonGuardarArchivoDirecciones_Click(object sender, EventArgs e)
        {
            if (GuardarArchivoDirecciones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RutaArchivoDirecciones.Text = GuardarArchivoDirecciones.FileName;
                pathFileDnsWriter = GuardarArchivoDirecciones.FileName;
            }
        }
        #endregion

    }
}
