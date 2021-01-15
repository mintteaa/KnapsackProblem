using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litemsss
{
   public interface litems
    {
        string category { get; set; }
        string name { get; set; }
        int priceofproduct { get; set; }
        int healthinessofproduct { get; set; }
    }
}
