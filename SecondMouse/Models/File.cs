using Microsoft.EntityFrameworkCore;

namespace SecondMouse.Models
{
    public class File
    {
        public string Id { get; set; }
        public string displayId { get; set; }
        public string state { get; set; }
        public string county { get; set; }
    }
}
