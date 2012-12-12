using System;
using System.Collections.Generic;
using NHibernate.Linq;
using DomiLibrary.Core.Dao;
using DomiLibrary.Entity.Interface;


namespace DomiLibrary.Data
{
    public class GenericDao<TDomain, TK> : GenericReadDao<TDomain, TK>, IGenericDao<TDomain, TK>
        where TDomain : class, IEntity<TK>
    {
        #region IGenericDao<TDomain> Members                

        public virtual TDomain SaveOrUpdate(TDomain obj)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(obj);        
            return obj;
        }

        public virtual TDomain Merge(TDomain obj)
        {
            return SessionFactory.GetCurrentSession().Merge(obj);
        }

        public virtual IList<TDomain> SaveOrUpdateBatch(IList<TDomain> objs)
        {
            var result = new List<TDomain>();
            foreach (TDomain obj in objs)
            {
                result.Add(SaveOrUpdate(obj));
            }
            return result;
        }
        
        public virtual void Delete(TDomain obj)
        {
            SessionFactory.GetCurrentSession().Delete(obj);       
        }

        public virtual void DeleteById(TK id)
        {
            var obj = GetById(id);
            if (obj != null)
                Delete(obj);
        }             
                
        #endregion


        public void DeleteBatch(IList<TDomain> obj)
        {
            obj.ForEach(x => SessionFactory.GetCurrentSession().Delete(x));
        }       
    }

    public class GenericDao<TDomain> : GenericDao<TDomain, Int32> where TDomain : class, IEntity<Int32>
    {

    }
}
