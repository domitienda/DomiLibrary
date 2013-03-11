namespace DomiLibrary.Utility.Dns.Bind
{
    /// <summary>
    /// Representa a una linea dentro de la zona dns
    /// Ejemplo: www   CNAME   0.0.0.0 - nombre    tiporegistro   valor
    /// </summary>
    public class Linea
    {
        /// <summary>
        /// Representa el tipo de registro de la linea CNAME, A, NS, etc
        /// </summary>
        public string TipoRegistro { get; set; }

        /// <summary>
        /// Representa el valor de la linea
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Representa el nombre o alias de la linea
        /// </summary>
        public string Nombre { get; set; }
    }
}
