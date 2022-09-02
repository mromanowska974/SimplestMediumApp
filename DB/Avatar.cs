using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyLoginPanel.DB
{
    public class Avatar
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
