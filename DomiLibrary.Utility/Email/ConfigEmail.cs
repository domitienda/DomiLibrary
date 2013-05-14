namespace DomiLibrary.Utility.Email
{
    /// <summary>
    /// Representa la configuracion del servidor de correo
    /// </summary>
    public class ConfigEmail
    {
        /// <summary>
        /// Credencial de usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Credencial clave usuario
        /// </summary>
        public string ClaveUsuario { get; set; }

        /// <summary>
        /// Direccion IP del servidor de correo
        /// </summary>
        public string IpServidor { get; set; }

        /// <summary>
        /// Puerto que tiene configurado el servidor de correo
        /// </summary>
        public int PuertoServidor { get; set; }

        /// <summary>
        /// Flag que define si se usa SSL
        /// </summary>
        public bool Ssl { get; set; }
    }
}
