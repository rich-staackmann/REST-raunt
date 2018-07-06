using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Response.ResourceViewModels
{
    public abstract class HyperMediaProtocol
    {
        public List<HyperMediaLink> Links { get; set; }
    }
}
