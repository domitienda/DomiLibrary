using System.Collections.Generic;
using DomiLibrary.Entity.Interface;

namespace DomiLibrary.Core.Service
{
    public interface IGenericReadService<TDomain, in TK> : IService where TDomain : IEntity<TK>
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
    }
}
