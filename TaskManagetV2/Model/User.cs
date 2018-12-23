using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TaskManagetV2.Model
{
    [Serializable]
    public class User
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

        public static string encodePassword(string str)
        {
            using (MD5CryptoServiceProvider sha1 = new MD5CryptoServiceProvider())
            {
                return Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(str)));
            }
        }



        public void Save(Stream str)
        {

            ////Получаем байтовое представление строки
            //byte[] tmp = Encoding.UTF8.GetBytes(Login);
            ////Записываем в стрим длинну нашего массива
            //str.Write(BitConverter.GetBytes(tmp.Length), 0, 4);
            ////Записываем сам массив
            //str.Write(tmp, 0, tmp.Length);

            BinaryWriter writer = new BinaryWriter(str);
            writer.Write(ID.ToByteArray());
            writer.Write(Login);
            writer.Write(Password);
            writer.Write(FIO);
            writer.Write(NickName);
            writer.Write(IsAdmin);
        }

        public void Load(Stream str)
        {
            BinaryReader reader = new BinaryReader(str);
            byte[] b = reader.ReadBytes(Guid.Empty.ToByteArray().Length);
            ID = new Guid(b);
            Login = reader.ReadString();
            Password = reader.ReadString();
            FIO = reader.ReadString();
            NickName = reader.ReadString();
            IsAdmin = reader.ReadBoolean();

        }
    }
}
