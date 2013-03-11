namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase con logica de negocio para los tipos booleans
    /// </summary>
    public class BooleanHelper
    {
        /// <summary>
        /// Convierte un boolean en Sí o No
        /// </summary>
        /// <param name="input">Parametro de entrada</param>
        /// <returns>Retorna en base al input sí o no</returns>
        public static string ConvertirSiNo(bool input)
        {
            return input ? "Sí" : "No";
        }
    }
}
