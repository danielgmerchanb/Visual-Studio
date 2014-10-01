using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OrdernarFotografias
{
    public static class Program
    {
        private const string _Slash = @"\";

        private static int consecutivo = 0;

        private static List<string> listaHash = new List<string>();

        private static StreamWriter streamWriter;

        private static string rutaArchivoHash = @"D:\HashFotos.txt";

        public static void Main(string[] args)
        {
            try
            {
                string rutaCarpetaFotos = @"D:\Fotos";
                string rutaCarpetaOrganizado = @"D:\Organizado";
                string rutaCarpetaBorrado = @"D:\Borrados";
                string rutaCarpetaOtros = @"D:\Otros";

                CargarArchivoHash();
                AbrirArchivoHash();
                BuscarCarpetasEnCarpetas(rutaCarpetaFotos, rutaCarpetaOrganizado, rutaCarpetaBorrado, rutaCarpetaOtros);
            }
            finally
            {
                CerrarArchivoHash();
            }
        }

        private static void BuscarCarpetasEnCarpetas(string rutaCarpeta, string rutaCarpetaOrganizado, string rutaCarpetaBorrado, string rutaCarpetaOtros)
        {
            string[] carpetas = Directory.GetDirectories(rutaCarpeta);

            foreach (string carpeta in carpetas)
            {
                BuscarCarpetasEnCarpetas(carpeta, rutaCarpetaOrganizado, rutaCarpetaBorrado, rutaCarpetaOtros);
            }

            string[] archivos = Directory.GetFiles(rutaCarpeta);

            foreach (string archivo in archivos)
            {
                if (EsImagen(archivo))
                {
                    if (YaExiste(archivo))
                    {
                        string nuevoArchivoBorrado = rutaCarpetaBorrado + _Slash + Path.GetFileName(archivo);

                        if (File.Exists(nuevoArchivoBorrado))
                            nuevoArchivoBorrado = Path.GetDirectoryName(nuevoArchivoBorrado) + _Slash + Path.GetFileNameWithoutExtension(nuevoArchivoBorrado) + "_" + (consecutivo++).ToString() + Path.GetExtension(nuevoArchivoBorrado).ToLower();

                        File.Move(archivo, nuevoArchivoBorrado);
                    }
                    else
                    {
                        DateTime fechaModificacion = ObtenerFechaCaptura(archivo);

                        if (fechaModificacion == DateTime.MinValue)
                            fechaModificacion = File.GetLastWriteTime(archivo);

                        string nuevaCarpetaAno = rutaCarpetaOrganizado + _Slash + fechaModificacion.ToString("yyyy");

                        if (!Directory.Exists(nuevaCarpetaAno))
                            Directory.CreateDirectory(nuevaCarpetaAno);

                        string nuevaCarpetaMes = nuevaCarpetaAno + _Slash + fechaModificacion.ToString("MM");

                        if (!Directory.Exists(nuevaCarpetaMes))
                            Directory.CreateDirectory(nuevaCarpetaMes);

                        string nuevaCarpeta = nuevaCarpetaMes + _Slash + fechaModificacion.ToString("dd");

                        if (!Directory.Exists(nuevaCarpeta))
                            Directory.CreateDirectory(nuevaCarpeta);

                        string nuevoArchivo = nuevaCarpeta + _Slash + fechaModificacion.ToString("yyyy-MM-dd hh-mm-ss") + Path.GetExtension(archivo).ToLower();

                        if (File.Exists(nuevoArchivo))
                            nuevoArchivo = nuevaCarpeta + _Slash + fechaModificacion.ToString("yyyy-MM-dd hh-mm-ss") + "_" + (consecutivo++).ToString() + Path.GetExtension(archivo).ToLower();

                        File.Move(archivo, nuevoArchivo);
                    }
                }
                else
                {
                    string nuevoArchivoOtros = rutaCarpetaOtros + _Slash + Path.GetFileName(archivo);

                    if (File.Exists(nuevoArchivoOtros))
                        nuevoArchivoOtros = Path.GetDirectoryName(nuevoArchivoOtros) + _Slash + Path.GetFileNameWithoutExtension(nuevoArchivoOtros) + "_" + (consecutivo++).ToString() + Path.GetExtension(nuevoArchivoOtros).ToLower();

                    if (!File.Exists(nuevoArchivoOtros))
                        File.Move(archivo, nuevoArchivoOtros);
                }
            }
        }

        private static bool YaExiste(string rutaArchivo)
        {
            string codigoHash = ObtenerCodigoHash(rutaArchivo);
            bool yaExiste = listaHash.Contains(ObtenerCodigoHash(rutaArchivo));

            if (!yaExiste)
            {
                listaHash.Add(codigoHash);
                GrabarCodigoHash(codigoHash);
            }

            return yaExiste;
        }

        private static string ObtenerCodigoHash(string rutaArchivo)
        {
            return ConvertirMatrizACadena(new MD5CryptoServiceProvider().ComputeHash(File.ReadAllBytes(rutaArchivo)));
        }

        private static string ConvertirMatrizACadena(byte[] matriz)
        {
            StringBuilder constructorCadena = new StringBuilder(matriz.Length);

            for (int i = 0; i < matriz.Length - 1; i++)
                constructorCadena.Append(matriz[i].ToString("X2"));

            return constructorCadena.ToString();
        }

        private static DateTime ObtenerFechaCaptura(string rutaArchivo)
        {
            DateTime fechaCaptura = DateTime.MinValue;

            using (Image image = Image.FromFile(rutaArchivo))
            {
                int position = -1;

                for (int i = 0; i < image.PropertyIdList.Length; i++)
                {
                    if (image.PropertyIdList[i] == 306)
                    {
                        position = i;
                        break;
                    }
                }

                if (position != -1)
                {
                    string fechaCapturaCadena = Encoding.ASCII.GetString(image.PropertyItems[position].Value, 0, image.PropertyItems[position].Len - 1);

                    string[] fechaCapturaMatriz = fechaCapturaCadena.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    fechaCaptura = Convert.ToDateTime(string.Format("{0}/{1}/{2} {3}:{4}:{5}", fechaCapturaMatriz));
                }
            }

            return fechaCaptura;
        }

        private static bool EsImagen(string nombreArchivo)
        {
            string extensionArchivo = Path.GetExtension(nombreArchivo).ToLower();

            List<string> extensionesImagen = new List<string>();

            extensionesImagen.Add(".jpg");

            return extensionesImagen.Contains(extensionArchivo);
        }

        private static void CargarArchivoHash()
        {
            if (File.Exists(rutaArchivoHash))
            {
                using (StreamReader streamReader = new StreamReader(rutaArchivoHash, Encoding.UTF8))
                {
                    while (streamReader.Peek() != -1)
                    {
                        listaHash.Add(streamReader.ReadLine());
                    }
                }
            }
        }

        private static void AbrirArchivoHash()
        {
            streamWriter = new StreamWriter(rutaArchivoHash, true, Encoding.UTF8);
        }

        private static void CerrarArchivoHash()
        {
            streamWriter.Close();
        }

        private static void GrabarCodigoHash(string hash)
        {
            streamWriter.WriteLine(hash);
        }
    }
}
