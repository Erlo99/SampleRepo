using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Http.Common
{
    public class BaseClassListResponse<T>
    {
        public IEnumerable<T> Results { get; set; }

        //jeszcze property z paginacja
    }
}
