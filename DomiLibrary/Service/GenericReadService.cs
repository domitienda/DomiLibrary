using System.Collections.Generic;
using DomiLibrary.Entity.Interface;
using DomiLibrary.Core.Service;
using DomiLibrary.Core.Dao;
using NHibernate;

namespace DomiLibrary.Service
{
    public class GenericReadService<TDomain, TK> : IGenericReadService<TDomain, TK> where TDomain : IEntity<TK>
    {
        #region Properties

        private IGenericReadDao<TDomain, TK> _genericReadDao;
        public IGenericReadDao<TDomain, TK> GenericReadDao
        {
            get { return _genericReadDao; }
            set { _genericReadDao = value; }
        }

        protected ISessionFactory _SessionFactory;
        public ISessionFactory SessionFactory
        {
            get { return _SessionFactory; }
            set
            {
                _SessionFactory = value;
                _genericReadDao.SessionFactory = _SessionFactory;
            }
        }

        #endregion

        #region Methods

        public virtual IList<TDomain> GetAll()
        {
            var result = _genericReadDao.GetAll();
            return result;
        }

        public virtual TDomain GetById(TK id)
        {
            var result = _genericReadDao.GetById(id);
            return result;
        }

        public virtual int GetCount()
        {
            var result = _genericReadDao.GetCount();
            return result;
        }

        #endregion
    }
}
