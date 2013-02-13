using System.Collections.Generic;
using DomiLibrary.Architecture.Entity.Interface;

namespace DomiLibrary.Architecture.Core.Dao
{
    public interface IGenericDao<TDomain, TK> : IGenericReadDao<TDomain, TK>
        where TDomain : IEntity<TK>
    {
         /// <summary>
        /// Elimina un elemento de la base de datos
        /// </summary>
        /// <param name="obj"></param>
        void Delete(TDomain obj);

        /// <summary>
        /// Eliminar un elemento de la base de datos con su id
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(TK id);                        

        /// <summary>
        /// Crea o actualiza un elemento
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TDomain SaveOrUpdate(TDomain obj);

        /// <summary>
        /// Guardado en lote
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        IList<TDomain> SaveOrUpdateBatch(IList<TDomain> obj);

        /// <summary>
        /// Elimina en lote
        /// </summary>
        /// <param name="obj"></param>
        void DeleteBatch(IList<TDomain> obj);

        /// <summary>
        /// Funcion que mergea la entidad con la de la cache
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TDomain Merge(TDomain obj);
                 
    }    
}
