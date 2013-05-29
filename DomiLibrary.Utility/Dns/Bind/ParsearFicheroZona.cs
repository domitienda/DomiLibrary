using System;
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

        private IList<string> BuscarParametros(IEnumerable<string> parametros)
        {
            ValidationHelper.NotNull(parametros);

            var result = new List<string>();

            foreach (var parametro in parametros)
            {
                var aux = BuscarParametro(parametro);
                if (aux != null)
                {
                    result.AddRange(aux);
                }
            }

            return result;
        } 

        /// <summary>
        /// Funcion encargada de devolver las lineas que coinciden con el 
        /// parametro de busqueda dentro del streamreader
        /// </summary>
        /// <param name="parametro">Parametro de busqueda</param>
        /// <returns>Devuelve un listado de lineas que coinciden con los parametros de busqueda</returns>
        private IList<string> BuscarParametro(string parametro)
        {
            ValidationHelper.NotBlank(parametro);

            var result = new List<string>();
            string linea;

            _fichero.BaseStream.Position = 0;
            while ((linea = _fichero.ReadLine()) != null)
            {
                if(linea.Contains(parametro))
                {
                    result.Add(linea);
                }
                //var lineaNormalizada = linea.ToLower();
                //var parametroNormalizado = parametro.ToLower();

                //if(lineaNormalizada.Contains(parametroNormalizado))
                //{
                //    result.Add(linea);
                //}
            }

            return result;
        }

        private IList<string> BuscarParametro(IEnumerable<string> parametros, string encabezado)
        {
            ValidationHelper.NotNull(parametros);
            ValidationHelper.NotBlank(encabezado);

            var result = new List<string>();

            foreach (var parametro in parametros)
            {
                var aux = BuscarParametro(parametro, encabezado);
                if(aux != null)
                {
                    result.AddRange(aux);
                }
            }

            return result;
        } 

        /// <summary>
        /// Funcion encargada de devolver las lineas que coinciden con el
        /// parametro y encabezado pasados en la funcion
        /// </summary>
        /// <param name="parametro">Parametro de busqueda</param>
        /// <param name="encabezado">Encabezado de busqueda</param>
        /// <returns>Devuelve un listado de lineas que coinciden con los parametros de busqueda</returns>
        private IList<string> BuscarParametro(string parametro, string encabezado)
        {
            ValidationHelper.NotBlank(parametro);
            ValidationHelper.NotBlank(encabezado);

            var result = new List<string>();
            string linea;

            _fichero.BaseStream.Position = 0;
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
        /// <returns>Devuelve la linea correspondiente al numero de serie</returns>
        public string GetLineaStringNumSerie()
        {
            var result = BuscarParametro(ConstantesDnsBind.NumSerie);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de actualizacion
        /// </summary>
        /// <returns>Retorna la linea de tiempo de actualizacion</returns>
        public string GetLineaStringTiempoActualizacion()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoActualizacion);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de reintento
        /// </summary>
        /// <returns>Retorna la linea de tiempo de reintento</returns>
        public string GetLineaStringTiempoReintento()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoReintento);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de caducidad
        /// </summary>
        /// <returns>Devuelve la linea de tiempo de caducidad</returns>
        public string GetLineaStringTiempoCaducidad()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoCaducidad);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve la linea que contiene el tiempo de vida
        /// </summary>
        /// <returns>Devuelve la linea de tiempo de vida</returns>
        public string GetLineaStringTiempoVida()
        {
            var result = BuscarParametro(ConstantesDnsBind.TiempoVida);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros NS
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro NS</returns>
        public IList<string> GetLineaStringNs()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Ns, 
                                     " " + ConstantesDnsBind.NsNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros MX
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro MX</returns>
        public IList<string> GetLineaStringMx()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Mx, 
                                     " " + ConstantesDnsBind.MxNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros A
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro A</returns>
        public IList<string> GetLineaStringA()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.A, 
                                     " " + ConstantesDnsBind.ANormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros TXT
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro TXT</returns>
        public IList<string> GetLineaStringTxt()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Txt, 
                                     " " + ConstantesDnsBind.TxtNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros AAA
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro AAA</returns>
        public IList<string> GetLineaStringAaa()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Aaa, 
                                     " " + ConstantesDnsBind.AaaNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros CNAME
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro CNAME</returns>
        public IList<string> GetLineaStringCname()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Cname, 
                                     " " + ConstantesDnsBind.CnameNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros PTR
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro PTR</returns>
        public IList<string> GetLineaStringPtr()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Ptr, 
                                     " " + ConstantesDnsBind.PtrNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros SPF
        /// </summary>
        /// <returns>Devuelve un listado de lineas con el registro SPF</returns>
        public IList<string> GetLineaStringSpf()
        {
            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Spf, 
                                     " " + ConstantesDnsBind.SpfNormalizado + " "
                                 };
            var result = BuscarParametros(parametros);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros A y un encabezado definido
        /// </summary>
        /// <param name="encabezado">Parametro de busqueda</param>
        /// <returns>Devuelve un listado de strings de las lineas A pero que coinciden con el encabezado</returns>
        public IList<string> GetLineaStringA(string encabezado)
        {
            ValidationHelper.NotBlank(encabezado);

            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.A, 
                                     " " + ConstantesDnsBind.ANormalizado + " "
                                 };

            var result = BuscarParametro(parametros, encabezado);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros AAA y un encabezado definido
        /// </summary>
        /// <param name="encabezado">Parametro de busqueda</param>
        /// <returns>Devuelve un listado de strings de las lineas AAA pero que coinciden con el encabezado</returns>
        public IList<string> GetLineaStringAaa(string encabezado)
        {
            ValidationHelper.NotBlank(encabezado);

            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Aaa, 
                                     " " + ConstantesDnsBind.AaaNormalizado + " "
                                 };

            var result = BuscarParametro(parametros, encabezado);
            return result;
        }

        /// <summary>
        /// Devuelve las lineas que contienen registros CNAME y un encabezado definido
        /// </summary>
        /// <param name="encabezado">Parametro de busqueda</param>
        /// <returns>Devuelve un listado de strings de las lineas CNAME pero que coinciden con el encabezado</returns>
        public IList<string> GetLineaStringCname(string encabezado)
        {
            ValidationHelper.NotBlank(encabezado);

            var parametros = new List<string>
                                 {
                                     ConstantesDnsBind.Cname, 
                                     " " + ConstantesDnsBind.CnameNormalizado + " "
                                 };

            var result = BuscarParametro(ConstantesDnsBind.Cname, encabezado);
            return result;
        }

        /// <summary>
        /// Devuelve el listado de valores referentes a NS
        /// </summary>
        /// <returns>Listado de strings</returns>
        private IEnumerable<string> GetValorStringNs()
        {
            var lineas = GetLineaStringNs();
            var resultado = new List<string>();

            foreach (var linea in lineas)
            {
                if (linea.StartsWith(";")) continue;
                var valores = linea.Split(' ');
                var valor = valores[valores.Length - 1];
                valor = ParsearValor(valor);
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    resultado.Add(valor);
                }
            }

            return resultado;
        }

        private static string ParsearValor(string input)
        {
            input = input.Replace('\t', ' ');
            var valorParseado = input.Split(' ')[input.Split(' ').Length - 1];
            if(valorParseado.EndsWith("."))
            {
                valorParseado = valorParseado.TrimEnd('.');
            }

            return valorParseado;
        }

        private static string ParsearValorTxt(string input)
        {
            input = input.Replace('\t', ' ');
            var valorParseado = input.Substring(input.IndexOf(" " + ConstantesDnsBind.TxtNormalizado + " ", System.StringComparison.Ordinal) + 4);
            valorParseado = valorParseado.Remove(0, 2);
            valorParseado = valorParseado.TrimEnd('\"');

            return valorParseado;
        }

        private static string ParsearValorMx(string input)
        {
            input = input.Replace('\t', ' ');
            var separator = new char[1];
            separator[0] = ' ';
            var split = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var valorParseado = split[split.Length - 2] + " " + split[split.Length - 1];
            if (split[split.Length - 1].EndsWith("."))
            {
                valorParseado =  split[split.Length - 2] + " " + split[split.Length - 1].TrimEnd('.');
            }

            return valorParseado;
        }

        private static string ParsearEncabezado(string input)
        {
            var arrayCharacters = new char[] {'@'};
            var result = StringHelper.Remove(input, arrayCharacters);

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas NS
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasNs()
        {
            var result = new List<Linea>();
            var valores = GetValorStringNs();

            foreach (var valor in valores)
            {
                var linea = new Linea
                                {
                                    TipoRegistro = ConstantesDnsBind.NsNormalizado, 
                                    Valor = valor
                                };
                result.Add(linea);
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas AAA
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasAaa()
        {
            var result = new List<Linea>();
            var lineasString = GetLineaStringAaa();

            foreach (var lineaString in lineasString)
            {
                var valores = lineaString.Split(' ');
                var valor = valores[valores.Length - 1];
                var encabezado = valores[0];
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    var linea = new Linea
                    {
                        TipoRegistro = ConstantesDnsBind.AaaNormalizado,
                        Valor = valor,
                        Nombre = encabezado
                    };
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas A
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasA()
        {
            var result = new List<Linea>();
            var lineasString = GetLineaStringA();

            foreach (var lineaString in lineasString)
            {
                var encabezado = lineaString.Split(' ')[0];
                encabezado = ParsearEncabezado(encabezado);
                var valor = ParsearValor(lineaString);
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    var linea = new Linea
                    {
                        TipoRegistro = ConstantesDnsBind.ANormalizado,
                        Valor = valor,
                        Nombre = encabezado
                    };
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas TXT
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasTxt()
        {
            var result = new List<Linea>();
            var lineasString = GetLineaStringTxt();

            foreach (var lineaString in lineasString)
            {
                var encabezado = lineaString.Split(' ')[0];
                encabezado = ParsearEncabezado(encabezado);
                var valor = ParsearValorTxt(lineaString);
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    var linea = new Linea
                    {
                        TipoRegistro = ConstantesDnsBind.TxtNormalizado,
                        Valor = valor,
                        Nombre = encabezado
                    };
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas CNAME
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasCname()
        {
            var result = new List<Linea>();
            var lineasString = GetLineaStringCname();

            foreach (var lineaString in lineasString)
            {
                var encabezado = lineaString.Split(' ')[0];
                var valor = ParsearValor(lineaString);
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    var linea = new Linea
                    {
                        TipoRegistro = ConstantesDnsBind.CnameNormalizado,
                        Valor = valor,
                        Nombre = encabezado
                    };
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas MX
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasMx()
        {
            var result = new List<Linea>();
            var lineasString = GetLineaStringMx();

            foreach (var lineaString in lineasString)
            {
                var encabezado = lineaString.Split(' ')[0];
                encabezado = ParsearEncabezado(encabezado);
                var valor = ParsearValorMx(lineaString);
                if (valor != null && valor.Equals(string.Empty) == false)
                {
                    var linea = new Linea
                    {
                        TipoRegistro = ConstantesDnsBind.MxNormalizado,
                        Valor = valor,
                        Nombre = encabezado
                    };
                    result.Add(linea);
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas SPF
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasSpf()
        {
            var result = new List<Linea>();

            return result;
        }

        /// <summary>
        /// Devuelve un listado de lineas PTR
        /// </summary>
        /// <returns>Listado de Linea</returns>
        public IList<Linea> GetLineasPtr()
        {
            var result = new List<Linea>();

            return result;
        }

        /// <summary>
        /// Devuelve todas las lineas de la zona
        /// </summary>
        /// <returns>Listado de lineas</returns>
        public IList<Linea> GetLineasZona()
        {
            var result = new List<Linea>();

            result.AddRange(GetLineasA());
            result.AddRange(GetLineasAaa());
            result.AddRange(GetLineasCname());
            result.AddRange(GetLineasMx());
            result.AddRange(GetLineasNs());
            result.AddRange(GetLineasSpf());
            result.AddRange(GetLineasPtr());
            result.AddRange(GetLineasTxt());

            return result;
        } 

        #endregion
    }
}
