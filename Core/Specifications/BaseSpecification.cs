using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Specifications;

namespace Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get;}
        public List<Expression<Func<T, object>>> Includes {get;}
            = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> orderBy {get; private set;}

        public Expression<Func<T, object>> orderByDescending {get; private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IsPagingEnabled  {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            orderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T,object>> OrderByDescExpression)
        {
            orderByDescending = OrderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
            }
    }
}