using System.Collections.Generic;
using DomiLibrary.Architecture.Core.Dao;
using DomiLibrary.Architecture.Core.Service;
using DomiLibrary.Architecture.Entity.Interface;

namespace DomiLibrary.Architecture.Service
{
    public class GenericService<TDomain, TK> : GenericReadService<TDomain, TK>, IGenericService<TDomain, TK>
        where TDomain : class, IEntity<TK>
    {
        #region Properties

        private IGenericDao<TDomain, TK> _genericDao;
        public IGenericDao<TDomain, TK> GenericDao
        {
            get { return _genericDao; }
            set { _genericDao = value; }
        }

        #endregion

        #region Methods

        public virtual void Delete(TDomain obj)
        {
            _genericDao.SessionFactory = _SessionFactory;
            _genericDao.Delete(obj);
        }

        public virtual void DeleteById(TK id)
        {
            _genericDao.SessionFactory = _SessionFactory;
            _genericDao.DeleteById(id);
        }        
        
        public virtual TDomain SaveOrUpdate(TDomain obj)
        {
            _genericDao.SessionFactory = _SessionFactory;
            obj = _genericDao.SaveOrUpdate(obj);
            return obj;
        }

        public virtual IList<TDomain> SaveOrUpdateBatch(IList<TDomain> obj)
        {
            _genericDao.SessionFactory = _SessionFactory;
            var result = _genericDao.SaveOrUpdateBatch(obj);
            return result;
        }

        public virtual void DeleteBatch(IList<TDomain> obj)
        {
            _genericDao.SessionFactory = _SessionFactory;
            _genericDao.DeleteBatch(obj);
        }

        public TDomain Merge(TDomain obj)
        {
            _genericDao.SessionFactory = _SessionFactory;
            return _genericDao.Merge(obj);
        }

        #endregion
    }
}
