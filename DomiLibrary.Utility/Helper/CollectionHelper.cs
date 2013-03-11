using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase encargada de proporcionar utilidades para las colecciones
    /// </summary>
    public class CollectionHelper
    {
        /// <summary>
        /// Comprueba si la coleccion es nula o vacia
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsEmpty(ICollection collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <summary>
        /// Comprueba si la coleccion es nula o vacia
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <summary>
        /// Comprueba si la coleccion es nula o vacia
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(T[] collection)
        {
            return collection == null || collection.Length == 0;
        }

        /// <summary>
        /// Devuelve una nueva coleccion que contiene a - b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ICollection Subtract(ICollection a, ICollection b)
        {
            ValidationHelper.NotNull(a, "El paramentro a es nulo");
            ValidationHelper.NotNull(b, "El paramentro b es nulo");

            var result = new ArrayList(a);

            foreach (var item in b)
            {
                result.Remove(item);
            }

            return result;
        }

        /// <summary>
        /// Devuelve una nueva coleccion que contiene a - b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ICollection Subtract<T>(ICollection<T> a, ICollection<T> b)
        {
            ValidationHelper.NotNull(a, "El paramentro a es nulo");
            ValidationHelper.NotNull(b, "El paramentro b es nulo");

            var result = new List<T>();

            foreach (var item in b)
            {
                result.Remove(item);
            }

            return result;
        }

        /// <summary>
        /// Devuelve una nueva coleccion que contiene a - b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ICollection Subtract<T>(T[] a, T[] b)
        {
            ValidationHelper.NotNull(a, "El paramentro a es nulo");
            ValidationHelper.NotNull(b, "El paramentro b es nulo");

            var result = new List<T>();

            foreach (var item in b)
            {
                result.Remove(item);
            }

            return result;
        }
    }
}
