using System.Collections.Generic;

namespace Hacking.Messages
{
    public interface IRoutingHeaders
    {
        IEnumerable<string> Steps{ get; set; }
    }
}