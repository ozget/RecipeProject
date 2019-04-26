using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class CategoryDto
    {
        public string Name { get; set; }
    }

    public class CategoryList
    {
        public int Results { get; set; }
        public string[] Categories { get; set; }

    }
}
