using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagetV2.Model
{
    [Serializable]
    class DBHolder
    {
        public List<User> Users { get; }

        public DBHolder()
        {
            Users = new List<User>();

            restoreDefault();
        }

        public void restoreDefault()
        {
            //TODO Заполнить дефолтные значения
            createAdmin();
        }

        private void createAdmin()
        {
            if (Users.Where(f => f.Login == "admin").FirstOrDefault() == null)
            {
                Users.Add(new User
                {
                    FIO = "admin",
                    IsAdmin = true,
                    Login = "admin",
                    NickName = "admin",
                    Password = "admin"
                });
            }
        }
    }
}
