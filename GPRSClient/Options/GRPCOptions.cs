using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRSClient.Options
{
    public class GRPCOptions
    {
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string AccomodationSearch { get; set; }

    }
}
