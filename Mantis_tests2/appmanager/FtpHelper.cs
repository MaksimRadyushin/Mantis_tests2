using System;
using System.IO;
using System.Net.FtpClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace mantis_tests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient client;

        public FtpHelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        public void BackupFile(String path)
        {
            String backupPath = path + ".back";
            if (client.FileExists(backupPath))
            {
                return;
            }
            client.Rename(path, backupPath);
        }

        public void RestoreBackupFile(String path)
        {
            String backupPath = path + ".back";

            if (!client.FileExists(path))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path);

        }

        public void Upload(String path, Stream localfile)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024]; // создаем буффер(массив) размером 8*1024
                int count = localfile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localfile.Read(buffer, 0, buffer.Length);
                }

            }
        }
    }
}