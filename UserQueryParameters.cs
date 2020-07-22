using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPracticeAPI
{
    public class UserQueryParameters
    {
        private readonly int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
