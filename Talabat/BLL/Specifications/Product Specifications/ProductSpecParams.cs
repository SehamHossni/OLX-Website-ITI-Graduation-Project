using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.BLL.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 21;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize? MaxPageSize: value; }
        }
        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

    }
}
