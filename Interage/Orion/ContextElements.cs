using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.Orion
{
    public class ContextElements
    {
        public ContextElements()
        {
            attributes = new List<AttributeObject>();
        }
        public string type { get; set; }
        public string isPattern { get; set; }
        public string id { get; set; }
        public IEnumerable<AttributeObject> attributes { get; set; }
    }
}