using Microsoft.EntityFrameworkCore;
using Movies.BAL.Interfaces;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Specifications.Evaluator
{
    public  static class SpecificationsEvaluator<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery (IQueryable<T> startQuery,ISpecifications<T> specs)
        {
            var query = startQuery;

            //set criteria 
            if (specs.Criteria is not null)
                query = query.Where(specs.Criteria);

            //add the list of includes
            query = specs.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

            if (specs.IsPaginationEnabled)
                query = query.Skip(specs.Skip).Take(specs.Take);

            //order the sequnce
            if (specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);
            else if (specs.OrderByDesc is not null)
                query = query.OrderByDescending(specs.OrderByDesc);
            return query;
        }
    }
}
