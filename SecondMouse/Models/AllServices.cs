using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SecondMouse.Models
{
    public class AllServices
    {
        public IEnumerable<Services> services { get; set; }
        public IEnumerable<SigningServices> signingServices { get; set; }
    }
}
