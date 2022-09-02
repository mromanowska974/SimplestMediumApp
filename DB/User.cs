using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoginPanel.DB
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public int BirthDateChangesCounter { get; set; }
        public byte[] Avatar { get; set; }
        //public Avatar Avatar { get; set; }
        //public int AvatarId { get; set; }
        //public List<User> Friends { get; set; }
        //public List<User> Followers { get; set; }
    }
}
