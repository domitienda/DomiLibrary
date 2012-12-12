using System;
using System.Collections;
using System.Collections.Generic;

namespace DomiLibrary.Helper
{
    /// <summary>
    /// Clase encargada de proporcionar utilidades para las validaciones
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// Comprueba si el objeto es nulo y si es devuelve un ArgumentException
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"> </param>
        public static void NotNull(object entity, string message)
        {
            if (entity == null)
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => entity), message);
            }
        }

        /// <summary>
        /// Comprueba que el objeto no sea nulo o vacio, si es asi, devuelve ArgumentException
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"> </param>
        public static void NotBlank(string entity, string message)
        {
            if(entity == null)
            {
                throw new NullReferenceException(MemberHelper.GetNameParameter(() => entity + " - " + message));
            }
            if(StringHelper.IsBlank(entity))
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => entity), message);
            }
        }

        /// <summary>
        /// Comprueba si la coleccion es nula o tiene 0 elementos
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotEmpty(ICollection collection, string message)
        {
            if(collection == null)
            {
                throw new NullReferenceException(MemberHelper.GetNameParameter(() => collection + " - " + message));
            }
            if(CollectionHelper.IsEmpty(collection))
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => collection), message);
            }
        }

        /// <summary>
        /// Comprueba si la coleccion es nula o tiene 0 elementos
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotEmpty<T>(T[] collection, string message)
        {
            if (collection == null)
            {
                throw new NullReferenceException(MemberHelper.GetNameParameter(() => collection + " - " + message));
            }
            if (CollectionHelper.IsEmpty(collection))
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => collection), message);
            }
        }

        /// <summary>
        /// Comprueba si la coleccion es nula o tiene 0 elementos
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotEmpty<T>(ICollection<T> collection, string message)
        {
            if (collection == null)
            {
                throw new NullReferenceException(MemberHelper.GetNameParameter(() => collection + " - " + message));
            }
            if (CollectionHelper.IsEmpty(collection))
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => collection), message);
            }
        }

        /// <summary>
        /// Comprueba que la condicion del argumento es true
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        public static void IsTrue(bool input, string message)
        {
            if(input == false)
            {
                throw new ArgumentException(MemberHelper.GetNameParameter(() => input), message);
            }
        }

        /// <summary>
        /// Comprueba si algun elemento de la coleccion es nulo
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotNullElements(ICollection collection, string message)
        {
            NotNull(collection, message);

            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentException(MemberHelper.GetNameParameter(() => item), message);
                }
            }
        }

        /// <summary>
        /// Comprueba si algun elemento de la coleccion es nulo
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotNullElements<T>(ICollection<T> collection, string message)
        {
            NotNull(collection, message);
            
            foreach (var item in collection)
            {
                if (item.Equals(null))
                {
                    throw new ArgumentException(MemberHelper.GetNameParameter(() => item), message);
                }
            }
        }

        /// <summary>
        /// Comprueba si algun elemento de la coleccion es nulo
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="message"></param>
        public static void NotNullElements<T>(T[] collection, string message)
        {
            NotNull(collection, message);

            foreach (var item in collection)
            {
                if (item.Equals(null))
                {
                    throw new ArgumentException(MemberHelper.GetNameParameter(() => item), message);
                }
            }
        }
    }
}
