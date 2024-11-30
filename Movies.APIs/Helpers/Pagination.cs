using Movies.PL.APIs.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace Movies.PL.APIs.Helpers
{
    public class Pagination<T> 
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }

    }
}
