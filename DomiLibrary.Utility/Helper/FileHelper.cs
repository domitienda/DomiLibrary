using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.IO.Compression;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase encargada de proporcionar utilidades para los ficheros
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Funcion que devuelve el tamanyo de un directorio
        /// </summary>
        /// <param name="path">Path del directorio que se realizara el calculo</param>
        /// <returns>Tamaño del directorio</returns>
        public static long GetSizeFolder(string path)
        {
            long folderSize;

            try
            {
                folderSize = Directory.GetFiles(path).Select(file => new FileInfo(file).Length).Sum();
                folderSize = folderSize / 1024 / 1024;
            }
            catch (Exception)
            {
                return 0;
            }

            return folderSize;
        }

        /// <summary>
        /// Función que dada una ruta y un patrón, elimina de un directorio
        /// todos los ficheros que empiezan por dicho patrón.
        /// </summary>
        /// <param name="path">Path del directorio</param>
        /// <param name="pattern">Patron</param>
        public static void DeleteFilesByStartWith(string path, string pattern)
        {
            try
            {
                if (!Directory.Exists(path))
                    return;

                var files = Directory.GetFiles(path);

                for (var i = 0; i <= files.Length - 1; i++)
                {
                    var nombreFichero = files[i].Split('\\')[files[i].Split('\\').Length - 1];
                    if (nombreFichero.StartsWith(pattern))
                        File.Delete(files[i]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteFilesByStartWith: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el tamaño en MB del fichero
        /// </summary>
        /// <param name="path">Path del fichero</param>
        /// <returns>Tamaño del fichero</returns>
        public static double GetTamanyoFileMb(string path)
        {
            var archivo = new FileInfo(path);
            var longtam = archivo.Length;
            var doutam = double.Parse(longtam.ToString(CultureInfo.InvariantCulture));
            doutam = doutam / 1024 / 1024;
            doutam = Math.Round(doutam, 2);

            return doutam;
        }

        /// <summary>
        /// Metodo que comprime un fichero
        /// </summary>
        /// <param name="fi">Informacion del fichero comprimido</param>
        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (var inFile = fi.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (var outFile = File.Create(fi.FullName + ".gz"))
                    {
                        using (var compress = new GZipStream(outFile, CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(compress);
                        }

                        outFile.Close();
                        outFile.Dispose();
                    }
                }

                inFile.Close();
                inFile.Dispose();
            }
        }

        /// <summary>
        /// Metodo que descomprime un fichero
        /// </summary>
        /// <param name="fi">Informacion del fichero descomprimido</param>
        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (var inFile = fi.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                var curFile = fi.FullName;
                var origName = curFile.Remove(curFile.Length -
                        fi.Extension.Length);

                //Create the decompressed file.
                using (var outFile = File.Create(origName))
                {
                    using (var decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
                        decompress.CopyTo(outFile);                                               
                        decompress.Close();
                    }

                    outFile.Close();
                }

                inFile.Close();
            }
        }
    }
}
