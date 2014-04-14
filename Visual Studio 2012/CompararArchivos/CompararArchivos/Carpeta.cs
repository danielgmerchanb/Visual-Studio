using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CompararArchivos
{
    public class Carpeta
    {
        private Dictionary<byte[], FileInfo> dictionaryArchivos = new Dictionary<byte[], FileInfo>(new ComparerByte());

        public Dictionary<byte[], FileInfo> DictionaryArchivos
        {
            get
            {
                return dictionaryArchivos;
            }
        }

        public Carpeta(DirectoryInfo directoryInfo)
        {
            this.ListarArchivos(directoryInfo);
        }

        private byte[] GetMD5(FileInfo itemFileInfo)
        {
            MD5 md5 = MD5.Create();

            return md5.ComputeHash(File.ReadAllBytes(itemFileInfo.FullName));
        }

        private void ListarArchivos(DirectoryInfo directoryInfo)
        {
            foreach (DirectoryInfo itemDirectoryInfo in directoryInfo.GetDirectories())
                ListarArchivos(itemDirectoryInfo);

            foreach (FileInfo itemFileInfo in directoryInfo.GetFiles())
            {
                byte[] key = GetMD5(itemFileInfo);

                if (!this.ContainArchivo(key))
                    this.DictionaryArchivos.Add(key, itemFileInfo);
            }
        }

        private bool ContainArchivo(byte[] md5)
        {
            return this.DictionaryArchivos.ContainsKey(md5);
        }

        public List<FileInfo> ListMatchingFiles(Carpeta carpeta)
        {
            List<FileInfo> list = new List<FileInfo>();

            foreach (KeyValuePair<byte[], FileInfo> itemFileInfo in carpeta.DictionaryArchivos)
            {
                if (this.ContainArchivo(itemFileInfo.Key))
                    list.Add(itemFileInfo.Value);
            }

            return list;
        }

        public static void EliminarCarpetasVacias(DirectoryInfo directoryInfo)
        {
            foreach (DirectoryInfo itemDirectoryInfo in directoryInfo.GetDirectories())
                EliminarCarpetasVacias(itemDirectoryInfo);

            if (directoryInfo.GetDirectories().Length == 0 && directoryInfo.GetFiles().Length == 0)
                Directory.Delete(directoryInfo.FullName);
        }

        private class ComparerByte : IEqualityComparer<byte[]>
        {
            public bool Equals(byte[] x, byte[] y)
            {
                if (x.Length == y.Length)
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        if (x[i] != y[i])
                            return false;
                    }

                    return true;
                }

                return false;
            }

            public int GetHashCode(byte[] obj)
            {
                int hashCode = 0;

                for (int i = obj.Length; i > 0; i--)
                {
                    hashCode += obj[i - 1] * (obj.Length - (i - 1));
                }

                return hashCode;
            }
        }
    }
}
