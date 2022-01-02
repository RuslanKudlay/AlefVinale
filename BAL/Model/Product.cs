using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Meaning { get; set; }
        public string Name { get; set; }
    }
}
