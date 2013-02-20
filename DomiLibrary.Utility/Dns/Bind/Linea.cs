namespace DomiLibrary.Utility.Dns.Bind
{
    /// <summary>
    /// Representa a una linea dentro de la zona dns
    /// Ejemplo: www   CNAME   0.0.0.0 - nombre    tiporegistro   valor
    /// </summary>
    public class Linea
    {
        public string TipoRegistro { get; set; }

        public string Valor { get; set; }

        public string Nombre { get; set; }
    }
}
