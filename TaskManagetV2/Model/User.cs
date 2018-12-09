using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetV2.Model
{
    [Serializable]
    class User
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string NickName { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            ID = Guid.NewGuid();
            Login = "";
            Password = "";
            FIO = "";
            NickName = "";
            IsAdmin = false;
        }
    }
}
