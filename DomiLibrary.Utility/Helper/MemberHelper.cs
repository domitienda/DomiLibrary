using System;
using System.Linq.Expressions;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase encargada de proporcionar utilidades para los atributos de las funciones/metodos/entidades
    /// </summary>
    public class MemberHelper
    {
        /// <summary>
        /// Funcion que devuelve el nombre del parametro de la funcion/metodo
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="expr">Expresion</param>
        /// <returns>Nombre del parametro</returns>
        public static string GetNameParameter<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }
    }
}
