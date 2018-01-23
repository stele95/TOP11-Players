using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace Neo4j.DomainModel
{
    public class Klub
    {
        public string name { get; set; }
        public string logo { get; set; }
        public int id { get; set; } //team
        public string kit { get; set; }

        override
        public string ToString()
        {
            return name;
        }
    }
}