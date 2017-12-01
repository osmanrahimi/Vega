using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vega.Models.Resources
{
    public class MakeResource:KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Models { get; set; }
    }
}
