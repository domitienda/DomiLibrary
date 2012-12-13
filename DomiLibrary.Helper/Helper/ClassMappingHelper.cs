using System;
using System.Collections.Generic;
using System.Data;
using Common.Logging;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Clase encargada de proporcionar metodos/funciones de mapeo de clases
    /// </summary>
    public class ClassMappingHelper
    {
        #region Properties

        protected static ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Convert<TS, T>(TS source)
        {
            var target = Activator.CreateInstance<T>();
            return FillProperties(source, target);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T Fill<TS, T>(TS source, T target)
        {
            return FillProperties(source, target);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Convert<T>(object source)
        {
            var target = Activator.CreateInstance<T>();
            return FillProperties(source, target);
        }


        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con los valores de las columnas del datarow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T Convert<T>(DataRow dr)
        {
            var target = Activator.CreateInstance<T>();
            return FillProperties(dr, target);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con los valores de un datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IEnumerable<T> Convert<T>(DataTable dt)
        {
            return FillProperties<T>(dt);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T Fill<T>(object source, T target)
        {
            return FillProperties(source, target);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static T FillProperties<TS, T>(TS source, T target)
        {
            return FillProperties<T>(source, target);
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static IEnumerable<T> FillProperties<T>(DataTable dt)
        {
            if (dt == null)
                return null;

            var list = new List<T>();
            foreach (var row in dt.Rows)
            {
                var target = Activator.CreateInstance<T>();
                var entity = FillProperties((DataRow)row, target);
                list.Add(entity);
            }

            return list;
        }

        /// <summary>
        /// Funcion que rellena las propiedades de T con los valores de dr
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static T FillProperties<T>(DataRow dr, T target)
        {
            if (dr == null)
                return default(T);
            
            var targetType = typeof(T);

            foreach (var column in dr.Table.Columns)
            {
                try
                {
                    var targetProperty = targetType.GetProperty(((DataColumn)column).ColumnName);
                    if(targetProperty == null) continue;

                    var targetValue = dr[((DataColumn) column).ColumnName];

                    if (targetValue is DBNull) 
                        targetValue = null;
                    if (targetProperty.GetValue(target, null) is Int32)
                        targetValue = System.Convert.ToInt32(targetValue);
                    if (targetProperty.GetValue(target, null) is String)
                        targetValue = System.Convert.ToString(targetValue);
                    if (targetProperty.GetValue(target, null) is DateTime)
                        targetValue = System.Convert.ToDateTime(targetValue);
                    if (targetProperty.GetValue(target, null) is Boolean)
                        targetValue = System.Convert.ToBoolean(targetValue);
                    if (targetProperty.GetValue(target, null) is String)
                        targetValue = System.Convert.ToString(targetValue);
                    if (targetProperty.GetValue(target, null) is Decimal)
                        targetValue = System.Convert.ToDecimal(targetValue);
                    if (targetProperty.GetValue(target, null) is Double)
                        targetValue = System.Convert.ToDouble(targetValue);
                    if (targetProperty.GetValue(target, null) is SByte)
                        targetValue = System.Convert.ToSByte(targetValue);
                    
                    targetProperty.SetValue(target, targetValue, null);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            
            return target;
        }

        /// <summary>
        /// Instancia un nuevo objeto de tipo T y lo rellena con las propiedades del objeto tipo S
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static T FillProperties<T>(object source, T target)
        {
            if (source == null)
                return default(T);

            var sourceType = source.GetType();
            var targetType = typeof(T);

            foreach (var targetProperty in targetType.GetProperties())
            {
                try
                {
                    if (!targetProperty.CanWrite)
                        continue;
                    var sourceProperty = sourceType.GetProperty(targetProperty.Name);
                    if (sourceProperty == null || !sourceProperty.CanRead || sourceProperty.PropertyType != targetProperty.PropertyType)
                        continue;
                    var sourceValue = sourceProperty.GetValue(source, null);
                    targetProperty.SetValue(target, sourceValue, null);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }

            return target;
        }

        #endregion
    }
}
