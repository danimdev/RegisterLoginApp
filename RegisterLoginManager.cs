using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace RegisterLoginApp
{
    public class RegisterLoginManager
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool RegisterAndWriteToFile(string username,string password)
        {
            var file = @"passwordFile.txt";

            FileInfo fileToEncrypt = new(file);

            try
            {
                using (FileStream fileToWrite = new FileStream(file, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writeToFile = new StreamWriter(fileToWrite, Encoding.UTF8))
                    {
                        writeToFile.Write(password);
                        fileToEncrypt.Encrypt();
                        MessageBox.Show("Encrypted Successfully!");
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return false;
        }

        public bool LoginAndReadFromFile(string password)
        {
            return false;
        }

    }
}
