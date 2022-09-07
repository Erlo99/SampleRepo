using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Http.Common
{
    public class BaseClassListRequest
    {
        //klasa filtrowania
        public string Filter { get; set; }

        //klasa sortowanie
        public string OrderBy { get; set; }

        //klasa paginacja
        public string Pagination { get; set; }
    }
}
