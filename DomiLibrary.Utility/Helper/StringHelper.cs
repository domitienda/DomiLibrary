using System.Collections.Generic;
using System.Globalization;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase encargada de ofrecer metodos para string
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Comprueba es vacio o nulo
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsBlank(string entity)
        {
            return entity == null || entity.Equals(string.Empty);
        }

        /// <summary>
        /// Devuelve un contador con el numero de bytes que tiene un string
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static int CountStringToBytes(string cadena)
        {
            var resultado = StringToBytes(cadena);

            return resultado.Length;
        }

        /// <summary>
        /// Convierte un string en un array de bytes
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static byte[] StringToBytes(string cadena)
        {
            var codificador = new System.Text.ASCIIEncoding();

            return codificador.GetBytes(cadena);
        }

        /// <summary>
        /// Formatea un string por la izquierda con el literal y cantidad especificada
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="numPosiciones"></param>
        /// <param name="caracter"></param>
        /// <returns></returns>
        public static string FormatString(string cadena, int numPosiciones, string caracter)
        {
            var numPosicionesCadena = cadena.Length;

            if (numPosicionesCadena >= numPosiciones)
            {
                return cadena;
            }

            var resta = numPosiciones - numPosicionesCadena;
            for (var i = 0; i < resta; i++)
            {
                cadena = caracter + cadena;
            }

            return cadena;
        }

        /// <summary>
        /// Reemplaza en un string el caracter correspondiente al indice pasado por paramatro
        /// por el caracter de reemplazo
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replace"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ReplaceByIndex(string input, string replace, int index)
        {
            ValidationHelper.NotBlank(input, string.Empty);
            ValidationHelper.NotNull(replace, string.Empty);

            var result = string.Empty;
            for (var i = 0; i < input.ToCharArray().Length; i++)
            {
                if (i == index)
                {
                    result += replace;
                    continue;
                }

                result += input[i];
            }

            return result;
        }

        /// <summary>
        /// Retorna un listado con los indices donde se encuentra el caracter que buscamos
        /// </summary>
        /// <param name="input"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int[] GetIndexesByCharacter(string input, char character)
        {
            ValidationHelper.NotBlank(input, string.Empty);
            ValidationHelper.NotNull(character, string.Empty);

            var indexes = new List<int>();
            for (var i = 0; i < input.ToCharArray().Length; i++)
            {
                if(input.ToCharArray()[i].Equals(character))
                    indexes.Add(i);
            }

            return indexes.ToArray();
        }

        /// <summary>
        /// Retorna un listado con los indices donde se encuentra el caracter que buscamos
        /// </summary>
        /// <param name="input"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static int[] GetIndexesByCharacter(string input, IList<char> characters)
        {
            ValidationHelper.NotBlank(input, string.Empty);
            ValidationHelper.NotEmpty(characters, string.Empty);

            var indexes = new List<int>();
            for (var i = 0; i < input.ToCharArray().Length; i++)
            {
                if (characters.Contains(input.ToCharArray()[i]))
                    indexes.Add(i);
            }

            return indexes.ToArray();
        }

        /// <summary>
        /// Convierte un string en formato pascal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToPascalCase(string input)
        {
            ValidationHelper.NotBlank(input, string.Empty);

            if(input.Length == 1) return input.ToUpper();

            //La primera la cambiamos a mayuscula
            var iniUpper = input[0].ToString(CultureInfo.InvariantCulture).ToUpper();
            input = ReplaceByIndex(input, iniUpper, 0);

            var characters = new List<char> {' ', '_'};
            var indexes = GetIndexesByCharacter(input, characters);

            foreach (var index in indexes)
            {
                var upper = input[index + 1].ToString(CultureInfo.InvariantCulture).ToUpper();
                input = input.Remove(index, 1);
                input = ReplaceByIndex(input, upper, index);
            }
            
            return input;
        }

        /// <summary>
        /// Funcion que busca una cadena dentro de un string
        /// Debemos indicarle que corte el string hasta que encuentra el string de fin
        /// </summary>
        /// <param name="str">String que se realiza la busqueda</param>
        /// <param name="search">Cadena de busqueda</param>
        /// <param name="strEnd">Cadena en que corta el resultado</param>
        /// <returns></returns>
        public static IList<string> SearchString(string str, string search, string strEnd)
        {
            ValidationHelper.NotBlank(str);
            ValidationHelper.NotBlank(search);
            ValidationHelper.NotBlank(strEnd);

            var result = new List<string>();
            var contains = str.Contains(search);
            if (!contains) return result;
            
            while (str.Contains(search))
            {
                var ini = str.IndexOf(search, System.StringComparison.Ordinal);
                var aux = str.Substring(ini);
                var fin = aux.IndexOf(strEnd, System.StringComparison.Ordinal);
                result.Add(aux.Substring(0, fin));
                str = aux.Substring(fin);
            }

            return result;
        }
    }
}
