using Movies.BAL.Interfaces;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get   ; set ; }
        public Expression<Func<T, object>> OrderByDesc { get ; set ; }
        public int Take { get ; set ; }
        public int Skip { get ; set ; }
        public bool IsPaginationEnabled { get ; set ; }

        public BaseSpecifications()
        {

        }
        public BaseSpecifications(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }

        public void AddOrderBy(Expression<Func<T,object>> expression)
        {
            OrderBy = expression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }

        public void AddPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            this.Skip = skip;
            this.Take = take;
        }



    }
}
