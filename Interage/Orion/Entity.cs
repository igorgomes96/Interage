using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.Orion
{
    public class Entity
    {
        public Entity ()
        {
            contextElements = new List<ContextElements>();
        }
        public IEnumerable<ContextElements> contextElements { get; set; }
        public string updateAction { get; set; }
    }
}