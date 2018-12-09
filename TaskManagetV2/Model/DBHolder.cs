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
            //TODO вызвать дефолтные данные
        }

        public void restoreDefault()
        {
            //TODO Заполнить дефолтные значения
            //TODO создать первого пользователя с логином и паролем admin/admin
        }
    }
}
