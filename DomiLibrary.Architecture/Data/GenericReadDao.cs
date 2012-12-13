using System;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using DomiLibrary.Core.Dao;
using DomiLibrary.Entity.Interface;
using System.Collections.Generic;
using System.Collections;

namespace DomiLibrary.Data
{    
    public class GenericReadDao<TDomain, TK> : IGenericReadDao<TDomain, TK>
        where TDomain : class, IEntity<TK>
    {
        protected ISessionFactory _SessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _SessionFactory; }
            set { _SessionFactory = value; }
        }

        public virtual IList<TDomain> GetAll()
        {            
            var query = _SessionFactory.GetCurrentSession().CreateCriteria(typeof(TDomain));
            return query.List<TDomain>();
        }

        public virtual TDomain GetById(TK id)
        {
            return _SessionFactory.GetCurrentSession().Get<TDomain>(id);
        }

        public virtual int GetCount()
        {
            return _SessionFactory.GetCurrentSession().Query<TDomain>().Count();
        }

        public IEnumerator<TDomain> GetEnumerator()
        {
            return _SessionFactory.GetCurrentSession().Query<TDomain>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _SessionFactory.GetCurrentSession().Query<TDomain>().GetEnumerator();
        }

        public Type ElementType
        {
            get { return _SessionFactory.GetCurrentSession().Query<TDomain>().ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _SessionFactory.GetCurrentSession().Query<TDomain>().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _SessionFactory.GetCurrentSession().Query<TDomain>().Provider; }
        }
    }
}
