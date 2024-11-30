using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Interfaces
{
    public interface ISpecifications<T> where T:BaseEntity
    {
        //Set<T>().Where(p=>p.Id==7).Include(P=>P.Genre).OrderBy(p=>p.Name);
        public Expression<Func<T,bool>> Criteria { get; set; }

        public List<Expression<Func<T,object>>> Includes { get; set; }

        public  Expression<Func<T,object>> OrderBy { get; set; }

        public  Expression<Func<T,object>> OrderByDesc { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }

        public bool IsPaginationEnabled { get; set; }



    }
}
