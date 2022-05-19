using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SecondMouse.Models
{
    public class FileServiceCheck
    {
        public File file { get; set; }
        public Services service { get; set; }
        public List<SigningServices> signingServices { get; set; }
    }
}
