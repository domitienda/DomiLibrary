using System.Collections.Generic;
using System.Linq;
using DomiLibrary.Architecture.Entity.Interface;
using NHibernate;

namespace DomiLibrary.Architecture.Core.Dao
{
    public interface IGenericReadDao<TDomain, in TK> : IQueryable<TDomain> where TDomain : IEntity<TK>
    {
        /// <summary>
        /// Obtiene todos los elementos de la base de datos
        /// </summary>
        /// <returns></returns>
        IList<TDomain> GetAll();

        /// <summary>
        /// Obtiene un elemento por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TDomain GetById(TK id);

        /// <summary>
        /// Número de elementos que contiene la tabla
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Propiedad que contiene la factoría de la sesión
        /// </summary>
        ISessionFactory SessionFactory { get; set; }
    }
}
