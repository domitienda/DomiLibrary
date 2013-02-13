using System.Collections.Generic;
using System.IO;
using DomiLibrary.Utility.Helper;

namespace DomiLibrary.Utility.Dns.Bind
{
    /// <summary>
    /// Clase que nos ayuda a parsear un fichero de zona de Bind DNS
    /// </summary>
    public class ParsearFicheroZona
    {
        #region Properties

        private readonly StreamReader _fichero;

        #endregion

        #region Constructor

        public ParsearFicheroZona(StreamReader fichero)
        {
            ValidationHelper.NotNull(fichero, "El parámetro fichero no puede ser nulo");
            _fichero = fichero;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Funcion encargada de devolver las lineas que coinciden con el 
        /// parametro de busqueda dentro del streamreader
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        private IList<string> BuscarParametro(string parametro)
        {
            ValidationHelper.NotBlank(parametro);

            var result = new List<string>();
            string linea;

            while ((linea = _fichero.ReadLine()) != null)
            {
                var lineaNormalizada = linea.ToLower();
                var parametroNormalizado = parametro.ToLower();

                if(lineaNormalizada.Contains(parametroNormalizado))
                {
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Funcion encargada de devolver las lineas que coinciden con el
        /// parametro y encabezado pasados en la funcion
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="encabezado"></param>
        /// <returns></returns>
        private IList<string> BuscarParametro(string parametro, string encabezado)
        {
            ValidationHelper.NotBlank(parametro);
            ValidationHelper.NotBlank(encabezado);

            var result = new List<string>();
            string linea;

            while ((linea = _fichero.ReadLine()) != null)
            {
                var lineaNormalizada = linea.ToLower();
                var parametroNormalizado = parametro.ToLower();
                var encabezadoNormalizado = encabezado.ToLower();

                if (lineaNormalizada.Contains(parametroNormalizado) 
                    && lineaNormalizada.Contains(encabezadoNormalizado))
                {
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve la linea que contiene el numero de serie
        /// </summary>
        /// <returns></returns>
        public string GetLineaNumSerie()
        {
            var result = BuscarParametro(ConstantesDnsBind.NumSerie);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de actualizacion
        /// </summary>
        /// <returns></returns>
        public string GetLineaTiempoActualizacion()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoActualizacion);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de reintento
        /// </summary>
        /// <returns></returns>
        public string GetLineaTiempoReintento()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoReintento);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de caducidad
        /// </summary>
        /// <returns></returns>
        public string GetLineaTiempoCaducidad()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoCaducidad);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de vida
        /// </summary>
        /// <returns></returns>
        public string GetLineaTiempoVida()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoVida);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros NS
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaNs()
        {
            var result = BuscarParametro(ConstantesDnsBind.Ns);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros MX
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaMx()
        {
            var result = BuscarParametro(ConstantesDnsBind.Mx);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros A
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaA()
        {
            var result = BuscarParametro(ConstantesDnsBind.A);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros AAA
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaAaa()
        {
            var result = BuscarParametro(ConstantesDnsBind.Aaa);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros CNAME
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaCname()
        {
            var result = BuscarParametro(ConstantesDnsBind.Cname);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros PTR
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaPtr()
        {
            var result = BuscarParametro(ConstantesDnsBind.Ptr);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros SPF
        /// </summary>
        /// <returns></returns>
        public IList<string> GetLineaSpf()
        {
            var result = BuscarParametro(ConstantesDnsBind.Spf);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros A y un encabezado definido
        /// </summary>
        /// <param name="encabezado"></param>
        /// <returns></returns>
        public IList<string> GetLineaA(string encabezado)
        {
            var result = BuscarParametro(ConstantesDnsBind.A, encabezado);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros AAA y un encabezado definido
        /// </summary>
        /// <param name="encabezado"></param>
        /// <returns></returns>
        public IList<string> GetLineaAaa(string encabezado)
        {
            var result = BuscarParametro(ConstantesDnsBind.Aaa, encabezado);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros CNAME y un encabezado definido
        /// </summary>
        /// <param name="encabezado"></param>
        /// <returns></returns>
        public IList<string> GetLineaCname(string encabezado)
        {
            var result = BuscarParametro(ConstantesDnsBind.Cname, encabezado);
            return result;
        }

        #endregion
    }
}
