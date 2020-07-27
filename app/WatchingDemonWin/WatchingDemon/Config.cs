﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchingDemon
{
    class Config
    {
        public int ListenPortNumber = 12300;
        public bool AutoStart = false;


        public void Serialize(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine("ListenPortNumber=" + ListenPortNumber);
                writer.WriteLine("AutoStart=" + AutoStart);

                writer.Close();
            }
        }

        public void Deserialize(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    while (reader.Peek() != -1)
                    {
                        string line = reader.ReadLine();
                        //Console.WriteLine(line);

                        string[] token = line.Split('=');

                        if(token[0] == "ListenPortNumber")
                        {
                            ListenPortNumber = int.Parse(token[1]);
                        }
                        else if(token[0] == "AutoStart")
                        {
                            AutoStart = bool.Parse(token[1]);
                        } 
                    }
                    reader.Close();
                }

            }
            catch
            {
                Serialize(path);
            }
        }
    }
}
