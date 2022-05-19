using Microsoft.EntityFrameworkCore;

namespace SecondMouse.Models
{   
    public class Services
    {
        public int Id { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public bool eFile { get; set; }
        public bool RON { get; set; }
        public bool RIN { get; set; }
        public bool otherService { get; set; }
        public bool otherService2 { get; set; }
    }
}
