using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entityes
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Meaning { get; set; }
        public string Name { get; set; }
    }
}
