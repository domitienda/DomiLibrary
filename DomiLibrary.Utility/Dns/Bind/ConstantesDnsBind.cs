namespace DomiLibrary.Utility.Dns.Bind
{
    public class ConstantesDnsBind
    {
        public const string NumSerie = "serial number";
        public const string TiempoActualizacion = "refresh";
        public const string TiempoReintento = "retry";
        public const string TiempoCaducidad = "expire";
        public const string TiempoVida = "ttl";

        public const string Ns = "NS\t";
        public const string Mx = "MX\t";
        public const string A = "A\t";
        public const string Aaa = "AAA\t";
        public const string Cname = "CNAME\t";
        public const string Ptr = "PTR\t";
        public const string Spf = "SPF\t";

        public const string NsNormalizado = "NS";
        public const string MxNormalizado = "MX";
        public const string ANormalizado = "A";
        public const string AaaNormalizado = "AAA";
        public const string CnameNormalizado = "CNAME";
        public const string PtrNormalizado = "PTR";
        public const string SpfNormalizado = "SPF";
    }
}
