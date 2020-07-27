using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WatchingDemon
{
    class Logger
    {
        public string DirectoryPath { get; private set; }

        public Logger(string directoryPath)
        {
            DirectoryPath = directoryPath;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public void Log(string log, bool timestamp = true)
        {
            string fileName = DirectoryPath + "log" + DateTime.Now.ToString("yyddMM") + ".log";

            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(log);
                writer.Close();
            }
        }
    }
}
