using Microsoft.EntityFrameworkCore;

namespace SecondMouse.Models
{
    public class SigningServices
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}
