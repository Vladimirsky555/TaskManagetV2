using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskManagetV2.Model
{
    [Serializable]
    public class DBHolder
    {
        public List<User> Users { get; }

        public DBHolder()
        {
            Users = new List<User>();
            //DBHolder d = this.loadData();
        }

        public void loadData()
        {
            if (!File.Exists("test.txt"))
            {
                restoreDefault();
                return;
            }

            using (FileStream fs = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(DBHolder));
                var Holder = (DBHolder)formatter.Deserialize(fs);
                Users.AddRange(Holder.Users);
            }
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
                    NickName = "AdM12N",
                    Password = User.encodePassword("admin")
                });
            }
        }

        public void Save()
        {
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    foreach (var user in Users)
            //    {
            //        user.Save(ms);
            //    }

            //    using (FileStream fs = new FileStream("test.txt", FileMode.Create))
            //    {
            //        ms.Seek(0, SeekOrigin.Begin);
            //        ms.WriteTo(fs);
            //    }

            //}

            using (FileStream fs = new FileStream("test.txt", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(DBHolder));
                formatter.Serialize(fs, this);
            }
            
        }

        public void Load()
        {

        }
    }
}
