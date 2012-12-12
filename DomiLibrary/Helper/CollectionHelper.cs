using System.Collections;
using System.Collections.Generic;

namespace DomiLibrary.Helper
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
    }
}
